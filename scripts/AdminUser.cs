using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M11_PROJETOFINAL.scripts
{
    public class AdminUser : User
    {
        private TabPage tabInicio;
        private TabPage tabCompra_Venda;
        private TabPage tabHistorico;
        private TabPage tabManu;
        private TabPage tabEmManu;
        private TabPage tabDistribuidores;

        public AdminUser (TabPage tabInicio, TabPage tabCompra_Venda, TabPage tabHistorico, TabPage tabManu,
            TabPage tabEmManu, TabPage tabDistribuidores)
        {
            this.tabInicio = tabInicio;
            this.tabCompra_Venda = tabCompra_Venda;
            this.tabHistorico = tabHistorico;
            this.tabManu = tabManu;
            this.tabEmManu = tabEmManu;
            this.tabDistribuidores = tabDistribuidores;
        }
        
        public override void FillTabs()
        {
            Tabs = new List<TabPage>
            {
                tabInicio,
                tabCompra_Venda,
                tabHistorico,
                tabManu,
                tabEmManu,
                tabDistribuidores
            };
        }
    }
}
