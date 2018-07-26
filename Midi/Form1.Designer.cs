namespace humanmusic
{
    public partial class Form1
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
            this.PlayScaleButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.programInfo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayScaleButton
            // 
            this.PlayScaleButton.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayScaleButton.Location = new System.Drawing.Point(12, 12);
            this.PlayScaleButton.Name = "PlayScaleButton";
            this.PlayScaleButton.Size = new System.Drawing.Size(108, 23);
            this.PlayScaleButton.TabIndex = 0;
            this.PlayScaleButton.Text = "Create MIDI File";
            this.PlayScaleButton.UseVisualStyleBackColor = true;
            this.PlayScaleButton.Visible = false;
            this.PlayScaleButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Generate Song";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // programInfo
            // 
            this.programInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.programInfo.Location = new System.Drawing.Point(12, 70);
            this.programInfo.Multiline = true;
            this.programInfo.Name = "programInfo";
            this.programInfo.Size = new System.Drawing.Size(247, 179);
            this.programInfo.TabIndex = 2;
            this.programInfo.TextChanged += new System.EventHandler(this.programInfo_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 19);
            this.button1.TabIndex = 3;
            this.button1.Text = "Stop Playing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ready!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.programInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PlayScaleButton);
            this.Name = "Form1";
            this.Text = "Human Music";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayScaleButton;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox programInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}