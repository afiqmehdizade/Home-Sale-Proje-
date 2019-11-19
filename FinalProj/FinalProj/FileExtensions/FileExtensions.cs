using System;
using System.IO;
using System.Web;

namespace FinalProj.FileExtensions
{
    public static class FileExtensions
    {
        public  static bool IsImage( this HttpPostedFileBase file)
        {
            return file.ContentType == "image/jpg" ||
                   file.ContentType == "image/jpeg" ||
                   file.ContentType == "image/png" ||
                   file.ContentType == "image/gif";
        }

        public static string SaveImage(this HttpPostedFileBase image, string subfolder)
        {
            string filename = subfolder + "/" + Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);

            string fullpath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), filename);

            image.SaveAs(fullpath);

            return filename;
        }

        public static void DeleteImage(string _path, string _filename)
        {
            string imagePath = Path.Combine(HttpContext.Current.Server.MapPath(_path), _filename);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        //public static bool DeleteImage(string folderPath, string filename)
        //{
        //    string fullfilename = filename.Split('/')[1];
        //    string fullfilepath = Path.Combine(folderPath, fullfilename);

        //    if (File.Exists(fullfilepath))
        //    {
        //        File.Delete(fullfilepath);
        //        return true;
        //    }
        //    return false;
        //}


    }

}