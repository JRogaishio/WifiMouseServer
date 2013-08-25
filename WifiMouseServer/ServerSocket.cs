using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace WifiMouseServer
{
    class ServerSocket
    {
        // Incoming data from the client.
        public static string data = null;
        public WifiMouserServer gui;
        private string ip;
        public bool isRunning = true;
        public int mouseX, mouseY, offsetX, offsetY;

        //Variables for handling mouse clicking
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;


        public ServerSocket(WifiMouserServer form, string localIp)
        {
            gui = form;
            ip = localIp;
        }

        public void MoveCursor(int newX, int newY)
        {

            Cursor.Current = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(newX, newY);
            gui.setPos("X: " + newX + "   Y: " + newY);

        }


        public void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8221);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (isRunning)
                {
                    gui.setServerStatus("Started");
                    Console.WriteLine("Server Started!");
                    // Program is suspended while waiting for an incoming connection.
                    Socket handler = listener.Accept();
                    data = null;
                    Console.WriteLine("Client Connected!");

                    gui.setClientStatus("True");

                    // An incoming connection needs to be processed.
                    while (isRunning)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        Console.WriteLine(data);

                        try
                        {
                            string[] command = data.Split('#');
                            int code, x, y, moveX, moveY;

                            //Mouse packets get combined from java. 
                            //Go through each part individually, set the position and then sleep for a smooooooooth mouse effect
                            for (int i = 0; i < command.Length - 1; i+=3)
                            {
                                code = Convert.ToInt16(command[i]);
                                x = Convert.ToInt16(command[i+1]);
                                y = Convert.ToInt16(command[i+2]);

                                //Console.WriteLine("CODE: " + code);
                                //Console.WriteLine("X: " + x);
                                //Console.WriteLine("Y: " + y);

                                //Handle different cases such as moving and clicking
                                switch (code)
                                {
                                    case 0:
                                        //Initial press
                                        mouseX = Cursor.Position.X;
                                        mouseY = Cursor.Position.Y;
                                        offsetX = x;
                                        offsetY = y;
                                        break;
                                    case 1:
                                        //Moving around
                                        moveX = mouseX + (x - offsetX);
                                        moveY = mouseY + (y - offsetY);
                                        MoveCursor(moveX, moveY);
                                        break;
                                    case 2:
                                        //left click
                                        mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                                        mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);

                                        break;
                                    case 3:
                                        //Right click
                                        mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                                        mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);

                                        break;

                                    default:
                                        MessageBox.Show("Bad command sent from the client!");
                                        break;

                                }

                                //Sleep for 10ms before using the next point
                                Thread.Sleep(10);
                                
                            }

                        }
                        catch (Exception e)
                        {
                            //Gotta catch em' all!
                            MessageBox.Show(e.ToString());
                        }

                    }


                    // Echo the data back to the client.
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            gui.setServerStatus("Stopped");
            Console.WriteLine("\nSERVER STOPPED");
            Console.Read();

        }




    }
}
