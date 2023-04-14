using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M11_PROJETOFINAL.entities
{
    public class EmployeeUser : User
    {

        public EmployeeUser() : base(FormInicial.INSTANCE.tabInicio, FormInicial.INSTANCE.tabCompra_Venda, FormInicial.INSTANCE.tabHistorico) =>
            Nome = "Employee";

    }
}
