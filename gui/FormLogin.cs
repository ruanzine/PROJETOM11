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

        /// <summary>
        /// Manipula o evento Click do botão de login. Verifica se as credenciais de login são válidas e inicia a sessão do usuário.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void bttLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Obtém a instância da classe de usuário apropriada com base no nome de usuário fornecido.
            User userClass = new EntityFactory().GetUserClass(username);

            if (userClass == null)
            {
                lblError.Text = "Este nome de usuário não existe.";
                lblError.Visible = true;
                txtUsername.Focus();
                return;
            }

            if (!password.Equals(userClass.GetCredentials()[1]))
            {
                lblError.Text = "Palavra-passe incorreta.";
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Configura o nome de usuário na instância do formulário principal e preenche as guias acessíveis ao usuário.
            FormInicial.INSTANCE.lblUsuario.Text = txtUsername.Text;
            userClass.FillTabs();

            // Define o resultado do diálogo como OK e fecha o formulário de login.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Manipula o evento MouseDown do ícone para mostrar a senha. Mostra a senha no campo de senha.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void picShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = (char)0;
        }

        /// <summary>
        /// Manipula o evento MouseUp do ícone para mostrar a senha. Oculta a senha no campo de senha.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void picShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }

        /// <summary>
        /// Manipula o evento KeyPress do campo de nome de usuário. Oculta a mensagem de erro.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblError.Visible = false;
        }

        /// <summary>
        /// Manipula o evento KeyPress do campo de senha. Oculta a mensagem de erro.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblError.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
