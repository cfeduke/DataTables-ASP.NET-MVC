using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datatables.Mvc;
using System.Text;

namespace MvcApplication.Test.Controllers {
    public class HomeController : Controller {
        
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult GetDataTables(DataTable dataTable) {
            List<List<string>> table = new List<List<string>>();

            List<int> column1 = new List<int>();
            for (int i = dataTable.iDisplayStart; i < dataTable.iDisplayStart + dataTable.iDisplayLength; i++) {
                column1.Add(i);
            }            

            foreach (var sortDir in dataTable.sSortDirs) {
                if (sortDir == DataTableSortDirection.Ascending) {
                    column1.Sort();
                } else {
                    column1.Sort(delegate(int a, int b) {
                        if (a > b) return -1;
                        if (a < b) return 1;
                        return 0;
                    });
                }            
            }

            for (int i = 0; i < column1.Count; i++) {
                table.Add(new List<string> { column1[i].ToString(), "Nummer" + i });
            }
            
            var result = new DataTableResult(dataTable, table.Count, table.Count, table);
            result.ContentEncoding = Encoding.UTF8;
            return result;
        }

        public ActionResult Index2() {
            return View();
        }

        [HttpPost]
        public ActionResult GetDataTables2(DataTable dataTable) {
            List<List<string>> table = new List<List<string>>();

            List<int> column1 = new List<int>();
            for (int i = dataTable.iDisplayStart; i < dataTable.iDisplayStart + dataTable.iDisplayLength; i++) {
                column1.Add(i);
            }

            foreach (var sortDir in dataTable.sSortDirs) {
                if (sortDir == DataTableSortDirection.Ascending) {
                    column1.Sort();
                } else {
                    column1.Sort(delegate(int a, int b) {
                        if (a > b) return -1;
                        if (a < b) return 1;
                        return 0;
                    });
                }
            }

            for (int i = 0; i < column1.Count; i++) {
                table.Add(new List<string> { column1[i].ToString(), "ÄÖÜäöü" + i });
            }

            var result = new DataTableResult(dataTable, table.Count, table.Count, table);
            result.ContentEncoding = Encoding.UTF8;
            return result;
        }



    }
}
