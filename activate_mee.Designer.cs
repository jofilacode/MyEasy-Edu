namespace My_Easy_Edu_V_1._0
{
    partial class activate_mee
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.confirmpassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorbox = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.password = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.username = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pin = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.schoolname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.countdown = new System.Windows.Forms.Label();
            this.schoolid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(721, 160);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(32, 35);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.Symbol = "";
            this.buttonX2.SymbolSize = 12F;
            this.buttonX2.TabIndex = 16;
            this.buttonX2.Tooltip = "Copy School-ID";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Confirm password:";
            // 
            // confirmpassword
            // 
            this.confirmpassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.confirmpassword.Border.Class = "TextBoxBorder";
            this.confirmpassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.confirmpassword.Border.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpassword.DisabledBackColor = System.Drawing.Color.White;
            this.confirmpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpassword.ForeColor = System.Drawing.Color.Black;
            this.confirmpassword.Location = new System.Drawing.Point(57, 344);
            this.confirmpassword.Name = "confirmpassword";
            this.confirmpassword.PreventEnterBeep = true;
            this.confirmpassword.Size = new System.Drawing.Size(700, 34);
            this.confirmpassword.TabIndex = 14;
            this.confirmpassword.UseSystemPasswordChar = true;
            this.confirmpassword.WatermarkText = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "School-ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Activation pin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "School Details (e.g Name of School, Address and Phone Number):";
            // 
            // errorbox
            // 
            this.errorbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.errorbox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.errorbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox.ForeColor = System.Drawing.Color.Red;
            this.errorbox.Location = new System.Drawing.Point(53, 86);
            this.errorbox.Name = "errorbox";
            this.errorbox.PaddingBottom = 10;
            this.errorbox.PaddingLeft = 10;
            this.errorbox.PaddingRight = 10;
            this.errorbox.PaddingTop = 10;
            this.errorbox.Size = new System.Drawing.Size(682, 41);
            this.errorbox.Symbol = "";
            this.errorbox.SymbolColor = System.Drawing.Color.Red;
            this.errorbox.TabIndex = 56;
            this.errorbox.TextAlignment = System.Drawing.StringAlignment.Center;
            this.errorbox.Visible = false;
            this.errorbox.WordWrap = true;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(0, 0);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(848, 34);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.SymbolColor = System.Drawing.Color.Red;
            this.buttonX1.SymbolSize = 16F;
            this.buttonX1.TabIndex = 55;
            this.buttonX1.Text = "Exit";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(848, 49);
            this.label1.TabIndex = 54;
            this.label1.Text = "MY EASY EDU ( Version 1.0) SYSTEM ACTIVATOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(604, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Activate Sars";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.password.Border.Class = "TextBoxBorder";
            this.password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.password.Border.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.DisabledBackColor = System.Drawing.Color.White;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Black;
            this.password.Location = new System.Drawing.Point(57, 285);
            this.password.Name = "password";
            this.password.PreventEnterBeep = true;
            this.password.Size = new System.Drawing.Size(700, 34);
            this.password.TabIndex = 7;
            this.password.UseSystemPasswordChar = true;
            this.password.WatermarkText = "Password";
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.username.Border.Class = "TextBoxBorder";
            this.username.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.username.Border.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.DisabledBackColor = System.Drawing.Color.White;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Black;
            this.username.Location = new System.Drawing.Point(57, 225);
            this.username.Name = "username";
            this.username.PreventEnterBeep = true;
            this.username.Size = new System.Drawing.Size(700, 34);
            this.username.TabIndex = 6;
            this.username.WatermarkText = "Username";
            // 
            // pin
            // 
            this.pin.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.pin.Border.Class = "TextBoxBorder";
            this.pin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pin.Border.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pin.DisabledBackColor = System.Drawing.Color.White;
            this.pin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pin.ForeColor = System.Drawing.Color.Black;
            this.pin.Location = new System.Drawing.Point(58, 99);
            this.pin.Name = "pin";
            this.pin.PreventEnterBeep = true;
            this.pin.Size = new System.Drawing.Size(700, 34);
            this.pin.TabIndex = 4;
            this.pin.WatermarkText = "Activation Pin";
            // 
            // schoolname
            // 
            this.schoolname.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.schoolname.Border.Class = "TextBoxBorder";
            this.schoolname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.schoolname.Border.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schoolname.DisabledBackColor = System.Drawing.Color.White;
            this.schoolname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schoolname.ForeColor = System.Drawing.Color.Black;
            this.schoolname.Location = new System.Drawing.Point(58, 39);
            this.schoolname.Name = "schoolname";
            this.schoolname.PreventEnterBeep = true;
            this.schoolname.Size = new System.Drawing.Size(700, 34);
            this.schoolname.TabIndex = 3;
            this.schoolname.WatermarkText = "School Details (e.g Name of School, Address and Phone Number)";
            // 
            // countdown
            // 
            this.countdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.countdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdown.ForeColor = System.Drawing.Color.White;
            this.countdown.Location = new System.Drawing.Point(736, 84);
            this.countdown.Name = "countdown";
            this.countdown.Size = new System.Drawing.Size(63, 43);
            this.countdown.TabIndex = 57;
            this.countdown.Text = "11";
            this.countdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.countdown.Visible = false;
            // 
            // schoolid
            // 
            this.schoolid.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.schoolid.Border.Class = "TextBoxBorder";
            this.schoolid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.schoolid.Border.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schoolid.DisabledBackColor = System.Drawing.Color.White;
            this.schoolid.Enabled = false;
            this.schoolid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schoolid.ForeColor = System.Drawing.Color.Black;
            this.schoolid.Location = new System.Drawing.Point(57, 161);
            this.schoolid.Name = "schoolid";
            this.schoolid.PreventEnterBeep = true;
            this.schoolid.Size = new System.Drawing.Size(656, 34);
            this.schoolid.TabIndex = 5;
            this.schoolid.WatermarkText = "School-ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.confirmpassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.schoolid);
            this.groupBox1.Controls.Add(this.pin);
            this.groupBox1.Controls.Add(this.schoolname);
            this.groupBox1.Location = new System.Drawing.Point(16, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 434);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // activate_mee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(848, 578);
            this.Controls.Add(this.errorbox);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.countdown);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "activate_mee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "activate_mee";
            this.Load += new System.EventHandler(this.activate_mee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX confirmpassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.LabelX errorbox;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.Controls.TextBoxX password;
        private DevComponents.DotNetBar.Controls.TextBoxX username;
        private DevComponents.DotNetBar.Controls.TextBoxX pin;
        private DevComponents.DotNetBar.Controls.TextBoxX schoolname;
        private System.Windows.Forms.Label countdown;
        private DevComponents.DotNetBar.Controls.TextBoxX schoolid;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}