namespace M11_PROJETOFINAL.entities
{
    public class EmployeeUser : User
    {
        /// <summary>
        /// Classe herdeira de User. Possui as tabs a qual o username «employee» possui acesso.
        /// </summary>
        public EmployeeUser() : base(FormInicial.INSTANCE.tabInicio, FormInicial.INSTANCE.tabCompra_Venda, FormInicial.INSTANCE.tabHistorico) =>
            Nome = "Employee";

    }
}
