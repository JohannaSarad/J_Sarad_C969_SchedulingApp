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

namespace J_Sarad_C969_SchedulingApp

{

    public partial class LogIn : Form
    {
        //FIX ME! Move me to a class user with method to update user and possibly add user for testing
        public static int currentUserID { get; set; }
        
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            DetectLanguage();
        }

        private void DetectLanguage()
        {
            CultureInfo language = CultureInfo.CurrentUICulture;
            if (language.Parent.Name == "en")
            {
                lblLogin.Text = "Please Enter Your Username and Password";
                lblPassword.Text = "Password";
                lblUsername.Text = "Username";
                btnLogin.Text = "Login";

            }
            else if (language.Parent.Name == "es")
            {
                lblLogin.Text = "Porfavor introduzca su nombre de usuario y contrasena";
                lblPassword.Text = "contrasena";
                lblUsername.Text = "Nombre de usuario";
                btnLogin.Text = "Accesso";
            }
            else
            {
                //FiXME make the format of this dialog box look nicer. 
                DialogResult dialog = MessageBox.Show("This application supports English or Spanish" +
                    "\n Please change language settings and restart application" + 
                    "\r\nEsta applicacion es compatible con ingles o espanol" +
                    "\nCambie la configuracion de idioma y reinicie la aplicacion" ,
                    "Unknown Language -- Idioma desconocido", MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DB.OpenConnection();
            string query = "SELECT * FROM User";
            DB.Query(query);
            DataTable dataTable = new DataTable();
            DB.adp.Fill(dataTable);
            //DB.FillTable(query);
            DB.CloseConnection();
            //MessageBox.Show(DB.dataTable.Rows[0]["userName"].ToString());

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["userName"].ToString() == txtUsername.Text
                    && dataTable.Rows[i]["password"].ToString() == txtPassword.Text)
                {
                    DB.currentUser = dataTable.Rows[i]["userName"].ToString();
                    this.Hide();
                    MainMenu form = new MainMenu();

                    //MainMenu form = new MainMenu();
                    form.ShowDialog();
                }
                else
                {
                    //FIXME!!! check for Spanish and make an error message in Spanish
                    MessageBox.Show("Please check your username and password", "Invalid username or password");
                }
            }
        }
    }
}
