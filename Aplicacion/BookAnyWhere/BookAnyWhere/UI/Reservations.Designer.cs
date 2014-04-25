namespace BookAnyWhere.UI
{
    partial class Reservations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservations));
            this.panel1 = new System.Windows.Forms.Panel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.comboSearchBox = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchFilterBox = new System.Windows.Forms.TextBox();
            this.searchDateLabel = new System.Windows.Forms.Label();
            this.reservationsList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.filterLabel);
            this.panel1.Controls.Add(this.comboSearchBox);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.searchFilterBox);
            this.panel1.Controls.Add(this.searchDateLabel);
            this.panel1.Controls.Add(this.reservationsList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 517);
            this.panel1.TabIndex = 0;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(14, 88);
            this.filterLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(50, 21);
            this.filterLabel.TabIndex = 6;
            this.filterLabel.Text = "Valor:";
            // 
            // comboSearchBox
            // 
            this.comboSearchBox.FormattingEnabled = true;
            this.comboSearchBox.Items.AddRange(new object[] {
            "Fecha",
            "Pasaporte de Usuario"});
            this.comboSearchBox.Location = new System.Drawing.Point(109, 32);
            this.comboSearchBox.Name = "comboSearchBox";
            this.comboSearchBox.Size = new System.Drawing.Size(219, 29);
            this.comboSearchBox.TabIndex = 5;
            this.comboSearchBox.Text = "Seleccione";
            this.comboSearchBox.SelectedIndexChanged += new System.EventHandler(this.comboSearchBox_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.SkyBlue;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(192, 474);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 31);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Inicio";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.SkyBlue;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(356, 83);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 31);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Buscar";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchFilterBox
            // 
            this.searchFilterBox.Location = new System.Drawing.Point(109, 83);
            this.searchFilterBox.Name = "searchFilterBox";
            this.searchFilterBox.Size = new System.Drawing.Size(219, 29);
            this.searchFilterBox.TabIndex = 2;
            this.searchFilterBox.Click += new System.EventHandler(this.searchFilterBox_Click);
            // 
            // searchDateLabel
            // 
            this.searchDateLabel.AutoSize = true;
            this.searchDateLabel.Location = new System.Drawing.Point(14, 35);
            this.searchDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.searchDateLabel.Name = "searchDateLabel";
            this.searchDateLabel.Size = new System.Drawing.Size(87, 21);
            this.searchDateLabel.TabIndex = 1;
            this.searchDateLabel.Text = "Buscar por:";
            // 
            // reservationsList
            // 
            this.reservationsList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.reservationsList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationsList.FormattingEnabled = true;
            this.reservationsList.ItemHeight = 17;
            this.reservationsList.Location = new System.Drawing.Point(14, 122);
            this.reservationsList.Margin = new System.Windows.Forms.Padding(5);
            this.reservationsList.Name = "reservationsList";
            this.reservationsList.Size = new System.Drawing.Size(456, 344);
            this.reservationsList.TabIndex = 0;
            this.reservationsList.SelectedIndexChanged += new System.EventHandler(this.reservationsList_SelectedIndexChanged);
            // 
            // Reservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 517);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Reservations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservaciones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox reservationsList;
        private System.Windows.Forms.ComboBox comboSearchBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchFilterBox;
        private System.Windows.Forms.Label searchDateLabel;
        private System.Windows.Forms.Label filterLabel;
    }
}