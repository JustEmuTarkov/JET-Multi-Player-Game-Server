using System;
using System.Drawing;
using System.Windows.Forms;

namespace JET.OldLauncher
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Field_SelectEdition = new System.Windows.Forms.ComboBox();
            this.Label_SelectEdition = new System.Windows.Forms.Label();
            this.Field_Email = new System.Windows.Forms.TextBox();
            this.Label_Email = new System.Windows.Forms.Label();
            this.Field_Password = new System.Windows.Forms.TextBox();
            this.Label_Password = new System.Windows.Forms.Label();
            this.BTN_Process = new System.Windows.Forms.Button();
            this.BTN_Side_1 = new System.Windows.Forms.Button();
            this.BTN_Side_2 = new System.Windows.Forms.Button();
            this.BTN_Side_3 = new System.Windows.Forms.Button();
            this.BTN_Side_4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_Show_Password = new System.Windows.Forms.Button();
            this.Field_AddServer = new System.Windows.Forms.TextBox();
            this.Label_Url = new System.Windows.Forms.Label();
            this.Label_Server = new System.Windows.Forms.Label();
            this.Field_SelectServer = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBL_LoginAs = new System.Windows.Forms.Label();
            this.BTN_GenLaunchArgs = new System.Windows.Forms.Button();
            this.Text_LaunchArgs = new System.Windows.Forms.TextBox();
            this.UpdateTick = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "JET Launcher";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // Field_SelectEdition
            // 
            this.Field_SelectEdition.BackColor = System.Drawing.Color.Black;
            this.Field_SelectEdition.DropDownHeight = 107;
            this.Field_SelectEdition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_SelectEdition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Field_SelectEdition.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Field_SelectEdition.FormattingEnabled = true;
            this.Field_SelectEdition.IntegralHeight = false;
            this.Field_SelectEdition.ItemHeight = 21;
            this.Field_SelectEdition.Location = new System.Drawing.Point(112, 38);
            this.Field_SelectEdition.Name = "Field_SelectEdition";
            this.Field_SelectEdition.Size = new System.Drawing.Size(230, 29);
            this.Field_SelectEdition.TabIndex = 6;
            this.Field_SelectEdition.Text = "No editions available";
            this.Field_SelectEdition.Visible = false;
            // 
            // Label_SelectEdition
            // 
            this.Label_SelectEdition.AutoSize = true;
            this.Label_SelectEdition.BackColor = System.Drawing.Color.Transparent;
            this.Label_SelectEdition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SelectEdition.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label_SelectEdition.Location = new System.Drawing.Point(48, 42);
            this.Label_SelectEdition.Name = "Label_SelectEdition";
            this.Label_SelectEdition.Size = new System.Drawing.Size(58, 21);
            this.Label_SelectEdition.TabIndex = 7;
            this.Label_SelectEdition.Text = "Edition";
            this.Label_SelectEdition.Visible = false;
            // 
            // Field_Email
            // 
            this.Field_Email.BackColor = System.Drawing.Color.Black;
            this.Field_Email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Field_Email.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Field_Email.Location = new System.Drawing.Point(112, 73);
            this.Field_Email.Name = "Field_Email";
            this.Field_Email.Size = new System.Drawing.Size(230, 29);
            this.Field_Email.TabIndex = 9;
            this.Field_Email.Visible = false;
            // 
            // Label_Email
            // 
            this.Label_Email.AutoSize = true;
            this.Label_Email.BackColor = System.Drawing.Color.Transparent;
            this.Label_Email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Email.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label_Email.Location = new System.Drawing.Point(25, 76);
            this.Label_Email.Name = "Label_Email";
            this.Label_Email.Size = new System.Drawing.Size(81, 21);
            this.Label_Email.TabIndex = 8;
            this.Label_Email.Text = "Username";
            this.Label_Email.Visible = false;
            // 
            // Field_Password
            // 
            this.Field_Password.BackColor = System.Drawing.Color.Black;
            this.Field_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Field_Password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Field_Password.Location = new System.Drawing.Point(112, 108);
            this.Field_Password.Name = "Field_Password";
            this.Field_Password.Size = new System.Drawing.Size(203, 29);
            this.Field_Password.TabIndex = 36;
            this.Field_Password.Visible = false;
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.BackColor = System.Drawing.Color.Transparent;
            this.Label_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label_Password.Location = new System.Drawing.Point(30, 111);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(76, 21);
            this.Label_Password.TabIndex = 35;
            this.Label_Password.Text = "Password";
            this.Label_Password.Visible = false;
            // 
            // BTN_Process
            // 
            this.BTN_Process.BackColor = System.Drawing.Color.Black;
            this.BTN_Process.Enabled = false;
            this.BTN_Process.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_Process.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Process.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Process.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_Process.Location = new System.Drawing.Point(139, 281);
            this.BTN_Process.Name = "BTN_Process";
            this.BTN_Process.Size = new System.Drawing.Size(218, 45);
            this.BTN_Process.TabIndex = 41;
            this.BTN_Process.Text = "Processing...";
            this.BTN_Process.UseVisualStyleBackColor = false;
            this.BTN_Process.Click += new System.EventHandler(this.ProcessMainButtonFunction);
            // 
            // BTN_Side_1
            // 
            this.BTN_Side_1.BackColor = System.Drawing.Color.Black;
            this.BTN_Side_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Side_1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Side_1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_Side_1.Location = new System.Drawing.Point(363, 93);
            this.BTN_Side_1.Name = "BTN_Side_1";
            this.BTN_Side_1.Size = new System.Drawing.Size(131, 23);
            this.BTN_Side_1.TabIndex = 42;
            this.BTN_Side_1.Text = "Side 1";
            this.BTN_Side_1.UseVisualStyleBackColor = false;
            this.BTN_Side_1.Visible = false;
            this.BTN_Side_1.Click += new System.EventHandler(this.SideButton_1_Click);
            // 
            // BTN_Side_2
            // 
            this.BTN_Side_2.BackColor = System.Drawing.Color.Black;
            this.BTN_Side_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Side_2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Side_2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_Side_2.Location = new System.Drawing.Point(363, 122);
            this.BTN_Side_2.Name = "BTN_Side_2";
            this.BTN_Side_2.Size = new System.Drawing.Size(131, 23);
            this.BTN_Side_2.TabIndex = 43;
            this.BTN_Side_2.Text = "Side 2";
            this.BTN_Side_2.UseVisualStyleBackColor = false;
            this.BTN_Side_2.Visible = false;
            this.BTN_Side_2.Click += new System.EventHandler(this.SideButton_2_Click);
            // 
            // BTN_Side_3
            // 
            this.BTN_Side_3.BackColor = System.Drawing.Color.Black;
            this.BTN_Side_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Side_3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Side_3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_Side_3.Location = new System.Drawing.Point(364, 151);
            this.BTN_Side_3.Name = "BTN_Side_3";
            this.BTN_Side_3.Size = new System.Drawing.Size(131, 23);
            this.BTN_Side_3.TabIndex = 44;
            this.BTN_Side_3.Text = "Side 3";
            this.BTN_Side_3.UseVisualStyleBackColor = false;
            this.BTN_Side_3.Visible = false;
            this.BTN_Side_3.Click += new System.EventHandler(this.SideButton_3_Click);
            // 
            // BTN_Side_4
            // 
            this.BTN_Side_4.BackColor = System.Drawing.Color.Black;
            this.BTN_Side_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Side_4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Side_4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_Side_4.Location = new System.Drawing.Point(364, 180);
            this.BTN_Side_4.Name = "BTN_Side_4";
            this.BTN_Side_4.Size = new System.Drawing.Size(131, 23);
            this.BTN_Side_4.TabIndex = 45;
            this.BTN_Side_4.Text = "Side 4";
            this.BTN_Side_4.UseVisualStyleBackColor = false;
            this.BTN_Side_4.Visible = false;
            this.BTN_Side_4.Click += new System.EventHandler(this.SideButton_4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BTN_Show_Password);
            this.panel1.Controls.Add(this.Field_AddServer);
            this.panel1.Controls.Add(this.Label_Url);
            this.panel1.Controls.Add(this.Label_Server);
            this.panel1.Controls.Add(this.Field_SelectServer);
            this.panel1.Controls.Add(this.Field_SelectEdition);
            this.panel1.Controls.Add(this.Label_SelectEdition);
            this.panel1.Controls.Add(this.Field_Email);
            this.panel1.Controls.Add(this.Label_Email);
            this.panel1.Controls.Add(this.Field_Password);
            this.panel1.Controls.Add(this.Label_Password);
            this.panel1.Location = new System.Drawing.Point(12, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 182);
            this.panel1.TabIndex = 46;
            // 
            // BTN_Show_Password
            // 
            this.BTN_Show_Password.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Show_Password.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Show_Password.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Show_Password.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Show_Password.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Show_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Show_Password.Image = ((System.Drawing.Image)(resources.GetObject("BTN_Show_Password.Image")));
            this.BTN_Show_Password.Location = new System.Drawing.Point(313, 108);
            this.BTN_Show_Password.Name = "BTN_Show_Password";
            this.BTN_Show_Password.Size = new System.Drawing.Size(29, 29);
            this.BTN_Show_Password.TabIndex = 0;
            this.BTN_Show_Password.TabStop = false;
            this.BTN_Show_Password.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_Show_Password.UseVisualStyleBackColor = false;
            this.BTN_Show_Password.Visible = false;
            this.BTN_Show_Password.Click += new System.EventHandler(this.BTN_Show_Password_Click);
            // 
            // Field_AddServer
            // 
            this.Field_AddServer.BackColor = System.Drawing.Color.Black;
            this.Field_AddServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Field_AddServer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Field_AddServer.Location = new System.Drawing.Point(112, 143);
            this.Field_AddServer.Name = "Field_AddServer";
            this.Field_AddServer.Size = new System.Drawing.Size(230, 29);
            this.Field_AddServer.TabIndex = 38;
            this.Field_AddServer.Text = "https://127.0.0.1";
            this.Field_AddServer.Visible = false;
            // 
            // Label_Url
            // 
            this.Label_Url.AutoSize = true;
            this.Label_Url.BackColor = System.Drawing.Color.Transparent;
            this.Label_Url.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Url.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label_Url.Location = new System.Drawing.Point(75, 146);
            this.Label_Url.Name = "Label_Url";
            this.Label_Url.Size = new System.Drawing.Size(31, 21);
            this.Label_Url.TabIndex = 37;
            this.Label_Url.Text = "Url";
            this.Label_Url.Visible = false;
            // 
            // Label_Server
            // 
            this.Label_Server.AutoSize = true;
            this.Label_Server.BackColor = System.Drawing.Color.Transparent;
            this.Label_Server.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Server.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label_Server.Location = new System.Drawing.Point(51, 7);
            this.Label_Server.Name = "Label_Server";
            this.Label_Server.Size = new System.Drawing.Size(55, 21);
            this.Label_Server.TabIndex = 20;
            this.Label_Server.Text = "Server";
            this.Label_Server.Visible = false;
            // 
            // Field_SelectServer
            // 
            this.Field_SelectServer.BackColor = System.Drawing.Color.Black;
            this.Field_SelectServer.DropDownHeight = 107;
            this.Field_SelectServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_SelectServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Field_SelectServer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Field_SelectServer.FormattingEnabled = true;
            this.Field_SelectServer.IntegralHeight = false;
            this.Field_SelectServer.ItemHeight = 21;
            this.Field_SelectServer.Location = new System.Drawing.Point(112, 3);
            this.Field_SelectServer.Name = "Field_SelectServer";
            this.Field_SelectServer.Size = new System.Drawing.Size(230, 29);
            this.Field_SelectServer.TabIndex = 19;
            this.Field_SelectServer.Text = "No servers available";
            this.Field_SelectServer.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JET.Launcher.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Title.Location = new System.Drawing.Point(91, 21);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(179, 29);
            this.Title.TabIndex = 48;
            this.Title.Text = "JustEmuTarkov";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(206, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Launcher";
            // 
            // LBL_LoginAs
            // 
            this.LBL_LoginAs.AutoSize = true;
            this.LBL_LoginAs.BackColor = System.Drawing.Color.Transparent;
            this.LBL_LoginAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_LoginAs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LBL_LoginAs.Location = new System.Drawing.Point(93, 69);
            this.LBL_LoginAs.Name = "LBL_LoginAs";
            this.LBL_LoginAs.Size = new System.Drawing.Size(79, 16);
            this.LBL_LoginAs.TabIndex = 50;
            this.LBL_LoginAs.Text = "Logged as: ";
            this.LBL_LoginAs.Visible = false;
            // 
            // BTN_GenLaunchArgs
            // 
            this.BTN_GenLaunchArgs.BackColor = System.Drawing.Color.Black;
            this.BTN_GenLaunchArgs.Enabled = false;
            this.BTN_GenLaunchArgs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_GenLaunchArgs.ForeColor = System.Drawing.Color.White;
            this.BTN_GenLaunchArgs.Location = new System.Drawing.Point(364, 252);
            this.BTN_GenLaunchArgs.Name = "BTN_GenLaunchArgs";
            this.BTN_GenLaunchArgs.Size = new System.Drawing.Size(131, 23);
            this.BTN_GenLaunchArgs.TabIndex = 51;
            this.BTN_GenLaunchArgs.Text = "Generate launch args";
            this.BTN_GenLaunchArgs.UseVisualStyleBackColor = false;
            this.BTN_GenLaunchArgs.Click += new System.EventHandler(this.BTN_GenLaunchArgs_Click);
            // 
            // Text_LaunchArgs
            // 
            this.Text_LaunchArgs.BackColor = System.Drawing.Color.Black;
            this.Text_LaunchArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_LaunchArgs.Enabled = false;
            this.Text_LaunchArgs.ForeColor = System.Drawing.Color.Silver;
            this.Text_LaunchArgs.Location = new System.Drawing.Point(364, 281);
            this.Text_LaunchArgs.Multiline = true;
            this.Text_LaunchArgs.Name = "Text_LaunchArgs";
            this.Text_LaunchArgs.Size = new System.Drawing.Size(131, 45);
            this.Text_LaunchArgs.TabIndex = 52;
            // 
            // UpdateTick
            // 
            this.UpdateTick.Interval = 50;
            this.UpdateTick.Tick += new System.EventHandler(this.FormUpdate);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(504, 335);
            this.Controls.Add(this.Text_LaunchArgs);
            this.Controls.Add(this.BTN_GenLaunchArgs);
            this.Controls.Add(this.LBL_LoginAs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTN_Side_4);
            this.Controls.Add(this.BTN_Side_3);
            this.Controls.Add(this.BTN_Side_2);
            this.Controls.Add(this.BTN_Side_1);
            this.Controls.Add(this.BTN_Process);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "JustEmuTarkov - Launcher";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon TrayIcon;
		private System.Windows.Forms.Label Label_SelectEdition;
		private System.Windows.Forms.TextBox Field_Email;
		private System.Windows.Forms.Label Label_Email;
		private System.Windows.Forms.TextBox Field_Password;
		private System.Windows.Forms.Label Label_Password;
		private System.Windows.Forms.ComboBox Field_SelectEdition;
        private System.Windows.Forms.Button BTN_Process;
        private System.Windows.Forms.Button BTN_Side_1;
        private System.Windows.Forms.Button BTN_Side_2;
        private System.Windows.Forms.Button BTN_Side_3;
        private System.Windows.Forms.Button BTN_Side_4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label_Server;
        private System.Windows.Forms.ComboBox Field_SelectServer;
        private System.Windows.Forms.TextBox Field_AddServer;
        private System.Windows.Forms.Label Label_Url;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_LoginAs;
        private System.Windows.Forms.Button BTN_GenLaunchArgs;
        private System.Windows.Forms.TextBox Text_LaunchArgs;
        private System.Windows.Forms.Timer UpdateTick;
        private System.Windows.Forms.Button BTN_Show_Password;
    }
}

