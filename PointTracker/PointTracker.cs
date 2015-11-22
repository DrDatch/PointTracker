﻿using System;
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
        private Mat frame = null;
        private Mat frameProc = null;
        private Mat frameHsv = null;
        private Mat frameOut = null;
        private DsDevice[] _sysCams = null;
        private int _camIndex;
        private bool _captureInProgress;
        private int _frames = 0;
        private long _currentTime;
        private long _fps;
        private int _dFps;
        private double sfps = 30;
        private Int32 width = 640;
        private Int32 height = 480;
        private List<KeyValuePair<int, string>> camList = null;
        private Mat[] hsv;
        private Mat hsv_h;
        private Mat hsv_s;
        private Mat hsv_v;

        private int Hmin = 0;
        private int Hmax = 256;

        private int Smin = 0;
        private int Smax = 256;

        private int Vmin = 0;
        private int Vmax = 256;

        private int HSVmax = 256;

        public PointTracker()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            camList = new List<KeyValuePair<int, string>>();
            _sysCams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            _camIndex = 0;
            imageBox1.SizeMode = PictureBoxSizeMode.Zoom;
            foreach (DsDevice _camera in _sysCams)
            {
                camList.Add(new KeyValuePair<int, string>(_camIndex, _camera.Name));
                _camIndex++;
            }
            _camIndex--;
            // Очищаем camListComboBox
            camListComboBox.DataSource = null;
            camListComboBox.Items.Clear();
            // Забиваем значения в camListComboBox
            camListComboBox.DataSource = new BindingSource(camList, null);
            camListComboBox.DisplayMember = "Value";
            camListComboBox.ValueMember = "Key";
        }
        private void setLabelValue(Label l, string value)
        {
            if (InvokeRequired)
                Invoke(new Action(() => setLabelValue(l, value)));
            else
                l.Text = value;
        }
        private int getTrackVal(TrackBar bar)
        {
            int res=0;
            if (InvokeRequired)
                Invoke(new Action(() => res = getTrackVal(bar)));
            else
                res = bar.Value;
            return res;
        }
        private Mat inRangeImage(Mat hsvImage, int lower, int upper)
        {
            Mat resultImage = new Mat(hsvImage.Rows, hsvImage.Cols, hsvImage.Depth, hsvImage.NumberOfChannels);
            Mat lowerBorder = new Mat(hsvImage.Rows, hsvImage.Cols, hsvImage.Depth, hsvImage.NumberOfChannels);
            Mat upperBorder = new Mat(hsvImage.Rows, hsvImage.Cols, hsvImage.Depth, hsvImage.NumberOfChannels);

            lowerBorder.SetTo(new Gray(lower).MCvScalar);
            upperBorder.SetTo(new Gray(upper).MCvScalar);

            CvInvoke.InRange(hsvImage, lowerBorder, upperBorder, resultImage); // Crash is here!! <=======================

            // Dispose the image due to causing memory leaking.
            lowerBorder.Dispose();
            upperBorder.Dispose();

            return resultImage;

        }
        private void ProcessFrame(object sender, EventArgs arg)
        {
            frame = new Mat();
            _capture.Retrieve(frame, 0);
            
            frameHsv = new Mat();
            CvInvoke.CvtColor(frame, frameHsv, ColorConversion.Bgr2Hsv);

            hsv = frameHsv.Split();
            hsv_h = hsv[0];
            hsv_s = hsv[1];
            hsv_v = hsv[2];

            Mat valFilter = new Mat(frame.Rows, frame.Cols, frame.Depth, frame.NumberOfChannels);
            
            valFilter = inRangeImage(hsv_v, getTrackVal(trackVal), getTrackVal(trackValMax));
            
            imageBox1.Image = valFilter;


            _frames++;
            // Подсчёт FPS
            long _thisTime;
            _thisTime = DateTime.Now.Ticks;
            if ((_thisTime - _currentTime) > 300 * 10000)
            {
                _fps = (_dFps * 10000000 / (_thisTime - _currentTime));
                setLabelValue(fps, _fps.ToString());
                _dFps = 1;
                _currentTime = _thisTime;
                setLabelValue(frames, _frames.ToString());
            }
            else
            {
                _dFps++;
            }

            // Killing all Mat
            frame.Dispose();
            frameHsv.Dispose();
            valFilter.Dispose();
        }
        private void printConsole(string line)
        {
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
                    printConsole("Frame size set automaticaly: " + widthBox.Text + " x " + heightBox.Text + "\n");
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
                //_capture = new Capture(_camIndex);
                GetCaptureInfo();
                //_capture.Dispose();
            }
        }
        private void GetCaptureInfo()
        {
            printConsole("Camera: " + camList[_camIndex].Value + "\n");  //Camera name

            /*gainBar.Value = _gain = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Gain);
            printConsole("Gain " + _gain.ToString() + "\n");
            exposureBar.Value = _exposure = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure);
            printConsole("Exposure " + _exposure.ToString() + "\n");
            contrastBar.Value = _contrast = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Contrast);
            printConsole("Contrast " + _contrast.ToString() + "\n");
            brigtnessBar.Value = _brigtness = (int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness);
            printConsole("Brigtness " + _brigtness.ToString() + "\n");*/

        }
    }
}
