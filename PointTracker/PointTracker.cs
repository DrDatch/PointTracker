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
        DsDevice[] _sysCams = null;
        private int _camIndex;
        private bool _captureInProgress;
        private int _frames=0;
        private long _currentTime;
        private long _fps;
        private int _dFps;
        private int _gain;
        private int _gainDef;
        private int _exposure;
        private int _exposureDef;
        private int _brigtness;
        private int _brigtnessDef;
        private int _contrast;
        private int _contrastDef;
        private double sfps = 30;
        private Int32 width = 640;
        private Int32 height = 480;
        List<KeyValuePair<int, string>> camList = null;
        public PointTracker()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            camList= new List<KeyValuePair<int, string>>();
            _sysCams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            _camIndex = 0;
            imageBox1.SizeMode = PictureBoxSizeMode.Zoom;
            foreach(DsDevice _camera in _sysCams){
                camList.Add(new KeyValuePair<int, string>(_camIndex,_camera.Name));
                _camIndex++;
            }
            _camIndex--;
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

            Mat frameProc = new Mat();
            CvInvoke.CvtColor(frame, frameProc, ColorConversion.Bgr2Gray);

            double cannyThreshold = 180.0;
            double circleAccumulatorThreshold = 120;
            CircleF[] circles = CvInvoke.HoughCircles(frameProc, HoughType.Gradient, 2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, 5);
            foreach (CircleF circle in circles)
                CvInvoke.Circle(frameProc, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Brown).MCvScalar, 2);

            imageBox1.Image = frameProc;
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
       private void printConsole(string line){
           consoleBox.Items.Add(line);
           consoleBox.SelectedIndex = consoleBox.Items.Count - 1;
           consoleBox.SelectedIndex = -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_captureInProgress)
            {
                //stop the capture
                button1.Text = "Start";
                camListComboBox.Enabled = true;
                fpsBox.Enabled = true;
                widthBox.Enabled = true;
                heightBox.Enabled = true;
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
                fpsBox.Enabled = false;
                widthBox.Enabled = false;
                heightBox.Enabled = false;
                if (String.IsNullOrWhiteSpace(fpsBox.Text))
                {
                    fpsBox.Text = sfps.ToString();
                    printConsole("FPS set automaticaly: " + fpsBox.Text + "\n");
                }
                else
                {
                    sfps = Convert.ToInt32(fpsBox.Text);
                }
                if (String.IsNullOrWhiteSpace(widthBox.Text) || String.IsNullOrWhiteSpace(heightBox.Text))
                {
                    widthBox.Text = width.ToString();
                    heightBox.Text = height.ToString();
                    printConsole("Frame size set automaticaly: " + widthBox.Text + " x " + heightBox.Text+ "\n");
                }
                else
                {
                    width = Convert.ToInt32(widthBox.Text);
                    height = Convert.ToInt32(heightBox.Text);
                }
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, sfps);
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, width);
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, height);
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
            if (_camIndex != SelectedItem.Key)
            {
                _camIndex = SelectedItem.Key;
                if (_capture != null)
                {
                    _capture.Dispose();
                }
                _capture = new Capture(_camIndex);
                GetCaptureInfo();
                _capture.Dispose();
            }
        }
        private void GetCaptureInfo()
        {
            printConsole("Camera: " + camList[_camIndex].Value + "\n");  //Camera name
            gainBar.Value = _gain = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Gain);
            printConsole("Gain " + _gain.ToString() + "\n");
            exposureBar.Value = _exposure = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure);
            printConsole("Exposure " + _exposure.ToString() + "\n");
            contrastBar.Value = _contrast = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Contrast);
            printConsole("Contrast " + _contrast.ToString() + "\n");
            brigtnessBar.Value = _brigtness = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness);
            printConsole("Brigtness " + _brigtness.ToString() + "\n");
            
        }

        private void gainBar_Scroll(object sender, EventArgs e)
        {
             _gain = gainBar.Value;
             _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Gain,_gain);
        }

        private void exposureBar_Scroll(object sender, EventArgs e)
        {
             _exposure = exposureBar.Value;
             _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure,_exposure);

        }

        private void contrastBar_Scroll(object sender, EventArgs e)
        {
             _contrast = contrastBar.Value;
             _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Contrast,_contrast);

        }

        private void brigtnessBar_Scroll(object sender, EventArgs e)
        {
             _brigtness = brigtnessBar.Value;
             _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness,_brigtness);
             
        }
    }
}
