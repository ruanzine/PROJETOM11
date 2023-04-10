using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11_PROJETOFINAL.scripts
{
    public class Login : DadosUteis
    {
        private const string path = "Data.txt";

        private FormInicial frm = new FormInicial();
        public static void ValidateLogin(string Nome, string Password)
        {
            foreach(string s in FileToList(path))
            {
                string[] data = s.Split(':');
                if (data[0] == Nome)
                {
                    if (data[1] == Password) 
                    {
                        if (data[2] == "Admin") new AdminUser(frm.tabInicio, frm.tabCompra_Venda, frm.tabHistorico, frm.tabManu, frm.tabEmManu, frm.tabDistribuidores).FillTabs();
                        if (data[2] == "Employee") new EmployeeControls().Employee();
                    }
                }
            }
            

        }
    }
}
