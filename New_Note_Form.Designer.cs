namespace Senior_Project
{
     partial class New_Note_Form
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
               this.textbox_note = new System.Windows.Forms.TextBox();
               this.new_note = new System.Windows.Forms.Button();
               this.cancel = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // textbox_note
               // 
               this.textbox_note.Location = new System.Drawing.Point(12, 12);
               this.textbox_note.Multiline = true;
               this.textbox_note.Name = "textbox_note";
               this.textbox_note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
               this.textbox_note.Size = new System.Drawing.Size(254, 237);
               this.textbox_note.TabIndex = 0;
               // 
               // new_note
               // 
               this.new_note.Location = new System.Drawing.Point(12, 255);
               this.new_note.Name = "new_note";
               this.new_note.Size = new System.Drawing.Size(127, 38);
               this.new_note.TabIndex = 1;
               this.new_note.Text = "Add Note";
               this.new_note.UseVisualStyleBackColor = true;
               this.new_note.Click += new System.EventHandler(this.New_Note_Click);
               // 
               // cancel
               // 
               this.cancel.Location = new System.Drawing.Point(145, 255);
               this.cancel.Name = "cancel";
               this.cancel.Size = new System.Drawing.Size(121, 38);
               this.cancel.TabIndex = 2;
               this.cancel.Text = "Cancel";
               this.cancel.UseVisualStyleBackColor = true;
               this.cancel.Click += new System.EventHandler(this.Cancel_Click);
               // 
               // New_Note_Form
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(281, 305);
               this.Controls.Add(this.cancel);
               this.Controls.Add(this.new_note);
               this.Controls.Add(this.textbox_note);
               this.Name = "New_Note_Form";
               this.Text = "New_Note_Form";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.TextBox textbox_note;
          private System.Windows.Forms.Button new_note;
          private System.Windows.Forms.Button cancel;
     }
}