using BookListMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MyNotes.Controllers.API;
using Microsoft.EntityFrameworkCore;
using MyNotes.Models;
using System.Xml;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace MyNotesTest
{


    [TestClass]
    public class UnitTest1
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    

        [TestMethod]
        public void TestMethod1()
        {
           

        }
    }
}
