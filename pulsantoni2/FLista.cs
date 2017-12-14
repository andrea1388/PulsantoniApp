using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace pulsantoni2
{
    public partial class FLista : Form
    {
        List<Slave> _slave;
        SerialPort _sp;
        public FLista()
        {
            InitializeComponent();
        }
        public void Mostra( List<Slave> slave,ref SerialPort serport)
        {
            this.Show();
            _slave = slave;
            dg1.DataSource = _slave;
            _sp = serport;
            _sp.WriteLine("io 1");
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            dg1.DataSource = null;
            dg1.DataSource = _slave;
        }

        private void FLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sp.WriteLine("io 0");
        }
    }
}
