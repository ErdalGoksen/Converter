using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class Form1 : Form
    {
        string videoPath, videoName, musicPath, musicName;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDailog = new OpenFileDialog() { Multiselect = false, Filter = "MP4 File|*.mp4" };
            if (openFileDailog.ShowDialog()==DialogResult.OK)
            {
                videoPath = openFileDailog.FileName;
                videoName = openFileDailog.SafeFileName;

            }
            txtPathVideo.Text = videoPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog()== DialogResult.OK)
            {
                musicPath = folderBrowserDialog.SelectedPath;
                musicName = videoName.Substring(0, videoName.Length - 4);
                musicPath += ("\\" + musicName + ".mp3");
            }
            txtSaveto.Text = musicPath;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var convert = new NReco.VideoConverter.FFMpegConverter();
            convert.ConvertMedia(txtPathVideo.Text.Trim(), txtSaveto.Text.Trim(), "mp3");
        }
    }
}
