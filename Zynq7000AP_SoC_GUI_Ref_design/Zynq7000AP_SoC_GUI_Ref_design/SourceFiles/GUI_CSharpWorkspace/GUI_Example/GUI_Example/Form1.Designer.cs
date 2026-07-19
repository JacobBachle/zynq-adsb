namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.SerialcomboBox = new System.Windows.Forms.ComboBox();
            this.InputTextBox = new System.Windows.Forms.RichTextBox();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serialMaster = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // SerialcomboBox
            // 
            this.SerialcomboBox.FormattingEnabled = true;
            this.SerialcomboBox.Location = new System.Drawing.Point(12, 36);
            this.SerialcomboBox.Name = "SerialcomboBox";
            this.SerialcomboBox.Size = new System.Drawing.Size(151, 21);
            this.SerialcomboBox.TabIndex = 0;
            this.SerialcomboBox.SelectedIndexChanged += new System.EventHandler(this.SerialcomboBox_SelectedIndexChanged);
            this.SerialcomboBox.Click += new System.EventHandler(this.SerialcomboBox_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Enabled = false;
            this.InputTextBox.Location = new System.Drawing.Point(220, 39);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(354, 89);
            this.InputTextBox.TabIndex = 1;
            this.InputTextBox.Text = "";
            this.InputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputTextBox_KeyPress);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Enabled = false;
            this.OutputTextBox.Location = new System.Drawing.Point(220, 164);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(354, 81);
            this.OutputTextBox.TabIndex = 2;
            this.OutputTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Serial Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter Input String";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Processed Ouput String";
            // 
            // serialMaster
            // 
            this.serialMaster.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialMaster_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.SerialcomboBox);
            this.Name = "Form1";
            this.Text = "GUIExample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SerialcomboBox;
        private System.Windows.Forms.RichTextBox InputTextBox;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.IO.Ports.SerialPort serialMaster;
    }
}

