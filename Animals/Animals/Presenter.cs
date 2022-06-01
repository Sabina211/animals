using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;

namespace Animals
{
    class Presenter
    {
        private DBModel Model;
        private IView View;
        public ObservableCollection<Animal> AnimalsList;
        private string csvFileName = "AllAnimals.csv";
        private string txtFileName = "AllAnimals.txt";


        public Presenter(IView View)
        {
            this.View = View;
            Model = new DBModel();
            View.Animals = GetAnimals();
            var classes = GetAnimalsClasses();
            View.AddClass = classes;
            View.EditClass = classes;

        }

        public void AddAnimal()
        {
            string className = View.SelectedAddClass;
            string name = View.AddName;
            string family = View.AddFamily;
            string population = View.AddPopulation;
            string place = View.AddPlace;
            //Type testClass = Type.GetType($"Animals.{className}");
            if (className != null & name != null & name != "" & className!= "")
            {
                IAnimal newAnimal = AnimalFactory.GetAnimal($"{className}", $"{name}",
                $"{family}", $"{population}", $"{place}");
                Model.SaveAnimal(newAnimal);
                MessageBox.Show($"Животное \"{name}\" сохранено");
                View.AddName = "";
                View.AddFamily = "";
                View.AddPopulation = "";
                View.AddPlace = "";
            }
            else 
            { 
                MessageBox.Show($"Необходимо заполнить обязательные поля");
                return;
            }
            View.Animals = GetAnimals();
        }

        public void EditAnimal()
        {
            if (View.SelectedEditClass != null & View.EditName != null & View.EditName != "" & View.SelectedEditClass.ToString() != "")
            {
                var selectedRow = (Animal)View.SelectedAnimal;
                Guid selectedAnimalId = selectedRow.AnimalObject.Id;
                IAnimal newAnimal = AnimalFactory.GetAnimal($"{View.SelectedEditClass}", selectedAnimalId, $"{View.EditName}",
                $"{View.EditFamily}", $"{View.EditPopulation}", $"{View.EditPlace}");
                
                Model.EditAnimal(newAnimal);
                MessageBox.Show($"Животное \"{View.EditName }\" изменено");
                View.EditName = "";
                View.EditFamily = "";
                View.EditPopulation = "";
                View.EditPlace = "";
            }
            else
            {
                MessageBox.Show($"Необходимо заполнить обязательные поля");
                return;
            }
            View.Animals = GetAnimals();
        }

