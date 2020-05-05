namespace WindowsFormsApp12
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_server = new System.Windows.Forms.Button();
            this.btn_path = new System.Windows.Forms.Button();
            this.btn_folder = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.상세정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다운로드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.자세히ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.간단히ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작은아이콘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.큰아이콘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.trvDir = new System.Windows.Forms.TreeView();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt_sure = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "다운로드 경로";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(53, 17);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(508, 25);
            this.txt_ip.TabIndex = 2;
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(135, 48);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(653, 25);
            this.txt_path.TabIndex = 3;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(681, 17);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(107, 25);
            this.txt_port.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(601, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "PORT : ";
            // 
            // btn_server
            // 
            this.btn_server.Location = new System.Drawing.Point(84, 79);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(121, 30);
            this.btn_server.TabIndex = 6;
            this.btn_server.Text = "서버연결";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(293, 79);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(130, 30);
            this.btn_path.TabIndex = 7;
            this.btn_path.Text = "경로설정";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // btn_folder
            // 
            this.btn_folder.Location = new System.Drawing.Point(486, 79);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(117, 30);
            this.btn_folder.TabIndex = 8;
            this.btn_folder.Text = "폴더열기";
            this.btn_folder.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "avi.png");
            this.imageList1.Images.SetKeyName(2, "image.png");
            this.imageList1.Images.SetKeyName(3, "music.png");
            this.imageList1.Images.SetKeyName(4, "temp.png");
            this.imageList1.Images.SetKeyName(5, "text.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상세정보ToolStripMenuItem,
            this.다운로드ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.자세히ToolStripMenuItem,
            this.간단히ToolStripMenuItem,
            this.작은아이콘ToolStripMenuItem,
            this.큰아이콘ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 154);
            // 
            // 상세정보ToolStripMenuItem
            // 
            this.상세정보ToolStripMenuItem.Name = "상세정보ToolStripMenuItem";
            this.상세정보ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.상세정보ToolStripMenuItem.Text = "상세정보";
            this.상세정보ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 다운로드ToolStripMenuItem
            // 
            this.다운로드ToolStripMenuItem.Name = "다운로드ToolStripMenuItem";
            this.다운로드ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.다운로드ToolStripMenuItem.Text = "다운로드";
            this.다운로드ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // 자세히ToolStripMenuItem
            // 
            this.자세히ToolStripMenuItem.Name = "자세히ToolStripMenuItem";
            this.자세히ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.자세히ToolStripMenuItem.Text = "자세히";
            this.자세히ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 간단히ToolStripMenuItem
            // 
            this.간단히ToolStripMenuItem.Name = "간단히ToolStripMenuItem";
            this.간단히ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.간단히ToolStripMenuItem.Text = "간단히";
            this.간단히ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 작은아이콘ToolStripMenuItem
            // 
            this.작은아이콘ToolStripMenuItem.Name = "작은아이콘ToolStripMenuItem";
            this.작은아이콘ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.작은아이콘ToolStripMenuItem.Text = "작은 아이콘";
            this.작은아이콘ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 큰아이콘ToolStripMenuItem
            // 
            this.큰아이콘ToolStripMenuItem.Name = "큰아이콘ToolStripMenuItem";
            this.큰아이콘ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.큰아이콘ToolStripMenuItem.Text = "큰 아이콘";
            this.큰아이콘ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // trvDir
            // 
            this.trvDir.ImageIndex = 0;
            this.trvDir.ImageList = this.imageList1;
            this.trvDir.Location = new System.Drawing.Point(8, 115);
            this.trvDir.Name = "trvDir";
            this.trvDir.SelectedImageIndex = 0;
            this.trvDir.Size = new System.Drawing.Size(174, 378);
            this.trvDir.TabIndex = 9;
            this.trvDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeExpand);
            this.trvDir.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeSelect);
            // 
            // lvwFiles
            // 
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colFileSize,
            this.colFileDate});
            this.lvwFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwFiles.LargeImageList = this.imageList1;
            this.lvwFiles.Location = new System.Drawing.Point(188, 115);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(608, 378);
            this.lvwFiles.SmallImageList = this.imageList1;
            this.lvwFiles.TabIndex = 10;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.DoubleClick += new System.EventHandler(this.lvwFiles_DoubleClick);
            this.lvwFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwFiles_MouseClick);
            // 
            // colFileName
            // 
            this.colFileName.Text = "파일이름";
            this.colFileName.Width = 250;
            // 
            // colFileSize
            // 
            this.colFileSize.Text = "파일크기";
            this.colFileSize.Width = 80;
            // 
            // colFileDate
            // 
            this.colFileDate.Text = "수정한날짜";
            this.colFileDate.Width = 180;
            // 
            // txt_sure
            // 
            this.txt_sure.Location = new System.Drawing.Point(669, 79);
            this.txt_sure.Name = "txt_sure";
            this.txt_sure.Size = new System.Drawing.Size(119, 25);
            this.txt_sure.TabIndex = 11;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.txt_sure);
            this.Controls.Add(this.lvwFiles);
            this.Controls.Add(this.trvDir);
            this.Controls.Add(this.btn_folder);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.btn_server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "File Manager - Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_server;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Button btn_folder;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 상세정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다운로드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 자세히ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 간단히ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작은아이콘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 큰아이콘ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.TreeView trvDir;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colFileSize;
        private System.Windows.Forms.ColumnHeader colFileDate;
        private System.Windows.Forms.TextBox txt_sure;
    }
}