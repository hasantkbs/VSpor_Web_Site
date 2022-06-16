namespace VSporAPI.Models.Entity
{
    public class LocationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public float SearchVolume { get; set; }
        public float IsActive { get; set; }
        public float ParentCategoryId { get; set; }
        public float IsHoliday { get; set; }
        public float IsImportant { get; set; }
        public float IsLink { get; set; }
        public float Level { get; set; }
        public float LocLevel1 { get; set; }
        public float LocLevel2 { get; set; }
        public string LocLevel3 { get; set; }
        public string LocLevel4 { get; set; }
        public string LocLevel5 { get; set; }


    }
}
