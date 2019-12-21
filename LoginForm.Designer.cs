namespace Ex01
{
    public partial class LoginForm 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private System.Windows.Forms.Label welcomeText;
        private System.Windows.Forms.Button loginButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.welcomeText = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeText
            // 
            this.welcomeText.AutoSize = true;
            this.welcomeText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.welcomeText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.welcomeText.Location = new System.Drawing.Point(324, 98);
            this.welcomeText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(299, 32);
            this.welcomeText.TabIndex = 0;
            this.welcomeText.Text = "Welcome to FaceBook";
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.loginButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginButton.Location = new System.Drawing.Point(281, 149);
            this.loginButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(407, 70);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Click to Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(953, 350);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.welcomeText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "FaceBook Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}