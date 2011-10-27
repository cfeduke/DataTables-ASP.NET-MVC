using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Net;
using System.Web.Mvc;
using Moq;
using System.Web;
using System.IO;
using Datatables.Mvc;

namespace jquery.dataTables.Test {
    
    [TestClass]
    public class DataTableResultTest {


        #region Additional test attributes

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext) { }

        [ClassCleanup]
        public static void MyClassCleanup() { }

        [TestInitialize]
        public void MyTestInitialize() { }

        [TestCleanup]
        public void MyTestCleanup() { }

        #endregion
        
        [TestMethod]
        public void DataTableResult_full_parameter_list() {
            var data = new List<List<string>>() {
                new List<string> { "hallo" }
            };
            DataTableResult dataTableResult = new DataTableResult("1", 10, 10, data);
            Assert.AreEqual("1", dataTableResult.sEcho);
            Assert.AreEqual(10, dataTableResult.iTotalRecords);
            Assert.AreEqual(10, dataTableResult.iTotalDisplayRecords);
            Assert.AreSame(data, dataTableResult.aaData);
            Assert.AreEqual(JsonRequestBehavior.DenyGet, dataTableResult.JsonRequestBehavior);
        }

        [TestMethod]
        public void DataTableResult_full_parameter_list_from_DataTable() {
            var data = new List<List<string>>() {
                new List<string> { "hallo" }
            };
            DataTableResult dataTableResult = new DataTableResult(new DataTable { sEcho = "1" }, 10, 10, data);
            Assert.AreEqual("1", dataTableResult.sEcho);
            Assert.AreEqual(10, dataTableResult.iTotalRecords);
            Assert.AreEqual(10, dataTableResult.iTotalDisplayRecords);
            Assert.AreSame(data, dataTableResult.aaData);
            Assert.AreEqual(JsonRequestBehavior.DenyGet, dataTableResult.JsonRequestBehavior);
        }

        [TestMethod]
        public void DataTableResult_from_DataTable() {            
            DataTableResult dataTableResult = new DataTableResult(new DataTable { sEcho = "1" });
            Assert.AreEqual("1", dataTableResult.sEcho);
            Assert.AreEqual(0, dataTableResult.iTotalRecords);
            Assert.AreEqual(0, dataTableResult.iTotalDisplayRecords);
            Assert.AreSame(null, dataTableResult.aaData);
            Assert.AreEqual(JsonRequestBehavior.DenyGet, dataTableResult.JsonRequestBehavior);
        }

        [TestMethod]
        public void ExecuteResult_Ok() {
            //Arrange
            var data = new List<List<string>>() {
                new List<string> { "hallo", "österreich" }
            };

            var httpRequest = new Mock<HttpRequestBase>();
            httpRequest.Setup(h => h.HttpMethod)
                       .Returns("POST");
            var httpResponse = new Mock<HttpResponseBase>();
            httpResponse.Setup(x => x.ContentEncoding)
                        .Returns(Encoding.UTF8);
            string result = string.Empty;
            httpResponse.Setup(x => x.Write(It.IsAny<string>()))
                        .Callback((string s) => result = s);
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request)
                       .Returns(httpRequest.Object);
            httpContext.Setup(h => h.Response)
                       .Returns(httpResponse.Object);
            DataTableResult dataTableResult = new DataTableResult("1", 10, 10, data);
            //Act            
            dataTableResult.ExecuteResult(new ControllerContext {
                HttpContext = httpContext.Object
            });                        
            //Assert
            Assert.AreEqual(@"{""aaData"":[[""hallo"",""österreich""]],""iTotalDisplayRecords"":10,""iTotalRecords"":10,""sColumns"":null}", result);            
        }
    }
}
