namespace WindowsFormsApp12
{
    partial class FileInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileInformation));
            this.txt_fileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.파일형식 = new System.Windows.Forms.Label();
            this.위치 = new System.Windows.Forms.Label();
            this.크기 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.만든날짜 = new System.Windows.Forms.Label();
            this.수정한날짜 = new System.Windows.Forms.Label();
            this.액세스한날짜 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.image_File = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.image_File)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_fileName
            // 
            this.txt_fileName.Location = new System.Drawing.Point(169, 74);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(473, 25);
            this.txt_fileName.TabIndex = 1;
            this.txt_fileName.Text = "avi.png";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "파일 형식: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "위치: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "크기: ";
            // 
            // 파일형식
            // 
            this.파일형식.AutoSize = true;
            this.파일형식.Location = new System.Drawing.Point(178, 177);
            this.파일형식.Name = "파일형식";
            this.파일형식.Size = new System.Drawing.Size(31, 15);
            this.파일형식.TabIndex = 5;
            this.파일형식.Text = "png";
            // 
            // 위치
            // 
            this.위치.AutoSize = true;
            this.위치.Location = new System.Drawing.Point(178, 217);
            this.위치.Name = "위치";
            this.위치.Size = new System.Drawing.Size(88, 15);
            this.위치.TabIndex = 6;
            this.위치.Text = "C:\\Users\\";
            // 
            // 크기
            // 
            this.크기.AutoSize = true;
            this.크기.Location = new System.Drawing.Point(178, 263);
            this.크기.Name = "크기";
            this.크기.Size = new System.Drawing.Size(89, 15);
            this.크기.TabIndex = 7;
            this.크기.Text = "6515 바이트";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "만든 날짜: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "수정한 날짜: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "엑세스한 날짜: ";
            // 
            // 만든날짜
            // 
            this.만든날짜.AutoSize = true;
            this.만든날짜.Location = new System.Drawing.Point(178, 321);
            this.만든날짜.Name = "만든날짜";
            this.만든날짜.Size = new System.Drawing.Size(53, 15);
            this.만든날짜.TabIndex = 11;
            this.만든날짜.Text = "label10";
            // 
            // 수정한날짜
            // 
            this.수정한날짜.AutoSize = true;
            this.수정한날짜.Location = new System.Drawing.Point(178, 366);
            this.수정한날짜.Name = "수정한날짜";
            this.수정한날짜.Size = new System.Drawing.Size(53, 15);
            this.수정한날짜.TabIndex = 12;
            this.수정한날짜.Text = "label11";
            // 
            // 액세스한날짜
            // 
            this.액세스한날짜.AutoSize = true;
            this.액세스한날짜.Location = new System.Drawing.Point(178, 408);
            this.액세스한날짜.Name = "액세스한날짜";
            this.액세스한날짜.Size = new System.Drawing.Size(53, 15);
            this.액세스한날짜.TabIndex = 13;
            this.액세스한날짜.Text = "label12";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // image_File
            // 
            this.image_File.Location = new System.Drawing.Point(24, 23);
            this.image_File.Name = "image_File";
            this.image_File.Size = new System.Drawing.Size(124, 120);
            this.image_File.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_File.TabIndex = 0;
            this.image_File.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "avi.png");
            this.imageList1.Images.SetKeyName(1, "image.png");
            this.imageList1.Images.SetKeyName(2, "music.png");
            this.imageList1.Images.SetKeyName(3, "temp.png");
            this.imageList1.Images.SetKeyName(4, "text.png");
            // 
            // FileInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 503);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.액세스한날짜);
            this.Controls.Add(this.수정한날짜);
            this.Controls.Add(this.만든날짜);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.크기);
            this.Controls.Add(this.위치);
            this.Controls.Add(this.파일형식);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_fileName);
            this.Controls.Add(this.image_File);
            this.Name = "FileInformation";
            this.Text = "상세정보";
            this.Load += new System.EventHandler(this.FileInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image_File)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image_File;
        private System.Windows.Forms.TextBox txt_fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label 파일형식;
        private System.Windows.Forms.Label 위치;
        private System.Windows.Forms.Label 크기;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label 만든날짜;
        private System.Windows.Forms.Label 수정한날짜;
        private System.Windows.Forms.Label 액세스한날짜;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
    }
}