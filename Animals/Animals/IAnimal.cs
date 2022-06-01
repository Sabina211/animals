using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public interface IAnimal
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Family { get; set; }
        string Population { get; set; }
        string Place { get; set; }

    }
}
