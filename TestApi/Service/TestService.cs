using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApi.Models;

namespace TestApi.Service
{
    public interface ITestService
    {
        List<PersonsModel> GetValue();

        void AddPerson(PersonsModel req);
    }

    public class TestService : ITestService
    {
        private TestApi01Context _ctx;
        public TestService()
        {
            _ctx = new TestApi01Context();
        }

        public List<PersonsModel> GetValue ()
        {
            var results = _ctx.Persons.ToList();

            return results;
        }

        public void AddPerson(PersonsModel req)
        {
            PersonsModel newReq = new PersonsModel()
            {
                PersonID = req.PersonID,
                Address = req.Address,
                City = req.City,
                FirstName = req.FirstName,
                LastName = req.LastName
            };
            _ctx.Persons.Add(newReq);
            _ctx.SaveChanges();
        }
    }
}