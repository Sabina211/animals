using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Amphibian : IAnimal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Population { get; set; }
        public string Place { get; set; }

        public Amphibian()
        { }

        public Amphibian(string Name, string Family, string Population, string Place)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Family = Family;
            this.Population = Population;
            this.Place = Place;
        }
        public Amphibian(Guid Id, string Name, string Family, string Population, string Place)
        {

            this.Id = Id;
            this.Name = Name;
            this.Family = Family;
            this.Population = Population;
            this.Place = Place;
        }

    }
}
