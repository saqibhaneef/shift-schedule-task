namespace scheduling.Models
{
    public class ShiftDto
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public int Type { get; set; }
        public string Date { get; set; }
    }
}
