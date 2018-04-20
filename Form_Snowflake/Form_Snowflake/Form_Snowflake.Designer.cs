namespace Form_Snowflake
{
    partial class button
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
            this.Snowflake = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Snowflake
            // 
            this.Snowflake.Location = new System.Drawing.Point(423, 181);
            this.Snowflake.Name = "Snowflake";
            this.Snowflake.Size = new System.Drawing.Size(102, 43);
            this.Snowflake.TabIndex = 0;
            this.Snowflake.Text = "Snowflake";
            this.Snowflake.UseVisualStyleBackColor = true;
            this.Snowflake.Click += new System.EventHandler(this.btnTr_Click);
            // 
            // button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 708);
            this.Controls.Add(this.Snowflake);
            this.Name = "button";
            this.Text = "Form_Snowflake";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Snowflake_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Snowflake;
    }
}

