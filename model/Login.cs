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

namespace J_Sarad_C969_SchedulingApp
{
    public partial class LogIn : Form
    {
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
                lblLogin.Text = "Accesso";
            }
            else
            {
                MessageBox.Show( "This application supports English or Spanish \nEsta applicacion es compatible con ingles o espanol", 
                    "Unknown Language -- Idioma desconocido");
            }
        }
    }
}
