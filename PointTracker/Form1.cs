using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.Util;

namespace PointTracker
{
    public partial class PointTracker : Form
    {
        private Capture _capture = null;
        private int _camIndex;
        private bool _captureInProgress;
        private int _frames=0;
        private long _currentTime;
        private long _fps;
        private int _dFps;
        public PointTracker()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            List<KeyValuePair<int, string>> camList= new List<KeyValuePair<int, string>>();
            DsDevice[] _sysCams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            _camIndex = 0;
            imageBox1.SizeMode = PictureBoxSizeMode.Zoom;
            foreach(DsDevice _camera in _sysCams){
                camList.Add(new KeyValuePair<int, string>(_camIndex,_camera.Name));
                _camIndex++;
            }
            // Очищаем camListComboBox
            camListComboBox.DataSource = null;
            camListComboBox.Items.Clear();
            // Забиваем значения в camListComboBox
            camListComboBox.DataSource = new BindingSource(camList,null);
            camListComboBox.DisplayMember = "Value";
            camListComboBox.ValueMember = "Key";
        }
        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            _capture.Retrieve(frame, 0);
            imageBox1.Image = frame;
            _frames++;
            // Подсчёт FPS
            long _thisTime;
            _thisTime = DateTime.Now.Ticks;
            if ((_thisTime - _currentTime)>300*10000)
            {
                _fps = (_dFps*10000000 / (_thisTime - _currentTime));
                fps.Text = _fps.ToString();
                _dFps = 1;
                _currentTime = _thisTime;
                frames.Text = _frames.ToString();
            }
            else
            {
                _dFps++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_captureInProgress)
            {
                //stop the capture
                button1.Text = "Start";
                camListComboBox.Enabled = true;
                _capture.Dispose();
                _frames = 0;
                _fps = 0;
                _dFps = 1;
            }
            else
            {
                try
                {
                    _capture = new Capture(_camIndex);
                    _capture.ImageGrabbed += ProcessFrame;
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
                //start the capture
                button1.Text = "Stop";
                camListComboBox.Enabled = false;
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 60);
                _capture.Start();
                _currentTime = DateTime.Now.Ticks;
            }

            _captureInProgress = !_captureInProgress;
        }
        private void ReleaseData()
        {
            if (_capture != null)
                _capture.Dispose();
        }

        private void camListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<int, string> SelectedItem = (KeyValuePair<int, string>)camListComboBox.SelectedItem;
            _camIndex = SelectedItem.Key;
        }
    }
}
