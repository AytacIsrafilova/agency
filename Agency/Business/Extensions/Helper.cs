using Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public class Helper
    {
        public static string SaveFile(string rootPath,string folder,IFormFile formFile)
        {
            if (!formFile.ContentType.Contains("image/"))
                throw new FileContentTypeException("ImgFile", "Content type is not correct!");
            if (formFile.Length > 2097152)
                throw new FileSizeException("ImgFile", "File size is not correct!");
            string fileName = Guid.NewGuid().ToString()+Path.GetExtension(formFile.FileName);
            string path = rootPath + @$"\{folder}\" + fileName;
            using(FileStream fileStream=new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return fileName;
        }
        public static void DeleteFile(string rootPath, string folder,string fileName)
        {
            string existImgUrlPath= rootPath + @$"\{folder}\" + fileName;
            if(!File.Exists(existImgUrlPath))
                throw new EntityFileNotFoundException("","Image Url is not correct!");
            File.Delete(existImgUrlPath);
        }
    }
}
