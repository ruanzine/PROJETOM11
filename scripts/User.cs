using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace M11_PROJETOFINAL.scripts
{
    public abstract class User
    {
        public string Nome { get; }

        public List<TabPage> Tabs { get; set; }

        public virtual void FillTabs()
        {
            Tabs = new List<TabPage>();
        }
        public string[] GetCredentials()
        {
            string[] credentials = new string[2];

            string fileName = Nome + ".txt";

            if (File.Exists(fileName){
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
