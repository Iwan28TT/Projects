namespace DiscordCounter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            start = new Button();
            textEmail = new TextBox();
            textWw = new TextBox();
            textChannel = new TextBox();
            textUsername = new TextBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // start
            // 
            start.ForeColor = SystemColors.Highlight;
            start.Location = new Point(442, 427);
            start.Name = "start";
            start.Size = new Size(152, 68);
            start.TabIndex = 0;
            start.Text = "Start the bot";
            start.UseVisualStyleBackColor = true;
            start.Click += button1_Click;
            // 
            // textEmail
            // 
            textEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textEmail.Location = new Point(344, 166);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(360, 23);
            textEmail.TabIndex = 1;
            textEmail.TextChanged += textEmail_TextChanged;
            // 
            // textWw
            // 
            textWw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textWw.Location = new Point(344, 219);
            textWw.Name = "textWw";
            textWw.Size = new Size(360, 23);
            textWw.TabIndex = 2;
            // 
            // textChannel
            // 
            textChannel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textChannel.Location = new Point(344, 279);
            textChannel.Name = "textChannel";
            textChannel.Size = new Size(360, 23);
            textChannel.TabIndex = 3;
            // 
            // textUsername
            // 
            textUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textUsername.Location = new Point(344, 334);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(360, 23);
            textUsername.TabIndex = 4;
            textUsername.TextChanged += textUsername_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.unnamed;
            pictureBox1.Location = new Point(54, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 178);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 530);
            panel1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(167, 484);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 6;
            label3.Text = "IwanVFX#1986";
            label3.Click += label2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(167, 464);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 6;
            label2.Text = "Developed by";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 222);
            label1.MinimumSize = new Size(50, 0);
            label1.Name = "label1";
            label1.Size = new Size(268, 20);
            label1.TabIndex = 6;
            label1.Text = "Welcome to the Discord Counter Bot";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(698, 12);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 7;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(410, 75);
            label4.Name = "label4";
            label4.Size = new Size(204, 24);
            label4.TabIndex = 6;
            label4.Text = "Enter your details here ";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Highlight;
            label5.Location = new Point(483, 153);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 6;
            label5.Text = "Discord Mail";
            label5.Click += label4_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Highlight;
            label6.Location = new Point(465, 206);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 6;
            label6.Text = "Discord Password";
            label6.Click += label4_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Highlight;
            label7.Location = new Point(468, 265);
            label7.Name = "label7";
            label7.Size = new Size(113, 15);
            label7.TabIndex = 6;
            label7.Text = "Discord Channel ID";
            label7.Click += label4_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Highlight;
            label8.Location = new Point(441, 321);
            label8.Name = "label8";
            label8.Size = new Size(162, 15);
            label8.TabIndex = 6;
            label8.Text = "Discord Username without #";
            label8.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 530);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(textUsername);
            Controls.Add(textChannel);
            Controls.Add(textWw);
            Controls.Add(textEmail);
            Controls.Add(start);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button start;
        private TextBox textEmail;
        private TextBox textWw;
        private TextBox textChannel;
        private TextBox textUsername;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}