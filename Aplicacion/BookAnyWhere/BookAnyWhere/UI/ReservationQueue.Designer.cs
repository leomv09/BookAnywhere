namespace BookAnyWhere.UI
{
    partial class ReservationQueue
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
            this.queuePanel = new System.Windows.Forms.Panel();
            this.reservationList = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.queuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // queuePanel
            // 
            this.queuePanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.queuePanel.Controls.Add(this.reservationList);
            this.queuePanel.Controls.Add(this.backButton);
            this.queuePanel.Controls.Add(this.label1);
            this.queuePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queuePanel.Location = new System.Drawing.Point(0, 0);
            this.queuePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queuePanel.Name = "queuePanel";
            this.queuePanel.Size = new System.Drawing.Size(484, 461);
            this.queuePanel.TabIndex = 0;
            // 
            // reservationList
            // 
            this.reservationList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.reservationList.FormattingEnabled = true;
            this.reservationList.ItemHeight = 21;
            this.reservationList.Location = new System.Drawing.Point(17, 70);
            this.reservationList.Name = "reservationList";
            this.reservationList.Size = new System.Drawing.Size(455, 340);
            this.reservationList.TabIndex = 6;
            this.reservationList.SelectedIndexChanged += new System.EventHandler(this.reservationList_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.SkyBlue;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(17, 420);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(89, 32);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Volver";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cola:";
            // 
            // ReservationQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.queuePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReservationQueue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cola de Reservaciones";
            this.queuePanel.ResumeLayout(false);
            this.queuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel queuePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListBox reservationList;
    }
}