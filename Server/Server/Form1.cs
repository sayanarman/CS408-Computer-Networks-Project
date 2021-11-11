using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clienSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;

        // This is the table to check whether connected client's username to be unique
        ConcurrentDictionary<string, bool> connectedClients = new ConcurrentDictionary<string, bool>();

        // This is the table to check the sweets coming from clients
        ConcurrentDictionary<string, List<Sweet>> receivedSweets = new ConcurrentDictionary<string, List<Sweet>>();

        public Server()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_Form1Closing);
            InitializeComponent();
            buildConnectedClientsDict();
            readSweetsFromTxt();
        }

        private void buildConnectedClientsDict()
        {
            try
            {
                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lines = System.IO.File.ReadAllLines("user-db.txt");

                // Initialize all of the users not connected at start
                foreach (string line in lines) connectedClients[line] = false;

                Console.WriteLine("Dict is created!\n");
            }
            catch
            {
                Console.WriteLine("User Database file is not found!\n");
            }
        }

        private void Form1_Form1Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            serverSocket.Close();
            writeToTxt();
            Environment.Exit(0);
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                // Initialize endpoint
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                logs.AppendText("Please check port number!\n");
            }
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();

                    Byte[] buffer = new Byte[64];
                    newClient.Receive(buffer);

                    string incomingUsername = Encoding.Default.GetString(buffer);
                    incomingUsername = incomingUsername.Trim('\0');

                    if (connectedClients.ContainsKey(incomingUsername) != false &&
                        connectedClients[incomingUsername] == false)
                    {
                        connectedClients[incomingUsername] = true;
                        clienSockets.Add(newClient);

                        logs.AppendText("A client with username " + incomingUsername + " is connected.\n");

                        string message = "You are a verified user!\n";

                        buffer = Encoding.Default.GetBytes(message);

                        try
                        {
                            newClient.Send(buffer);
                        }
                        catch
                        {
                            logs.AppendText("There is a problem! Check the connection!\n");
                            terminating = true;

                            textBox_port.Enabled = true;
                            button_listen.Enabled = true;

                            serverSocket.Close();
                        }

                        Thread receiveThread = new Thread(() => Receive(newClient, incomingUsername));
                        receiveThread.Start();
                    }

                    else
                    {
                        string message = "You are not a verified user!\n";

                        buffer = Encoding.Default.GetBytes(message);

                        try
                        {
                            newClient.Send(buffer);
                        }
                        catch
                        {
                            logs.AppendText("There is a problem! Check the connection!\n");
                            terminating = true;

                            textBox_port.Enabled = true;
                            button_listen.Enabled = true;

                            serverSocket.Close();
                        }
                    }
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working!\n");

                        textBox_port.Enabled = true;
                        button_listen.Enabled = true;
                    }
                }
            }
        }

        private void Receive(Socket thisClient, string username)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Trim('\0');

                    string userCommand = incomingMessage.Substring(0, 3);

                    // If the user wants to get sweets until so far, 
                    //then the incomingMessage should start with get
                    if (userCommand == "get")
                    {
                        // SEND SWEETS FROM DATABASE TO CLIENT
                        logs.AppendText("Client " + username + " asks the sweets from server.\n");

                        // Inform the server side starting the process
                        logs.AppendText("Server started to send all sweets for user " + username + ".\n");

                        try
                        {
                            foreach (string key in receivedSweets.Keys)
                            {
                                if (key != username)
                                {
                                    foreach (Sweet singleSweet in receivedSweets[key])
                                    {
                                        string message = singleSweet.toString();

                                        uint length = (uint) message.Length;

                                        var sizeBuffer = BitConverter.GetBytes(length);

                                        if (BitConverter.IsLittleEndian)
                                            Array.Reverse(sizeBuffer);

                                        thisClient.Send(sizeBuffer);

                                        buffer = Encoding.Default.GetBytes(message);

                                        thisClient.Send(buffer);
                                    }
                                }
                            }
                            thisClient.Send(BitConverter.GetBytes(0));
                        }
                        catch
                        {
                            logs.AppendText("There is a problem! Check the connection!\n");
                            terminating = true;

                            textBox_port.Enabled = true;
                            button_listen.Enabled = true;

                            serverSocket.Close();
                        }

                        // Inform the server side ending the process
                        logs.AppendText("Server ended to send all sweets for user " + username + ".\n");
                    }
                    // Otherwise, the user wants to send sweet to the server
                    else
                    {
                        // Inform the server side
                        logs.AppendText("Client " + username + " wrote a sweet.\n");

                        // create the sweet object
                        Sweet upcomingSweet = new Sweet(
                            SweetId: receivedSweets.Count, Username: username,
                            Sweet: incomingMessage.Substring(5), TimeStamp: DateTime.Now.ToString());

                        // add it to global dictionary
                        // first check whether this user sent sweet before or not
                        if (receivedSweets.ContainsKey(username) == false)
                        {
                            // Create the sweet list for a user
                            List <Sweet> sweetList = new List<Sweet>();
                            sweetList.Add(upcomingSweet);
                            receivedSweets[username] = sweetList;
                        }
                        else
                        {
                            receivedSweets[username].Add(upcomingSweet);
                        }

                        // Inform the server side after adding sweet to hash table
                        logs.AppendText("Sweet arrived from client " + username + " has been added to database.\n");
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("A client with username " + username + " has disconnected.\n");
                    }

                    thisClient.Close();
                    clienSockets.Remove(thisClient);
                    connectedClients[username] = false;
                    connected = false;
                }
            }
        }

        // Will be used after server disconnects
        private void writeToTxt()
        {
            List<String> lines = new List<String>();

            foreach (List<Sweet> userSweets in receivedSweets.Values)
                foreach (Sweet sweet in userSweets)
                    lines.Add(sweet.toString());

            System.IO.File.WriteAllLines("sweet-db.txt", lines);
        }

        // Will be used after initialization
        private void readSweetsFromTxt()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("sweet-db.txt");

                foreach (string line in lines)
                {
                    Sweet newSweet = new Sweet(line);

                    var sweetOfUser = receivedSweets.GetOrAdd(newSweet.username, new List<Sweet> { });
                    sweetOfUser.Add(newSweet);
                }

                Console.WriteLine("Dict is created.\n");
            }
            catch
            {
                Console.WriteLine("Sweet databse is not found!.\n");
            }
        }

     
    }

    public class Sweet
    {
        public string username;
        public int sweetId;
        public string timeStamp;
        public string sweet;

        public Sweet(int SweetId, string Username, string Sweet, string TimeStamp)
        {
            this.username = Username;
            this.sweetId = SweetId;
            this.timeStamp = TimeStamp;
            this.sweet = Sweet;
        }

        public Sweet(string lineInfo)
        {
            string[] properties = lineInfo.Split('\t');

            try
            {
                this.username = properties[0];
                this.sweetId = Int32.Parse(properties[1]);
                this.timeStamp = properties[2];
                this.sweet = properties[3];
            }
            catch
            { 
                // fill later
            }
        }

        public string toString()
        {
            return username + '\t' + sweetId + '\t' + timeStamp + '\t' + sweet; 
        }
    }
}
