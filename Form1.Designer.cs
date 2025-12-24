namespace MLMathImageProcess
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnLoadImage;
        private Button btnProcessImage;
        private Button btnSaveResult;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxProcessed;
        private Label lblOriginal;
        private Label lblProcessed;
        private Label lblStatus;
        private TextBox txtResult;
        private GroupBox groupBoxControls;
        private GroupBox groupBoxImages;
        private GroupBox groupBoxResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoadImage = new Button();
            this.btnProcessImage = new Button();
            this.btnSaveResult = new Button();
            this.pictureBoxOriginal = new PictureBox();
            this.pictureBoxProcessed = new PictureBox();
            this.lblOriginal = new Label();
            this.lblProcessed = new Label();
            this.lblStatus = new Label();
            this.txtResult = new TextBox();
            this.groupBoxControls = new GroupBox();
            this.groupBoxImages = new GroupBox();
            this.groupBoxResults = new GroupBox();
            this.groupBoxControls.SuspendLayout();
            this.groupBoxImages.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).BeginInit();
            this.SuspendLayout();
            
            // Form1
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.Text = "ML Math Image Processor";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // groupBoxControls
            this.groupBoxControls.Controls.Add(this.btnLoadImage);
            this.groupBoxControls.Controls.Add(this.btnProcessImage);
            this.groupBoxControls.Controls.Add(this.btnSaveResult);
            this.groupBoxControls.Location = new Point(12, 12);
            this.groupBoxControls.Size = new Size(200, 150);
            this.groupBoxControls.Text = "Controls";
            this.groupBoxControls.TabIndex = 0;
            this.groupBoxControls.TabStop = false;
            
            // btnLoadImage
            this.btnLoadImage.Location = new Point(15, 25);
            this.btnLoadImage.Size = new Size(170, 30);
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new EventHandler(this.BtnLoadImage_Click);
            
            // btnProcessImage
            this.btnProcessImage.Location = new Point(15, 65);
            this.btnProcessImage.Size = new Size(170, 30);
            this.btnProcessImage.Text = "Process Image";
            this.btnProcessImage.UseVisualStyleBackColor = true;
            this.btnProcessImage.Enabled = false;
            this.btnProcessImage.Click += new EventHandler(this.BtnProcessImage_Click);
            
            // btnSaveResult
            this.btnSaveResult.Location = new Point(15, 105);
            this.btnSaveResult.Size = new Size(170, 30);
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Enabled = false;
            this.btnSaveResult.Click += new EventHandler(this.BtnSaveResult_Click);
            
            // groupBoxImages
            this.groupBoxImages.Controls.Add(this.lblOriginal);
            this.groupBoxImages.Controls.Add(this.pictureBoxOriginal);
            this.groupBoxImages.Controls.Add(this.lblProcessed);
            this.groupBoxImages.Controls.Add(this.pictureBoxProcessed);
            this.groupBoxImages.Location = new Point(220, 12);
            this.groupBoxImages.Size = new Size(750, 500);
            this.groupBoxImages.Text = "Images";
            this.groupBoxImages.TabIndex = 1;
            this.groupBoxImages.TabStop = false;
            
            // lblOriginal
            this.lblOriginal.Location = new Point(15, 20);
            this.lblOriginal.Size = new Size(350, 20);
            this.lblOriginal.Text = "Original Image";
            this.lblOriginal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            
            // pictureBoxOriginal
            this.pictureBoxOriginal.Location = new Point(15, 45);
            this.pictureBoxOriginal.Size = new Size(350, 440);
            this.pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxOriginal.BackColor = Color.White;
            
            // lblProcessed
            this.lblProcessed.Location = new Point(385, 20);
            this.lblProcessed.Size = new Size(350, 20);
            this.lblProcessed.Text = "Processed Image";
            this.lblProcessed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            
            // pictureBoxProcessed
            this.pictureBoxProcessed.Location = new Point(385, 45);
            this.pictureBoxProcessed.Size = new Size(350, 440);
            this.pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxProcessed.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxProcessed.BackColor = Color.White;
            
            // groupBoxResults
            this.groupBoxResults.Controls.Add(this.txtResult);
            this.groupBoxResults.Location = new Point(12, 170);
            this.groupBoxResults.Size = new Size(200, 342);
            this.groupBoxResults.Text = "Results";
            this.groupBoxResults.TabIndex = 2;
            this.groupBoxResults.TabStop = false;
            
            // txtResult
            this.txtResult.Location = new Point(15, 25);
            this.txtResult.Multiline = true;
            this.txtResult.Size = new Size(170, 300);
            this.txtResult.ScrollBars = ScrollBars.Vertical;
            this.txtResult.ReadOnly = true;
            this.txtResult.Font = new Font("Consolas", 9F);
            
            // lblStatus
            this.lblStatus.Location = new Point(12, 520);
            this.lblStatus.Size = new Size(958, 25);
            this.lblStatus.Text = "Ready";
            this.lblStatus.BorderStyle = BorderStyle.FixedSingle;
            this.lblStatus.Padding = new Padding(5);
            this.lblStatus.BackColor = Color.LightGray;
            
            // Add controls to form
            this.Controls.Add(this.groupBoxControls);
            this.Controls.Add(this.groupBoxImages);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.lblStatus);
            
            this.groupBoxControls.ResumeLayout(false);
            this.groupBoxImages.ResumeLayout(false);
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

