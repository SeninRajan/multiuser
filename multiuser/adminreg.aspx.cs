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
    public partial class adminreg : System.Web.UI.Page
    {
        Class1 obj=new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(Reg_id) from logintab";
            string regid = obj.Fn_Scalar(s);
            int reg_id = 0;
            if (regid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string ins = "insert into adminreg1 values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "')";
            int i = obj.Fn_NonQuery(ins);
            if (i == 1)
            {
                string inslog = "insert into logintab values(" + reg_id + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','Admin','active')";
                int j = obj.Fn_NonQuery(inslog);
            }
        }
    }
}