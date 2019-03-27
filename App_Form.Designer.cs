namespace Senior_Project
{
    partial class App
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dashboard_label = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.manage_classroom_button = new System.Windows.Forms.Button();
            this.help_reader_button = new System.Windows.Forms.Button();
            this.conference_button = new System.Windows.Forms.Button();
            this.analysis_class_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 51);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(394, 526);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Insert graphs/charts here";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dashboard_label
            // 
            this.dashboard_label.AutoSize = true;
            this.dashboard_label.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_label.Location = new System.Drawing.Point(141, 9);
            this.dashboard_label.Name = "dashboard_label";
            this.dashboard_label.Size = new System.Drawing.Size(121, 23);
            this.dashboard_label.TabIndex = 1;
            this.dashboard_label.Text = "Dashboard";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.manage_classroom_button);
            this.flowLayoutPanel2.Controls.Add(this.help_reader_button);
            this.flowLayoutPanel2.Controls.Add(this.conference_button);
            this.flowLayoutPanel2.Controls.Add(this.analysis_class_button);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(432, 51);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(548, 526);
            this.flowLayoutPanel2.TabIndex = 2;
//            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // manage_classroom_button
            // 
            this.manage_classroom_button.BackColor = System.Drawing.Color.Turquoise;
            this.manage_classroom_button.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manage_classroom_button.Location = new System.Drawing.Point(3, 3);
            this.manage_classroom_button.Name = "manage_classroom_button";
            this.manage_classroom_button.Size = new System.Drawing.Size(200, 75);
            this.manage_classroom_button.TabIndex = 4;
            this.manage_classroom_button.Text = "Manage Classroom";
            this.manage_classroom_button.UseVisualStyleBackColor = false;
            // 
            // help_reader_button
            // 
            this.help_reader_button.BackColor = System.Drawing.Color.Firebrick;
            this.help_reader_button.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_reader_button.ForeColor = System.Drawing.Color.White;
            this.help_reader_button.Location = new System.Drawing.Point(209, 3);
            this.help_reader_button.Name = "help_reader_button";
            this.help_reader_button.Size = new System.Drawing.Size(200, 75);
            this.help_reader_button.TabIndex = 5;
            this.help_reader_button.Text = "Help a Reader";
            this.help_reader_button.UseVisualStyleBackColor = false;
            // 
            // conference_button
            // 
            this.conference_button.BackColor = System.Drawing.Color.Gold;
            this.conference_button.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conference_button.Location = new System.Drawing.Point(3, 84);
            this.conference_button.Name = "conference_button";
            this.conference_button.Size = new System.Drawing.Size(200, 75);
            this.conference_button.TabIndex = 6;
            this.conference_button.Text = "Student Conferences";
            this.conference_button.UseVisualStyleBackColor = false;
            // 
            // analysis_class_button
            // 
            this.analysis_class_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.analysis_class_button.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysis_class_button.ForeColor = System.Drawing.Color.White;
            this.analysis_class_button.Location = new System.Drawing.Point(209, 84);
            this.analysis_class_button.Name = "analysis_class_button";
            this.analysis_class_button.Size = new System.Drawing.Size(200, 75);
            this.analysis_class_button.TabIndex = 7;
            this.analysis_class_button.Text = "Class Analysis";
            this.analysis_class_button.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(650, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Actions";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 589);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.dashboard_label);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "App";
            this.Text = "App";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label dashboard_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button manage_classroom_button;
        private System.Windows.Forms.Button help_reader_button;
        private System.Windows.Forms.Button conference_button;
        private System.Windows.Forms.Button analysis_class_button;
        private System.Windows.Forms.Label label1;
    }
}