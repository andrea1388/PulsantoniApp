using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pulsantoni2
{
    class Slave : INotifyPropertyChanged //: ListViewItem
    {
        protected int _segnale;
        public event PropertyChangedEventHandler PropertyChanged;
        public int indirizzo { get; set; }
        public float batteria { get; set; }
        public int segnale { get { return _segnale; }  set { _segnale = value; NotifyPropertyChanged(); } }
        public bool votato { get; set; }
        public float oravoto { get; set; }
        public bool sincronizzato { get; set; }
        public int indripetitore { get; set; }
        public bool isripetitore { get; set; }
        public int fallimenti { get; set; }
        public bool morto { get; set; }

        private void NotifyPropertyChanged( String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                Program.fmain.Invoke((MethodInvoker)delegate { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); });
                //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public Slave(int ind)
        {
            indirizzo = ind;
            segnale = -127;
            batteria = 0;
            votato = false;
            oravoto = 0;
            indripetitore = 1;
            isripetitore = false;
            fallimenti = 0;
            morto = false;
            sincronizzato = false;
            //Name = ind.ToString();
            //this.Text = ind.ToString();
            //sthis.Index = 0;
            /*
            ListViewSubItem s = new ListViewSubItem(this,segnale.ToString());
            s.Name = "Signal";
            this.SubItems.Add(s);
            s = new ListViewSubItem(this, sincronizzato.ToString());
            s.Name = "In sync";
            this.SubItems.Add(s);
            */

        }




    }
}
