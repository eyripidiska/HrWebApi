using Application.Interfaces;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet]
        public List<Person> GetAll()
        {
            var persons = _personService.GetListPerson();

            return persons;
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            var person = _personService.GetPerson(id);

            return person;
        }

        [HttpPost]
        public Person Add([FromBody] Person person)
        {
            person = _personService.InsertPerson(person);

            return person;
        }

       [HttpPut]
       public Person Put([FromBody] Person person)
        {
            person = _personService.UpdatePerson(person);

            return person;
        }

        [HttpDelete]
        public bool Dellete(int Id)
        {
            return _personService.DeletePerson(Id);
        }
    }
}
