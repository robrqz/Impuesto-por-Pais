using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cálculo_de_impuestos_por_usuario.User
{
    public class UserEntity
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected string Country { get; set; }
        protected decimal lastAmount { get; set; }

        public string name => Name;
        public int id => Id;
        public string country => Country;
        public decimal LastAmount => lastAmount;
        public UserEntity(string name, string country, decimal LastAmount)
        {
            Name = name;
            Country = country;
            lastAmount = LastAmount;
        }
        public void SetId(int id)
        {
            Id = id;
        }

    }
}
