using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DO
{
    public class Person
    {
        private int Id { get; set; } = 10;

        protected string Address { get; set; }
        public string Email { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }

        public Person(string _firstName, string _lastname)
        {
            firstName = _firstName;
            lastName = _lastname;
        }
        public int GetId()
        {
            return Id;
        }

        public string GetFullName()
        {
            return firstName + lastName;
        }
    }
}
