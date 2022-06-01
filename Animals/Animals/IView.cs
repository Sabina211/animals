using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    interface IView
    {
        ObservableCollection<Animal> Animals { set; }
        List<string> AddClass { get; set; }
        string SelectedAddClass { get; }
        string AddName { get; set; }
        string AddFamily { get; set; }
        string AddPopulation { get; set; }
        string AddPlace { get; set; }

        List<string> EditClass { get; set; }
        object SelectedEditClass { get; set; }
        string EditName { get; set; }
        string EditFamily { get; set; }
        string EditPopulation { get; set; }
        string EditPlace { get; set; }
        object SelectedAnimal { get; }

        string DeleteLable { set; }

    }
}
