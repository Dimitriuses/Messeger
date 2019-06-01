using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class FileDTO
    {
        public FileDTO()
        {

        }
        public FileDTO(string path)
        {
            FileInfo = new FileInfo(path);
            using (System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                FileStream = stream;
            }
            FileName = FileInfo.Name;
        }
        public string FileName { get; set; }
        public Stream FileStream { get; set; }
        public FileInfo FileInfo { get; set; }
        public int ChatId { get; set; }
    }
}
