namespace TibosiHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbOldText = new System.Windows.Forms.TextBox();
            this.tbNewText = new System.Windows.Forms.TextBox();
            this.btExchange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOldText
            // 
            this.tbOldText.Location = new System.Drawing.Point(34, 12);
            this.tbOldText.MaxLength = 9999999;
            this.tbOldText.Multiline = true;
            this.tbOldText.Name = "tbOldText";
            this.tbOldText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOldText.Size = new System.Drawing.Size(564, 167);
            this.tbOldText.TabIndex = 0;
            // 
            // tbNewText
            // 
            this.tbNewText.Location = new System.Drawing.Point(34, 223);
            this.tbNewText.MaxLength = 9999999;
            this.tbNewText.Multiline = true;
            this.tbNewText.Name = "tbNewText";
            this.tbNewText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbNewText.Size = new System.Drawing.Size(564, 201);
            this.tbNewText.TabIndex = 1;
            // 
            // btExchange
            // 
            this.btExchange.Location = new System.Drawing.Point(637, 187);
            this.btExchange.Name = "btExchange";
            this.btExchange.Size = new System.Drawing.Size(75, 23);
            this.btExchange.TabIndex = 2;
            this.btExchange.Text = "转换";
            this.btExchange.UseVisualStyleBackColor = true;
            this.btExchange.Click += new System.EventHandler(this.btExchange_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btExchange);
            this.Controls.Add(this.tbNewText);
            this.Controls.Add(this.tbOldText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOldText;
        private System.Windows.Forms.TextBox tbNewText;
        private System.Windows.Forms.Button btExchange;
    }
}

