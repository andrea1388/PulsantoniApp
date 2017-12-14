using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace pulsantoni2
{

    public partial class FMain : Form
    {
        
        Dictionary<int,Slave> slave;
        String cmdricevuto;
        String  rtbase = @"{\rtf1\ansi\deff0 {\colortbl;\red255\green0\blue0;\red0\green255\blue0;\red10\green10\blue245;\red0\green255\blue255;}\fs96";


        int stato = 0;
        private int numeroammessialvoto;
        private Thread rdr;
        private bool mustexit;

        public FMain()
        {
            InitializeComponent();
        }
        public FMain(String pathToConfFile)
        {
            InitializeComponent();
            try
            {
                LeggiParametriConf(pathToConfFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            slave = new Dictionary<int, Slave>();
            //slave.Add(1,new Slave(1)); // il master

        }

        private void FMain_Load(object sender, EventArgs e)
        {

            try
            {
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.NewLine = "\r\n";
                serialPort1.StopBits = StopBits.One;
                serialPort1.DtrEnable = false;
                serialPort1.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }
            // chiedi il numero di slave
            rdr = new Thread(ReadSerial);
            rdr.Start();
            serialPort1.WriteLine("E");
            Thread.Sleep(10);
            serialPort1.WriteLine("C");
            Thread.Sleep(10);
            serialPort1.WriteLine("R");
            //Stato0();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

        }
        private void LeggiParametriConf(String path)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                String[] sottocomandi = line.Split('=');
                switch (sottocomandi[0])
                {
                    case "porta":
                        serialPort1.PortName = sottocomandi[1];
                        break;
                    case "baudrate":
                        serialPort1.BaudRate = int.Parse(sottocomandi[1]);
                        break;
                }
            }
        }
        private void ReadSerial()
        {
            do
            {
                try
                {
                    cmdricevuto = serialPort1.ReadLine().Trim();
                }
                catch (Exception ex) { return; }
                Console.WriteLine(cmdricevuto);
                ElaboraCmdRicevuto();

            } while (!mustexit);
            /*
            if (sp.BytesToRead == 0) return;
            //cmdricevuto = sp.ReadLine();
            //ElaboraCmdRicevuto();
            while (sp.BytesToRead > 0)
            {
                int b = sp.ReadByte();
                Console.Write(b.ToString());
                cmdricevuto += ((char)b);
                if (b == '\n')
                {
                    ElaboraCmdRicevuto();
                    cmdricevuto = "";
                }

            }
            */
        }
 
        void ElaboraCmdRicevuto()
        {
            int ns;
            String[] sottocomandi = cmdricevuto.Split(' ');

            switch (sottocomandi[0])
            {
                case "F":
                    ns = int.Parse(sottocomandi[1]);
                    slave.Clear();
                    //slave.Add(1, new Slave(1)); // il master

                    for (int j = 2; j < ns+2; j++)
                    {
                        Slave s = new Slave(j);
                        slave.Add(j, s);
                    }
                    this.Invoke((MethodInvoker)delegate { AggiornaLista(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + ns.ToString());
                    break;
                case "G":
                    this.Invoke((MethodInvoker)delegate { PollingIniziato(); });
                    Console.WriteLine("Rx " + sottocomandi[0] );
                    break;
                case "H":
                    numeroammessialvoto = int.Parse(sottocomandi[1]);
                    this.Invoke((MethodInvoker)delegate { VotoIniziato(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + numeroammessialvoto.ToString());

                    break;
                case "I":
                    this.Invoke((MethodInvoker)delegate { VotoConcluso(); });
                    Console.WriteLine("Rx " + sottocomandi[0]);
                    break;
                case "S":
                    this.Invoke((MethodInvoker)delegate { Stato0(); });
                    Console.WriteLine("Rx " + sottocomandi[0]);
                    break;
                case "J":
                    ns = int.Parse(sottocomandi[1]);
                    if(ns<2 || ns>slave.Count+1) { Console.WriteLine("errore n slave"); break; }
                    slave[ns].morto = true;
                    slave[ns].sincronizzato =false;
                    this.Invoke((MethodInvoker)delegate { AggiornaLista(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + ns.ToString());
                    break;
                case "K":
                    ns = int.Parse(sottocomandi[1]);
                    if (ns < 2 || ns > slave.Count + 1) { Console.WriteLine("errore n slave"); break; }
                    slave[ns].morto = false;
                    slave[ns].fallimenti = 0;
                    this.Invoke((MethodInvoker)delegate { AggiornaLista(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + ns.ToString());
                    break;
                case "Q":
                    ns = int.Parse(sottocomandi[1]);
                    if (ns < 2 || ns > slave.Count + 1) { Console.WriteLine("errore n slave"); break; }
                    slave[ns].morto = false;
                    slave[ns].isripetitore = true;
                    this.Invoke((MethodInvoker)delegate { AggiornaLista(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + ns.ToString());
                    break;
                case "L":
                    ns = int.Parse(sottocomandi[1]);
                    if (ns < 2 || ns > slave.Count + 1) { Console.WriteLine("errore n slave"); break; }
                    slave[ns].batteria = int.Parse(sottocomandi[2]) / (float)77.6;
                    slave[ns].segnale = int.Parse(sottocomandi[3]);
                    slave[ns].morto = false;
                    slave[ns].fallimenti = 0;
                    slave[ns].sincronizzato = true;
                    this.Invoke((MethodInvoker)delegate { AggiornaLista(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + ns.ToString());
                    break;
                case "M":
                    ns = int.Parse(sottocomandi[1]);
                    if (ns < 2 || ns > slave.Count + 1) { Console.WriteLine("errore n slave"); break; }
                    slave[ns].batteria = int.Parse(sottocomandi[2])/(float)77.6;
                    slave[ns].segnale = int.Parse(sottocomandi[3]);
                    slave[ns].fallimenti = 0;
                    slave[ns].morto = false;
                    this.Invoke((MethodInvoker)delegate { AggiornaLista(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + ns.ToString());
                    break;
                case "N":
                    ns = int.Parse(sottocomandi[1]);
                    if (ns < 2 || ns > slave.Count + 1) { Console.WriteLine("errore n slave"); break; }
                    slave[ns].oravoto = float.Parse(sottocomandi[2]) / 1000000;
                    slave[ns].votato=true;
                    this.Invoke((MethodInvoker)delegate { AggiornaLista(); });
                    Console.WriteLine("Rx " + sottocomandi[0] + " " + ns.ToString());
                    break;
                case "poll":
                    ns = int.Parse(sottocomandi[1]);
                    if (ns < 2 || ns > slave.Count + 1) { Console.WriteLine("errore n slave"); break; }
                    slave[ns].indripetitore = int.Parse(sottocomandi[2]) ;
                    slave[ns].fallimenti = int.Parse(sottocomandi[3]);
                    slave[ns].sincronizzato = (int.Parse(sottocomandi[4])==0) ? false : true;

                    break;


            }
        }

        void PollingIniziato()
        {
            lstato.Text = "Polling started";
            bstartpolling.Enabled = false;
            bstartvote.Enabled = true;
            bstopvote.Enabled = false;
            bstoppolling.Enabled = true;
            stato = 1;
            AggiornaLista();
        }
        void VotoIniziato()
        {
            bstartpolling.Enabled = false;
            bstartvote.Enabled = false;
            bstopvote.Enabled = true;
            bstoppolling.Enabled = false;
            lstato.Text = "Vote started (slave ammitted=" + numeroammessialvoto+")";
            rt1.Text = "";
            foreach (Slave s in slave.Values)
            {
                s.votato = false;
                s.oravoto = 0;
            }
            stato = 2;
        }
        void VotoConcluso()
        {
            lstato.Text = "Vote ended";
            bstartpolling.Enabled = true;
            bstartvote.Enabled = false;
            bstopvote.Enabled = false;
            bstoppolling.Enabled = true;
            stato = 3;
        }
        void Stato0()
        {
            lstato.Text = "Pulsantoni";
            rt1.Rtf = rtbase  + RtfCol("Green") + "Slaves: " + slave.Count.ToString() + "}";
            bstartpolling.Enabled = true;
            bstartvote.Enabled = false;
            bstopvote.Enabled = false;
            bstoppolling.Enabled = false;
            stato = 0;
        }


        void AggiornaLista()
        {
            String rtb = rtbase;
            String col;
            if(stato== 1)
            {
                foreach (Slave s in slave.Values)
                {
                    
                    String ss = s.indirizzo.ToString() + " ";
                    if (s.morto) col = "Red";
                    else
                    {
                        if (s.sincronizzato) col="Blue"; else col = "Green";
                        if (s.isripetitore) col = "Cyan";
                    }
                    rtb+=RtfCol(col)+ss;
                }
                rtb += "}";
                rt1.Rtf = rtb;





            }
            if (stato == 2)
            {
                var query = from p in slave.Values
                            where p.votato ==true
                            orderby p.oravoto ascending
                            select p;
                int i = 0;
                foreach (Slave s in query)
                {
                    String ss = s.indirizzo.ToString() + @"\tab\tab\tab " + s.oravoto.ToString("0.0000") + @"\line ";
                    if (i++==0) col = "Red";
                    else col = "Blue";
                    rtb += RtfCol(col) + ss;
                }

                rtb += "}";
                rt1.Rtf = rtb;

            }

        }

        String RtfCol(String c)
        {
            String s="";
            switch(c)
            {
                case "Red":
                    s = @"\cf1";
                    break;
                case "Green":
                    s = @"\cf2";
                    break;
                case "Blue":
                    s = @"\cf3";
                    break;
                case "Cyan":
                    s = @"\cf4";
                    break;
                default:
                    MessageBox.Show("hh");
                    break;
            }
            return s+" ";
        }

        private void bstartpolling_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("E");
            serialPort1.WriteLine("A");
        }

        private void bstartvote_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("B");
        }

        private void bstopvote_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("C");
        }

        private void bstoppolling_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("R");
        }


        private void mostraSegnaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLista f = new FLista();
            f.Mostra( slave.Values.ToList<Slave>(),ref serialPort1);

        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mustexit = true;
            serialPort1.Close();
            rdr.Abort();
        }


        private void startPollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bstartpolling_Click(sender, e);
        }

        private void startVoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bstartvote_Click(sender, e);
        }

        private void stopVoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bstopvote_Click(sender, e);
        }

        private void stoppedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bstoppolling_Click(sender, e);
        }

        private void FMain_Resize(object sender, EventArgs e)
        {
            rt1.Height = this.Height - 200;
        }

        private void changeSlaveNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = Microsoft.VisualBasic.Interaction.InputBox("Number of slaves", "", "");
            int ns = int.Parse(s);
            if(ns>0 && ns<250)
            {
                serialPort1.WriteLine("D " + ns.ToString());
            }

        }
    }
}

