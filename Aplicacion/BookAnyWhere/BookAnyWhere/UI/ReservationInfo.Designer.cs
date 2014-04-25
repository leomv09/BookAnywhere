namespace BookAnyWhere.UI
{
    partial class ReservationInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationInfo));
            this.reservationsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.countryBox = new System.Windows.Forms.TextBox();
            this.seatBox = new System.Windows.Forms.TextBox();
            this.flightBox = new System.Windows.Forms.TextBox();
            this.hourBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clientBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.reservationsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reservationsPanel
            // 
            this.reservationsPanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.reservationsPanel.Controls.Add(this.tableLayoutPanel1);
            this.reservationsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reservationsPanel.Location = new System.Drawing.Point(0, 0);
            this.reservationsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reservationsPanel.Name = "reservationsPanel";
            this.reservationsPanel.Size = new System.Drawing.Size(484, 390);
            this.reservationsPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.backButton, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.countryBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.seatBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.flightBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.hourBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.clientBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 414);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.SkyBlue;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(3, 309);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(89, 32);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Volver";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // countryBox
            // 
            this.countryBox.Location = new System.Drawing.Point(233, 258);
            this.countryBox.Name = "countryBox";
            this.countryBox.ReadOnly = true;
            this.countryBox.Size = new System.Drawing.Size(224, 29);
            this.countryBox.TabIndex = 11;
            // 
            // seatBox
            // 
            this.seatBox.Location = new System.Drawing.Point(233, 207);
            this.seatBox.Name = "seatBox";
            this.seatBox.ReadOnly = true;
            this.seatBox.Size = new System.Drawing.Size(224, 29);
            this.seatBox.TabIndex = 10;
            // 
            // flightBox
            // 
            this.flightBox.Location = new System.Drawing.Point(233, 156);
            this.flightBox.Name = "flightBox";
            this.flightBox.ReadOnly = true;
            this.flightBox.Size = new System.Drawing.Size(224, 29);
            this.flightBox.TabIndex = 9;
            // 
            // hourBox
            // 
            this.hourBox.Location = new System.Drawing.Point(233, 105);
            this.hourBox.Name = "hourBox";
            this.hourBox.ReadOnly = true;
            this.hourBox.Size = new System.Drawing.Size(224, 29);
            this.hourBox.TabIndex = 8;
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(233, 54);
            this.dateBox.Name = "dateBox";
            this.dateBox.ReadOnly = true;
            this.dateBox.Size = new System.Drawing.Size(224, 29);
            this.dateBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pais de Registro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Asiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vuelo:";
            // 
            // clientBox
            // 
            this.clientBox.Location = new System.Drawing.Point(233, 3);
            this.clientBox.Name = "clientBox";
            this.clientBox.ReadOnly = true;
            this.clientBox.Size = new System.Drawing.Size(224, 29);
            this.clientBox.TabIndex = 6;
            this.clientBox.TextChanged += new System.EventHandler(this.clientBox_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(233, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReservationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 390);
            this.Controls.Add(this.reservationsPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReservationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservación";
            this.reservationsPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel reservationsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox countryBox;
        private System.Windows.Forms.TextBox seatBox;
        private System.Windows.Forms.TextBox flightBox;
        private System.Windows.Forms.TextBox hourBox;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clientBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button button1;
    }
}