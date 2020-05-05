using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp12
{
    public partial class Client : Form
    {
        private NetworkStream networkstream;
        private TcpClient client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;

        public Initialize m_initializeClass;
        public Select_toClient m_selectClass;
        public Expand_toClient m_expandClass;

        //public string file_path;
        public TreeNode root;
        // public TreeNode node;
        public Thread thread;
        public TreeViewCancelEventArgs ev;
        public Thread thread_expand;
        public Thread thread_select;
        public TreeViewCancelEventArgs ee;
        public Thread thread_details;

        public string path_init;
        public List<string> Drv_list_init;
        public List<string> File_list_init;
       

        public string path_expand;
        //public DirectoryInfo[] Drv_list_expand;
        public List<string> Drv_list_expand;
        public List<int> Drv_num_expand;

        public string path_select;
        public List<string> Drv_list_select;
        public List<string> File_list_select;
        public List<int> Drv_num_select;

        int num = 0;


        public Client()
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
        void RUN()
        {
            this.client = new TcpClient();

            if (txt_path.Text == "")
            {
                MessageBox.Show("경로가 설정되어있지 않습니다.");
                return;
            }
            try
            {
                this.client.Connect(this.txt_ip.Text, int.Parse(this.txt_port.Text));

            }
            catch
            {
                MessageBox.Show("접속 에러");
                return;
            }
            CSafeSetText(btn_server, "서버끊기");
            //btn_server.Text = "서버끊기";
            //btn_server.ForeColor = Color.Red;
            this.m_bConnect = true;
            this.networkstream = this.client.GetStream();

            int nRead = 0;

            while (this.m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = this.networkstream.Read(readBuffer, 0, 1024 * 4);
                    //MessageBox.Show("read_RUN" + nRead);
                }
                catch
                {
                    this.m_bConnect = false;
                    this.networkstream = null;
                }

                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                switch ((int)packet.Type)
                {
                    case (int)PacketType.초기화:
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                try
                                {

                                    ListViewItem item;

                                    this.m_initializeClass = (Initialize)Packet.Desserialize(this.readBuffer);

                                    path_init = this.m_initializeClass.path;
                                    Drv_list_init = this.m_initializeClass.dir;
                                    File_list_init = this.m_initializeClass.fil;
                                    Dictionary<string, string> file_info = this.m_initializeClass.file_info;
                                    List<string> dir_date = this.m_initializeClass.dir_date;


                                    root = new TreeNode(path_init);
                                    trvDir.Nodes.Add(root);
                                    if (this.m_initializeClass.dir_num > 0)
                                        root.Nodes.Add("");

                                    int i = 0;
                                    foreach (string Drv in Drv_list_init)
                                    {
                                        item = lvwFiles.Items.Add(Drv);
                                        item.SubItems.Add("");
                                        item.SubItems.Add(dir_date[i].ToString());
                                        item.ImageIndex = 0;
                                        item.Tag = "D";
                                        i++;
                                    }

                                    i = 0;
                                    foreach (string fis in File_list_init)
                                    {
                                        item = lvwFiles.Items.Add(fis); // 이름
                                        item.SubItems.Add(file_info.Keys.ElementAt(i).ToString()); // 크기(byte)
                                        item.SubItems.Add(file_info.Values.ElementAt(i).ToString()); // 수정한 날짜
                                        item.ImageIndex = ImageNumber(fis.ToString());
                                        item.Tag = "F";
                                        i++;
                                    }


                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }));
                            break;
                        }
                    case (int)PacketType.확장손님:
                        {
                            thread_expand = new Thread(() => RUN_EXPAND(ev));
                            thread_expand.Start();
                            break;
                        }
                    case (int)PacketType.선택손님:
                        {
                            thread_select = new Thread(() => RUN_SELECT(ee));
                            thread_select.Start();
                            break;
                        }
                    case (int)PacketType.상세정보손님:
                        {
                            thread_details = new Thread(() => OpenFiles());
                            thread_details.Start();
                            break;
                        }

                }
            }
        }
        private void btn_server_Click(object sender, EventArgs e)
        {
            if (btn_server.Text == "서버연결")
            {
                this.thread = new Thread(new ThreadStart(RUN));
                this.thread.Start();
            }
            else
            {
                btn_server.Text = "서버연결";
                btn_server.ForeColor = Color.Black;

                this.m_bConnect = false;
                this.client.Close();
            }
        }


        private void btn_path_Click(object sender, EventArgs e)
        {
            fbd1 = new FolderBrowserDialog();
            fbd1.ShowNewFolderButton = true;

            DialogResult result = fbd1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_path.Text = fbd1.SelectedPath;
                Environment.SpecialFolder root = fbd1.RootFolder;
            }

        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.client.Close();
            this.networkstream.Close();
            this.thread_expand.Abort();
            this.thread_select.Abort();
            this.thread.Abort();
        }


        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //this.thread_expand = new Thread(() => RUN_EXPAND(e));
            //this.thread_expand.Start();
            string path; //경로지정변수
            //TreeNode node;
            //TreeNode temp;

            try
            {
                //e.Node.Nodes.Clear();
                path = e.Node.FullPath;
                ev = e;
                //num = trvDir.SelectedNode.Index;
                //node = new TreeNode();

                Expand_toServer expand = new Expand_toServer();
                expand.Type = (int)PacketType.확장서버;
                expand.path = path;
                expand.dir = null;


                Packet.Serialize(expand).CopyTo(this.sendBuffer, 0);
                this.Send();

                //MessageBox.Show("send after");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void RUN_EXPAND(TreeViewCancelEventArgs e)
        {

            //string path; //경로지정변수
            ////TreeNode node;
            TreeNode temp;

            try
            {
                num = 0;


                while (m_bConnect && num == 0)
                {

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        try
                        {

                            this.m_expandClass = (Expand_toClient)Packet.Desserialize(this.readBuffer);

                            path_expand = this.m_expandClass.path;
                            Drv_list_expand = this.m_expandClass.dir;
                            Drv_num_expand = this.m_expandClass.dir_num;

                            ev.Node.Nodes.Clear();
                            root = ev.Node;

                            //여기부터
                            int num1 = 0;
                            foreach (string drv in Drv_list_expand)
                            {
                                temp = ev.Node.Nodes.Add(drv);
                                if (Drv_num_expand[num1] != 0)
                                    temp.Nodes.Add("");
                                num1++;
                            }
                            //여기까지

                            num = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));

                    break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    
        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            string path;
            try
            {

                path = e.Node.FullPath;
                ee = e;
               
                Select_toServer select = new Select_toServer();
                select.Type = (int)PacketType.선택서버;
                select.path = path;

                Packet.Serialize(select).CopyTo(this.sendBuffer, 0);
                this.Send();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void RUN_SELECT(TreeViewCancelEventArgs e)
        {

            try
            {
                ListViewItem item;
                int num2 = 0;
                ///TreeNode temp;
                while (m_bConnect && num2 == 0)
                {

                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        try
                        {

                            this.m_selectClass = (Select_toClient)Packet.Desserialize(this.readBuffer);

                            path_select = this.m_selectClass.path;
                            Drv_list_select = this.m_selectClass.dir;
                            File_list_select = this.m_selectClass.fil;
                            List<string> dir_date = this.m_selectClass.dir_date;
                            Dictionary<string, string> file_info = this.m_selectClass.file_info;
                            lvwFiles.Items.Clear();
                            int i = 0;
                            foreach (string tdis in Drv_list_select)
                            {
                                item = lvwFiles.Items.Add(tdis); // 이름
                                //txt_sure.AppendText(item.Name);
                                item.SubItems.Add(""); //디렉토리의 크기는 표시하지 않는다.
                                item.SubItems.Add(dir_date[i].ToString()); //수정한 날짜
                                item.ImageIndex = 0;
                                item.Tag = "D";
                                i++;
                            }
                            i = 0;
                            foreach (string fis in File_list_select)
                            {
                                item = lvwFiles.Items.Add(fis); // 이름
                                item.SubItems.Add(file_info.Keys.ElementAt(i).ToString()); // 크기(byte)
                                item.SubItems.Add(file_info.Values.ElementAt(i).ToString()); // 수정한 날짜
                                item.ImageIndex = ImageNumber(fis);
                                item.Tag = "F";
                                i++;
                            }
                            num2 = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            string path;
            try
            {

                //path = e.Node.FullPath;
                //ee = e;
                //ListViewItem items = lvwFiles.SelectedItems.ToString();

                Details_toServer details = new Details_toServer();
                details.Type = (int)PacketType.상세정보서버;
                details.name = lvwFiles.SelectedItems.ToString();
                //details.tag = 
                //Packet.Serialize(details).CopyTo(this.sendBuffer, 0);
                //this.Send();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            //OpenFiles();
        }

        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;

            foreach (ListViewItem item in siList)
            {
                OpenItem(item);
            }
        }
        public void OpenItem(ListViewItem item)
        {
            TreeNode node;
            TreeNode child;

            if (item.Tag.ToString() == "D")
            {
                node = trvDir.SelectedNode;
                node.Expand();

                child = node.FirstNode;

                while (child != null)
                {
                    if (child.Text == item.Text)
                    {
                        trvDir.SelectedNode = child;
                        trvDir.Focus();
                        break;
                    }

                    child = child.NextNode;
                }

            }
            else // 파일을 입력하면 실행이 되도록 설정해주어야한다.
            {
                FileInformation f = new FileInformation("a", "a", "a", 4, "a", "a", "a");
                f.Show();
            }

        }

        public void setPlus(TreeNode node, DirectoryInfo[] dir)
        {
            DirectoryInfo[] di = dir;
            try
            {
                if (di.Length > 0)
                    node.Nodes.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //오른쪽 버튼 클릭시 contextMenu
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            //상세정보ToolStripMenuItem.Checked = false;
            //다운로드ToolStripMenuItem.Checked = false;
            자세히ToolStripMenuItem.Checked = false;
            간단히ToolStripMenuItem.Checked = false;
            작은아이콘ToolStripMenuItem.Checked = false;
            큰아이콘ToolStripMenuItem.Checked = false;

            switch (item.Text)
            {
                case "자세히":
                    자세히ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.Details;
                    break;
                case "간단히":
                    간단히ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.List;
                    break;
                case "작은 아이콘":
                    작은아이콘ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.SmallIcon;
                    break;
                case "큰 아이콘":
                    큰아이콘ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.LargeIcon;
                    break;
                    //case "상세정보":
                    //    상세정보ToolStripMenuItem.Checked = true;
                    //    ListView.SelectedListViewItemCollection index = lvwFiles.SelectedItems;
                    //    if (index != null)
                    //    {
                    //        FileInformation f = new FileInformation();
                    //        f.Show();
                    //    }
                    //    break;
                    //case "다운로드":
                    //    다운로드ToolStripMenuItem.Checked = true;

                    //    break;
            }
        }
        public int ImageNumber(string fi)
        {
            string extension = fi.ToString().Split('.')[1];

            if (extension == "txt")
                return 5;
            else if (extension == "avi")
                return 1;
            else if (extension == "mp3")
                return 3;
            else if (extension == "png")
                return 2;
            else
                return 4;
        }
        public void Send()
        {
            this.networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        private void lvwFiles_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button.Equals(MouseButtons.Right))
            //{
            //    string selectedNickName = lvwFiles.GetItemAt(e.X, e.Y).Text;

            //    contextMenuStrip1 = new ContextMenuStrip();

            //    contextMenuStrip1_Click += (sender, e) =>
            //    {
            //        if(sender.Text == "상세정보")
            //        {
            //            thread_details = new Thread()
            //        }
            //    };
            //}
        }
    }
}
