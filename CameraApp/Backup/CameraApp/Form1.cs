using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Importing the DLL
using TouchlessLib;

namespace CameraApp
{
    public partial class Form1 : Form
    {
        //The touchless manager has the properties of the camera info etc
        TouchlessMgr manager;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize the touchless manager object
            manager = new TouchlessMgr();

            //Listing the available cameras in the combobox
            foreach (Camera item in manager.Cameras)
            {
                cmbCamera.Items.Add(item);
            }
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            //initializing the camera to be used based on the selection
            manager.CurrentCamera = (Camera)cmbCamera.SelectedItem;

            //Setting the Event handler for the camera
            manager.CurrentCamera.OnImageCaptured += new EventHandler<CameraEventArgs>(CurrentCamera_OnImageCaptured);

        }

        void CurrentCamera_OnImageCaptured(object sender, CameraEventArgs e)
        {
            //Giving the feed of the camera to the picturepox
            picFeed.Image = manager.CurrentCamera.GetCurrentImage();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //Displaying the Current image in the other text box
            picPreview.Image = manager.CurrentCamera.GetCurrentImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //getting the current image of preview picturebox
            Bitmap b = (Bitmap)picPreview.Image;

            //Dispalying the save file dialog
            saveFileDialog1.Filter = "JPEG Image|*.jpg";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            //Saving the image
            if (saveFileDialog1.FileName != "")
                b.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            else
                MessageBox.Show("Nmae Not specified");
        }
    }
}
