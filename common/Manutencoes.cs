using System.Collections.Generic;

namespace M11_PROJETOFINAL.common
{
    public class Manutencoes : Registos
    {

        /// <summary>
        /// Classe Manutencoes herdeira da classe Registos
        /// </summary>
        public string Defeito { get; set; }
        public string Descricao { get; set; }
        public class Lista
        {
            public static List<Manutencoes> Lista_Manu = new List<Manutencoes>();
        }
    }
}
