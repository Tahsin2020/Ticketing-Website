using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ticketing_System
{
    public partial class New_Ticket : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

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


                SqlCommand cmd = new SqlCommand("INSERT INTO Ticket_Table(User_Name,User_1,User_2,User_3,User_4,User_5,User_6,Title,Description,Date) values(@User_Name,@User_1,@User_2,@User_3,@User_4,@User_5,@User_6,@Title,@Description,@Date)", con);
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
                Response.Write("<script>alert('New Ticket Created!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            Response.Redirect("/Tickets.aspx");
        }
    }
}