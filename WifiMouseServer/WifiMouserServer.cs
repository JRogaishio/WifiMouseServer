using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace WifiMouseServer
{
    public partial class WifiMouserServer : Form
    {

        private string localIp;
        ServerSocket server;
        Thread oThread;
        public WifiMouserServer()
        {
            InitializeComponent();
        }

        private void btn_startServer_Click(object sender, EventArgs e)
        {


            server = new ServerSocket(this, localIp);
            server.isRunning = true;
            oThread = new Thread(new ThreadStart(server.StartListening));

            oThread.Start();

            //Wait for the thread to start up
            while (!oThread.IsAlive) ;

            //Sleep the main thread so the server has a moment to process
            Thread.Sleep(1);
        }

        private void btn_stopServer_Click(object sender, EventArgs e)
        {
            try
            {
                server.isRunning = false;
                oThread.Abort();
                lbl_serverStatus.Text = "Server Status: Off";
                lbl_clientStatus.Text = "Client Connected: False";
                lbl_pos.Text = "Mouse Pos: ";
                server = null;
                oThread = null;
            }
            catch (Exception ex)
            {
                //Gotta catch em all
                MessageBox.Show("Error stopping server: " + ex.ToString());
            }
        }

        private string getServerIp()
        {
            //Set the default to localhost incase we can't find an IP
            string ipAddress = "127.0.0.1";
            //Grab this machines IP address
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();

                }
            }
      
            return ipAddress;
        }

        private void WifiMouserServer_Load(object sender, EventArgs e)
        {
            localIp = getServerIp();
            lbl_serverIp.Text = "Server IP: " + localIp;
        }

        public void setServerStatus(String started)
        {
            MethodInvoker mi = delegate
            {
                if (started == "Started")
                {
                    btn_startServer.Enabled = false;
                    btn_stopServer.Enabled = true;
                }
                else if (started == "Off")
                {
                    btn_startServer.Enabled = true;
                    btn_stopServer.Enabled = false;
                }
                lbl_serverStatus.Text = "Server Status: " + started;

            };
            if (InvokeRequired)
                this.Invoke(mi);
           
        }
        public void setPos(String started)
        {
            MethodInvoker mi = delegate
            {
                lbl_pos.Text = "Mouse Pos: " + started;
            };
            if (InvokeRequired)
                this.Invoke(mi);
        }
        public void setClientStatus(String started)
        {
            MethodInvoker mi = delegate
            {
                lbl_clientStatus.Text = "Client Connected: " + started;
            };
            if (InvokeRequired)
                this.Invoke(mi);
        }

    }

}
