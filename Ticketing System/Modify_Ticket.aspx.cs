using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Ticketing_System
{
    public partial class Modify_Ticket : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void textChangedEventHandler(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Ticket_Table WHERE Title='" + Titles.SelectedItem.Value + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = Titles.SelectedItem.Value;
                    TextBox2.Text = dt.Rows[0]["Description"].ToString();
                }
            }
            catch
            {

            }

        }

                protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Ticket_Table SET User_Name=@User_Name, User_1=@User_1, User_2=@User_2, User_3=@User_3, User_3=@User_3, User_4=@User_4, User_5=@User_5, User_6=@User_6, Title=@Title, Description=@Description, Date=@Date where Title='" + Titles.SelectedItem.Value.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@User_Name", "Tahsin Hasan");
                cmd.Parameters.AddWithValue("@User_1", "");
                cmd.Parameters.AddWithValue("@User_2", "");
                cmd.Parameters.AddWithValue("@User_3", "");
                cmd.Parameters.AddWithValue("@User_4", "");
                cmd.Parameters.AddWithValue("@User_5", "");
                cmd.Parameters.AddWithValue("@User_6", "");
                cmd.Parameters.AddWithValue("@Title", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("M/d/yyyy"));

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Modified Ticket!');</script>");

                //Response.Redirect("/Tickets.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           
        }
    }
}