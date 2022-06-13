using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using FikirEdin.Authentication.JwtBearer;
using FikirEdin.Configuration;
using FikirEdin.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.IO;
using System.Collections.Generic;
using Abp.IO;

namespace FikirEdin
{
    [DependsOn(
         typeof(FikirEdinApplicationModule),
         typeof(FikirEdinEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule)
     )]
    public class FikirEdinWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FikirEdinWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                FikirEdinConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(FikirEdinApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FikirEdinWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FikirEdinWebCoreModule).Assembly);

            SetAppPaths();
        }
        private void SetAppPaths()
        {
            var appPaths = IocManager.Resolve<AppPaths>();

            appPaths.DomainName = _appConfiguration["Host:DomainName"];
            appPaths.HttpSchema = _appConfiguration["Host:HttpSchema"];
            appPaths.DomainFullName = _appConfiguration["Host:DomainFullName"];

           
            
            appPaths.BlogPicturePath = "/Common/Blog/";
            appPaths.BlogPictureFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Blog");
            appPaths.ProductPicturePath = "/Common/Product/";
            appPaths.ProductPictureFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Product");

            appPaths.FileContentTypes = new[]
            {
                "audio/mpeg",
                "audio/mp3",
                "audio/ogg",
                "video/ogg",
                "application/ogg",
                "video/mp4",
                "application/zip",
                "multipart/x-zip",
                "application/vnd.rar",
                "application/octet-stream",
                "application/x-7z-compressed",
                "application/x-rar-compressed",
                "application/x-zip-compressed",
            };

            appPaths.ImageContentTypes = new[]
            {
                "image/bmp",
                "image/gif",
                "image/png",
                "image/jpeg",
            };

            appPaths.FileExtension = new Dictionary<string, string>
            {
                {"audio/mpeg",".mp3"},
                {"audio/mp3",".mp3"},
                {"audio/ogg",".ogg"},
                {"video/ogg",".ogg"},
                {"application/ogg",".ogg"},
                {"video/mp4",".mp4"},
                {"image/bmp",".bmp"},
                {"image/gif",".gif"},
                {"image/png",".png"},
                {"image/jpeg",".jpg"},
                {"multipart/x-zip",".zip"},
                {"application/zip",".zip"},
                {"application/octet-stream",".zip"},
                {"application/x-7z-compressed",".7z"},
                {"application/x-zip-compressed",".zip"},
            };

            try
            {
                DirectoryHelper.CreateIfNotExists(appPaths.BlogPictureFolder);
                DirectoryHelper.CreateIfNotExists(appPaths.ProductPictureFolder);
            }
            catch { }
        }
    }
}
