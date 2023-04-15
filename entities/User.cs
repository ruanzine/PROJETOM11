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
            string[] credentials = new string[2];

            string fileName = Nome + ".txt";

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                if (lines.Length >= 2)
                {
                    credentials[0] = lines[0];
                    credentials[1] = lines[1];
                }
            }
            else
            {
                credentials = null;
            }
            return credentials;
        }
    }
}
