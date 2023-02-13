using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace neptun
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection MyConnection;
                SqlCommand MyCommand;
                SqlDataAdapter MyAdapter;
                DataTable myTable = new DataTable();

                MyConnection = new SqlConnection();
                MyConnection.ConnectionString = 
                    ConfigurationManager.ConnectionStrings["AdventureWorks2019ConnectionString"].ConnectionString;

                MyCommand = new SqlCommand();
                MyCommand.CommandText = "SELECT [Name], [Color], [SafetyStockLevel], [ListPrice] FROM [Production].[Product]";
                MyCommand.CommandType = CommandType.Text;
                MyCommand.Connection = MyConnection;

                MyAdapter = new SqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                MyAdapter.Fill(myTable);

                GridView1.DataSource = myTable.DefaultView;
                GridView1.DataBind();

                MyAdapter.Dispose();
                MyCommand.Dispose();
                MyConnection.Dispose();
            }
        }

        protected void abc(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
                if (Convert.ToInt32(e.Row.Cells[2].Text) >= 1000)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[i].Text = "<b>" + e.Row.Cells[i].Text + "</b>";
                    }
                }
            }
        }
    }
}