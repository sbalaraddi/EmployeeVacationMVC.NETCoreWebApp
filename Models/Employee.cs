namespace EmployeeVacation.Models
{
    public abstract class Employee
    {
        private float vacationDaysUsed;
        private int totalDaysWorked;
        private const int WorkYearDays = 260;

        public string Name { get; set; }
        public abstract float VacationDaysPerYear { get; }

        public int TotalDaysWorked => totalDaysWorked;
        public float VacationDaysAccumulated
        {
            get
            {
                // Calculate accumulated vacation so far, depending on the days worked
                float earned = (totalDaysWorked / (float)WorkYearDays) * VacationDaysPerYear;
                return earned - vacationDaysUsed;
            }
        }

        protected Employee(string name)
        {
            Name = name;
            vacationDaysUsed = 0;
            totalDaysWorked = 0;
        }

        /// <summary>
        /// Employee Work() method that takes a single integer parameter that defines the number of days worked which should be a value between 0 and 260. 
        /// When this method is called, the total days worked is updated and hence the number of vacation days accumulated.
        /// An employee cannot work more than the number of workdays in a work year
        /// </summary>
        /// <param name="days"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Work(int days)
        {
            if (days < 0 || days > WorkYearDays)
                throw new ArgumentException("Days worked must be between 0 to 260.");

            if (totalDaysWorked + days > WorkYearDays)
                throw new InvalidOperationException("Employee cannot work more than 260 days in the given calender year.");

            totalDaysWorked += days;
        }

        /// <summary>
        /// Employee TakeVacation() method that takes a single floating-point parameter that defines the number of vacation days used.
        /// When this method is called, the total vacation days used calculated and hence the number of vaction days accumulated.
        /// </summary>
        /// <param name="days"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void TakeVacation(float days)
        {
            if (days < 0) throw new ArgumentException("Vacation days cannot be negative.");

            // An employee cannot take more vacation than is available.
            if (days > VacationDaysAccumulated) throw new InvalidOperationException("Sorry! Not enough vacation days available");

            if (vacationDaysUsed + days < 0)
                throw new InvalidOperationException("Vacation days cannot go below 0.");

            vacationDaysUsed += days;
        }
    }
}
