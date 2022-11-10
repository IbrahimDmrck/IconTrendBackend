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


        public static string AnnounceImageIsListed="Duyuru Görseli Listelendi";
        public static string AnnounceImageLimitExceeded= "Daha Fazla Duyuru Görseli Yüklenemez";
        public static string AnnounceImageIdNotExist="Duyuru Görseli Mevcut Değil";
        public static string AnnounceImagesListed = "Duyuru Görselleri Listelendi";
        public static string AnnounceImageIsAdded = "Duyuru Görseli Eklendi";
        public static string AnnounceImageIsDeleted = "Duyuru Görseli Silindi";
        public static string NoPictureOfTheAnnounce = "Duyuru Görseli Yok";
        public static string AnnounceImageIsUpdate="Duyuru Görseli Güncellendi";


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
        public static string NoPictureOfTheCongress="Kongre görseli yok";
        public static string CongressImageLimitExceeded="Daha fazla kongre görseli yüklenemez";
        public static string CongressImageIdNotExist="Kongre görseli mevcut değil";


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


        public static string ScienceBoardISCreated="Bilim kurulu oluşturuldu";
        public static string ScienceBoardISDeleted="Bilim kurulu silindi";
        public static string ScienceBoardsListed="Bilim kurulları listelendi";
        public static string ScienceBoardIsListed = "Bilim kurulu listelendi";
        public static string ScienceBoardISUpdated="Bilim kurlu güncellendi";


        public static string RegulatoryBoardIsCreated="Düzenleme kurulu oluşturuldu";
        public static string RegulatoryBoardIsDeleted="Düzenleme kurulu silindi";
        public static string RegulatoryBoardIsUpdated="Düzenleme kurulu güncellendi";
        public static string RegulatoryBoardsListed="Düzenleme kurulları listelendi";
        public static string RegulatoryBoardIsListed="Düzenleme kurulu listelendi";


        public static string CongressPresidentIsAdded="Kongre başkanı eklendi";
        public static string CongressPresidentIsDeleted="Kongre başkanı silindi";
        public static string CongressPresidentIsUpdated="kongre başkanı güncellendi";
        public static string CongressPresidentsListed="Kongre başkanları listelendi";
        public static string CongressPresidentIsListed="Kongre başkanı listelendi";
        public static string CongressPresidentNotExist = "Böyle bir kongre başkanı mevcut değil";
        public static string CongressPresidentExist = "Kongre başkanı zaten mevcut";

        public static string TransportImageIsAdded="Ulaşım görseli eklendi";
        public static string TransportImageIsDeleted="Ulaşım görseli silindi";
        public static string NoPictureOfTheTransport="Ulaşım görseli yok";
        public static string TransportImagesListed="Ulaşım görselleri listelendi";
        public static string TransportImageIsUpdate="Ulaşım görseli güncellendi";
        public static string TransportImageIdNotExist="Ulaşım görseli mevcut değil";
        public static string TransportImageLimitExceeded="Daha fazla görsel yüklenemez";
        public static string TransportImageIsListed="Ulaşım görseli listelendi";
        public static string TransportIsListed="Ulaşımlar listelendi";

        internal static string RegulatoryBoardMemberExist="Üye Zaten Mevcut";
        internal static string RegulatoryBoardMemberNotExist="Böyle Bir Üye Mevcut Değil";

    }
}
