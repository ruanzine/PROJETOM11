using M11_PROJETOFINAL.entities;
using System;
using System.Windows.Forms;

namespace M11_PROJETOFINAL.gui
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void bttLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            User userClass = new EntityFactory().GetUserClass(username);

            if (userClass == null)
            {
                lblError.Text = "este nome de usuário não existe";
                lblError.Visible = true;
                txtUsername.Focus();
                return;
            }

            if (!password.Equals(userClass.GetCredentials()[1]))
            {
                lblError.Text = "palavra-passe incorreta";
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            FormInicial.INSTANCE.lblUsuario.Text = txtUsername.Text;
            userClass.FillTabs();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    
        private void picShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = (char)0;
        }

        private void picShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblError.Visible = false;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblError.Visible = false;
        }
    }
}
