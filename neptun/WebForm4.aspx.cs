using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace neptun
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string ad = row.Cells[2].Text;
                string soyad = row.Cells[3].Text;
                Response.Write(index + ". satır: " + ad + " " + soyad);
            }
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.BackColor = System.Drawing.Color.White;
                gvr.ForeColor = System.Drawing.Color.Black;
            }
            GridViewRow row = GridView2.Rows[e.NewSelectedIndex];
            row.BackColor = System.Drawing.Color.Red;
            row.ForeColor = System.Drawing.Color.White;
        }
    }
}