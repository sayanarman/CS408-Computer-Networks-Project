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
                    logs.AppendText("Client: " + incomingMessage + "\n");
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("A client has disconnected.\n");
                    }

                    thisClient.Close();
                    clienSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }
    }
}
