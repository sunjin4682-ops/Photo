namespace Photo
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuStrip1 = new MenuStrip();
            Menu = new ToolStripMenuItem();
            AreaEdit = new ToolStripMenuItem();
            Cut = new ToolStripMenuItem();
            Pixelation = new ToolStripMenuItem();
            DetailEdit = new ToolStripMenuItem();
            WrinklesDel = new ToolStripMenuItem();
            BlemishDel = new ToolStripMenuItem();
            Filter = new ToolStripMenuItem();
            ChangeFilter = new ToolStripMenuItem();
            Contrast = new ToolStripMenuItem();
            Brightness = new ToolStripMenuItem();
            Decorate = new ToolStripMenuItem();
            Collage = new ToolStripMenuItem();
            Sticker = new ToolStripMenuItem();
            BGEdit = new ToolStripMenuItem();
            Polaroid = new ToolStripMenuItem();
            MainPic = new PictureBox();
            btnSave = new Button();
            btnReset = new Button();
            btnPost = new Button();
            btnDel = new Button();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainPic).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            Menu.DropDownItems.AddRange(new ToolStripItem[] { AreaEdit, DetailEdit, Filter, Decorate, BGEdit });
            Menu.Name = "Menu";
            Menu.Size = new Size(43, 20);
            Menu.Text = "편집";
            // 
            // AreaEdit
            // 
            AreaEdit.DropDownItems.AddRange(new ToolStripItem[] { Cut, Pixelation });
            AreaEdit.Name = "AreaEdit";
            AreaEdit.Size = new Size(126, 22);
            AreaEdit.Text = "영역 편집";
            // 
            // Cut
            // 
            Cut.Name = "Cut";
            Cut.Size = new Size(150, 22);
            Cut.Text = "자르기";
            // 
            // Pixelation
            // 
            Pixelation.Name = "Pixelation";
            Pixelation.Size = new Size(150, 22);
            Pixelation.Text = "모자이크 처리";
            // 
            // DetailEdit
            // 
            DetailEdit.DropDownItems.AddRange(new ToolStripItem[] { WrinklesDel, BlemishDel });
            DetailEdit.Name = "DetailEdit";
            DetailEdit.Size = new Size(126, 22);
            DetailEdit.Text = "세부 편집";
            // 
            // WrinklesDel
            // 
            WrinklesDel.Name = "WrinklesDel";
            WrinklesDel.Size = new Size(126, 22);
            WrinklesDel.Text = "주름 제거";
            // 
            // BlemishDel
            // 
            BlemishDel.Name = "BlemishDel";
            BlemishDel.Size = new Size(126, 22);
            BlemishDel.Text = "잡티 제거";
            // 
            // Filter
            // 
            Filter.DropDownItems.AddRange(new ToolStripItem[] { ChangeFilter, Contrast, Brightness });
            Filter.Name = "Filter";
            Filter.Size = new Size(126, 22);
            Filter.Text = "필터";
            // 
            // ChangeFilter
            // 
            ChangeFilter.Name = "ChangeFilter";
            ChangeFilter.Size = new Size(126, 22);
            ChangeFilter.Text = "필터 변경";
            // 
            // Contrast
            // 
            Contrast.Name = "Contrast";
            Contrast.Size = new Size(126, 22);
            Contrast.Text = "대비 변경";
            // 
            // Brightness
            // 
            Brightness.Name = "Brightness";
            Brightness.Size = new Size(126, 22);
            Brightness.Text = "밝기 변경";
            // 
            // Decorate
            // 
            Decorate.DropDownItems.AddRange(new ToolStripItem[] { Collage, Sticker });
            Decorate.Name = "Decorate";
            Decorate.Size = new Size(126, 22);
            Decorate.Text = "꾸미기";
            // 
            // Collage
            // 
            Collage.Name = "Collage";
            Collage.Size = new Size(138, 22);
            Collage.Text = "포토 콜라주";
            // 
            // Sticker
            // 
            Sticker.Name = "Sticker";
            Sticker.Size = new Size(138, 22);
            Sticker.Text = "스티커 추가";
            Sticker.Click += Sticker_Click;
            // 
            // BGEdit
            // 
            BGEdit.DropDownItems.AddRange(new ToolStripItem[] { Polaroid });
            BGEdit.Name = "BGEdit";
            BGEdit.Size = new Size(126, 22);
            BGEdit.Text = "배경 변경";
            // 
            // Polaroid
            // 
            Polaroid.Name = "Polaroid";
            Polaroid.Size = new Size(134, 22);
            Polaroid.Text = "폴라로이드";
            // 
            // MainPic
            // 
            MainPic.BackgroundImage = (Image)resources.GetObject("MainPic.BackgroundImage");
            MainPic.BackgroundImageLayout = ImageLayout.Stretch;
            MainPic.Location = new Point(0, 27);
            MainPic.Name = "MainPic";
            MainPic.Size = new Size(707, 424);
            MainPic.SizeMode = PictureBoxSizeMode.Zoom;
            MainPic.TabIndex = 1;
            MainPic.TabStop = false;
            MainPic.DragDrop += MainPic_DragDrop;
            MainPic.DragEnter += MainPic_DragEnter;
            MainPic.Paint += MainPic_Paint;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(713, 27);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 31);
            btnSave.TabIndex = 2;
            btnSave.Text = "저장";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(713, 370);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 31);
            btnReset.TabIndex = 2;
            btnReset.Text = "초기화";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnPost
            // 
            btnPost.Location = new Point(713, 64);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(75, 31);
            btnPost.TabIndex = 2;
            btnPost.Text = "사진 넣기";
            btnPost.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(713, 407);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 31);
            btnDel.TabIndex = 2;
            btnDel.Text = "제거";
            btnDel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(713, 101);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 2;
            button1.Text = "스티커";
            button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPost);
            Controls.Add(btnDel);
            Controls.Add(button1);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(MainPic);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "포토샵 프로그램";
            DragDrop += Main_DragDrop;
            DragEnter += Main_DragEnter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MainPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private PictureBox MainPic;
        private Button btnSave;
        private Button btnReset;
        private Button btnPost;
        private Button btnDel;
        private ToolStripMenuItem Menu;
        private ToolStripMenuItem AreaEdit;
        private ToolStripMenuItem Cut;
        private ToolStripMenuItem Pixelation;
        private ToolStripMenuItem DetailEdit;
        private ToolStripMenuItem WrinklesDel;
        private ToolStripMenuItem BlemishDel;
        private ToolStripMenuItem Filter;
        private ToolStripMenuItem ChangeFilter;
        private ToolStripMenuItem Contrast;
        private ToolStripMenuItem Decorate;
        private ToolStripMenuItem Collage;
        private ToolStripMenuItem Sticker;
        private ToolStripMenuItem BGEdit;
        private ToolStripMenuItem Polaroid;
        private ToolStripMenuItem Brightness;
        private Button button1;
    }
}
