using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IPeople
    {
        List<Person> EveryOne { get; }
        Task Add(Person person);
    }
}
