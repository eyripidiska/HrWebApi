using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Person GetPerson(int id);
        List<Person> GetListPerson();
        Person InsertPerson(Person person);
        Person UpdatePerson(Person person);
        bool DeletePerson(int id);
    }
}
