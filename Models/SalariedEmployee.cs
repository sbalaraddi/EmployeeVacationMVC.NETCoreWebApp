using System;

namespace EmployeeVacation.Models
{
    public class SalariedEmployee : Employee
    {
        // Salaried employees accumulate 15 vacation days during the work year.
        public override float VacationDaysPerYear => 15f;
        public SalariedEmployee(string name) : base(name) { }
    }
}
