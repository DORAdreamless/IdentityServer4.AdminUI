using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tiantianquan.Infrastructure.Helpers;

namespace IdentityServer4.Admin.Api.Services
{
    public class DefaultStoreService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        public DefaultStoreService(IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._hostingEnvironment = hostingEnvironment;
        }
        public string SaveFileIfExist(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }
            IFormFile file = this._httpContextAccessor.HttpContext.Request.Form.Files.GetFile(name);
            if (file == null)
            {
                return string.Empty;
            }

            string extension = MimeHelpers.GetExtension(file.ContentType);
            if (string.IsNullOrWhiteSpace(extension))
            {
                extension = Path.GetExtension(file.FileName);
            }
            Console.WriteLine(file.ContentType);
            string relativePath = string.Format("\\Upload\\{0}\\{1}{2}{3}",
                  DateTime.Now.ToString("yyyyMM"),
                  DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                  RandomHelpers.RandomInt(1000, 9999),
                  extension
                  ).ToLower();

            string absolutePath = this._hostingEnvironment.WebRootPath + relativePath;
            PathHelpers.EnsureParentDirectory(absolutePath);

            Stream stream = file.OpenReadStream();
            //对大于1MB的图片进行压缩，最大宽度为1024像素
            //if (MimeUtils.IsImage(file.ContentType) && file.Length > 1024 * 1000)
            //{
            //    ThumbUtils.SendSmallImage(stream, absolutePath, 1024, 1024);
            //}
            //else
            {
                byte[] buffer = new byte[file.Length];
                stream.Read(buffer, 0, buffer.Length);
                System.IO.File.WriteAllBytes(absolutePath, buffer);
            }
            stream.Close();

            string host = GetHostUrl(this._httpContextAccessor.HttpContext);
            return host + relativePath.Replace("\\", "/");
        }
        public  string GetHostUrl(HttpContext context)
        {
            return context.Request.Scheme + "://" + context.Request.Host;
        }
      
    }
}
