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

        public Server()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_Form1Closing);
            InitializeComponent();
            buildConnectedClientsDict();
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

        // NOT WORKING CORRECTLY
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
                        

                    }
                    // Otherwise, the user wants to send sweet to the server
                    else
                    {
                        // ADD THE SWEET TO DATABASE
                        logs.AppendText("Client " + username + " wrote a sweet.\n");


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

        }

        // Will be used after initialization
        private void readSweetsFromTxt()
        {

        }
    }
}
