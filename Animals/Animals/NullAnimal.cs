using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class NullAnimal : IAnimal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Population { get; set; }
        public string Place { get; set; }
        public NullAnimal()
        {
            this.Name = "UndefinedName";
            this.Family = "UndefinedFamily";
            this.Population = "Undefined";
            this.Place = "Undefined";
        }
    }
}
