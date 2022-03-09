using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using J_Sarad_C969_SchedulingApp.model;
using System.IO;

namespace J_Sarad_C969_SchedulingApp

{
    
    public partial class LogIn : Form
    {
       //bool foundUser;
       
        
        CultureInfo language = CultureInfo.CurrentUICulture;
        CultureInfo locale = CultureInfo.CurrentCulture;
        
        //get current date and time
        DateTime currentTime = DateTime.Now;

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            //MessageBox.Show($"locale Parent: {locale.Parent.Name} \nlanguage Parent: {language.Parent.Name} " +
            //    $"\nlocale Name: {locale.Name} \nregion: {region.TwoLetterISORegionName}");
            
            DetectLanguage();

        }

        private void DetectLanguage()
        {
            if ((language.Parent.Name != "en" && language.Parent.Name != "es") 
                || (locale.Parent.Name != "en" && locale.Parent.Name != "es"))
            {
                //user language not English or Spanish
                DialogResult dialog = MessageBox.Show("This application supports English or Spanish" +
                    "\r\nPlease change language settings and restart application" +
                    "\r\n\r\nEsta applicacion es compatible con ingles o espanol" +
                    "\r\nCambie la configuracion de idioma y reinicie la aplicacion",
                    "Unknown Language -- Idioma desconocido", MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            
            else if ((language.Parent.Name == "es") || (locale.Parent.Name == "es"))
            {
                //user language in Spanish 
                lblLogin.Text = "Porfavor introduzca su nombre de usuario y contrasena";
                lblPassword.Text = "contrasena";
                lblUsername.Text = "Nombre de usuario";
                btnLogin.Text = "Accesso";
                lblLogin.Location = new Point(55, 22);
                txtPassword.Location = new Point(210, 100);
                txtUsername.Location = new Point(210, 63);
            }
            else
            {
                //user language English
                lblLogin.Text = "Please Enter Your Username and Password";
                lblPassword.Text = "Password";
                lblUsername.Text = "Username";
                btnLogin.Text = "Login";
               
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            try
            {
                DB.OpenConnection();
                string query = "SELECT * FROM User";
                DB.Query(query);
                DB.adp.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!" + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }
            
            //bool foundUser = false;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["userName"].ToString() == txtUsername.Text
                    && dataTable.Rows[i]["password"].ToString() == txtPassword.Text)
                {
                    DB.currentUser = dataTable.Rows[i]["userName"].ToString();
                    DB.currentUserID = (int)dataTable.Rows[i]["userId"];
                    //foundUser = true;
                }
            }

            if (DB.currentUserID > 0)
            {
                CheckForAppt();
                DirectoryInfo info = new DirectoryInfo(".");
                //string path = @"userLogs.txt";
                string path = info + "\\userLogs.txt";
                

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"User: {DB.currentUser} . UserId: {DB.currentUserID} . Logged in at: {currentTime}");
                }
                this.Hide();
                MainMenu form = new MainMenu();
                form.ShowDialog();
            }
            else
            {
               if ((language.Parent.Name == "es") || (locale.Parent.Name == "es"))
                {
                    MessageBox.Show("Por favor verifique su nombre de usuario y contrasena",
                       "usuario o contrasena invalido");
                   
                }
                else 
                {
                    MessageBox.Show("Please check your username and password", "Invalid username or password");
                }
            }
        }

        private void CheckForAppt ()
        {
            DataTable check = new DataTable();
            try
            {
                DB.OpenConnection();
                string query2 = "Select appointmentId as ApptID, start as Start from appointment ";
                DB.Query(query2);
                DB.adp.Fill(check);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Ocurred" + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }

            for (int i = 0; i < check.Rows.Count; i++)
            {
                
                check.Rows[i]["Start"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)check.Rows[i]["Start"],
                    TimeZoneInfo.Local);
                DateTime upcoming = (DateTime)check.Rows[i]["Start"];
                var id = check.Rows[i]["ApptID"];
                if (currentTime < upcoming &&
                    (currentTime.AddMinutes(15) > upcoming))
                {
                    MessageBox.Show($"You have an appointment within fifteen minutes with " +
                        $"{id} at {upcoming}");
                }
            }
        }
    }
}
