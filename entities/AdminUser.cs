namespace M11_PROJETOFINAL.entities
{
    public class AdminUser : User
    {
        /// <summary>
        /// Classe herdeira de User. Possui as tabs a qual o username «admin» possui acesso.
        /// </summary>
        public AdminUser() : base(FormInicial.INSTANCE.tabInicio, FormInicial.INSTANCE.tabCompra_Venda, FormInicial.INSTANCE.tabHistorico,
            FormInicial.INSTANCE.tabManu, FormInicial.INSTANCE.tabEmManu, FormInicial.INSTANCE.tabDistribuidores) =>
            Nome = "Admin";
    }
}
