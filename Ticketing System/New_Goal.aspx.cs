using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Ticketing_System
{
    public partial class New_Goal : System.Web.UI.Page
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

                SqlCommand cmd = new SqlCommand("INSERT INTO Goal_Table(User_Name,Title,Description,Date) values(@User_Name,@Title,@Description,@Date)", con);
                cmd.Parameters.AddWithValue("@User_Name", "Tahsin Hasan");
                cmd.Parameters.AddWithValue("@Title", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("M/d/yyyy"));
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('New Goal Created');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            Response.Redirect("/Goal-Setting.aspx");

        }
    }
}