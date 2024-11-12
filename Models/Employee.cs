namespace Task.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string City { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
