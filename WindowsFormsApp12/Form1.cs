using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ClassLibrary3;

namespace WindowsFormsApp12
{
    public partial class Server : Form
    {
        private TcpListener server = null;
        private int PORT = 0;
        private IPAddress ipaddress = null;

        private NetworkStream networkstream;

        private bool m_bClientOn = false;

        private Thread m_thread;

        public Initialize m_initializeClass;
        public Select_toServer m_selectClass;
        public Expand_toServer m_expandclientClass;
        public Details_toServer m_detailsClass;

        public byte[] sendBuffer = new byte[1024 * 4];
        public byte[] readBuffer = new byte[1024 * 4];
        public int n = 0;

        public Server()
        {
            InitializeComponent();

        }

        delegate void CrossThreadSafetySetText(Control ctl, String text);

        private void CSafeSetText(Control ctl, String text)
        {
            if (ctl.InvokeRequired)
                ctl.Invoke(new CrossThreadSafetySetText(CSafeSetText), ctl, text);
            else
            {
                ctl.Text = text;
                ctl.ForeColor = Color.Red;
            }
        }
        public void RUN()
        {
            if (txt_path.Text == "" || txt_ip.Text == "" || txt_port.Text == "")
            {
                if (txt_path.Text == "")
                {
                    MessageBox.Show("경로가 설정되어있지 않습니다.");
                    return;
                }
                if (txt_ip.Text == "" || txt_port.Text == "")
                {
                    MessageBox.Show("IP와 PORT를 정확히 입력하십시오.");
                    return;

                }
            }
            else
            {
                CSafeSetText(btn_server, "서버끊기");


                this.ipaddress = IPAddress.Parse(txt_ip.Text);
                this.PORT = int.Parse(txt_port.Text);
                this.server = new TcpListener(ipaddress, PORT);
                this.server.Start();

                //btn_server.Text = "서버끊기";
                //btn_server.ForeColor = Color.Red;

                if (!this.m_bClientOn)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.txt_server_state.AppendText("클라이언트 접속 대기중..." + "\r\n");
                    }));
                }

                TcpClient client = this.server.AcceptTcpClient();


                if (client.Connected)
                {
                    this.m_bClientOn = true;
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.txt_server_state.AppendText("클라이언트 접속..." + "\r\n");
                    }));
                    networkstream = client.GetStream();
                }



                int nRead = 0;


                while (this.m_bClientOn)
                {

                    try
                    {
                        nRead = 0;
                        init();
                        nRead = this.networkstream.Read(readBuffer, 0, 1024 * 4);

                    }
                    catch
                    {
                        this.m_bClientOn = false;
                        this.networkstream = null;
                    }


                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.선택서버:
                            {
                                this.m_selectClass = (Select_toServer)Packet.Desserialize(this.readBuffer);

                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    this.txt_server_state.AppendText("beforeSelect 데이터 요청.." + "\r\n");
                                    Select_toClient select = new Select_toClient();

                                    select.Type = (int)PacketType.선택손님;

                                    select.path = this.m_selectClass.path;

                                    DirectoryInfo[] di = new DirectoryInfo(select.path).GetDirectories();
                                    //list_dir
                                    List<string> list = new List<string>();
                                    //select.dir = new DirectoryInfo(select.path).GetDirectories();
                                    for (int i = 0; i < di.Length; i++)
                                    {
                                        list.Add(di[i].ToString());
                                    }
                                    select.dir = list;

                                    List<string> dir_date = new List<string>();
                                    for (int i = 0; i < di.Length; i++)
                                    {
                                        dir_date.Add(di[i].LastWriteTime.ToString());
                                    }
                                    select.dir_date = dir_date;

                                    FileInfo[] fi = new DirectoryInfo(select.path).GetFiles();
                                    //list_file
                                    List<string> list_f = new List<string>();
                                    //select.fil = new DirectoryInfo(select.path).GetFiles();
                                    for (int i = 0; i < fi.Length; i++)
                                    {
                                        list_f.Add(fi[i].ToString());
                                    }
                                    select.fil = list_f;

                                    //dir_num
                                    List<int> list_num = new List<int>();

                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        DirectoryInfo[] di_num = new DirectoryInfo(select.path + "\\" + di[i]).GetDirectories();
                                        list_num.Add(di_num.Length);
                                    }
                                    select.dir_num = list_num;

                                    //file_info
                                    Dictionary<string, string> file_Info = new Dictionary<string, string>();
                                    for (int i = 0; i < fi.Length; i++)
                                    {
                                        file_Info.Add(fi[i].Length.ToString(), fi[i].LastWriteTime.ToString());
                                    }
                                    select.file_info = file_Info;


                                    Packet.Serialize(select).CopyTo(this.sendBuffer, 0);
                                    this.Send();
                                }));
                            }
                            break;
                        case (int)PacketType.확장서버:
                            {
                                this.m_expandclientClass = (Expand_toServer)Packet.Desserialize(this.readBuffer);

                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    this.txt_server_state.AppendText("beforeExpand 데이터 요청.." + "\r\n");
                                    Expand_toClient expand = new Expand_toClient();
                                    expand.Type = (int)PacketType.확장손님;
                                    expand.path = this.m_expandclientClass.path;
                                    DirectoryInfo[] di = new DirectoryInfo(expand.path).GetDirectories();
                                    List<string> list = new List<string>();

                                    for (int i = 0; i < di.Length; i++)
                                    {
                                        list.Add(di[i].ToString());
                                    }
                                    // string[] a = list.
                                    expand.dir = list;

                                    List<int> list_num = new List<int>();

                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        DirectoryInfo[] di_num = new DirectoryInfo(expand.path + "\\" + di[i]).GetDirectories();
                                        list_num.Add(di_num.Length);
                                    }
                                    expand.dir_num = list_num;

                                    List<string> dir_date = new List<string>();
                                    for (int i = 0; i < di.Length; i++)
                                    {
                                        dir_date.Add(di[i].LastWriteTime.ToString());
                                    }
                                    expand.dir_date = dir_date;

                                    Packet.Serialize(expand).CopyTo(this.sendBuffer, 0);
                                    this.Send();
                                }));

                            }
                            break;
                        case (int)PacketType.상세정보서버:
                            {
                                this.m_detailsClass = (Details_toServer)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    if (this.m_detailsClass.tag != "D")
                                    {
                                        Details_toClient details = new Details_toClient();
                                        details.Type = (int)PacketType.상세정보손님;
                                        details.path = m_detailsClass.name;
                                        //public FileInformation(string fileInfo, string structure, string path, int size, string date, string modify_date, string access_date)
                                        string[] name = details.path.Split('\\');//이름
                                        details.fileInfo = name[name.Length - 1];//이름
                                        details.structure = details.fileInfo.Split('.')[1];//형식
                                        FileInfo di = new FileInfo(details.fileInfo); //파일의 정보가져오기
                                        details.size = di.Length; //파일의 크기
                                        
                                        details.date = di.CreationTime.ToString(); //만든 날짜
                                        details.modify_date = di.LastWriteTime.ToString(); //마지막으로 수정한 날짜
                                        details.access_date = di.LastAccessTime.ToString(); //마지막으로 접근한 날짜

                                        Packet.Serialize(details).CopyTo(this.sendBuffer, 0);
                                        this.Send();

                                        this.txt_server_state.AppendText("상세정보 데이터 요청.." + "\r\n");
                                    }
                                }));
                            }
                            break;
                    }

                }
            }

        }
        public void Send()
        {
            while (true)
            {
                try
                {
                    this.networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                    this.networkstream.Flush();

                    for (int i = 0; i < 1024 * 4; i++)
                    {
                        this.sendBuffer[i] = 0;
                    }
                    return;
                }
                catch (NullReferenceException e)
                {
                    this.networkstream = this.server.AcceptTcpClient().GetStream();

                }
            }

        }
        public void init()
        {
            if (!this.m_bClientOn)
            {
                return;
            }

            if (n == 0)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    try
                    {
                        //TcpClient m_client = new TcpClient(ipaddress.ToString(), this.PORT);
                        //NetworkStream stream = m_client.GetStream();

                        Initialize Init = new Initialize();
                        Init.Type = (int)PacketType.초기화;
                        Init.path = this.txt_path.Text;

                        DirectoryInfo[] di = new DirectoryInfo(txt_path.Text).GetDirectories();
                        Init.dir_num = di.Length;
                        List<string> list = new List<string>();

                        for (int i = 0; i < di.Length; i++)
                        {
                            list.Add(di[i].ToString());
                        }
                        Init.dir = list;

                        FileInfo[] fi = new DirectoryInfo(txt_path.Text).GetFiles();

                        List<string> list_f = new List<string>();
                        for (int i = 0; i < fi.Length; i++)
                        {
                            list_f.Add(fi[i].ToString());
                        }
                        Init.fil = list_f;

                        List<string> dir_date = new List<string>();
                        for (int i = 0; i < di.Length; i++)
                        {
                            dir_date.Add(di[i].LastWriteTime.ToString());
                        }
                        Init.dir_date = dir_date;

                        Dictionary<string, string> file_Info = new Dictionary<string, string>();

                        for (int i = 0; i < fi.Length; i++)
                        {
                            file_Info.Add(fi[i].Length.ToString(), fi[i].LastWriteTime.ToString());
                        }
                        Init.file_info = file_Info;

                        this.txt_server_state.AppendText("초기화 데이터 요청.." + "\r\n");
                        Packet.Serialize(Init).CopyTo(this.sendBuffer, 0);
                        this.Send();
                        n++;
                        //stream.Close();
                        //m_client.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));

            }
        }
        private void btn_server_Click(object sender, EventArgs e)
        {
            if (btn_server.Text == "서버켜기")
            {
                this.m_thread = new Thread(new ThreadStart(RUN));
                this.m_thread.Start();

            }
            else
            {
                btn_server.Text = "서버켜기";
                btn_server.ForeColor = Color.Black;

                this.server.Stop();

            }
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            fbd_server = new FolderBrowserDialog();
            fbd_server.ShowNewFolderButton = true;

            n = 0;

            DialogResult result = fbd_server.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_path.Text = fbd_server.SelectedPath;
                Environment.SpecialFolder root = fbd_server.RootFolder;
                this.txt_server_state.AppendText(txt_path.Text + "로 경로가 수정되었습니다." + "\r\n");
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Client form_client = new Client();
            form_client.Show();
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_thread.Abort();
            this.server.Stop();
            this.networkstream.Close();
        }
    }
}
