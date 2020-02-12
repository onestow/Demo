namespace Client
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPerCall = new System.Windows.Forms.TextBox();
            this.btnPerHit = new System.Windows.Forms.Button();
            this.tbPerSession = new System.Windows.Forms.TextBox();
            this.tbSingle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbPerCall2 = new System.Windows.Forms.TextBox();
            this.tbPerSession2 = new System.Windows.Forms.TextBox();
            this.tbSingle2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbMaxCall = new System.Windows.Forms.TextBox();
            this.btnMaxCall = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPerCall
            // 
            this.tbPerCall.Location = new System.Drawing.Point(77, 55);
            this.tbPerCall.Name = "tbPerCall";
            this.tbPerCall.Size = new System.Drawing.Size(323, 21);
            this.tbPerCall.TabIndex = 0;
            // 
            // btnPerHit
            // 
            this.btnPerHit.Location = new System.Drawing.Point(6, 20);
            this.btnPerHit.Name = "btnPerHit";
            this.btnPerHit.Size = new System.Drawing.Size(75, 23);
            this.btnPerHit.TabIndex = 1;
            this.btnPerHit.Text = "调用";
            this.btnPerHit.UseVisualStyleBackColor = true;
            this.btnPerHit.Click += new System.EventHandler(this.btnPerHit_Click);
            // 
            // tbPerSession
            // 
            this.tbPerSession.Location = new System.Drawing.Point(77, 82);
            this.tbPerSession.Name = "tbPerSession";
            this.tbPerSession.Size = new System.Drawing.Size(323, 21);
            this.tbPerSession.TabIndex = 0;
            // 
            // tbSingle
            // 
            this.tbSingle.Location = new System.Drawing.Point(77, 109);
            this.tbSingle.Name = "tbSingle";
            this.tbSingle.Size = new System.Drawing.Size(323, 21);
            this.tbSingle.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPerHit);
            this.groupBox1.Controls.Add(this.tbPerCall);
            this.groupBox1.Controls.Add(this.tbPerSession);
            this.groupBox1.Controls.Add(this.tbSingle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "每次点击创建连接";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Single";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "PerSession";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "PerCall";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.tbPerCall2);
            this.groupBox2.Controls.Add(this.tbPerSession2);
            this.groupBox2.Controls.Add(this.tbSingle2);
            this.groupBox2.Location = new System.Drawing.Point(12, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 171);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "启动时创建连接";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Single";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "PerSession";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "PerCall";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "调用";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbPerCall2
            // 
            this.tbPerCall2.Location = new System.Drawing.Point(77, 55);
            this.tbPerCall2.Name = "tbPerCall2";
            this.tbPerCall2.Size = new System.Drawing.Size(323, 21);
            this.tbPerCall2.TabIndex = 0;
            // 
            // tbPerSession2
            // 
            this.tbPerSession2.Location = new System.Drawing.Point(77, 82);
            this.tbPerSession2.Name = "tbPerSession2";
            this.tbPerSession2.Size = new System.Drawing.Size(323, 21);
            this.tbPerSession2.TabIndex = 0;
            // 
            // tbSingle2
            // 
            this.tbSingle2.Location = new System.Drawing.Point(77, 109);
            this.tbSingle2.Name = "tbSingle2";
            this.tbSingle2.Size = new System.Drawing.Size(323, 21);
            this.tbSingle2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbMaxCall);
            this.groupBox3.Controls.Add(this.btnMaxCall);
            this.groupBox3.Location = new System.Drawing.Point(424, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 203);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "maxcall测试";
            // 
            // tbMaxCall
            // 
            this.tbMaxCall.Location = new System.Drawing.Point(7, 48);
            this.tbMaxCall.Multiline = true;
            this.tbMaxCall.Name = "tbMaxCall";
            this.tbMaxCall.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMaxCall.Size = new System.Drawing.Size(367, 149);
            this.tbMaxCall.TabIndex = 1;
            // 
            // btnMaxCall
            // 
            this.btnMaxCall.Location = new System.Drawing.Point(7, 20);
            this.btnMaxCall.Name = "btnMaxCall";
            this.btnMaxCall.Size = new System.Drawing.Size(75, 23);
            this.btnMaxCall.TabIndex = 0;
            this.btnMaxCall.Text = "button1";
            this.btnMaxCall.UseVisualStyleBackColor = true;
            this.btnMaxCall.Click += new System.EventHandler(this.btnMaxCall_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(431, 231);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ReadOnly = true;
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMsg.Size = new System.Drawing.Size(367, 207);
            this.tbMsg.TabIndex = 1;
            this.tbMsg.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 450);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPerCall;
        private System.Windows.Forms.Button btnPerHit;
        private System.Windows.Forms.TextBox tbPerSession;
        private System.Windows.Forms.TextBox tbSingle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbPerCall2;
        private System.Windows.Forms.TextBox tbPerSession2;
        private System.Windows.Forms.TextBox tbSingle2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbMaxCall;
        private System.Windows.Forms.Button btnMaxCall;
        private System.Windows.Forms.TextBox tbMsg;
    }
}

