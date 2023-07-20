using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTimeWinForms
{
    public partial class User_LogTime : Form
    {
        public static uint t1, t2;
        private TimeSpan activeTime = TimeSpan.Zero;
        private TimeSpan inactiveTime = TimeSpan.Zero;
       
        public User_LogTime()
        {
            InitializeComponent();
        }

        //private void btnSave_Click(object sender, EventArgs e)   //Login
        //{
        //    try
        //    {
        //        string qry = "INSERT INTO User_LogTime VALUES (@Empid, @Logintime)";
        //        cmd = new SqlCommand(qry, con);
        //        cmd.Parameters.AddWithValue("@Empid", Convert.ToInt32(txtempid.Text));  // Set the employee ID
        //        cmd.Parameters.AddWithValue("@Logintime", DateTime.Now);  // Current login time
        //        con.Open();
        //        int res = cmd.ExecuteNonQuery();
        //         if (res > 0)
        //         {
        //            MessageBox.Show("Record inserted");
        //         }
        //    }
        //       catch(Exception ex)
        //        {
        //           MessageBox.Show(ex.Message);
        //        }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private void btnsearch_Click(object sender, EventArgs e)  
        //{
        //    try
        //    {
        //        string query = "SELECT Logintime, Logouttime FROM User_LogTime WHERE Empid = @Empid";
        //        SqlCommand command = new SqlCommand(query, con);
        //        command.Parameters.AddWithValue("@Empid", Convert.ToInt32(txtempid.Text));  // Set the employee ID

        //        // SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        //DataTable loginHistory = new DataTable();
        //        con.Open();
        //        dr=cmd.ExecuteReader();
        //        if(dr.HasRows)
        //        {
        //            while(dr.Read())
        //            {
        //                dateTimePicker1.Text = dr["Logintime"].ToString();
        //                dateTimePicker2.Text = dr["Logouttime"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Record not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private void btnupdate_Click(object sender, EventArgs e)  //Logout btn
        //{
        //    try
        //    {
        //        string query = "UPDATE User_LogTime SET LogoutTime = @LogoutTime WHERE EmployeeID = @EmployeeID AND LogoutTime IS NULL";
        //        SqlCommand command = new SqlCommand(query, con);
        //        command.Parameters.AddWithValue("@LogoutTime", DateTime.Now);  // Current logout time
        //        command.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(txtempid.Text));  // Set the employee ID
        //        con.Open();
        //        int res = cmd.ExecuteNonQuery();
        //        if (res > 0)
        //        {
        //            MessageBox.Show("Record inserted");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        private void btndalete_Click(object sender, EventArgs e)
        {

        }

        private void btnshoall_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void User_LogTime_Load(object sender, EventArgs e)
        {
            lblActivetime.Text = "00:00";
            lblInactivetime.Text = "00:00";
            timer1.Enabled = true;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //long l1 = Convert.ToInt64(lblActivetime.Text);
            //long l2 = Convert.ToInt64(lblInactivetime.Text);
            //double d1 = TimeSpan.FromMilliseconds(l1).TotalMinutes;
            //double d2 = TimeSpan.FromMilliseconds(l2).TotalMinutes;
            //MessageBox.Show("Active time " + d1 + " Inactive time " + d2);
            //MessageBox.Show($"Active time: {activeTime.TotalMinutes:F2} minutes, {activeTime.Seconds} seconds\nInactive time: {inactiveTime.TotalMinutes:F2} minutes, {inactiveTime.Seconds} seconds");
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //  listBox1.Items.Add(Win32.GetIdleTime().ToString());
            //uint a = Win32.GetIdleTime();

            //if (Win32.GetIdleTime() > 1000) // 1 minute
            //{
            //    t1 += a;
            //    lblInactivetime.Text = t1.ToString();
            //}
            //else
            //{
            //    t2 += a;
            //    lblActivetime.Text = t2.ToString();
            //}

            uint idleTime = Win32.GetIdleTime();

            if (idleTime > 1000) // 1 minute
            {
                inactiveTime += TimeSpan.FromMilliseconds(idleTime);
               
                lblInactivetime.Text = FormatTimeSpan(inactiveTime);
            }
            else
            {
                activeTime += TimeSpan.FromMilliseconds(idleTime);
               
                lblActivetime.Text = FormatTimeSpan(activeTime);
            }
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            return $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        }
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        public class Win32
        {
            [DllImport("User32.dll")]
            public static extern bool LockWorkStation();

            [DllImport("User32.dll")]
            private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

            [DllImport("Kernel32.dll")]
            private static extern uint GetLastError();

            public static uint GetIdleTime()
            {
                LASTINPUTINFO lastInput = new LASTINPUTINFO();
                lastInput.cbSize = (uint)Marshal.SizeOf(lastInput);
                if (!GetLastInputInfo(ref lastInput))
                {
                    throw new Exception(GetLastError().ToString());
                }

                uint idleTime = (uint)Environment.TickCount - lastInput.dwTime;
                return idleTime;
            }

            public static long GetLastInputTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                if (!GetLastInputInfo(ref lastInPut))
                {
                    throw new Exception(GetLastError().ToString());
                }

                return lastInPut.dwTime;
            }

        }
    }
}
