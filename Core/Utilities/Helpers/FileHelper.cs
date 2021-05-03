using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {   
            var sourcePath = Path.GetTempFileName();

            if (file.Length>0)
            {
                using (var uploading = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }

            var result = newPath(file);
            File.Move(sourcePath, result);
            return result;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result =newPath(file);
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result;

        }

        public static string newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
