using System;
using System.Collections.Generic;
using System.IO;
using Abp.Dependency;


namespace FikirEdin
{
    public interface IAppPaths
    {
        string HttpSchema { get; set; }
        string DomainName { get; set; }
        string DomainFullName { get; set; }
        string UserResetCodeUrl { get; set; }
        string UserActivationUrl { get; set; }

        string LogoPath { get; set; }
        string LogoFolder { get; set; }
        string ProfilePicturePath { get; set; }
        string[] FileContentTypes { get; set; }
        string[] ImageContentTypes { get; set; }
        string ScreenGalleryFolder { get; set; }
        string ProfilePictureFolder { get; set; }
        string NotificationPicturePath { get; set; }
        string NotificationPictureFolder { get; set; }
        Dictionary<string, string> FileExtension { get; set; }

        string BlogPicturePath { get; set; }
        string BlogPictureFolder { get; set; }

        string ProductPicturePath { get; set; }
        string ProductPictureFolder { get; set; }

        string CoverArtPath { get; set; }
        string MusicFilePath { get; set; }
        string CoverArtFolder { set; get; }
        string MusicFileFolder { get; set; }
        string ScreenGalleryPath { get; set; }
        string SourceMusicFolder { get; set; }
        string InvalidMusicFolder { get; set; }

        string GetNoLogoPath();
        string GetNoCovertArtPath();
        string GetNoBlogPicturePath();
        string SetLogoPath(string logo);
        string SetCoverArtPath(string coverArt);
        string SetMusicFilePath(string musicFile);
        string SetCoverArtFolder(string coverArt);
        
        string SetMusicFileFolder(string musicFile);
        string SetBlogPicturePath(string coverArt);
        string SetBlogPictureFolder(string picture);
        string SetProductPicturePath(string coverArt);
        string SetProductPictureFolder(string picture);
        string SetScreenGalleryPath(string screenGallery);
        string SetScreenGalleryFolder(string screenGallery);
        string SetProfilePicturePath(string profilePicture);
        string SetNotificationPath(string notificationPicture);
        string SetNotificationFolder(string notificationPicture);
        
    }

    public class AppPaths : IAppPaths, ISingletonDependency
    {
        public string MusicFilePath { get; set; }
        public string MusicFileFolder { get; set; }
        public string ScreenGalleryPath { get; set; }
        public string SourceMusicFolder { get; set; }
        public string InvalidMusicFolder { get; set; }
        public string CoverArtPath { get; set; }
        public string CoverArtFolder { get; set; }
        public string BlogPicturePath { get; set; }
        public string BlogPictureFolder { get; set; }
        public string ProductPicturePath { get; set; }
        public string ProductPictureFolder { get; set; }
        public string HttpSchema { get; set; }
        public string DomainName { get; set; }
        public string DomainFullName { get; set; }
        public string UserResetCodeUrl { get; set; }
        public string UserActivationUrl { get; set; }
        public string LogoPath { get; set; }
        public string LogoFolder { get; set; }
        public string NotificationPicturePath { get; set; }
        public string NotificationPictureFolder { get; set; }
        public string ProfilePicturePath { get; set; }
        public string ScreenGalleryFolder { get; set; }
        public string ProfilePictureFolder { get; set; }
        public string[] ImageContentTypes { get; set; }
        public string[] FileContentTypes { get; set; }
        public Dictionary<string, string> FileExtension { get; set; }

        public string SetLogoPath(string logo)
        {
            if (string.IsNullOrEmpty(logo))
                return string.Empty;

            return $"{DomainFullName}{LogoPath}{logo}";
        }

        public string GetNoLogoPath()
        {
            return $"{DomainFullName}/img/no-logo.png";
        }

        

        public string GetNoCovertArtPath()
        {
            return $"{DomainFullName}/img/no-coverart.png";
        }

        public string GetNoBlogPicturePath()
        {
            return $"{DomainFullName}/img/no-blog-picture.png";
        }

        public string GetNoProductPicturePath()
        {
            return $"{DomainFullName}/img/no-product-picture.png";
        }

        public string SetCoverArtPath(string coverArt)
        {
            if (string.IsNullOrEmpty(coverArt))
                return string.Empty;

            return $"{DomainFullName}{CoverArtPath}{coverArt}";
        }

        public string SetScreenGalleryPath(string screenGallery)
        {
            if (string.IsNullOrEmpty(screenGallery))
                return string.Empty;

            return $"{DomainFullName}{ScreenGalleryPath}{screenGallery}";
        }

        public string SetBlogPicturePath(string picture)
        {
            if (string.IsNullOrEmpty(picture))
                return string.Empty;

            return $"{DomainFullName}{BlogPicturePath}{picture}";
        }

        public string SetProductPicturePath(string picture)
        {
            if (string.IsNullOrEmpty(picture))
                return string.Empty;

            return $"{DomainFullName}{ProductPicturePath}{picture}";
        }

        public string SetMusicFilePath(string musicFile)
        {
            if (string.IsNullOrEmpty(musicFile))
                return string.Empty;

            return $"{DomainFullName}{MusicFilePath}{musicFile}";
        }

        public string SetProfilePicturePath(string profilePicture)
        {
            if (string.IsNullOrEmpty(profilePicture))
                return string.Empty;

            return $"{DomainFullName}{ProfilePicturePath}{profilePicture}";
        }

       

        public string SetNotificationPath(string notificationPicture)
        {
            if (string.IsNullOrEmpty(notificationPicture))
                return string.Empty;

            return $"{DomainFullName}{NotificationPicturePath}{notificationPicture}";
        }

        public string SetMusicFileFolder(string musicFile)
        {
            if (string.IsNullOrEmpty(musicFile))
                return string.Empty;

            return Path.Combine(MusicFileFolder, musicFile);
        }

        public string SetScreenGalleryFolder(string screenGallery)
        {
            if (string.IsNullOrEmpty(screenGallery))
                return string.Empty;

            return Path.Combine(ScreenGalleryFolder, screenGallery);
        }

        public string SetCoverArtFolder(string coverArt)
        {
            if (string.IsNullOrEmpty(coverArt))
                return string.Empty;

            return Path.Combine(CoverArtFolder, coverArt);
        }

        public string SetBlogPictureFolder(string picture)
        {
            if (string.IsNullOrEmpty(picture))
                return string.Empty;

            return Path.Combine(BlogPictureFolder, picture);
        }

        public string SetProductPictureFolder(string picture)
        {
            if (string.IsNullOrEmpty(picture))
                return string.Empty;

            return Path.Combine(ProductPictureFolder, picture);
        }

        public string SetNotificationFolder(string notificationPicture)
        {
            if (string.IsNullOrEmpty(notificationPicture))
                return string.Empty;

            return Path.Combine(NotificationPictureFolder, notificationPicture);
        }
    }
}

