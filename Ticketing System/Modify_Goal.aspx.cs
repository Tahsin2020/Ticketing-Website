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
    public partial class Modify_Goal : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        bool bRet = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (bRet)
            {

                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM dbo.Goal_Table;", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        // This code here sets the value inside the boxes, making it impossible to modify them later.
                        //TextBox1.Text = dt.Rows[0]["Title"].ToString();
                        //TextBox2.Text = dt.Rows[0]["Description"].ToString();
                    }
                }
                catch
                {

                }
            }
        }

        protected void textChangedEventHandler(object sender, EventArgs e)
        {
            if (bRet)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from dbo.Goal_Table WHERE Title='" + Titles.SelectedItem.Value + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        // This code here sets the value inside the boxes, making it impossible to modify them later.
                       TextBox1.Text = Titles.SelectedItem.Value;
                        TextBox2.Text = dt.Rows[0]["Description"].ToString();
                    }
                }
                catch
                {

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bRet= false;
            Response.Write("<script>alert('" + TextBox1.Text.Trim() + "');</script>");
            try
            {
                 SqlConnection con = new SqlConnection(strcon);
                 if (con.State == ConnectionState.Closed)
                 {
                     con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE dbo.Goal_Table SET User_Name=@User_Name, Title =@Title, Description=@Description, Date=@Date WHERE Title='" + Titles.SelectedItem.Value + "'", con);

                 cmd.Parameters.AddWithValue("@User_Name", "Tahsin Hasan");
                 cmd.Parameters.AddWithValue("@Title", TextBox1.Text.Trim());
                 cmd.Parameters.AddWithValue("@Description", TextBox2.Text.Trim());
                 cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("M/d/yyyy"));

                 cmd.ExecuteNonQuery();

                con.Close();
                // Response.Write("<script>alert('Modified Goal!');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            //Response.Redirect("/Goal-Setting.aspx");
        }
    }
}