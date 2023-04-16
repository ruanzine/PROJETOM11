using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace M11_PROJETOFINAL.entities
{
    public abstract class User
    {

        public string Nome { get; set; }

        public List<TabPage> Tabs { get; set; }

        public User(params TabPage[] allowedTabs) => Tabs = allowedTabs.ToList<TabPage>();

        /// <summary>
        /// Limpa todas as tabs dentor do TabControl e adiciona todas as presentes na propriedade Tabs
        /// </summary>
        public virtual void FillTabs()
        {
            FormInicial.INSTANCE.TabGeral.TabPages.Clear();
            Tabs.ForEach(FormInicial.INSTANCE.TabGeral.TabPages.Add);

        }


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
