using System;
using WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class Person
    {
        public Person()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public ColorEnum Color { get; set; }

        public override string ToString()
        {
            return string.Concat(Name, " ", LastName).Trim();
        }
    }
}
