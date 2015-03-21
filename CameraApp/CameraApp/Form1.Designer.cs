namespace CameraApp
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
            this.picFeed = new System.Windows.Forms.PictureBox();
            this.lblCamera = new System.Windows.Forms.Label();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picFeed
            // 
            this.picFeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFeed.Location = new System.Drawing.Point(345, 12);
            this.picFeed.Name = "picFeed";
            this.picFeed.Size = new System.Drawing.Size(255, 209);
            this.picFeed.TabIndex = 0;
            this.picFeed.TabStop = false;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Location = new System.Drawing.Point(21, 381);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(76, 13);
            this.lblCamera.TabIndex = 1;
            this.lblCamera.Text = "Select Camera";
            // 
            // cmbCamera
            // 
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(115, 373);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(121, 21);
            this.cmbCamera.TabIndex = 2;
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(24, 420);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(108, 23);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // picPreview
            // 
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(345, 227);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(255, 216);
            this.picPreview.TabIndex = 4;
            this.picPreview.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.update.Location = new System.Drawing.Point(24, 449);
            this.update.Name = "updateButton";
            this.update.Size = new System.Drawing.Size(108, 23);
            this.update.TabIndex = 6;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.UpdateClick);
            
            this.MyTimer = new System.Windows.Forms.Timer();
            this.MyTimer.Interval = 1;
            this.MyTimer.Tick += new System.EventHandler(TimerTick);
            this.MyTimer.Enabled = true;
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 513);
            this.Controls.Add(this.update);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.lblCamera);
            this.Controls.Add(this.picFeed);
            this.Name = "Form1";
            this.Text = "Camera Capture";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            this.MyTimer.Start();
        }

        #endregion

        private System.Windows.Forms.PictureBox picFeed;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Timer MyTimer;
    }
}

