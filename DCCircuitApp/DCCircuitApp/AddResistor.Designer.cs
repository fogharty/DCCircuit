namespace DCCircuitApp
{
    partial class AddResistor
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
            this.label1 = new System.Windows.Forms.Label();
            this.input_resistance = new System.Windows.Forms.TextBox();
            this.input_voltage = new System.Windows.Forms.TextBox();
            this.input_amperage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Параметры резистора";
            // 
            // input_resistance
            // 
            this.input_resistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.input_resistance.Location = new System.Drawing.Point(12, 80);
            this.input_resistance.MaxLength = 6;
            this.input_resistance.Name = "input_resistance";
            this.input_resistance.Size = new System.Drawing.Size(126, 20);
            this.input_resistance.TabIndex = 1;
            this.input_resistance.Text = "Сопротивление";
            // 
            // input_voltage
            // 
            this.input_voltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.input_voltage.Location = new System.Drawing.Point(12, 116);
            this.input_voltage.MaxLength = 6;
            this.input_voltage.Name = "input_voltage";
            this.input_voltage.Size = new System.Drawing.Size(126, 20);
            this.input_voltage.TabIndex = 2;
            this.input_voltage.Text = "Рабочее напряжение";
            // 
            // input_amperage
            // 
            this.input_amperage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.input_amperage.Location = new System.Drawing.Point(12, 156);
            this.input_amperage.MaxLength = 6;
            this.input_amperage.Name = "input_amperage";
            this.input_amperage.Size = new System.Drawing.Size(126, 20);
            this.input_amperage.TabIndex = 3;
            this.input_amperage.Text = "Допустимый ток";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ом";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "В";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "А";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(306, 220);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 7;
            this.button_ok.Text = "Применить";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(225, 220);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // AddResistor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 255);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.input_amperage);
            this.Controls.Add(this.input_voltage);
            this.Controls.Add(this.input_resistance);
            this.Controls.Add(this.label1);
            this.Name = "AddResistor";
            this.Text = "AddResistor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_resistance;
        private System.Windows.Forms.TextBox input_voltage;
        private System.Windows.Forms.TextBox input_amperage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}