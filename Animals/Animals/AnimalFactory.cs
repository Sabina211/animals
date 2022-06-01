using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    static class AnimalFactory
    {
        public static IAnimal GetAnimal(
            string AnimalClass, 
            string Name, 
            string Family, 
            string Population, 
            string Place)
        {
            switch (AnimalClass)
            {
                case "Amphibian": return new Amphibian(Name, Family, Population, Place);
                case "Mammal": return new Mammal(Name, Family, Population, Place);
                case "Bird": return new Bird(Name, Family, Population, Place);
                default: return new NullAnimal();       
            }
        }

        public static IAnimal GetAnimal(
           string AnimalClass,
           Guid Id,
           string Name,
           string Family,
           string Population,
           string Place)
        {
            switch (AnimalClass)
            {
                case "Amphibian": return new Amphibian(Id, Name, Family, Population, Place);
                case "Mammal": return new Mammal(Id, Name, Family, Population, Place);
                case "Bird": return new Bird(Id, Name, Family, Population, Place);
                default: return new NullAnimal();
            }
        }
    }
}
