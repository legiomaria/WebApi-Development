namespace Demo.Models
{
    public class Course
    {
        public Guid Id { set; get; }
        public string? Name { set; get; }
        public string? Code { set; get; }
        public int DepartmentId { set; get; }
    }
}