using System.Collections.Generic;
using System.Linq;

namespace M11_PROJETOFINAL.entities
{
    /// <summary>
    /// Esta classe factory tem o objetivo de prover o classe do Usuárop correta baseado num username dado
    /// </summary>
    internal class EntityFactory
    {

        /// <summary>
        /// The dictionary responsible for holding all the usernames mapped to their respective user classes.
        /// Esse dicionário é responsável por guardar todos os usernames mapeados para suas classes respetivas.
        /// </summary>
        public Dictionary<string, User> EntityUserMapping { get; set; } = new Dictionary<string, User>()
        {
            { "admin", new AdminUser() },
            { "employee", new EmployeeUser() }
        };

        /// <summary>
        /// Acessa o mapa EntityUserMapping e retorna a classe Entity que está conectada ao username provido.
        /// Se não é encontrado, retorna null.
        /// </summary> 
        /// <param name="username">O username para encontrar a classe</param>
        /// <returns>Classe conectada ao username</returns>
        public User GetUserClass(string username) =>
            EntityUserMapping.Keys.ToList().Contains(username.ToLower()) ? EntityUserMapping[username.ToLower()] : null;

    }
}
