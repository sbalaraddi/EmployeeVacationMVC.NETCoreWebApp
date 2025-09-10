namespace EmployeeVacation.Models
{
    public class Manager: SalariedEmployee
    {
        // Managers accumulate 30 vacation days during the work year.
        public override float VacationDaysPerYear => 30f;
        public Manager(string name): base(name) { }
    }
}
