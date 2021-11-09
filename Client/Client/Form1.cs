using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        bool connected = false;
        bool terminating = false;
        Socket clientSocket;

        public Client()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;

            // for releasing the environment resources
            Environment.Exit(0);
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string IP = textBox_ip.Text;

            int portNum;

            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    string username = textBox_username.Text;

                    // Is there a need for length here ?????????
                    if (username != "" && username.Length <= 64)
                    {
                        clientSocket.Connect(IP, portNum);

                        Byte[] buffer = Encoding.Default.GetBytes(username);

                        clientSocket.Send(buffer);

                        try
                        {
                            buffer = new Byte[64];

                            // receive the message coming from the server
                            clientSocket.Receive(buffer);

                            // parse the byte array into string
                            string incomingMessage = Encoding.Default.GetString(buffer);

                            // discard the \0 bytes
                            incomingMessage = incomingMessage.Trim('\0');

                            richTextBox1.AppendText("Server: " + incomingMessage + "\n");

                            if (incomingMessage != "You are not a verified user!\n")
                            {
                                textBox_ip.Enabled = false;
                                textBox_port.Enabled = false;
                                textBox_username.Enabled = false;
                                button_connect.Enabled = false;
                                button_getSweets.Enabled = true;
                                button_sendSweet.Enabled = true;
                                textBox_sweet.Enabled = true;

                                connected = true;
                                richTextBox1.AppendText("Connected to the server.\n\n");

                                //Thread receiveThread = new Thread(Receive);
                                //receiveThread.Start();
                            }
                        }
                        catch
                        {
                            if (!terminating)
                            {
                                richTextBox1.AppendText("Server has disconnected!\n\n");

                                button_connect.Enabled = true;
                            }

                            clientSocket.Close();
                            connected = false;
                        }
                    }

                    else
                    {
                        richTextBox1.AppendText("Username field can not be empty!\n\n");
                    }
                }
                catch
                {
                    richTextBox1.AppendText("Could not connect to the server!\n\n");
                }
            }
            else
            {
                richTextBox1.AppendText("Check the IP and Port Number!\n\n");
            }
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];

                    // receive the message coming from the server
                    clientSocket.Receive(buffer);

                    // parse the byte array into string
                    string incomingMessage = Encoding.Default.GetString(buffer);

                    // discard the \0 bytes
                    incomingMessage = incomingMessage.Trim('\0');

                    richTextBox1.AppendText("Server: " + incomingMessage + "\n");
                }
                catch
                {
                    if (!terminating)
                    {
                        richTextBox1.AppendText("Server has disconnected!\n");

                        button_sendSweet.Enabled = false;
                        button_getSweets.Enabled = false;
                        textBox_sweet.Enabled = false;
                        button_connect.Enabled = true;
                        textBox_ip.Enabled = true;
                        textBox_port.Enabled = true;
                        textBox_username.Enabled = true;
                    }

                    clientSocket.Close();
                    connected = false;
                }
            }
        }

        private void button_sendSweet_Click(object sender, EventArgs e)
        {
            try
            {
                string message = textBox_sweet.Text;


                if (message != "")
                {
                    Byte[] buffer = Encoding.Default.GetBytes("send " + message);

                    clientSocket.Send(buffer);

                    richTextBox1.AppendText("Sent sweet to server like this: " + message + "\n\n");

                    textBox_sweet.Clear();
                }

                else
                {
                    richTextBox1.AppendText("Please enter a sweet before clicking send button!\n\n");
                }
            }
            catch
            {
                if (!terminating)
                {
                    richTextBox1.AppendText("Server has disconnected!\n\n");

                    button_sendSweet.Enabled = false;
                    button_getSweets.Enabled = false;
                    textBox_sweet.Enabled = false;
                    textBox_sweet.Clear();
                    button_connect.Enabled = true;
                    textBox_ip.Enabled = true;
                    textBox_port.Enabled = true;
                    textBox_username.Enabled = true;
                }

                clientSocket.Close();
                connected = false;
            }
        }

        private void button_getSweets_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "get ";

                Byte[] buffer = Encoding.Default.GetBytes(message);

                clientSocket.Send(buffer);

                richTextBox1.AppendText("Asked server to get all sweets so far.\n\n");

            }
            catch
            {
                if (!terminating)
                {
                    richTextBox1.AppendText("Server has disconnected!\n\n");

                    button_sendSweet.Enabled = false;
                    button_getSweets.Enabled = false;
                    textBox_sweet.Enabled = false;
                    textBox_sweet.Clear();
                    button_connect.Enabled = true;
                    textBox_ip.Enabled = true;
                    textBox_port.Enabled = true;
                    textBox_username.Enabled = true;
                }

                clientSocket.Close();
                connected = false;
            }
        }
    }
}
