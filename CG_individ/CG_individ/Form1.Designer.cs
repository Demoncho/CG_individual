namespace CG_individ
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_algoritm = new System.Windows.Forms.Button();
            this.label_help = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(169, 1);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(636, 449);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(30, 94);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(107, 23);
            this.button_clear.TabIndex = 1;
            this.button_clear.Text = "Очистить поле";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_algoritm
            // 
            this.button_algoritm.Location = new System.Drawing.Point(30, 144);
            this.button_algoritm.Name = "button_algoritm";
            this.button_algoritm.Size = new System.Drawing.Size(107, 23);
            this.button_algoritm.TabIndex = 2;
            this.button_algoritm.Text = "Применить";
            this.button_algoritm.UseVisualStyleBackColor = true;
            this.button_algoritm.Click += new System.EventHandler(this.button_algoritm_Click);
            // 
            // label_help
            // 
            this.label_help.AutoSize = true;
            this.label_help.Location = new System.Drawing.Point(27, 211);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(109, 13);
            this.label_help.TabIndex = 3;
            this.label_help.Text = "Недостаточно точек";
            this.label_help.Visible = false;
            this.label_help.Click += new System.EventHandler(this.label_help_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_help);
            this.Controls.Add(this.button_algoritm);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_algoritm;
        private System.Windows.Forms.Label label_help;
    }
}

