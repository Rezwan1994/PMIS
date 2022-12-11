using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PMIS.Utility
{
    public static class FileManager
    {
        private static readonly string[] _allowedDocTypes = new string[] { "application/pdf",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/octet-stream", "application/msword",
        "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-powerpoint",
        "application/vnd.openxmlformats-officedocument.presentationml.presentation"};
        private static readonly string[] _allowedImageTypes = new string[] { "image/jpeg", "image/png" };

     
        public static async Task<string> UploadFile(string folder, IFormFile file)
        {
            string fileName;
            if (file.Length > 0 && (file.IsVerified(_allowedDocTypes) || file.IsVerified(_allowedImageTypes)))
            {
                fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string absoluteFilePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(absoluteFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            else
                return string.Empty;

            return fileName;
        }

        public static void DeleteFile(params string[] files)
        {
            foreach (var absoluteFilePath in files)
            {
                if (File.Exists(absoluteFilePath))
                {
                    try
                    {
                        File.Delete(absoluteFilePath);
                    }
                    catch (IOException exception)
                    {
                        throw;
                    }
                }
            }
        }


        private static bool IsVerified(this IFormFile file, string[] allowedTypes)
        {
            if (allowedTypes.Contains(file.ContentType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}