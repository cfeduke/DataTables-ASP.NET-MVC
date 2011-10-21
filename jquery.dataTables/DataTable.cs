using System.Collections.Generic;

namespace Datatables.Mvc {
        
    /// <summary>
    /// This class represents a jquery.dataTable request
    /// object. This class can be used as parameter
    /// in a Controllers Actions method. The Jquery.datatable
    /// parameter are bound automatically to this object.
    /// </summary>
    public class DataTable {

        public DataTable() {
            bSortables = new List<bool>();
            bSearchables = new List<bool>();
            sSearchs = new List<string>();
            bEscapeRegexs = new List<bool>();
            iSortCols = new List<int>();
            sSortDirs = new List<DataTableSortDirection>();
        }

        /// <summary>
        /// Information for DataTables to use for rendering
        /// </summary>
        public string sEcho { get; set; }
        /// <summary>
        /// Display start point
        /// </summary>
        public int iDisplayStart { get; set; }
        /// <summary>
        /// Number of records to display
        /// </summary>
        public int iDisplayLength { get; set; }
        /// <summary>
        /// Number of columns being displayed (useful for getting individual column search info)
        /// </summary>
        public int iColumns { get; set; }
        /// <summary>
        /// Global search field
        /// </summary>
        public string sSearch { get; set; }
        /// <summary>
        /// Global search is regex or not
        /// </summary>
        public bool? bEscapeRegex { get; set; }
        /// <summary>
        /// Indicator for if a column is flagged as sortable or not on the client-side
        /// </summary>
        public IList<bool> bSortables { get; set; }
        /// <summary>
        /// Indicator for if a column is flagged as searchable or not on the client-side
        /// </summary>
        public IList<bool> bSearchables { get; set; }
        /// <summary>
        /// Individual column filter
        /// </summary>
        public IList<string> sSearchs { get; set; }
        /// <summary>
        /// Individual column filter is regex or not
        /// </summary>
        public IList<bool> bEscapeRegexs { get; set; }
        /// <summary>
        /// Number of columns to sort on
        /// </summary>
        public int iSortingCols { get; set; }
        /// <summary>
        /// Column being sorted on (you will need to decode this number for your database)
        /// </summary>
        public IList<int> iSortCols { get; set; }
        /// <summary>
        /// Direction to be sorted - "desc" or "asc". Note that the prefix for this variable is wrong in 1.5.x where iSortDir_(int) was used)
        /// </summary>
        public IList<DataTableSortDirection> sSortDirs { get; set; }
    }

    /// <summary>
    /// The sort order of a column.
    /// </summary>
    public enum DataTableSortDirection {
        /// <summary>
        /// Sort the column ascending
        /// </summary>
        Ascending,

        /// <summary>
        /// Sort the column descending
        /// </summary>
        Descending
    }
}