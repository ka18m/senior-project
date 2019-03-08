namespace Senior_Project
{
    partial class welcome_form
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
            this.import_button = new System.Windows.Forms.Button();
            this.create_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(133, 279);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(337, 86);
            this.import_button.TabIndex = 0;
            this.import_button.Text = "Import spreadsheet (.xl, .csv)";
            this.import_button.UseVisualStyleBackColor = true;
            // 
            // create_button
            // 
            this.create_button.Location = new System.Drawing.Point(561, 279);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(337, 86);
            this.create_button.TabIndex = 1;
            this.create_button.Text = "Create from scratch";
            this.create_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(631, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to the Student Administration Panel! \r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(310, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "How would you like to create your classroom?";
            // 
            // welcome_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 638);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.import_button);
            this.Name = "welcome_form";
            this.Text = "Teacher Admin Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

