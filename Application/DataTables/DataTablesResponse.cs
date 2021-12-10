using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTables
{
    public class DataTablesResponse<T>
    {
        public int Draw { get; private set; }
        public int RecordsTotal { get; private set; }
        public int RecordsFiltered { get; private set; }
        public IEnumerable<T> Data { get; private set; }

        public DataTablesResponse(int draw,
                        int recordsTotal,
                        int recordsFiltered,
                        IEnumerable<T> data)
        {
            Draw = draw;
            RecordsTotal = recordsTotal;
            RecordsFiltered = recordsFiltered;
            Data = data;
        }
    }
}
