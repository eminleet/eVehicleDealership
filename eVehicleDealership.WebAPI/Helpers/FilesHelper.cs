using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Helpers
{
    public class FilesHelper
    {
        public static bool UploadPhoto(MemoryStream memoryStream, string folderName, string fileName)
        {
            try
            {
                memoryStream.Position = 0;
                var path = Path.Combine(folderName, fileName);
                File.WriteAllBytes(path, memoryStream.ToArray());
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
    }
}
