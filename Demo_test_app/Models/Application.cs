namespace Demo_test_app.Models
{
    public class Application
    {
        public int Id { get; set; }
        public DateOnly DateAddition { get; set; }
        public string NameEquipment { get; set; }
        public int TypeProblemId { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public string NameClient {  get; set; }
        public decimal Cost { get; set; }
        public DateOnly DateEnd { get; set; }
        public TimeOnly TimeWork { get; set; }
        public int EmployeeId { get; set; }
        public string WorkStatus { get; set; }
        public DateOnly PeriodExecution { get; set; }
        public int TypeEquipmentId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
    }
}
