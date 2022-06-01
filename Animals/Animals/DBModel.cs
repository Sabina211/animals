using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Animals
{
    class DBModel
    {
        public List<IAnimal> Animals { get; set; }
        public MSSqlConnection Connection { get; set; }
        public AnimalsContext AnimalsContext { get; set; }
        public DBModel()
        {
            Animals = new List<IAnimal>();
            AnimalsContext = new AnimalsContext();
            Connection = new MSSqlConnection();
        }

        public List<IAnimal> GetAnimals()
        {
            Animals.Clear();
            Animals.AddRange(AnimalsContext.Mammals.ToList());
            Animals.AddRange(AnimalsContext.Amphibians.ToList());
            Animals.AddRange(AnimalsContext.Birds.ToList());
            return Animals;
        }

        public void SaveAnimal(IAnimal animal)
        {
            using (Connection.Connection)
            {
                try
                {
                    Type className = animal.GetType();
                    switch (className.Name)
                    {
                        case "Mammal":
                            AnimalsContext.Mammals.Add((Mammal)animal);
                            break;
                        case "Amphibian":
                            AnimalsContext.Amphibians.Add((Amphibian)animal);
                            break;
                        case "Bird":
                            AnimalsContext.Birds.Add((Bird)animal);
                            break;
                        default:
                            MessageBox.Show("ошибка с сохранением, тип не определен");
                            break;
                    }
                    AnimalsContext.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }
        
    }
        public void EditAnimal(IAnimal animal)
        {
            using (Connection.Connection)
            {
                try
                {
                    Type className = animal.GetType();
                    switch (className.Name)
                    {
                        case "Mammal":
                           // AnimalsContext.Mammals.Add((Mammal)animal);
                            IAnimal neededRow = AnimalsContext.Mammals.Where(x=> x.Id==animal.Id).FirstOrDefault();
                            if (neededRow != null)
                            {
                                neededRow.Name = animal.Name;
                                neededRow.Family = animal.Family;
                                neededRow.Population = animal.Population;
                                neededRow.Place = animal.Place;
                            }
                            else
                            {
                                AnimalsContext.Mammals.Add((Mammal)animal);
                                DeletePreviousRow(animal);
                            }
                            break;
                        case "Amphibian":
                            neededRow = AnimalsContext.Amphibians.Where(x => x.Id == animal.Id).FirstOrDefault();
                            if (neededRow != null)
                            {
                                neededRow.Name = animal.Name;
                                neededRow.Family = animal.Family;
                                neededRow.Population = animal.Population;
                                neededRow.Place = animal.Place;
                            }
                            else
                            {
                                AnimalsContext.Amphibians.Add((Amphibian)animal);
                                DeletePreviousRow(animal);
                            }
                            break;
                        case "Bird":
                            neededRow = AnimalsContext.Birds.Where(x => x.Id == animal.Id).FirstOrDefault();
                            if (neededRow != null)
                            {
                                neededRow.Name = animal.Name;
                                neededRow.Family = animal.Family;
                                neededRow.Population = animal.Population;
                                neededRow.Place = animal.Place;
                            }
                            else
                            {
                                AnimalsContext.Birds.Add((Bird)animal);
                                DeletePreviousRow(animal);
                            }
                            break;
                        default:
                            MessageBox.Show("ошибка с сохранением, тип не определен");
                            break;
                    }
                    AnimalsContext.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }

        }
    
        public void DeletePreviousRow(IAnimal animal)
        {
            IAnimal neededMammal = AnimalsContext.Mammals.Where(x => x.Id == animal.Id).FirstOrDefault();
            IAnimal neededAmphibian = AnimalsContext.Amphibians.Where(x => x.Id == animal.Id).FirstOrDefault();
            IAnimal neededBird = AnimalsContext.Birds.Where(x => x.Id == animal.Id).FirstOrDefault();
            if (neededMammal != null) AnimalsContext.Mammals.Remove((Mammal)neededMammal);
            if (neededAmphibian != null) AnimalsContext.Amphibians.Remove((Amphibian)neededAmphibian);
            if (neededBird != null) AnimalsContext.Birds.Remove((Bird)neededBird);
            AnimalsContext.SaveChanges();
        }
    }
} 
