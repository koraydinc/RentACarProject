using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Core.Utilities.Results;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        private static string _path = Environment.CurrentDirectory + @"\wwwroot\Uploads\Images\"; //Dosya dizini ataması yapılır.

        public  IResult Upload(IFormFile file)
        {
            var fileExists = CheckFileExists(file); //Dosya varlığı kontrolü yapılır.
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName); //Dosya uzantısı elde edilir.
            var typeValid = CheckFileTypeValid(type); //Tip uygunluğu kontrolü yapılır.
            var randomName = Guid.NewGuid().ToString(); //Random name elde edilir.

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            CheckDirectoryExists(_path); //Dosyanın kaydedileceği dizin kontrolü yapılır, yoksa oluşturulur.
            CreateImageFile(_path + randomName + type, file); //Dosya ilk parametre'de belirtilen dizine kopyalanır ve bellek boşaltılır.

            return new SuccessResult(randomName + type); //SQL kaydolması için dosya adı döndürülür.
        }

        public  IResult Update(IFormFile file, string filePath)
        {
            DeleteOldImageFile(filePath); //Aynı isimli dosya kontrolü yapar ve varsa siler.

            return Upload(file);
        }

        public  IResult Delete(string filePath)
        {
            DeleteOldImageFile(filePath);
            return new SuccessResult();
        }

        //Kontrol Methodları

        private static IResult CheckFileExists(IFormFile file) //Dosya varlığı kontrolü yapılır.
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't exists.");
        }

        private static IResult CheckFileTypeValid(string type) //Tip uygunluğu kontrolü yapılır.
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type.");
            }
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string directory) //Dosyanın kaydedileceği dizin kontrolü yapılır, yoksa oluşturulur.
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string directory, IFormFile file) //Dosya ilk parametre'de belirtilen dizine kopyalanır ve bellek boşaltılır.
        {
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory) //Aynı isimli dosya kontrolü yapar ve varsa siler.
        {
            if (File.Exists(directory))
            {
                File.Delete(directory);
            }
        }
    }
}