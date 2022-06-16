using System.Text.Json.Serialization;

namespace VSpor.Auths
{
    public class Account
    {
        public int Id { get; set; }
        public string PersonelId { get; set; }
        public string UserName { get; set; }
        public string AdSoyad { get; set; }
        public bool Aktif { get; set; }
        public string Bolge { get; set; }
        public string Sube { get; set; }
        public short KullaniciTipi { get; set; }
        public string Rol { get; set; }
        public List<Roles> Roles { get; set; } = new List<Roles>();
    }
    public class Roles
    {
        public int RolId { get; set; }
        public string KullaniciId { get; set; }
        public string Name { get; set; }
    }
}
