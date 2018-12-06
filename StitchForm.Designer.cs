namespace SpriteBitcher
{
	partial class StitchForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_chooseSprites = new System.Windows.Forms.Button();
            this.lbl_outputSizeVw = new System.Windows.Forms.Label();
            this.lbl_outputSize = new System.Windows.Forms.Label();
            this.lbl_frameSizeVw = new System.Windows.Forms.Label();
            this.lbl_frameSize = new System.Windows.Forms.Label();
            this.tbx_sheetCols = new System.Windows.Forms.TextBox();
            this.lbl_sheetCols = new System.Windows.Forms.Label();
            this.btn_saveStitch = new System.Windows.Forms.Button();
            this.btn_saveOutput = new System.Windows.Forms.Button();
            this.tbx_sheetRows = new System.Windows.Forms.TextBox();
            this.lbl_sheetRows = new System.Windows.Forms.Label();
            this.ofd_spriteChooser = new System.Windows.Forms.OpenFileDialog();
            this.sfd_spritesheetSaver = new System.Windows.Forms.SaveFileDialog();
            this.pnl_stitchPreview = new System.Windows.Forms.Panel();
            this.pbx_stitchPreview = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnl_stitchPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_stitchPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_chooseSprites);
            this.panel1.Controls.Add(this.lbl_outputSizeVw);
            this.panel1.Controls.Add(this.lbl_outputSize);
            this.panel1.Controls.Add(this.lbl_frameSizeVw);
            this.panel1.Controls.Add(this.lbl_frameSize);
            this.panel1.Controls.Add(this.tbx_sheetCols);
            this.panel1.Controls.Add(this.lbl_sheetCols);
            this.panel1.Controls.Add(this.btn_saveStitch);
            this.panel1.Controls.Add(this.btn_saveOutput);
            this.panel1.Controls.Add(this.tbx_sheetRows);
            this.panel1.Controls.Add(this.lbl_sheetRows);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 100);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(3, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(648, 360);
            this.panel2.TabIndex = 2;
            // 
            // btn_chooseSprites
            // 
            this.btn_chooseSprites.Location = new System.Drawing.Point(502, 9);
            this.btn_chooseSprites.Name = "btn_chooseSprites";
            this.btn_chooseSprites.Size = new System.Drawing.Size(75, 75);
            this.btn_chooseSprites.TabIndex = 3;
            this.btn_chooseSprites.Text = "Choose Sprites";
            this.btn_chooseSprites.UseVisualStyleBackColor = true;
            this.btn_chooseSprites.Click += new System.EventHandler(this.btn_addSprite_Click);
            // 
            // lbl_outputSizeVw
            // 
            this.lbl_outputSizeVw.AutoSize = true;
            this.lbl_outputSizeVw.Location = new System.Drawing.Point(332, 61);
            this.lbl_outputSizeVw.Name = "lbl_outputSizeVw";
            this.lbl_outputSizeVw.Size = new System.Drawing.Size(30, 13);
            this.lbl_outputSizeVw.TabIndex = 6;
            this.lbl_outputSizeVw.Text = "a x b";
            // 
            // lbl_outputSize
            // 
            this.lbl_outputSize.AutoSize = true;
            this.lbl_outputSize.Location = new System.Drawing.Point(228, 61);
            this.lbl_outputSize.Name = "lbl_outputSize";
            this.lbl_outputSize.Size = new System.Drawing.Size(65, 13);
            this.lbl_outputSize.TabIndex = 6;
            this.lbl_outputSize.Text = "Output Size:";
            // 
            // lbl_frameSizeVw
            // 
            this.lbl_frameSizeVw.AutoSize = true;
            this.lbl_frameSizeVw.Location = new System.Drawing.Point(332, 23);
            this.lbl_frameSizeVw.Name = "lbl_frameSizeVw";
            this.lbl_frameSizeVw.Size = new System.Drawing.Size(30, 13);
            this.lbl_frameSizeVw.TabIndex = 5;
            this.lbl_frameSizeVw.Text = "a x b";
            // 
            // lbl_frameSize
            // 
            this.lbl_frameSize.AutoSize = true;
            this.lbl_frameSize.Location = new System.Drawing.Point(228, 23);
            this.lbl_frameSize.Name = "lbl_frameSize";
            this.lbl_frameSize.Size = new System.Drawing.Size(62, 13);
            this.lbl_frameSize.TabIndex = 5;
            this.lbl_frameSize.Text = "Frame Size:";
            // 
            // tbx_sheetCols
            // 
            this.tbx_sheetCols.Location = new System.Drawing.Point(107, 58);
            this.tbx_sheetCols.Name = "tbx_sheetCols";
            this.tbx_sheetCols.Size = new System.Drawing.Size(87, 20);
            this.tbx_sheetCols.TabIndex = 2;
            this.tbx_sheetCols.TextChanged += new System.EventHandler(this.tbx_sheetCols_TextChanged);
            // 
            // lbl_sheetCols
            // 
            this.lbl_sheetCols.AutoSize = true;
            this.lbl_sheetCols.Location = new System.Drawing.Point(20, 61);
            this.lbl_sheetCols.Name = "lbl_sheetCols";
            this.lbl_sheetCols.Size = new System.Drawing.Size(47, 13);
            this.lbl_sheetCols.TabIndex = 3;
            this.lbl_sheetCols.Text = "Columns";
            // 
            // btn_saveStitch
            // 
            this.btn_saveStitch.Location = new System.Drawing.Point(684, 9);
            this.btn_saveStitch.Name = "btn_saveStitch";
            this.btn_saveStitch.Size = new System.Drawing.Size(75, 75);
            this.btn_saveStitch.TabIndex = 5;
            this.btn_saveStitch.Text = "Save Stitch";
            this.btn_saveStitch.UseVisualStyleBackColor = true;
            this.btn_saveStitch.Visible = false;
            this.btn_saveStitch.Click += new System.EventHandler(this.btn_saveStitch_Click);
            // 
            // btn_saveOutput
            // 
            this.btn_saveOutput.Location = new System.Drawing.Point(592, 9);
            this.btn_saveOutput.Name = "btn_saveOutput";
            this.btn_saveOutput.Size = new System.Drawing.Size(75, 75);
            this.btn_saveOutput.TabIndex = 4;
            this.btn_saveOutput.Text = "Save Output";
            this.btn_saveOutput.UseVisualStyleBackColor = true;
            this.btn_saveOutput.Click += new System.EventHandler(this.btn_saveOutput_Click);
            // 
            // tbx_sheetRows
            // 
            this.tbx_sheetRows.Location = new System.Drawing.Point(107, 20);
            this.tbx_sheetRows.Name = "tbx_sheetRows";
            this.tbx_sheetRows.Size = new System.Drawing.Size(87, 20);
            this.tbx_sheetRows.TabIndex = 1;
            this.tbx_sheetRows.TextChanged += new System.EventHandler(this.tbx_sheetRows_TextChanged);
            // 
            // lbl_sheetRows
            // 
            this.lbl_sheetRows.AutoSize = true;
            this.lbl_sheetRows.Location = new System.Drawing.Point(20, 23);
            this.lbl_sheetRows.Name = "lbl_sheetRows";
            this.lbl_sheetRows.Size = new System.Drawing.Size(34, 13);
            this.lbl_sheetRows.TabIndex = 0;
            this.lbl_sheetRows.Text = "Rows";
            // 
            // ofd_spriteChooser
            // 
            this.ofd_spriteChooser.FileName = "openFileDialog1";
            this.ofd_spriteChooser.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png, *.gif, *.tif)|*.bmp;*.jpg;*.jpeg;*.png;" +
    "*.gif;*.tif";
            this.ofd_spriteChooser.Multiselect = true;
            this.ofd_spriteChooser.Title = "Choose a bunch of sprites";
            // 
            // sfd_spritesheetSaver
            // 
            this.sfd_spritesheetSaver.Filter = "PNG files (*.png)|*.pngBitmap files (*.bmp)|*.bmp||JPG files (*.jpg)|*.jpg|JPEG f" +
    "iles (*.jpeg)|*.jpeg|GIF files (*.gif)|*.gif";
            // 
            // pnl_stitchPreview
            // 
            this.pnl_stitchPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_stitchPreview.AutoScroll = true;
            this.pnl_stitchPreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnl_stitchPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_stitchPreview.Controls.Add(this.pbx_stitchPreview);
            this.pnl_stitchPreview.Location = new System.Drawing.Point(12, 106);
            this.pnl_stitchPreview.Name = "pnl_stitchPreview";
            this.pnl_stitchPreview.Size = new System.Drawing.Size(960, 544);
            this.pnl_stitchPreview.TabIndex = 2;
            // 
            // pbx_stitchPreview
            // 
            this.pbx_stitchPreview.Location = new System.Drawing.Point(0, 0);
            this.pbx_stitchPreview.Name = "pbx_stitchPreview";
            this.pbx_stitchPreview.Size = new System.Drawing.Size(50, 50);
            this.pbx_stitchPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbx_stitchPreview.TabIndex = 0;
            this.pbx_stitchPreview.TabStop = false;
            this.pbx_stitchPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx_stitchPreview_MouseDown);
            this.pbx_stitchPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbx_stitchPreview_MouseUp);
            // 
            // StitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.pnl_stitchPreview);
            this.Controls.Add(this.panel1);
            this.Name = "StitchForm";
            this.Text = "SpriteStitcher";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_stitchPreview.ResumeLayout(false);
            this.pnl_stitchPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_stitchPreview)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_outputSizeVw;
		private System.Windows.Forms.Label lbl_outputSize;
		private System.Windows.Forms.Label lbl_frameSizeVw;
		private System.Windows.Forms.Label lbl_frameSize;
		private System.Windows.Forms.TextBox tbx_sheetCols;
		private System.Windows.Forms.Label lbl_sheetCols;
		private System.Windows.Forms.Button btn_saveStitch;
		private System.Windows.Forms.Button btn_saveOutput;
		private System.Windows.Forms.TextBox tbx_sheetRows;
		private System.Windows.Forms.Label lbl_sheetRows;
		private System.Windows.Forms.Button btn_chooseSprites;
		private System.Windows.Forms.OpenFileDialog ofd_spriteChooser;
		private System.Windows.Forms.SaveFileDialog sfd_spritesheetSaver;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel pnl_stitchPreview;
		private System.Windows.Forms.PictureBox pbx_stitchPreview;

	}
}

