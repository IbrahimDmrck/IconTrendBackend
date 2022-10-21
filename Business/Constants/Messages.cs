using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string Announced="Duyuru eklendi";
        public static string AnnounceDeleted="Duyuru silindi";
        public static string AnnounceUpdated="Duyuru Güncellendi";
        public static string AnnouncesListed="duyurular listelendi";
        public static string AnnouncementListed="Duyuru Listelendi";


        public static string CongressAdded="Kongre oluşturuldu";
        public static string CongressDeleted="Kongre Silindi";
        public static string CongressUpdated="Kongre Güncellendi";
        public static string CongressesListed="Kongreler Listelendi";
        public static string CongressIsListed="Kongre Listelendi";


        public static string PaperIsAdded="Makale eklendi";
        public static string PaperIsDeleted="Makale silindi";
        public static string PapersListed="Makaleler listelndi";
        public static string PaperIsUpdated="Makale güncellendi";
        public static string PaperIsListed="Makale Listelendi";


        public static string TopicIsAdded="Başlık Eklendi";
        public static string TopicIsDeleted="Başlık Silindi";
        public static string TopicIsUpdated="Başlık Güncellendi";
        public static string TopicIsListed="Başlık Listelendi";
        public static string TopicsListed="Başlıklar Listelendi";


        public static string TransportLayoverIsAdded="Ulaşım ve konaklama bilgisi eklendi";
        public static string TransportLayoverIsDeleted="Ulaşım ve konaklama bilgisi silindi";
        public static string TransportLayoverIsUpdated="Ulaşım ve konaklama bilgisi güncellendi";
        public static string TransportLayoversListed="Ulaşım ve konaklama bilgileri listelendi";
        public static string TransportLayoverIsListed="Ulaşım ve konaklama bilgisi listelendi";


        public static string CongressImagesListed="Kongre görselleri listelendi";
        public static string GetDefaultImage="Herhangi bir gösel bulunamadı , varsayılan görsel getirildi";
        public static string CongressImageIsListed="Kongre görseli listelendi";
        public static string CongressImageIsAdded="Kongre görseli eklendi";
        public static string ErrorUpdateingImage="Görsel güncellenirken hata oluştu";
        public static string CongressImageIsUpdate="Kongre görseli güncellendi";
        public static string ErrorDeleteingImage="Görsel silinirken bir hata oluştu";
        public static string CongressImageIsDeleted="Kongre Görseli Silindi";


        public  static string AuthorizationDenied="Bu işlemi yapmak için yetkiniz yok";


        public static string PasswordIsChanged="Şifre değiştirildi";
        public static string AccessTokenIsCreated="Token oluşturuldu";
        public static string UserIsNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string LoginIsSuccessful="Giriş Başarılı";
        public static string UserIsRegitered="Kullanıcı kayıt edildi";
        public static string UserIsAlreadyExists="Böyle bir kullanıcı zaten var";


        public static string UsersListed="Kullanıcılar Listelendi";
        public static string UserIsListed="Kullanıcı Listelendi";
        public static string UserIsNotExists="Böyle bir kullanıcı bulunamadı";
        public static string UserEmaiIsExists="Bu e-posta kullanılıyor";
        public static string UserEmailNotAvailable="Kullanıcı e-postası geçersiz";
        public static string UserIsDeleted="Kullanıcı silindi";
        public static string UserIsUpdate="Kullanıcı Güncellendi";
        public static string UserIsAdded="Kullanıcı Eklendi";
        
    }
}
