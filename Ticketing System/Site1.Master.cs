using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace Ticketing_System
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        // http://localhost:1302/TESTERS/Default6.aspx

        string path = HttpContext.Current.Request.Url.AbsolutePath;
        // /TESTERS/Default6.aspx

        string host = HttpContext.Current.Request.Url.Host;
        // localhost
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            if (path.Equals("/userlogin.aspx"))
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                Panel3.Visible = false;
            }
            else if (path.Equals("/New_Goal.aspx"))
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                Panel3.Visible = false;
            }

            else if (path.Equals("/New_Ticket.aspx"))
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                Panel3.Visible = false;
            }

            else if (path.Equals("/Goal-Setting.aspx"))
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
                DropDownList1.Visible = true;
                DropDownList2.Visible = false;
                Panel3.Visible = true;
            }

            else if (path.Equals("/Tickets.aspx"))
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
                DropDownList1.Visible = false;
                DropDownList2.Visible = true;
                Panel3.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                Panel3.Visible = false;
            }

        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (path.Equals("/Goal-Setting.aspx"))
            {
                Response.Redirect("/New_Goal.aspx");
            }
            else if (path.Equals("/Tickets.aspx"))
            {
                Response.Redirect("/New_Ticket.aspx");
            }
        }

        protected void ImageButton_Click1(object sender, ImageClickEventArgs e)
        {
            if (path.Equals("/Goal-Setting.aspx"))
            {
                Response.Redirect("/Modify_Goal.aspx");
            }
            else if (path.Equals("/Tickets.aspx"))
            {
                String Value = DropDownList2.SelectedItem.Value;
                Response.Redirect("/Modify_Ticket.aspx");
            }
        }

        protected void ImageButton_Click2(object sender, ImageClickEventArgs e)
        {
            if (path.Equals("/Goal-Setting.aspx"))
            {
                String Value = DropDownList1.SelectedItem.Value;

                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from Goal_Table WHERE Title='" + Value + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Goal Deleted Successfully');</script>");
                    Response.Redirect("Goal-Setting.aspx");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else if (path.Equals("/Tickets.aspx"))
            {
                String Value = DropDownList2.SelectedItem.Value;

                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from Ticket_Table WHERE Title='" + Value + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Ticket Deleted Successfully');</script>");
                    Response.Redirect("Tickets.aspx");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}