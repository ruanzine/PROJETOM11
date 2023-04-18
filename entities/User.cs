using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace M11_PROJETOFINAL.entities
{
    /// <summary>
    /// Representa um usuário do sistema com propriedades como nome e lista de Tabs permitidas.
    /// </summary>
    public abstract class User
    {
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define a lista de Tabs permitidas para o usuário.
        /// </summary>
        public List<TabPage> Tabs { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe User com uma ou mais tabs permitidas.
        /// </summary>
        /// <param name="allowedTabs">Uma ou mais TabPages permitidas para o usuário.</param>
        public User(params TabPage[] allowedTabs) => Tabs = allowedTabs.ToList<TabPage>();

        /// <summary>
        /// Limpa todas as tabs dentor do TabControl e adiciona todas as presentes na propriedade Tabs
        /// </summary>
        public virtual void FillTabs()
        {
            FormInicial.INSTANCE.TabGeral.TabPages.Clear();
            Tabs.ForEach(FormInicial.INSTANCE.TabGeral.TabPages.Add);

        }

        /// <summary>
        /// Obtém as credenciais do usuário armazenadas em um arquivo txt, sendo a primeira linha o nome de usuário e a segunda linha a senha.
        /// </summary>
        /// <returns>Um array com as credenciais, sendo a primeira posição o nome de usuário e a segunda posição a senha. 
        /// Caso o arquivo não exista, retorna null.</returns>
        public string[] GetCredentials()
        {
            string[] credenciais = new string[2];

            string nomeArquivo = Nome + ".txt";

            if (File.Exists(nomeArquivo))
            {
                string[] lines = File.ReadAllLines(nomeArquivo);

                if (lines.Length >= 2)
                {
                    credenciais[0] = lines[0];
                    credenciais[1] = lines[1];
                }
            }
            else
            {
                credenciais = null;
            }
            return credenciais;
        }
    }
}
