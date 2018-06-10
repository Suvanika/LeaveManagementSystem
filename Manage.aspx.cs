using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System.Web.UI;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace WebApplication5
{
    public partial class Manage : Page
    {
        int empid=0;
        string emp;

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = Request.QueryString["name"];
            if (emp != null && emp.Length > 0)
            {
                empid = int.Parse(emp);
                if (empid <= 0) empid = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "user id=app;password=app;data source=//localhost:1521/xe";

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;
            cmd.CommandText = "UPDATE CREDENTIALS SET PASSWORD = :pass WHERE :prev = ( SELECT PASSWORD FROM CREDENTIALS WHERE emp_id = (select emp_id from employee where emp_id = :empid))";
            //cmd.Parameters.Add(":pass", curr.Text);
            //cmd.Parameters.Add(":prev", prev.Text);
            cmd.Parameters.Add(":empid", empid);
            cmd.ExecuteNonQuery();
            cmd.Cancel();
            conn.Close();
        }
    }
}