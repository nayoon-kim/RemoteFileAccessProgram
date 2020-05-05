using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class FileInformation : Form
    {
        string fileInfo;
        string structure;
        string path;
        long size;
        string date;
        string modify_date;
        string access_date;
        
        public FileInformation(string fileInfo, string structure, string path, long size, string date, string modify_date, string access_date)
        {
            InitializeComponent();
            this.fileInfo = fileInfo;
            this.structure = structure;
            this.path = path;
            this.size = size;
            this.date = date;
            this.modify_date = modify_date;
            this.access_date = access_date;

        }

        private void FileInformation_Load(object sender, EventArgs e)
        {
            txt_fileName.Text = fileInfo;
            파일형식.Text = structure;
          
            위치.Text = path;
            크기.Text = size.ToString();
            만든날짜.Text = date.ToString();
            수정한날짜.Text = modify_date.ToString();
            액세스한날짜.Text = access_date.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();     
        }

        public int ImageNumber(string extension)
        {
          
            if (extension == "txt")
                return 5;
            else if (extension == "avi")
                return 0;
            else if (extension == "mp3")
                return 3;
            else if (extension == "png")
                return 2;
            else
                return 4;
        }

    }
}
