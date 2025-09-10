namespace EmployeeVacation.Models
{
    public class HourlyEmployee : Employee
    {
        // Hourly employees accumulate 10 vacation days during the work year.
        public override float VacationDaysPerYear => 10f;
        public HourlyEmployee(string name) : base(name) { }
    }
}
