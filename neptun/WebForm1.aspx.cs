using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace neptun
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                GridView1.PageSize = Convert.ToInt32(DropDownList1.SelectedItem.Text);
                Label1.Text = DropDownList2.SelectedValue + " / " + DropDownList2.SelectedItem.Text;
            }
        }
    }
}