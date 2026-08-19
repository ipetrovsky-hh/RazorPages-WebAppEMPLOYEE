namespace WebAppEMPLOYEE.Models
{
    public class EmployeeModel
    {
        public string LastName {  get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string WorkPlace { get; set; }

        public EmployeeModel(string lastName, 
            string name, 
            string middleName, 
            string workPlace)
        {
            this.LastName = lastName;
            this.Name = name;
            this.MiddleName = middleName;
            this.WorkPlace = workPlace;
        }
    }
}