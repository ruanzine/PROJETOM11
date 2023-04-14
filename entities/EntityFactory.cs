using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11_PROJETOFINAL.entities
{
    /// <summary>
    /// This factory class aims to provide the correct user class based on a given username.
    /// </summary>
    internal class EntityFactory
    {

        /// <summary>
        /// The dictionary responsible for holding all the usernames mapped to their respective user classes.
        /// </summary>
        public Dictionary<string, User> EntityUserMapping { get; set; } = new Dictionary<string, User>()
        {
            { "admin", new AdminUser() },
            { "employee", new EmployeeUser() }
        };

        /// <summary>
        /// Acesses the EntityUserMapping map and returns the entity class matching the username provided. If it isn't found,
        /// return null.
        /// </summary>
        /// <param name="username">The username to find the matching class for.</param>
        /// <returns>The user class matching the username</returns>
        public User GetUserClass(string username) => 
            EntityUserMapping.Keys.ToList().Contains(username.ToLower()) ? EntityUserMapping[username.ToLower()] : null;

    }
}
