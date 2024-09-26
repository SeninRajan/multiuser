using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace multiuser
{
    public partial class login : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select Count(Reg_id) from logintab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = obj.Fn_Scalar(s);
            int cid1 = Convert.ToInt32(cid);
            if(cid1==1)
            {
                string str = "select Reg_id from logintab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string rid = obj.Fn_Scalar(str);
                Session["userid"] = rid;
                string sr="select Log_type from logintab where username='"+TextBox1.Text+ "' and password='" + TextBox2.Text + "'";
                string logtype = obj.Fn_Scalar(sr);
                if(logtype=="Admin")//table-le same name kodukanam
                {
                    Label3.Text = "Admin";
                }
                else if(logtype=="User")//table-le same name kodukanam
                {
                    Label3.Text = "User";
                }

            }
            else
            {
                Label3.Text = "invalid username/password";
            }

        }
    }
}