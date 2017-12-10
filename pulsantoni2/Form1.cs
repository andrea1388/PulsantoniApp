using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pulsantoni2
{
    public partial class FMain : Form
    {
        //Dictionary<int,Slave> slave;
        //MySortableBindingList<Slave> list = new MySortableBindingList<Slave>();
        SlaveDataTable tabslave = new SlaveDataTable();
        String cmdricevuto;
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
            //slave = new Dictionary<int, Slave>();
            //slave.Add(1,new Slave(1)); // il master

        }

        private void FMain_Load(object sender, EventArgs e)
        {
            /*
            tabslave.Columns.Add(new DataColumn("Address"));
            tabslave.Columns.Add(new DataColumn("Sync"));
            tabslave.Columns.Add(new DataColumn("Signal"));
            */
            try
            {
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.NewLine = "\r\n";
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            // chiedi il numero di slave
            /*
            listView1.Columns.Add("Device number", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("V Batt.", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("Slave Sign.", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("Master Sign.", -2, HorizontalAlignment.Center);
            listView1.View = View.Details;
            listView1.Items.Add("bau");
            */
            serialPort1.WriteLine("C");
            serialPort1.WriteLine("R");
            serialPort1.WriteLine("E");
            dg1.DataSource = tabslave;

            /*
            var source = new BindingSource(list, null);
            dg1.DataSource = list;
            dg1.Columns["indirizzo"].SortMode = DataGridViewColumnSortMode.Automatic;
            dg1.Columns["segnale"].SortMode = DataGridViewColumnSortMode.Automatic;
            */

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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
             
            SerialPort sp = (SerialPort)sender;
            if (sp.BytesToRead == 0) return;
            cmdricevuto = sp.ReadLine();
            ElaboraCmdRicevuto();
            /*
            for (int j=0;j< indata.Length;j++)
            {
                cmdricevuto += indata[j];
                if (indata[j] == '\n')
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
                    //slave.Clear();
                    //slave.Add(1, new Slave(1)); // il master

                    for (int j = 2; j < ns+2; j++)
                    {
                        Slave s = new Slave(j);
                        //slave.Add(j, s);
                        //list.Add(s);
                        var row = tabslave.GetNewRow();
                        row.Address = j;
                        tabslave.Rows.Add(row);
                        //this.Invoke((MethodInvoker)delegate { list.Add(s); });
                        this.Invoke((MethodInvoker)delegate { dg1.Refresh(); });
                        //this.Invoke((MethodInvoker)delegate { listView1.Items.Add(s); });
                    }
                    break;
                case "G":
                    PollingIniziato();
                    break;
                case "H":
                    VotoIniziato();
                    break;
                case "I":
                    VotoConcluso();
                    break;
                case "S":
                    Stato0();
                    break;
                case "J":
                    ns = int.Parse(sottocomandi[1]);
                    //slave[ns].morto = true;
                    break;
                case "K":
                    ns = int.Parse(sottocomandi[1]);
                    //slave[ns].morto = false;
                    //slave[ns].fallimenti = 0;
                    break;
                case "Q":
                    ns = int.Parse(sottocomandi[1]);
                    //slave[ns].isripetitore = true;
                    break;
                case "L":
                    ns = int.Parse(sottocomandi[1]);
                    for(int pj= 0; pj < tabslave.Rows.Count; pj++)
                    {
                        if(tabslave[pj].Address== ns) s.Signal= int.Parse(sottocomandi[2]);
                    }
                    /*
                    slave[ns].segnale = int.Parse(sottocomandi[2]);
                    slave[ns].morto = false;
                    slave[ns].fallimenti = 0;
                    slave[ns].sincronizzato = true;
                    */
                    //this.Invoke((MethodInvoker)delegate { /listView1.Items[ns].SubItems[1].Text = slave[ns].segnale.ToString(); });
                    //this.Invoke((MethodInvoker)delegate { listView1.Refresh(); });
                    break;
                case "M":
                    ns = int.Parse(sottocomandi[1]);
                    /*
                    slave[ns].batteria = int.Parse(sottocomandi[2])/(float)77.6;
                    slave[ns].segnale = int.Parse(sottocomandi[3]);
                    slave[ns].fallimenti = 0;
                    slave[ns].sincronizzato = true;
                    */
                    break;
                case "N":
                    ns = int.Parse(sottocomandi[1]);
                    /*
                    slave[ns].oravoto = int.Parse(sottocomandi[2]) / 1000000;
                    slave[ns].votato=true;
                    */
                    break;


            }
        }

        void PollingIniziato()
        {
            this.Invoke((MethodInvoker)delegate { lstato.Text = "Polling started"; });
            this.Invoke((MethodInvoker)delegate { listView1.Columns.Add("Device number", -2, HorizontalAlignment.Center); });
            this.Invoke((MethodInvoker)delegate { listView1.Columns.Add("V Batt.", -2, HorizontalAlignment.Center); });
            this.Invoke((MethodInvoker)delegate { listView1.Columns.Add("Slave Sign.", -2, HorizontalAlignment.Center); });
            this.Invoke((MethodInvoker)delegate { listView1.Columns.Add("Master Sign.", -2, HorizontalAlignment.Center); });

        }
        void VotoIniziato()
        {
            lstato.Text = "Vote started";
            /*
            foreach (Slave s in tabslave)
            {
                s.votato = false;
                s.oravoto = 0;
            }
            */
        }
        void VotoConcluso()
        {
            lstato.Text = "Vote ended";
        }
        void Stato0()
        {
            this.Invoke((MethodInvoker)delegate { lstato.Text = "Pulsantoni"; });
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dg1.Sort(dg1.Columns[0], ListSortDirection.Descending);
        }
    }
}

