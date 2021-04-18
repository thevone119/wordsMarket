namespace WordsMarket4
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.text_path = new System.Windows.Forms.TextBox();
            this.but_market = new System.Windows.Forms.Button();
            this.but_path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.text_wordCount = new System.Windows.Forms.TextBox();
            this.text_wkCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_imgCount = new System.Windows.Forms.TextBox();
            this.but_img = new System.Windows.Forms.Button();
            this.text_img = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.but_test = new System.Windows.Forms.Button();
            this.text_width = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "成语库路径";
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(97, 18);
            this.text_path.Name = "text_path";
            this.text_path.Size = new System.Drawing.Size(390, 21);
            this.text_path.TabIndex = 1;
            // 
            // but_market
            // 
            this.but_market.Location = new System.Drawing.Point(479, 529);
            this.but_market.Name = "but_market";
            this.but_market.Size = new System.Drawing.Size(75, 23);
            this.but_market.TabIndex = 2;
            this.but_market.Text = "生成";
            this.but_market.UseVisualStyleBackColor = true;
            this.but_market.Click += new System.EventHandler(this.but_market_Click);
            // 
            // but_path
            // 
            this.but_path.Location = new System.Drawing.Point(493, 18);
            this.but_path.Name = "but_path";
            this.but_path.Size = new System.Drawing.Size(75, 23);
            this.but_path.TabIndex = 3;
            this.but_path.Text = "选择";
            this.but_path.UseVisualStyleBackColor = true;
            this.but_path.Click += new System.EventHandler(this.but_path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "单张成语数";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // text_wordCount
            // 
            this.text_wordCount.Location = new System.Drawing.Point(97, 126);
            this.text_wordCount.Name = "text_wordCount";
            this.text_wordCount.Size = new System.Drawing.Size(75, 21);
            this.text_wordCount.TabIndex = 5;
            this.text_wordCount.Text = "5";
            // 
            // text_wkCount
            // 
            this.text_wkCount.Location = new System.Drawing.Point(398, 123);
            this.text_wkCount.Name = "text_wkCount";
            this.text_wkCount.Size = new System.Drawing.Size(75, 21);
            this.text_wkCount.TabIndex = 6;
            this.text_wkCount.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "挖孔数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(622, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "生成图片数";
            // 
            // text_imgCount
            // 
            this.text_imgCount.Location = new System.Drawing.Point(693, 123);
            this.text_imgCount.Name = "text_imgCount";
            this.text_imgCount.Size = new System.Drawing.Size(75, 21);
            this.text_imgCount.TabIndex = 8;
            this.text_imgCount.Text = "100";
            // 
            // but_img
            // 
            this.but_img.Location = new System.Drawing.Point(493, 54);
            this.but_img.Name = "but_img";
            this.but_img.Size = new System.Drawing.Size(75, 23);
            this.but_img.TabIndex = 12;
            this.but_img.Text = "选择";
            this.but_img.UseVisualStyleBackColor = true;
            this.but_img.Click += new System.EventHandler(this.but_img_Click);
            // 
            // text_img
            // 
            this.text_img.Location = new System.Drawing.Point(97, 54);
            this.text_img.Name = "text_img";
            this.text_img.Size = new System.Drawing.Size(390, 21);
            this.text_img.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "生成图片路径";
            // 
            // but_test
            // 
            this.but_test.Location = new System.Drawing.Point(598, 529);
            this.but_test.Name = "but_test";
            this.but_test.Size = new System.Drawing.Size(75, 23);
            this.but_test.TabIndex = 13;
            this.but_test.Text = "测试";
            this.but_test.UseVisualStyleBackColor = true;
            this.but_test.Click += new System.EventHandler(this.but_test_Click);
            // 
            // text_width
            // 
            this.text_width.Location = new System.Drawing.Point(97, 176);
            this.text_width.Name = "text_width";
            this.text_width.Size = new System.Drawing.Size(75, 21);
            this.text_width.TabIndex = 15;
            this.text_width.Text = "9";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "方阵";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 575);
            this.Controls.Add(this.text_width);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.but_test);
            this.Controls.Add(this.but_img);
            this.Controls.Add(this.text_img);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_imgCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_wkCount);
            this.Controls.Add(this.text_wordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_path);
            this.Controls.Add(this.but_market);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.label1);
            this.Name = "main";
            this.Text = "成语生产器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button but_market;
        private System.Windows.Forms.Button but_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_wordCount;
        private System.Windows.Forms.TextBox text_wkCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_imgCount;
        private System.Windows.Forms.Button but_img;
        private System.Windows.Forms.TextBox text_img;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button but_test;
        private System.Windows.Forms.TextBox text_width;
        private System.Windows.Forms.Label label6;
    }
}

