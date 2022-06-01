namespace Animals
{
    public class Animal
    {
        public IAnimal AnimalObject { get; set; }
        public string Class { get; set; }
        public Animal()
        { }
        public Animal(IAnimal AnimalObject, string Class)
        {
            this.AnimalObject = AnimalObject;
            this.Class = Class;
        }

    }
}
