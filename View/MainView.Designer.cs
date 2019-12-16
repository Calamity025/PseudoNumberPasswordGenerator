using PasswordGenerator;
using System;
using System.Configuration;

namespace View
{
    partial class MainView
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
            this.passwordLengthTrackBar = new System.Windows.Forms.TrackBar();
            this.trackBarLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.changeDicewareWordList = new System.Windows.Forms.Button();
            this.generatePasswordButton = new System.Windows.Forms.Button();
            this.resultTextbox = new System.Windows.Forms.TextBox();
            this.trackBarValueLabel = new System.Windows.Forms.Label();
            this.algoritmSelector1 = new System.Windows.Forms.RadioButton();
            this.algoritmSelector2 = new System.Windows.Forms.RadioButton();
            this.algorithmSelectorLabel = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthTrackBar)).BeginInit();
            this.passwordLengthTrackBar.ValueChanged += (x, y) => trackBarValueLabel.Text = passwordLengthTrackBar.Value.ToString();
            this.SuspendLayout();
            // 
            // passwordLengthTrackBar
            // 
            this.passwordLengthTrackBar.Location = new System.Drawing.Point(25, 66);
            this.passwordLengthTrackBar.Maximum = 20;
            this.passwordLengthTrackBar.Minimum = 3;
            this.passwordLengthTrackBar.Name = "trackBar1";
            this.passwordLengthTrackBar.Size = new System.Drawing.Size(257, 45);
            this.passwordLengthTrackBar.TabIndex = 0;
            this.passwordLengthTrackBar.Value = 6;
            // 
            // trackBarLabel
            // 
            this.trackBarLabel.AutoSize = true;
            this.trackBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.trackBarLabel.Location = new System.Drawing.Point(22, 32);
            this.trackBarLabel.Name = "label1";
            this.trackBarLabel.Size = new System.Drawing.Size(302, 24);
            this.trackBarLabel.TabIndex = 1;
            this.trackBarLabel.Text = "Кількість слів або символів: ";
            // 
            // changeDicewareWordList
            // 
            this.changeDicewareWordList.Location = new System.Drawing.Point(25, 120);
            this.changeDicewareWordList.Name = "button1";
            this.changeDicewareWordList.Size = new System.Drawing.Size(150, 40);
            this.changeDicewareWordList.TabIndex = 2;
            this.changeDicewareWordList.Text = "Вибрати користувацький набір слів";
            this.changeDicewareWordList.UseVisualStyleBackColor = true;
            this.changeDicewareWordList.Click += new EventHandler(OnFileSelect);
            
            // 
            // generatePasswordButton
            // 
            this.generatePasswordButton.Location = new System.Drawing.Point(180, 120);
            this.generatePasswordButton.Name = "button2";
            this.generatePasswordButton.Size = new System.Drawing.Size(130, 40);
            this.generatePasswordButton.TabIndex = 3;
            this.generatePasswordButton.Text = "Згенерувати паролі";
            this.generatePasswordButton.UseVisualStyleBackColor = true;
            this.generatePasswordButton.Click += new EventHandler(OnGenerateClick);
            
            this.algoritmSelector1.Location = new System.Drawing.Point(10, 20);
            this.algoritmSelector1.Checked = true;
            this.algoritmSelector1.Text = "Модифікація Diceware";
            this.algoritmSelector1.Size = new System.Drawing.Size(120, 50);
            this.algoritmSelector1.CheckedChanged += new EventHandler(RadioBoxChanged);

            this.algoritmSelector2.Location = new System.Drawing.Point(135, 20);
            this.algoritmSelector2.Text = "Механічний алгоритм";
            this.algoritmSelector2.Size = new System.Drawing.Size(120, 50);
            this.algoritmSelector2.CheckedChanged += new EventHandler(RadioBoxChanged);

            this.gb.Text = "Вибір алгоритму";
            this.gb.Size = new System.Drawing.Size(285, 90);
            this.gb.Location = new System.Drawing.Point(25, 170);
            this.gb.Controls.Add(this.algoritmSelector1);
            this.gb.Controls.Add(this.algoritmSelector2);
            // 
            // resultTextBox
            // 
            this.resultTextbox.AutoSize = true;
            this.resultTextbox.Size = new System.Drawing.Size(400, 350);
            this.resultTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.resultTextbox.Location = new System.Drawing.Point(325, 20);
            this.resultTextbox.Name = "label2";
            this.resultTextbox.ReadOnly = true;
            this.resultTextbox.Multiline = true;
            this.resultTextbox.AcceptsReturn = true;
            this.resultTextbox.TabIndex = 4;
            this.resultTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // trackBarValueLabel
            // 
            this.trackBarValueLabel.AutoSize = true;
            this.trackBarValueLabel.Location = new System.Drawing.Point(290, 70);
            this.trackBarValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.trackBarValueLabel.Name = "label3";
            this.trackBarValueLabel.Size = new System.Drawing.Size(35, 13);
            this.trackBarValueLabel.TabIndex = 5;
            this.trackBarValueLabel.Text = passwordLengthTrackBar.Value.ToString();
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 400);
            this.Controls.Add(this.trackBarValueLabel);
            this.Controls.Add(this.resultTextbox);
            this.Controls.Add(this.generatePasswordButton);
            this.Controls.Add(this.changeDicewareWordList);
            this.Controls.Add(this.trackBarLabel);
            this.Controls.Add(this.passwordLengthTrackBar);
            this.Controls.Add(this.gb);
            this.Name = "Form1";
            this.Text = "Password generator";
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RadioBoxChanged(object sender, EventArgs e)
        {
            var radioBox = sender as System.Windows.Forms.RadioButton;

            if(radioBox == null)
            {
                return;
            }

            if (radioBox.Checked)
            {
                if(radioBox.Text.Equals("Механічний алгоритм"))
                {
                    factory = PasswordGeneratorFactory.AvailableFactories.Mechanical;
                }
                else if(radioBox.Text.Equals("Модифікація Diceware"))
                {
                    factory = PasswordGeneratorFactory.AvailableFactories.Diceware;
                }
            }
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
            var passwordGenerator = new PasswordGenerator.PasswordGenerator(Convert.ToInt64(ConfigurationManager.AppSettings.Get("seed")), 
                Convert.ToInt64(ConfigurationManager.AppSettings.Get("key")), Convert.ToInt64(ConfigurationManager.AppSettings.Get("iv")), path, factory);
            var res = passwordGenerator.Generate(passwordLengthTrackBar.Value);
            this.resultTextbox.Clear();
            foreach(var pass in res.Passwords)
            {
                this.resultTextbox.Text += $"{pass}" + Environment.NewLine + Environment.NewLine;
            }
            this.resultTextbox.Text += $"{Environment.NewLine}From file: {res.Path ?? "default"}{Environment.NewLine}Entropy is {res.Entropy}{Environment.NewLine}Entropy per symbol is {res.EntropyPerSymbol}";            
        }

        private string path;

        #endregion

        private System.Windows.Forms.TrackBar passwordLengthTrackBar;
        private System.Windows.Forms.Label trackBarLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button changeDicewareWordList;
        private System.Windows.Forms.Button generatePasswordButton;
        private System.Windows.Forms.TextBox resultTextbox;
        private System.Windows.Forms.Label trackBarValueLabel;
        private System.Windows.Forms.RadioButton algoritmSelector1;
        private System.Windows.Forms.RadioButton algoritmSelector2;
        private PasswordGenerator.PasswordGeneratorFactory.AvailableFactories factory;
        private System.Windows.Forms.Label algorithmSelectorLabel;
        private System.Windows.Forms.GroupBox gb;
    }
}

