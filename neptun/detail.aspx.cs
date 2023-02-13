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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string fonksiyon = Request.QueryString["Function"];
                int kID = Convert.ToInt32(Request.QueryString["ID"]);

                fill_ddlID();
                fill_ddlPhoneType();

                switch (fonksiyon)
                {
                    case "Read":
                        data_read(kID);
                        ddlID.Enabled = false;
                        ddlPType.Enabled = false;
                        Button1.Visible = false;
                        txtPhoneNumber.Enabled = false;
                        break;
                    case "New":
                        Button1.Text = "Ekle";
                        txtDate.Text = DateTime.Now.ToString();
                        break;
                    case "Update":
                        data_read(kID);
                        Button1.Text = "Güncelle";
                        txtDate.Text = DateTime.Now.ToString();
                        break;
                    case "Delete":
                        data_read(kID);
                        ddlID.Enabled = false;
                        ddlPType.Enabled = false;
                        Button1.Text = "Sil";
                        txtPhoneNumber.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
        }
        protected void data_read(int PID)
        {
            SqlConnection MyConnection;
            SqlCommand MyCommand;
            SqlDataReader MyReader;

            MyConnection = new SqlConnection();
            MyConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["AdventureWorks2019ConnectionString"].ConnectionString;

            MyCommand = new SqlCommand();
            MyCommand.CommandText = "SELECT TOP 1 BusinessEntityID, PhoneNumber, PhoneNumberTypeID, ModifiedDate " +
                "FROM Person.PersonPhone WHERE BusinessEntityID=@BusinessEntityID";
            MyCommand.Parameters.AddWithValue("@BusinessEntityID", PID);
            MyCommand.CommandType = CommandType.Text;
            MyCommand.Connection = MyConnection;

            MyCommand.Connection.Open();
            MyReader = MyCommand.ExecuteReader(CommandBehavior.CloseConnection);

            if (MyReader.HasRows)
            {
                while (MyReader.Read())
                {
                    ddlID.SelectedValue = MyReader["BusinessEntityID"].ToString();
                    ViewState["BEID"] = MyReader["BusinessEntityID"].ToString();
                    txtPhoneNumber.Text = MyReader["PhoneNumber"].ToString();
                    ViewState["PN"] = MyReader["PhoneNumber"].ToString();
                    ddlPType.SelectedValue = MyReader["PhoneNumberTypeID"].ToString();
                    ViewState["PNTID"] = MyReader["PhoneNumberTypeID"].ToString();
                    txtDate.Text = MyReader["ModifiedDate"].ToString();
                }
            }
            MyCommand.Dispose();
            MyConnection.Dispose();

        }
        protected void fill_ddlPhoneType()
        {
            SqlConnection MyConnection;
            SqlCommand MyCommand;
            SqlDataAdapter MyAdapter;
            DataTable myTable = new DataTable();

            MyConnection = new SqlConnection();
            MyConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["AdventureWorks2019ConnectionString"].ConnectionString;

            MyCommand = new SqlCommand();
            MyCommand.CommandText = "SELECT PhoneNumberTypeID, Name FROM Person.PhoneNumberType";
            MyCommand.CommandType = CommandType.Text;
            MyCommand.Connection = MyConnection;

            MyAdapter = new SqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand;
            MyAdapter.Fill(myTable);

            ddlPType.DataSource = myTable;
            ddlPType.DataTextField = myTable.Columns[1].ToString();
            ddlPType.DataValueField = myTable.Columns[0].ToString();
            ddlPType.DataBind();
            ListItem li = new ListItem("Bir tip seçiniz","0");
            ddlPType.Items.Insert(0, li);

            MyAdapter.Dispose();
            MyCommand.Dispose();
            MyConnection.Dispose();
        }

        protected void fill_ddlID()
        {
            SqlConnection MyConnection;
            SqlCommand MyCommand;
            SqlDataAdapter MyAdapter;
            DataTable myTable = new DataTable();

            MyConnection = new SqlConnection();
            MyConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["AdventureWorks2019ConnectionString"].ConnectionString;

            MyCommand = new SqlCommand();
            MyCommand.CommandText = "SELECT DISTINCT BusinessEntityID, FirstName + ' ' + LastName AS Name FROM Person.Person";
            MyCommand.CommandType = CommandType.Text;
            MyCommand.Connection = MyConnection;

            MyAdapter = new SqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand;
            MyAdapter.Fill(myTable);

            ddlID.DataSource = myTable;
            ddlID.DataTextField = myTable.Columns[1].ToString();
            ddlID.DataValueField = myTable.Columns[0].ToString();
            ddlID.DataBind();
            ListItem li = new ListItem("Bir kişi seçiniz", "0");
            ddlID.Items.Insert(0, li);

            MyAdapter.Dispose();
            MyCommand.Dispose();
            MyConnection.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string islem = btn.Text;
            string hata="";

            SqlConnection baglanti;
            SqlCommand komut;
            string baglanStr = ConfigurationManager.ConnectionStrings["AdventureWorks2019ConnectionString"].ConnectionString;
            baglanti = new SqlConnection(baglanStr);
            try
            {
                switch (islem)
                {
                    case "Ekle":
                        komut = new SqlCommand("INSERT INTO Person.PersonPhone (BusinessEntityID, PhoneNumber, PhoneNumberTypeID," +
                            " ModifiedDate) VALUES(@BusinessEntityID, @PhoneNumber,@PhoneNumberTypeID,@ModifiedDate)", baglanti);
                        komut.Parameters.AddWithValue("@BusinessEntityID", ddlID.SelectedValue);
                        komut.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        komut.Parameters.AddWithValue("@PhoneNumberTypeID", ddlPType.SelectedValue);
                        komut.Parameters.AddWithValue("@ModifiedDate", Convert.ToDateTime(txtDate.Text).ToString("yyyy-MM-dd"));
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        break;
                    case "Güncelle":
                        komut = new SqlCommand("UPDATE Person.PersonPhone SET BusinessEntityID=@BusinessEntityID, PhoneNumber=@PhoneNumber, " +
                                " PhoneNumberTypeID=@PhoneNumberTypeID, ModifiedDate=@ModifiedDate WHERE BusinessEntityID=@BEID" +
                                " AND PhoneNumber=@PN AND PhoneNumberTypeID=@PNTID", baglanti);
                        komut.Parameters.AddWithValue("@BusinessEntityID", ddlID.SelectedValue);
                        komut.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        komut.Parameters.AddWithValue("@PhoneNumberTypeID", ddlPType.SelectedValue);
                        komut.Parameters.AddWithValue("@ModifiedDate", Convert.ToDateTime(txtDate.Text).ToString("yyyy-MM-dd"));
                        komut.Parameters.AddWithValue("@BEID", ViewState["BEID"]);
                        komut.Parameters.AddWithValue("@PN", ViewState["PN"]);
                        komut.Parameters.AddWithValue("@PNTID", ViewState["PNTID"]);
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        break;
                    case "Sil":
                        komut = new SqlCommand("DELETE FROM Person.PersonPhone WHERE BusinessEntityID=@BusinessEntityID AND" +
                            " PhoneNumber=@PhoneNumber AND PhoneNumberTypeID=@PhoneNumberTypeID", baglanti);
                        komut.Parameters.AddWithValue("@BusinessEntityID", ddlID.SelectedValue);
                        komut.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        komut.Parameters.AddWithValue("@PhoneNumberTypeID", ddlPType.SelectedValue);
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        break;
                    default:
                        break;
                }
                lblMesaj.Text = "İşlem tamam!";
            }
            catch
            {
                lblMesaj.Text = "Hata oluştu, kaydedilemedi.";
            }
            finally
            {
                baglanti.Close();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}