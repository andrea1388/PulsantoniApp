using System;
using System.ComponentModel;

namespace pulsantoni2
{
    public class Slave 
    {
        public int indirizzo { get; set; }
        public float batteria { get; set; }
        public int segnale { get; set; }
        public bool votato { get; set; }
        public float oravoto { get; set; }
        public bool sincronizzato { get; set; }
        public int indripetitore { get; set; }
        public bool isripetitore { get; set; }
        public int fallimenti { get; set; }
        public bool morto { get; set; }
        //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

    

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
        }
        /*
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                //Program.fmain.Invoke((MethodInvoker)delegate { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); });
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void PropertyChanged(Slave slave, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            throw new NotImplementedException();
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
        */
    }
}
