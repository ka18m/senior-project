namespace Senior_Project
{
     partial class Conference_Form
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
               this.home_button = new System.Windows.Forms.Button();
               this.notes = new System.Windows.Forms.ListView();
               this.NoteID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
               this.StudentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
               this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
               this.Note = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
               this.student_select = new System.Windows.Forms.ComboBox();
               this.label1 = new System.Windows.Forms.Label();
               this.add_note = new System.Windows.Forms.Button();
               this.edit_note = new System.Windows.Forms.Button();
               this.delete_note = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // home_button
               // 
               this.home_button.Location = new System.Drawing.Point(13, 13);
               this.home_button.Name = "home_button";
               this.home_button.Size = new System.Drawing.Size(88, 31);
               this.home_button.TabIndex = 0;
               this.home_button.Text = "Home";
               this.home_button.UseVisualStyleBackColor = true;
               this.home_button.Click += new System.EventHandler(this.home_button_Click);
               // 
               // notes
               // 
               this.notes.Activation = System.Windows.Forms.ItemActivation.OneClick;
               this.notes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NoteID,
            this.StudentID,
            this.Date,
            this.Note});
               this.notes.FullRowSelect = true;
               this.notes.HoverSelection = true;
               this.notes.Location = new System.Drawing.Point(12, 90);
               this.notes.Name = "notes";
               this.notes.ShowItemToolTips = true;
               this.notes.Size = new System.Drawing.Size(451, 348);
               this.notes.TabIndex = 1;
               this.notes.UseCompatibleStateImageBehavior = false;
               this.notes.View = System.Windows.Forms.View.Details;
               // 
               // NoteID
               // 
               this.NoteID.DisplayIndex = 2;
               this.NoteID.Text = "";
               this.NoteID.Width = 1;
               // 
               // StudentID
               // 
               this.StudentID.DisplayIndex = 3;
               this.StudentID.Width = 1;
               // 
               // Date
               // 
               this.Date.DisplayIndex = 0;
               this.Date.Text = "Date";
               // 
               // Note
               // 
               this.Note.DisplayIndex = 1;
               this.Note.Text = "Notes";
               this.Note.Width = 385;
               // 
               // student_select
               // 
               this.student_select.FormattingEnabled = true;
               this.student_select.Location = new System.Drawing.Point(107, 63);
               this.student_select.Name = "student_select";
               this.student_select.Size = new System.Drawing.Size(220, 21);
               this.student_select.TabIndex = 2;
               this.student_select.SelectedIndexChanged += new System.EventHandler(this.Student_Select_SelectedIndexChanged);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(14, 66);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(87, 13);
               this.label1.TabIndex = 3;
               this.label1.Text = "Select a student:";
               // 
               // add_note
               // 
               this.add_note.Location = new System.Drawing.Point(107, 12);
               this.add_note.Name = "add_note";
               this.add_note.Size = new System.Drawing.Size(94, 32);
               this.add_note.TabIndex = 4;
               this.add_note.Text = "Add New Note";
               this.add_note.UseVisualStyleBackColor = true;
               this.add_note.Click += new System.EventHandler(this.Add_Note_Click);
               // 
               // edit_note
               // 
               this.edit_note.Location = new System.Drawing.Point(207, 12);
               this.edit_note.Name = "edit_note";
               this.edit_note.Size = new System.Drawing.Size(120, 31);
               this.edit_note.TabIndex = 5;
               this.edit_note.Text = "Edit Selected Note";
               this.edit_note.UseVisualStyleBackColor = true;
               this.edit_note.Click += new System.EventHandler(this.Edit_Note_Click);
               // 
               // delete_note
               // 
               this.delete_note.Location = new System.Drawing.Point(333, 12);
               this.delete_note.Name = "delete_note";
               this.delete_note.Size = new System.Drawing.Size(130, 31);
               this.delete_note.TabIndex = 6;
               this.delete_note.Text = "Delete Selected Note";
               this.delete_note.UseVisualStyleBackColor = true;
               this.delete_note.Click += new System.EventHandler(this.Delete_Note_Click);
               // 
               // Conference_Form
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(476, 450);
               this.Controls.Add(this.delete_note);
               this.Controls.Add(this.edit_note);
               this.Controls.Add(this.add_note);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.student_select);
               this.Controls.Add(this.notes);
               this.Controls.Add(this.home_button);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.Name = "Conference_Form";
               this.Text = "Conference_Form";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Button home_button;
          private System.Windows.Forms.ListView notes;
          private System.Windows.Forms.ComboBox student_select;
          private System.Windows.Forms.ColumnHeader Date;
          private System.Windows.Forms.ColumnHeader Note;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Button add_note;
          private System.Windows.Forms.Button edit_note;
          private System.Windows.Forms.Button delete_note;
          private System.Windows.Forms.ColumnHeader NoteID;
          private System.Windows.Forms.ColumnHeader StudentID;
     }
}