using PasswordGenerator;
using System;
using System.Configuration;

namespace View
{
    partial class Form1
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.trackBar1.ValueChanged += (x, y) => label3.Text = trackBar1.Value.ToString();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(25, 66);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 3;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(257, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Виберіть кількість слів в паролі: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Вибрати користувацький набір слів";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(OnFileSelect);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 53);
            this.button2.TabIndex = 3;
            this.button2.Text = "Згенерувати пароль";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(OnGenerateClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Size = new System.Drawing.Size(340, 180);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(25, 235);
            this.label2.Name = "label2";
            this.label2.ReadOnly = true;
            this.label2.Multiline = true;
            this.label2.AcceptsReturn = true;
            this.label2.TabIndex = 4;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = trackBar1.Value.ToString();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 492);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Password generator";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private void OnFileSelect(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
        }

        private void OnGenerateClick(object sender, EventArgs e)
        {
            var passwordGenerator = new PasswordGenerator.PasswordGenerator(Convert.ToInt64(ConfigurationManager.AppSettings.Get("seed")), path);
            var res = passwordGenerator.Generate(trackBar1.Value);
            this.label2.Clear();
            foreach(var pass in res.Passwords)
            {
                this.label2.Text += $"{pass}" + Environment.NewLine;
            }
            this.label2.Text += $"{Environment.NewLine}From file: {res.Path ?? "default"}{Environment.NewLine}Entropy is {res.Entropy}{Environment.NewLine}Entropy per symbol is {res.EntropyPerSymbol}";
        }

        private string path;

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox label2;
        private System.Windows.Forms.Label label3;
    }
}

