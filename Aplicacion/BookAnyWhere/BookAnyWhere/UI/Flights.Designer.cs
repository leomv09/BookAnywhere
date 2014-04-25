namespace BookAnyWhere.UI
{
    partial class Flights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Flights));
            this.flightPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSearchBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.valueLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.selecFlightButton = new System.Windows.Forms.Button();
            this.flightSelectionLabel = new System.Windows.Forms.Label();
            this.flightsList = new System.Windows.Forms.ListBox();
            this.flightPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flightPanel
            // 
            this.flightPanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.flightPanel.Controls.Add(this.tableLayoutPanel1);
            this.flightPanel.Controls.Add(this.selecFlightButton);
            this.flightPanel.Controls.Add(this.flightSelectionLabel);
            this.flightPanel.Controls.Add(this.flightsList);
            this.flightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flightPanel.Location = new System.Drawing.Point(0, 0);
            this.flightPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flightPanel.Name = "flightPanel";
            this.flightPanel.Size = new System.Drawing.Size(484, 517);
            this.flightPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboSearchBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.searchButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.valueLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.searchBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 100);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar por:";
            // 
            // comboSearchBox
            // 
            this.comboSearchBox.FormattingEnabled = true;
            this.comboSearchBox.Items.AddRange(new object[] {
            "País Destino",
            "País Salida",
            "Fecha"});
            this.comboSearchBox.Location = new System.Drawing.Point(160, 3);
            this.comboSearchBox.Name = "comboSearchBox";
            this.comboSearchBox.Size = new System.Drawing.Size(134, 29);
            this.comboSearchBox.TabIndex = 3;
            this.comboSearchBox.SelectedValueChanged += new System.EventHandler(this.comboSearchBox_SelectedValueChanged);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.SkyBlue;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(317, 53);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(94, 33);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Buscar";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(3, 50);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(50, 21);
            this.valueLabel.TabIndex = 6;
            this.valueLabel.Text = "Valor:";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(160, 53);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(134, 29);
            this.searchBox.TabIndex = 7;
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click);
            // 
            // selecFlightButton
            // 
            this.selecFlightButton.BackColor = System.Drawing.Color.SkyBlue;
            this.selecFlightButton.Enabled = false;
            this.selecFlightButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.selecFlightButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.selecFlightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selecFlightButton.Location = new System.Drawing.Point(178, 472);
            this.selecFlightButton.Name = "selecFlightButton";
            this.selecFlightButton.Size = new System.Drawing.Size(99, 33);
            this.selecFlightButton.TabIndex = 2;
            this.selecFlightButton.Text = "Seleccionar";
            this.selecFlightButton.UseVisualStyleBackColor = false;
            this.selecFlightButton.Click += new System.EventHandler(this.selecFlightButton_Click);
            // 
            // flightSelectionLabel
            // 
            this.flightSelectionLabel.AutoSize = true;
            this.flightSelectionLabel.Location = new System.Drawing.Point(12, 26);
            this.flightSelectionLabel.Name = "flightSelectionLabel";
            this.flightSelectionLabel.Size = new System.Drawing.Size(144, 21);
            this.flightSelectionLabel.TabIndex = 1;
            this.flightSelectionLabel.Text = "Seleccione el vuelo:";
            // 
            // flightsList
            // 
            this.flightsList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flightsList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightsList.FormattingEnabled = true;
            this.flightsList.ItemHeight = 17;
            this.flightsList.Location = new System.Drawing.Point(16, 154);
            this.flightsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flightsList.Name = "flightsList";
            this.flightsList.Size = new System.Drawing.Size(458, 310);
            this.flightsList.TabIndex = 0;
            this.flightsList.SelectedIndexChanged += new System.EventHandler(this.flightsList_SelectedIndexChanged);
            // 
            // Flights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 517);
            this.Controls.Add(this.flightPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Flights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vuelos";
            this.flightPanel.ResumeLayout(false);
            this.flightPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel flightPanel;
        private System.Windows.Forms.Button selecFlightButton;
        private System.Windows.Forms.Label flightSelectionLabel;
        private System.Windows.Forms.ListBox flightsList;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSearchBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox searchBox;
    }
}