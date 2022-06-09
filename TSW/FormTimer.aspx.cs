using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TSW
{
    public partial class FormTimer : System.Web.UI.Page
    {
        public string constr = @"Data Source=YOUNGLIVING7243\SQLEXPRESS;Initial Catalog =dbTimer;Integrated Security=True;";
        public static Stopwatch sw;
        DateTime DateAndTime = DateTime.Now;
        public string DT;
        public string ID;
        public string IDno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {          
                sw = new Stopwatch();
                lblID.Enabled = false;
            }
        }

        protected void tm1_Tick(object sender, EventArgs e)
        {
            long sec = sw.Elapsed.Seconds;
            long min = sw.Elapsed.Minutes;
            long hour = sw.Elapsed.Hours;
            Label1.Text = hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
        }

        protected void Start(object sender, EventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();
            btnStop.Enabled = true;
            btnStart.Enabled = false;

            using (var con = new SqlConnection(constr))
            {
                string query = "insert into [tblTimer](fldCurrentTime)values(@fldCurrentTime)";
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@fldCurrentTime", SqlDbType.VarChar).Value = DateAndTime;
                    DT = DateAndTime.ToString();                
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }        
            using (var con = new SqlConnection(constr))
            {
                string query = "select * from [tblTimer] where [fldCurrentTime]='" + DT + "'";
                using (var cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        sdr.Read();
                        lblID.Text = sdr["fldID"].ToString();                       
                    }
                    con.Close();
                }            
            }
        }

        protected void Stop(object sender, EventArgs e)
        {

            sw = new Stopwatch();
            sw.Stop();          
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            using (var con = new SqlConnection(constr))
            {
                string query = "update tblTimer set fldValue=@fldValue where [fldID]='" + lblID.Text + "'";
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@fldValue", SqlDbType.NVarChar).Value = Label1.Text.ToString();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Label1.Text = "00" + ":" + "00" + ":" + "00";         
        }
    }
}