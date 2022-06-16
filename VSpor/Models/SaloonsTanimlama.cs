namespace VSporMVC.Models
{
    public class SaloonsTanimlama
    {
        public int Id { get; set; }
        public int BussinessId { get; set; }
        public int SaloonTypeId { get; set; }
        public string M2 { get; set; }
        public List<SaloonTanimlama> List { get; set; }
    }
    public class SaloonTanimlama
    {
        public int Id { get; set; }
        public int BussinessId { get; set; }
        public int SaloonTypeId { get; set; }
        public string M2 { get; set; }
    }
}
