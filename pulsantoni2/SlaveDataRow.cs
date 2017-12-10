using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pulsantoni2
{
    class SlaveDataRow : DataRow
    {
        public SlaveDataRow(DataRowBuilder builder) : base(builder)
        {
            Signal = -127;
            Sync = false;

        }
        public int Address
        {
            get { return (int)base["Address"]; }
            set { base["Address"] = value; }
        }
        public int Signal
        {
            get { return (int)base["Signal"]; }
            set { base["Signal"] = value; }
        }
        public bool Sync
        {
            get { return (bool)base["Sync"]; }
            set { base["Sync"] = value; }
        }
    }
}
