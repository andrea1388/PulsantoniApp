using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pulsantoni2
{
    class SlaveDataTable : DataTable
    {
        public SlaveDataTable()
        {
            Columns.Add(new DataColumn("Address", typeof(int)));
            Columns.Add(new DataColumn("Signal", typeof(int)));
            Columns.Add(new DataColumn("Sync", typeof(bool)));
        }
        public SlaveDataRow GetNewRow()
        {
            SlaveDataRow row = (SlaveDataRow)NewRow();

            return row;
        }



        protected override Type GetRowType()
        {
            return typeof(SlaveDataRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new SlaveDataRow(builder);
        }
    }
}
