namespace OTP
{
    partial class OTP
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.encryptAllBtn = new System.Windows.Forms.Button();
            this.outputLocationBtn = new System.Windows.Forms.Button();
            this.outputLbl = new System.Windows.Forms.Label();
            this.fileSystemWatcherCB = new System.Windows.Forms.CheckBox();
            this.inputLbl = new System.Windows.Forms.Label();
            this.inputLocationBtn = new System.Windows.Forms.Button();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.keyStatusLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.programLogLv = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.encryptAllBtn);
            this.groupBox1.Controls.Add(this.outputLocationBtn);
            this.groupBox1.Controls.Add(this.outputLbl);
            this.groupBox1.Controls.Add(this.fileSystemWatcherCB);
            this.groupBox1.Controls.Add(this.inputLbl);
            this.groupBox1.Controls.Add(this.inputLocationBtn);
            this.groupBox1.Location = new System.Drawing.Point(13, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input And Output Location";
            // 
            // encryptAllBtn
            // 
            this.encryptAllBtn.Location = new System.Drawing.Point(174, 120);
            this.encryptAllBtn.Name = "encryptAllBtn";
            this.encryptAllBtn.Size = new System.Drawing.Size(169, 23);
            this.encryptAllBtn.TabIndex = 7;
            this.encryptAllBtn.Text = "Encrypt all in selecteed folder";
            this.encryptAllBtn.UseVisualStyleBackColor = true;
            this.encryptAllBtn.Click += new System.EventHandler(this.encryptAllBtn_Click);
            // 
            // outputLocationBtn
            // 
            this.outputLocationBtn.Location = new System.Drawing.Point(9, 65);
            this.outputLocationBtn.Name = "outputLocationBtn";
            this.outputLocationBtn.Size = new System.Drawing.Size(334, 23);
            this.outputLocationBtn.TabIndex = 6;
            this.outputLocationBtn.Text = "Select Output Location";
            this.outputLocationBtn.UseVisualStyleBackColor = true;
            this.outputLocationBtn.Click += new System.EventHandler(this.outputLocationBtn_Click);
            // 
            // outputLbl
            // 
            this.outputLbl.AutoSize = true;
            this.outputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLbl.Location = new System.Drawing.Point(6, 91);
            this.outputLbl.Name = "outputLbl";
            this.outputLbl.Size = new System.Drawing.Size(340, 13);
            this.outputLbl.TabIndex = 1;
            this.outputLbl.Text = "Default output location is the same as file location, but with postfix dec.";
            // 
            // fileSystemWatcherCB
            // 
            this.fileSystemWatcherCB.AutoSize = true;
            this.fileSystemWatcherCB.Location = new System.Drawing.Point(9, 126);
            this.fileSystemWatcherCB.Name = "fileSystemWatcherCB";
            this.fileSystemWatcherCB.Size = new System.Drawing.Size(159, 17);
            this.fileSystemWatcherCB.TabIndex = 5;
            this.fileSystemWatcherCB.Text = "Enable File System Watcher";
            this.fileSystemWatcherCB.UseVisualStyleBackColor = true;
            this.fileSystemWatcherCB.CheckedChanged += new System.EventHandler(this.fileSystemWatcherCB_CheckedChanged);
            // 
            // inputLbl
            // 
            this.inputLbl.AutoSize = true;
            this.inputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLbl.Location = new System.Drawing.Point(6, 48);
            this.inputLbl.Name = "inputLbl";
            this.inputLbl.Size = new System.Drawing.Size(29, 13);
            this.inputLbl.TabIndex = 4;
            this.inputLbl.Text = "Path";
            // 
            // inputLocationBtn
            // 
            this.inputLocationBtn.Location = new System.Drawing.Point(9, 20);
            this.inputLocationBtn.Name = "inputLocationBtn";
            this.inputLocationBtn.Size = new System.Drawing.Size(334, 23);
            this.inputLocationBtn.TabIndex = 0;
            this.inputLocationBtn.Text = "Select Input Location";
            this.inputLocationBtn.UseVisualStyleBackColor = true;
            this.inputLocationBtn.Click += new System.EventHandler(this.inputLocationBtn_Click);
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(8, 48);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(334, 23);
            this.decryptBtn.TabIndex = 0;
            this.decryptBtn.Text = "Select File For Decryption ";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(8, 19);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(334, 23);
            this.encryptBtn.TabIndex = 2;
            this.encryptBtn.Text = "Select File For Encryption ";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(40, 19);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(302, 20);
            this.textBoxKey.TabIndex = 4;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.decryptBtn);
            this.groupBox3.Controls.Add(this.encryptBtn);
            this.groupBox3.Location = new System.Drawing.Point(13, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 83);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption or Decryption";
            // 
            // keyStatusLbl
            // 
            this.keyStatusLbl.AutoSize = true;
            this.keyStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyStatusLbl.ForeColor = System.Drawing.Color.Red;
            this.keyStatusLbl.Location = new System.Drawing.Point(92, 59);
            this.keyStatusLbl.Name = "keyStatusLbl";
            this.keyStatusLbl.Size = new System.Drawing.Size(57, 20);
            this.keyStatusLbl.TabIndex = 7;
            this.keyStatusLbl.Text = "No key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Key Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.programLogLv);
            this.groupBox4.Location = new System.Drawing.Point(369, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(397, 369);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Program Log";
            // 
            // programLogLv
            // 
            this.programLogLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.fileName,
            this.Action});
            this.programLogLv.Location = new System.Drawing.Point(6, 14);
            this.programLogLv.Name = "programLogLv";
            this.programLogLv.Size = new System.Drawing.Size(385, 349);
            this.programLogLv.TabIndex = 0;
            this.programLogLv.UseCompatibleStateImageBehavior = false;
            this.programLogLv.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "#";
            this.Number.Width = 34;
            // 
            // fileName
            // 
            this.fileName.Text = "File Name";
            this.fileName.Width = 184;
            // 
            // Action
            // 
            this.Action.Text = "Action";
            this.Action.Width = 110;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.keyStatusLbl);
            this.groupBox2.Controls.Add(this.textBoxKey);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 112);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(211, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Key can be only abeceda!";
            // 
            // OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(778, 393);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTP";
            this.Load += new System.EventHandler(this.OTP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button inputLocationBtn;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Label inputLbl;
        private System.Windows.Forms.Label outputLbl;
        private System.Windows.Forms.CheckBox fileSystemWatcherCB;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label keyStatusLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView programLogLv;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.Button outputLocationBtn;
        private System.Windows.Forms.Button encryptAllBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
    }
}

