namespace VSporMVC.Models
{
    public class WorkersTanimlama 
    {
        public int Id { get; set; }
        public string TCNo { get; set; }
        public string PassportNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cv { get; set; }
        public int BusinessId { get; set; }
        public string OpenAddress { get; set; }
       
        public List<WorkersTanimlamaList> List { get; set; }
    }

    public class WorkersTanimlamaList
    {
        public int Id { get; set; }
        public string TCNo { get; set; }
        public string PassportNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cv { get; set; }
        public int BusinessId { get; set; }
        public string OpenAddress { get; set; }
      
    }
}
