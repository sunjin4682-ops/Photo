namespace Photo
{
    partial class Sticker_property
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
            label1 = new Label();
            lb_stickerSize = new Label();
            hScrollBar1 = new HScrollBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "크기조절";
            // 
            // lb_stickerSize
            // 
            lb_stickerSize.Location = new Point(86, 20);
            lb_stickerSize.Name = "lb_stickerSize";
            lb_stickerSize.Size = new Size(55, 15);
            lb_stickerSize.TabIndex = 0;
            lb_stickerSize.Text = "-";
            lb_stickerSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(35, 46);
            hScrollBar1.Minimum = -100;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(153, 21);
            hScrollBar1.TabIndex = 1;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // Sticker_property
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 450);
            Controls.Add(hScrollBar1);
            Controls.Add(lb_stickerSize);
            Controls.Add(label1);
            Name = "Sticker_property";
            Text = "Sticker_property";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lb_stickerSize;
        private HScrollBar hScrollBar1;
    }
}