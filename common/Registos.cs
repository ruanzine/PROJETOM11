using System;

namespace M11_PROJETOFINAL.common
{

    [Serializable]
    /// <summary>
    /// Classe Registos
    /// Possui as classes herdeiras Manutencoes e Compra_Venda
    /// </summary>
    public class Registos
    {
        public string Preco { get; set; }
        public string Nome { get; set; }
        public string Tel { get; set; }
        public string Instrumento { get; set; }

    }
}
