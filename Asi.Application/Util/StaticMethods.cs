using System;
using System.IO;

namespace Asi.Application.Util
{
    public static class StaticMethods
    {
       public enum SavedImageFormat
        {
            JPG,
            PNG
        };
        public enum ImageDirectory
        {
            Images,
            Signitures
        };
        public static string SaveImage(string signitureFile, SavedImageFormat format,ImageDirectory imageDirectory)
        {
            string directoryPath = string.Format(@"E:\{0}\", imageDirectory.ToString());
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            string filepath = string.Format(@"{0}{1}.{2}",directoryPath, DateTime.Now.ToFileTime().ToString(), format.ToString().ToLower());
            File.WriteAllBytes(filepath, Convert.FromBase64String(signitureFile));
            return filepath;
        }
        public static string LoadImage(string signiturepath)
        {
            byte[] signiturefile = File.ReadAllBytes(signiturepath);
            return Convert.ToBase64String(signiturefile);
        }
        public static string GetControlTime(int controltime)
        {
            string controlTimeText = string.Empty;
            switch (controltime)
            {
                case 1:
                    controlTimeText = "بازرسی اول";
                    break;
                case 2:
                    controlTimeText = "بازرسی دوم";
                    break;
                case 3:
                    controlTimeText = "بازرسی سوم";
                    break;
                case 4:
                    controlTimeText = "بازرسی چهارم";
                    break;
            }
            return controlTimeText;
        }
    }
}
