using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTables
{
    public abstract class DataTablesRequest
    {
        /* Draw counter. */
        public int Draw { get; set; }

        /* The start point in the current data set */
        public int Start { get; set; }

        /* Number of records that the table can display in the current draw */
        public int Length { get; set; }

        /* Global search */
        public Search Search { get; set; }

        /* Order by */
        public IEnumerable<Order> Order { get; set; }

        /* Columns, search for individial column */
        public IEnumerable<Column> Columns { get; set; }

        public DataTablesRequest()
        {
            Order = new List<Order>();
            Columns = new List<Column>();
        }
    }

    public class Search
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

    public class Order
    {
        public string Dir { get; set; }
        public int Column { get; set; }
    }

    public class Column
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public Search Search { get; set; }
    }

    public class OrderDir
    {
        private OrderDir(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static OrderDir Asc { get { return new OrderDir("asc"); } }
        public static OrderDir Desc { get { return new OrderDir("desc"); } }
    }
}
