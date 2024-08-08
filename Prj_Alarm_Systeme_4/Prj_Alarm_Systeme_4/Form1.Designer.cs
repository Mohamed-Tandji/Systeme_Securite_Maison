namespace Prj_Alarm_Systeme_4
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
            BtnZone1 = new Button();
            BtnZone2 = new Button();
            BtnZone4 = new Button();
            BtnZone3 = new Button();
            BtnActivate = new Button();
            BtnDeactivate = new Button();
            BtnReset = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // BtnZone1
            // 
            BtnZone1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnZone1.Location = new Point(21, 21);
            BtnZone1.Name = "BtnZone1";
            BtnZone1.Size = new Size(116, 79);
            BtnZone1.TabIndex = 0;
            BtnZone1.Text = "Zone 1";
            BtnZone1.UseVisualStyleBackColor = true;
            BtnZone1.Click += BtnZone1_Click;
            // 
            // BtnZone2
            // 
            BtnZone2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnZone2.Location = new Point(172, 21);
            BtnZone2.Name = "BtnZone2";
            BtnZone2.Size = new Size(110, 79);
            BtnZone2.TabIndex = 1;
            BtnZone2.Text = "Zone2";
            BtnZone2.UseVisualStyleBackColor = true;
            BtnZone2.Click += BtnZone2_Click;
            // 
            // BtnZone4
            // 
            BtnZone4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnZone4.Location = new Point(172, 106);
            BtnZone4.Name = "BtnZone4";
            BtnZone4.Size = new Size(110, 77);
            BtnZone4.TabIndex = 2;
            BtnZone4.Text = "Zone4";
            BtnZone4.UseVisualStyleBackColor = true;
            BtnZone4.Click += BtnZone4_Click;
            // 
            // BtnZone3
            // 
            BtnZone3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnZone3.Location = new Point(21, 106);
            BtnZone3.Name = "BtnZone3";
            BtnZone3.Size = new Size(116, 77);
            BtnZone3.TabIndex = 3;
            BtnZone3.Text = "Zone3";
            BtnZone3.UseVisualStyleBackColor = true;
            BtnZone3.Click += BtnZone3_Click;
            // 
            // BtnActivate
            // 
            BtnActivate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnActivate.Location = new Point(320, 22);
            BtnActivate.Name = "BtnActivate";
            BtnActivate.Size = new Size(228, 58);
            BtnActivate.TabIndex = 4;
            BtnActivate.Text = "Activate";
            BtnActivate.UseVisualStyleBackColor = true;
            BtnActivate.Click += BtnActivate_Click;
            // 
            // BtnDeactivate
            // 
            BtnDeactivate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDeactivate.Location = new Point(320, 106);
            BtnDeactivate.Name = "BtnDeactivate";
            BtnDeactivate.Size = new Size(228, 58);
            BtnDeactivate.TabIndex = 5;
            BtnDeactivate.Text = "Deactivate";
            BtnDeactivate.UseVisualStyleBackColor = true;
            BtnDeactivate.Click += BtnDeactivate_Click;
            // 
            // BtnReset
            // 
            BtnReset.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnReset.Location = new Point(320, 186);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(228, 58);
            BtnReset.TabIndex = 6;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = true;
            BtnReset.Click += BtnReset_Click;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.Location = new Point(21, 197);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(261, 58);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status :  Deactivate";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(lblStatus);
            Controls.Add(BtnReset);
            Controls.Add(BtnDeactivate);
            Controls.Add(BtnActivate);
            Controls.Add(BtnZone3);
            Controls.Add(BtnZone4);
            Controls.Add(BtnZone2);
            Controls.Add(BtnZone1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "MT Security";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnZone1;
        private Button BtnZone2;
        private Button BtnZone4;
        private Button BtnZone3;
        private Button BtnActivate;
        private Button BtnDeactivate;
        private Button BtnReset;
        private Label lblStatus;
    }
}