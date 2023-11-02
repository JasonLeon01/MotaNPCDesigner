namespace NPCDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button5 = new Button();
            button6 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            listBox2 = new ListBox();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 250);
            button1.Name = "button1";
            button1.Size = new Size(84, 25);
            button1.TabIndex = 0;
            button1.Text = "新建对话";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 281);
            button2.Name = "button2";
            button2.Size = new Size(84, 24);
            button2.TabIndex = 1;
            button2.Text = "删除对话";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(12, 11);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(85, 225);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(213, 78);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(262, 176);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(390, 17);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(66, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "0";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(287, 49);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(99, 23);
            textBox3.TabIndex = 5;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(213, 19);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 6;
            label1.Text = "对话事件";
            // 
            // button3
            // 
            button3.Location = new Point(275, 15);
            button3.Name = "button3";
            button3.Size = new Size(47, 25);
            button3.TabIndex = 7;
            button3.Text = "主角";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(328, 15);
            button4.Name = "button4";
            button4.Size = new Size(56, 25);
            button4.TabIndex = 8;
            button4.Text = "本事件";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.Location = new Point(462, 12);
            label2.Name = "label2";
            label2.Size = new Size(96, 39);
            label2.TabIndex = 9;
            label2.Text = "有其他确定事件号的在此处修改";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(213, 55);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 10;
            label3.Text = "对话人名称";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(392, 52);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 11;
            label4.Text = "此处可为空";
            // 
            // button5
            // 
            button5.Location = new Point(116, 250);
            button5.Name = "button5";
            button5.Size = new Size(78, 25);
            button5.TabIndex = 12;
            button5.Text = "增添";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(116, 281);
            button6.Name = "button6";
            button6.Size = new Size(78, 25);
            button6.TabIndex = 13;
            button6.Text = "删除";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(213, 261);
            label5.Name = "label5";
            label5.Size = new Size(104, 17);
            label5.TabIndex = 14;
            label5.Text = "结束后转换的名称";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(323, 258);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(78, 23);
            textBox4.TabIndex = 15;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(407, 261);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 16;
            label6.Text = "此处可为空";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(481, 78);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(75, 21);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "是否淡出";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(213, 285);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(111, 21);
            checkBox2.TabIndex = 18;
            checkBox2.Text = "转换后立刻执行";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 17;
            listBox2.Location = new Point(110, 11);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(85, 225);
            listBox2.TabIndex = 19;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // button7
            // 
            button7.Location = new Point(323, 285);
            button7.Name = "button7";
            button7.Size = new Size(150, 25);
            button7.TabIndex = 20;
            button7.Text = "保存文件";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(560, 322);
            Controls.Add(button7);
            Controls.Add(listBox2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "对话编辑器";
            Load += Form1_load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private ListBox listBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Button button3;
        private Button button4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button5;
        private Button button6;
        private Label label5;
        private TextBox textBox4;
        private Label label6;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ListBox listBox2;
        private Button button7;
    }
}