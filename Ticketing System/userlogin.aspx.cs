using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ticketing_System
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "Login";

        }

        // user login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from User_Table1 where Email='" + TextBox1.Text.Trim() + "' AND Password='" + TextBox2.Text.Trim() + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Hello " + dr.GetValue(2).ToString() + "');</script>");
                        Session["Full_Name"] = dr.GetValue(2).ToString();
                        Session["Password"] = dr.GetValue(1).ToString();
                        Session["Email"] = dr.GetValue(0).ToString();
                        Response.Redirect("/Goal-Setting.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}