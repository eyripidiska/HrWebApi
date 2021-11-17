using Application.Errors;
using Application.Interfaces;
using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;
        public PersonService(DataContext context)
        {
            _context = context;
        }

        public bool DeletePerson(int id)
        {
            Person person = _context.persons.Find(id);
            if (person == null)
                throw new RestException(HttpStatusCode.NotFound, "Πρόβλημα στη διαγραφή");

            _context.persons.Remove(person);

            var success = _context.SaveChanges() > 0;

            if (success) return true;

            throw new Exception("Πρόβλημα στη διαγραφή");
        }

        public List<Person> GetListPerson()
        {
            List<Person> listPerson = _context.persons.ToList();

            return listPerson;
        }

        public Person GetPerson(int id)
        {
            Person person = _context.persons.Find(id);

            if (person == null)
                throw new RestException(HttpStatusCode.NotFound, "Δεν βρέθηκε το συγκεκριμένο άτομο");

            return person;
        }

        public Person InsertPerson(Person person)
        {
            _context.persons.Add(person);

            var success = _context.SaveChanges() > 0;

            if (success) return person;

            throw new Exception("Πρόβλημα στην αποθήκευση");
        }

        public Person UpdatePerson(Person person)
        {
            _context.persons.Update(person);

            var success = _context.SaveChanges() > 0;

            if (success) return person;

            throw new Exception("Πρόβλημα στην αποθήκευση");
        }
    }
}
