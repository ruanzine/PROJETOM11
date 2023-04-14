using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M11_PROJETOFINAL.entities
{
    public class AdminUser : User
    {
        public AdminUser() : base(FormInicial.INSTANCE.tabInicio, FormInicial.INSTANCE.tabCompra_Venda, FormInicial.INSTANCE.tabHistorico,
            FormInicial.INSTANCE.tabManu, FormInicial.INSTANCE.tabEmManu, FormInicial.INSTANCE.tabDistribuidores) => 
            Nome = "Admin";
    }
}
