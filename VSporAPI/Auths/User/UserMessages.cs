
namespace VSpor.Auths.User
{
   public static class UserMessages
    {
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string PasswordOrUserNameError = "Hatalı Kullanıcı Adı/Şifre";
        public static string UserNoAuthorisation = "Yetkisiz Kullanıcı.Lütfen yetki talep ediniz";
        public static string UserTableNoAuthorisation = "Yetkisiz Kullanıcı. Lütfen yetki talep ediniz";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string PasswordEmpty = "Şifre boş olamaz.";
        public static string PasswordLength = "Şifre uzunluğu geçersiz.";
        public static string PasswordUppercaseLetter => "Şifre en az bir adet büyük karakter içermelidir.";
        public static string PasswordLowercaseLetter => "Şifre en az bir adet küçük karakter içermelidir.";
        public static string PasswordDigit => "Şifre en az bir adet rakam içermelidir.";
        public static string PasswordSpecialCharacter => "Şifre en az bir adet özel karakter içermelidir.";
    }
}
