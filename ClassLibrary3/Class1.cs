using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ClassLibrary3
{   public enum PacketType
    {
        초기화 = 0,
        선택서버,
        선택손님,
        확장서버,
        확장손님,
        상세정보서버,
        상세정보손님,
        다운로드서버,
        다운로드손님,
        다운로드파일

    }
    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }
    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach(byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
        
    }

    [Serializable]
    public class Initialize : Packet
    {
        public string path;
        public List<string> dir;
        public List<string> dir_date;
        public List<string> fil;
        //public Dictionary<string, Element> file_info;
        public List<string> fileInfo_size;
        public List<string> fileInfo_time;
        public int dir_num;
    }

    [Serializable]
    public class Select_toServer : Packet
    {
        public string path;
        //public DirectoryInfo[] dir;
        //public FileInfo[] fil;
        //public List<string> dir;
        //public List<string> fil;
    }
    
    [Serializable]
    public class Select_toClient : Packet
    {
        public string path;
        //public DirectoryInfo[] dir;
        //public FileInfo[] fil;
        public List<string> dir;
        public List<string> dir_date;
        public List<string> fil;
        //public Dictionary<string, Element> file_info;
        public List<string> file_info_size;
        public List<string> file_info_time;
        public List<int> dir_num;
    }

    [Serializable]
    public class Expand_toServer : Packet
    {
        public string path;
        public List<string> dir;
        public List<int> dir_num;
    }

    [Serializable]
    public class Expand_toClient : Packet
    {
        public string path;
        public List<string> dir;
        public List<int> dir_num;
        public List<string> dir_date;
    }

    [Serializable]
    public class Details_toServer : Packet
    {
        public string path;
        public string name;
        public string tag;
        //public string tag; //디렉토리인지 파일인지 구분해서 상세정보요청보낼건지 말건지 결정한다.
    }

    [Serializable]
    public class Details_toClient : Packet
    {
        // public FileInformation(string fileInfo, string structure, string path, int size, string date, string modify_date, string access_date)
        public string fileInfo;
        public string structure;
        public string path;
        public string size;
        public string date;
        public string modify_date;
        public string access_date;
    }
    
    [Serializable]
    public class Download_toServer : Packet
    {
        public string path;
        public string name;
    }

    [Serializable]
    public class Download_toClient : Packet
    {

        public byte[] file_size;
        public byte[] name_size;
        public byte[] name;
        //public byte[] size;
    }
    
    [Serializable]
    public class Download_file : Packet
    {
        public List<byte[]> file;
        //public byte[] ReceiveData()
        //{
        //    byte[] dataBuffer = null;
        //    return dataBuffer;
        //}
    }

    //[Serializable]
    //public class Download_toClient : Packet
    //{

    //}
}
