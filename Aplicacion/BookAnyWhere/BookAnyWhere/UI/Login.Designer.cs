namespace BookAnyWhere.UI
{
    partial class Login
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
            this.loginPanel = new System.Windows.Forms.Panel();
            this.userLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.countryLabel = new System.Windows.Forms.Label();
            this.crButton = new System.Windows.Forms.RadioButton();
            this.pmButton = new System.Windows.Forms.RadioButton();
            this.brButton = new System.Windows.Forms.RadioButton();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.loginPanel.Controls.Add(this.brButton);
            this.loginPanel.Controls.Add(this.pmButton);
            this.loginPanel.Controls.Add(this.crButton);
            this.loginPanel.Controls.Add(this.countryLabel);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.passwordBox);
            this.loginPanel.Controls.Add(this.userNameBox);
            this.loginPanel.Controls.Add(this.passwordLabel);
            this.loginPanel.Controls.Add(this.userLabel);
            this.loginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(352, 276);
            this.loginPanel.TabIndex = 0;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(12, 23);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(67, 21);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Usuario:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 73);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(92, 21);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Contraseña:";
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(110, 20);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(168, 29);
            this.userNameBox.TabIndex = 2;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(110, 70);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(168, 29);
            this.passwordBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.SkyBlue;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.loginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Location = new System.Drawing.Point(110, 233);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(130, 31);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Ingresar";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(12, 119);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(41, 21);
            this.countryLabel.TabIndex = 5;
            this.countryLabel.Text = "País:";
            // 
            // crButton
            // 
            this.crButton.AutoSize = true;
            this.crButton.Location = new System.Drawing.Point(110, 117);
            this.crButton.Name = "crButton";
            this.crButton.Size = new System.Drawing.Size(100, 25);
            this.crButton.TabIndex = 6;
            this.crButton.TabStop = true;
            this.crButton.Text = "Costa Rica";
            this.crButton.UseVisualStyleBackColor = true;
            // 
            // pmButton
            // 
            this.pmButton.AutoSize = true;
            this.pmButton.Location = new System.Drawing.Point(110, 148);
            this.pmButton.Name = "pmButton";
            this.pmButton.Size = new System.Drawing.Size(84, 25);
            this.pmButton.TabIndex = 7;
            this.pmButton.TabStop = true;
            this.pmButton.Text = "Panama";
            this.pmButton.UseVisualStyleBackColor = true;
            // 
            // brButton
            // 
            this.brButton.AutoSize = true;
            this.brButton.Location = new System.Drawing.Point(110, 179);
            this.brButton.Name = "brButton";
            this.brButton.Size = new System.Drawing.Size(66, 25);
            this.brButton.TabIndex = 8;
            this.brButton.TabStop = true;
            this.brButton.Text = "Brasil";
            this.brButton.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 276);
            this.Controls.Add(this.loginPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.RadioButton brButton;
        private System.Windows.Forms.RadioButton pmButton;
        private System.Windows.Forms.RadioButton crButton;
        private System.Windows.Forms.Label countryLabel;
    }
}