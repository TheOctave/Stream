using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

//Importing the DLL
using TouchlessLib;

namespace CameraApp
{

    public partial class Form1 : Form
    {
        //The touchless manager has the properties of the camera info etc
        TouchlessMgr manager;
        UdpClient client;
        UdpClient publisher;
        static String computerName;
        System.Net.IPAddress[] ipAddresses;

        //Webcam defines
        Size picSize;
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
            try
            {
                manager.CurrentCamera = (Camera)manager.Cameras[0];
            }
            catch (Exception)
            {

            }

            //manager.CurrentCamera.OnImageCaptured += new EventHandler<CameraEventArgs>(CurrentCamera_OnImageCaptured);

            picSize = new Size(255, 209);
            publisher = new UdpClient();
            client = new UdpClient();
            computerName = Environment.MachineName;
            ipAddresses = System.Net.Dns.GetHostAddresses(computerName);

            //webcam defines

            publisher.Client.Blocking = false;
            client.Client.ReceiveTimeout = 100;
            client.Client.Blocking = false;
            client.ExclusiveAddressUse = false;
            publisher.ExclusiveAddressUse = false;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            try
            {
                    Bitmap bitmap = manager.CurrentCamera.GetCurrentImage();
                    picFeed.Image = bitmap;
                    //picFeed.Visible = false;
                    byte[] bytes = new byte[3];
                    bytesFromImage(bytes, bitmap);
                    //picFeed.Visible = true;

                //publisher.Send(bytes, bytes.Length);
            } catch (Exception)
            {

            }

            //Retrieve
            try
            {
                System.Net.IPEndPoint ep = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
                Byte[] recvbytes = client.Receive(ref ep);
                Bitmap bitmapz = new Bitmap(picSize.Width, picSize.Height);
                imageFromBytes(recvbytes, bitmapz);
                picPreview.Image = bitmapz;
            } 
            catch (Exception)
            {

            }

        }

        private void bytesFromImage(byte[] byteInput, Bitmap piccolor)
        {
            Rectangle rect = new Rectangle(0, 0, piccolor.Width, piccolor.Height);
            System.Drawing.Imaging.BitmapData bmpData  = piccolor.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            
            IntPtr ptr = bmpData.Scan0;
            Int32 bytes = bmpData.Stride * piccolor.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
 
            Int32 secondcounter;
            byte tempred;
            byte tempblue;
            byte tempgreen;
            byte tempalpha;
            secondcounter = 0;
            List<Byte> bytelist = new List<Byte>();
            String a = rgbValues.Length + "";
            
 
            while (secondcounter < rgbValues.Length)
            {   
                tempblue = rgbValues[secondcounter];
                tempgreen = rgbValues[secondcounter + 1];
                tempred = rgbValues[secondcounter + 2];
                tempalpha = rgbValues[secondcounter + 3];
                tempalpha = 255;
 
                bytelist.Add(tempred);
                bytelist.Add(tempgreen);
                bytelist.Add(tempblue);
                
 
                rgbValues[secondcounter] = tempblue;
                rgbValues[secondcounter + 1] = tempgreen;
                rgbValues[secondcounter + 2] = tempred;
                rgbValues[secondcounter + 3] = tempalpha;
                //MessageBox.Show(a);
 
                secondcounter = secondcounter + 4;
            }

            
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);


            piccolor.UnlockBits(bmpData);
            //MessageBox.Show("After while loop");
 
            Byte[] bytearray = new Byte[bytelist.Count];
            for (int i = 0; i <  bytelist.Count; i++)
                bytearray[i] = bytelist[i];

            byteInput = bytearray;

            ///MessageBox.Show("DOne");

        }

        private void imageFromBytes(Byte[] byteInput, Bitmap piccolor)
        {
            Rectangle rect = new Rectangle(0, 0, piccolor.Width, piccolor.Height);
            System.Drawing.Imaging.BitmapData bmpData = piccolor.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            IntPtr ptr = bmpData.Scan0;
            Int32 bytes = bmpData.Stride * piccolor.Height;
            Byte[] rgbValues = new Byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
 
            Int32 secondcounter;
            byte tempred;
            byte tempblue;
            byte tempgreen;
            byte tempalpha;
            secondcounter = 0;
 
            while (secondcounter < rgbValues.Length)
            {
                tempblue = rgbValues[secondcounter];
                tempgreen = rgbValues[secondcounter + 1];
                tempred = rgbValues[secondcounter + 2];
                tempalpha = rgbValues[secondcounter + 3];
                tempalpha = 255;
 
                tempred = byteInput[(int)(((secondcounter * 0.25) * 3) + 0)];
                tempgreen = byteInput[(int)(((secondcounter * 0.25) * 3) + 1)];
                tempblue = byteInput[(int)(((secondcounter * 0.25) * 3) + 2)];
 
                rgbValues[secondcounter] = tempblue;
                rgbValues[secondcounter + 1] = tempgreen;
                rgbValues[secondcounter + 2] = tempred;
                rgbValues[secondcounter + 3] = tempalpha;
 
                secondcounter = secondcounter + 4;
            }
 
 
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
 
            piccolor.UnlockBits(bmpData);
        }
        
        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            //initializing the camera to be used based on the selection
            manager.CurrentCamera = (Camera)cmbCamera.SelectedItem;

            //Setting the Event handler for the camera
            //manager.CurrentCamera.OnImageCaptured += new EventHandler<CameraEventArgs>(CurrentCamera_OnImageCaptured);

        }

        void CurrentCamera_OnImageCaptured(object sender, CameraEventArgs e)
        {
            //Giving the feed of the camera to the picturepox
            //picFeed.Image = manager.CurrentCamera.GetCurrentImage();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //Displaying the Current image in the other text box
            //picPreview.Image = manager.CurrentCamera.GetCurrentImage();
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            publisher.Connect(Environment.MachineName, 2100);
            client.Client.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, 2100));
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
                MessageBox.Show("Name Not specified");
        }
    }
}
