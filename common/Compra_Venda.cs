using System.Collections.Generic;

namespace M11_PROJETOFINAL.common
{
    public class Compra_Venda : Registos
    {
        /// <summary>
        /// Classe Compra_Venda herdeira da classe Registos
        /// </summary>

        public string Tipo { get; set; }
        public string Marca { get; set; }

        public class Lista
        {
            public static List<Compra_Venda> Lista_CompraVenda = new List<Compra_Venda>();

        }


    }
}