        public void DeleteAnimal()
        {
            MessageBoxResult messagebox = MessageBox.Show($"Вы уверены, что хотите удалить животное \"{View.EditName }\"?",
                "Подтверждение операции", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (messagebox == MessageBoxResult.Yes)
            {
                if (View.SelectedAnimal != null)
                {
                    Model.DeletePreviousRow(((Animal)View.SelectedAnimal).AnimalObject);
                }
                MessageBox.Show($"Запись \"{View.EditName}\" удалена") ;
                View.Animals = GetAnimals();
            }
        }

        public void DownloadCsv()
        {
            if (File.Exists(csvFileName))
            {
                File.Delete(csvFileName);
            }   
            StreamWriter streamWriter = new StreamWriter(csvFileName, true, Encoding.Unicode);
            using (streamWriter)
            {
                streamWriter.Write($"Id\tКласс\tНазвание\tОтряд/семейство\tПопуляция\tМесто обитания\n");
                for (int i = 0; i < AnimalsList.Count; i++)
                {
                    streamWriter.WriteLine($"{AnimalsList[i].AnimalObject.Id}" +
                        $"\t{AnimalsList[i].Class}\t{AnimalsList[i].AnimalObject.Name}" +
                        $"\t{AnimalsList[i].AnimalObject.Family}\t{AnimalsList[i].AnimalObject.Population}" +
                        $"\t{AnimalsList[i].AnimalObject.Place}\t");
                }
            }
            MessageBox.Show($"Данные животных сохранены в папке проекта \\bin\\Debug в файл \"{csvFileName}\"");
        }

        public void DownloadTxt()
        {
            if (File.Exists(txtFileName))
            {
                File.Delete(txtFileName);
            }
            StreamWriter streamWriter = new StreamWriter(txtFileName, true, Encoding.Unicode);
            using (streamWriter)
            {
                for (int i = 0; i < AnimalsList.Count; i++)
                {
                    streamWriter.WriteLine($"{AnimalsList[i].AnimalObject.Id}" +
                        $"\t{AnimalsList[i].Class}\t{AnimalsList[i].AnimalObject.Name}" +
                        $"\t{AnimalsList[i].AnimalObject.Family}\t{AnimalsList[i].AnimalObject.Population}" +
                        $"\t{AnimalsList[i].AnimalObject.Place}\t");
                }
            }
            MessageBox.Show($"Данные животных сохранены в папке проекта \\bin\\Debug в файл \"{txtFileName}\"");
        }

        public List<string> GetAnimalsClasses()
        {
            Mammal animal = new Mammal();
            IEnumerable<Type> typesInTheAssembly;
            typesInTheAssembly = animal.GetType().Assembly.GetTypes();
            var implementedInterface = typeof(IAnimal);
            IList<Type> classesImplementingInterface = new List<Type>();
            if (implementedInterface.IsGenericType)
            {
                foreach (var typeInTheAssembly in typesInTheAssembly)
                {
                    if (typeInTheAssembly.IsClass)
                    {
                        var typeInterfaces = typeInTheAssembly.GetInterfaces();
                        foreach (var typeInterface in typeInterfaces)
                        {
                            if (typeInterface.IsGenericType)
                            {
                                var typeGenericInterface = typeInterface.GetGenericTypeDefinition();
                                var implementedGenericInterface = implementedInterface.GetGenericTypeDefinition();

                                if (typeGenericInterface == implementedGenericInterface)
                                {
                                    classesImplementingInterface.Add(typeInTheAssembly);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var typeInTheAssembly in typesInTheAssembly)
                {
                    if (typeInTheAssembly.IsClass)
                    {
                        // if the interface is a non-generic interface
                        if (implementedInterface.IsAssignableFrom(typeInTheAssembly))
                        {
                            classesImplementingInterface.Add(typeInTheAssembly);
                        }
                    }
                }
            }

            List<string> classesNames = new List<string>();
            foreach (var item in classesImplementingInterface)
            {
                if (item.Name != "NullAnimal") classesNames.Add(item.Name);
            }
            return classesNames;


        }
        public ObservableCollection<Animal> GetAnimals()
        {
            AnimalsList = new ObservableCollection<Animal>();
            var animalsList = Model.GetAnimals();
            for (int i = 0; i < animalsList.Count; i++)
            {
                switch (animalsList[i].GetType().Name)
                {
                    case "Mammal":
                        var mammal = new Mammal(
                   animalsList[i].Id,
                   animalsList[i].Name,
                   animalsList[i].Family,
                   animalsList[i].Population,
                   animalsList[i].Place);
                        AnimalsList.Add(new Animal(mammal, "Млекопитающее"));
                        break;
                    case "Bird":
                        AnimalsList.Add(new Animal(new Bird(
                  animalsList[i].Id,
                  animalsList[i].Name,
                  animalsList[i].Family,
                  animalsList[i].Population,
                  animalsList[i].Place
                  ), "Птицы"));
                        break;
                    case "Amphibian":
                        AnimalsList.Add(new Animal(new Amphibian(
                  animalsList[i].Id,
                  animalsList[i].Name,
                  animalsList[i].Family,
                  animalsList[i].Population,
                  animalsList[i].Place
                ), "Земноводные"));
                        break;
                    default:
                        AnimalsList.Add(new Animal(new NullAnimal(), "Не определено"));
                        break;
                }
               
            }
            return AnimalsList;
        }
        public void PrefillFields()
        {
            if (View.SelectedAnimal.ToString() != "{NewItemPlaceholder}")
            {
                var selectedRow = (Animal)View.SelectedAnimal;
                View.EditName = selectedRow.AnimalObject.Name;
                View.EditFamily = selectedRow.AnimalObject.Family;
                View.EditPopulation = selectedRow.AnimalObject.Population;
                View.EditPlace = selectedRow.AnimalObject.Place;
                View.SelectedEditClass = selectedRow.AnimalObject.GetType().Name;

                View.DeleteLable = $"Удалить животное \"{selectedRow.AnimalObject.Name}\" класса {selectedRow.Class}?";
            }
        }
    }
}
