using CursoUnitTesting.API.Models;
using CursoUnitTesting.API.Services.Interfaces;
using CursoUnitTesting.Business.Entities;
using CursoUnitTesting.Business.Interfaces;
using System;

namespace CursoUnitTesting.API.Services
{

    public class EmployeeService
    {
        public static string GetFullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name must be provided.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name must be provided.");
            }

            return $"{firstName.Trim()} {lastName.Trim()}".Trim();
        }

    }
}
