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
        private Mat valFilter = null;
        private int[,,] arr = null;
        private DsDevice[] _sysCams = null;
        private int _camIndex;
        private int Val;
        private int ValMax;
        private bool _captureInProgress;
        private int _frames = 0;
        private long _currentTime;
        private long _fps;
        private int _dFps;
        private int size, pSize;
        private double sfps = 30;
        private Int32 width = 640;
        private Int32 height = 480;
        private List<KeyValuePair<int, string>> camList = null;
        private Mat hsv_v;


        public PointTracker()
        {
            size = 20;
            pSize = 20;
            frame = new Mat();
            frameHsv = new Mat();
            valFilter = new Mat();
            InitializeComponent();
            Val = trackVal.Value;
            ValMax = trackValMax.Value;
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
        /*private int getTrackVal(TrackBar bar)
        {
            int res=0;
            if (InvokeRequired)
                Invoke(new Action(() => res = getTrackVal(bar)));
            else
                res = bar.Value;
            return res;
        }*/
        /*private void inRangeImage(Mat hsvImage, int lower, int upper, Mat outImage)
        {
            Mat lowerBorder = new Mat(hsvImage.Rows, hsvImage.Cols, hsvImage.Depth, hsvImage.NumberOfChannels);
            Mat upperBorder = new Mat(hsvImage.Rows, hsvImage.Cols, hsvImage.Depth, hsvImage.NumberOfChannels);

            lowerBorder.SetTo(new Gray(lower).MCvScalar);
            upperBorder.SetTo(new Gray(upper).MCvScalar);

            CvInvoke.InRange(hsvImage, lowerBorder, upperBorder, outImage);

            // Dispose the image due to causing memory leaking.
            lowerBorder.Dispose();
            upperBorder.Dispose();
            
        }*/
        /*private int[,,] getArray(Mat Image)// Get array from Mat image
        {
            int cols = 0, rows = 0, chan = 0, k=0;
            chan = Image.NumberOfChannels;
            cols = Image.Cols;
            rows = Image.Rows;

            int[,,] arrIn = new int[cols, rows, chan];

            byte[] data = new byte[cols * rows * chan];
            data = Image.GetData();

            for (int i = chan - 1; i < rows * cols * chan; i += chan)
            {
                for (int j = 0; j < chan; j++)
                {
                    arrIn[(i/chan)%cols,(i/chan)/cols,j]=data[i-j];
                }
            }

            return arrIn;
        }
        private void setArray(int[,,] arrIn, Mat Image)// Set array to Mat image
        {
            int cols = 0, rows = 0, chan = 0;
            chan = Image.NumberOfChannels;
            cols = Image.Cols;
            rows = Image.Rows;


            byte[] data = new byte[cols * rows * chan];
            data = Image.GetData();

            for (int i = chan - 1; i < rows * cols * chan; i += chan)
            {
                for (int j = 0; j < chan; j++)
                {
                    data[i - j] = Convert.ToByte(arrIn[(i / chan) % cols, (i / chan) / cols, j]);
                }
            }
            Image.SetTo(data);
        }*/
        /*private void addFilter(Mat mainImage, Mat addImage)
        {
            int mainC = 0, mainR = 0, addC = 0, addR = 0, mainChan=0, addChan=0;
            mainChan = mainImage.NumberOfChannels;
            addChan = addImage.NumberOfChannels;

            mainC = mainImage.Cols;
            addC = addImage.Cols;
            mainR = mainImage.Rows;
            addR = addImage.Rows;

            byte[] data = new byte[mainC * mainR * mainChan];
            data = mainImage.GetData();

            byte[] addData = new byte[addC * addR * addChan];
            addData = addImage.GetData();


            for (int i = mainChan - 1; i < mainR * mainC * mainChan; i += mainChan)
            {
                if (addData[i * addChan / mainChan] == 255)
                {
                    data[i] = 0;
                    data[i - 1] = 0;
                    data[i - 2] = 255;
                }
                if (addData[i * addChan / mainChan] == 1)
                {
                    data[i] = 255;
                    data[i - 1] = 0;
                    data[i - 2] = 0;
                }
                if (addData[i * addChan / mainChan] == 2)
                {
                    data[i] = 0;
                    data[i - 1] = 255;
                    data[i - 2] = 0;
                }
                if (addData[i * addChan / mainChan] == 3)
                {
                    data[i] = 255;
                    data[i - 1] = 255;
                    data[i - 2] = 0;
                }
                if (addData[i * addChan / mainChan] == 240)
                {
                    data[i] = 255;
                    data[i - 1] = 255;
                    data[i - 2] = 255;
                }
            }


            mainImage.SetTo(data);
            
        }*/
        private void ProcessFrame(object sender, EventArgs arg)
        {
            _capture.Retrieve(frame, 0);
            
            CvInvoke.CvtColor(frame, frameHsv, ColorConversion.Bgr2Hsv);

            valFilter = frameHsv.Split()[2];

            //inRangeImage(hsv_v, Val, ValMax, valFilter);// Get filtered image


            int cols, rows;
            int mat;
            cols = valFilter.Cols;
            rows = valFilter.Rows;

            mat = cols * rows;
            byte[] data = new byte[mat];
            byte[] dataFil = new byte[mat];
            byte[] dataOut = new byte[mat];
            data = valFilter.GetData();
            dataFil = valFilter.GetData();
            dataOut = frame.GetData();

            for (int i = 0; i < mat; i++)
            {
                if (data[i] >= Val && data[i] <= ValMax)
                {
                    data[i] = 255;
                    dataFil[i] = 255;
                }
                else
                {
                    data[i] = 0;
                    dataFil[i] = 0;
                }
            }

            int sum;
            bool inPoint;

            byte k=1;
            
            inPoint = true;
            int points, maxPoints;
            int y, x, my, mx;
            int[] height, width, ys, xs;

            maxPoints = 3;

            height = new int[2];
            width = new int[2];
            ys = new int[2];
            xs = new int[2];
            bool kek;
            kek = true;
            while (inPoint && k <= maxPoints)
            {
                inPoint = false;
                points = 0;
                int inc = 1;
                xs[k] = 0;
                ys[k] = 0;
                width[k] = 0;
                height[k] = 0;
                for (int i = 0; i < mat && i>=0 || i == mat && Convert.ToBoolean(inc=-inc) && Convert.ToBoolean(i--); i+=inc)
                {
                    if (data[i] == 255 && !inPoint)
                    {

                        inPoint = true;
                        for (int j = 0; j < size; j++)
                        {
                            for (int l = 0; l < size; l++)
                            {
                                if (!(i + cols * j * inc + l * inc > 0 && i + cols * j * inc + l * inc < mat && (i % cols + l * inc) < cols && (i % cols + l * inc) >= 0) || (data[i + cols * j * inc + l * inc] != 255))
                                {
                                        inPoint = false;
                                }
                                /*if (!(((i + cols * j * inc + l * inc) % cols) * inc >= (i % cols) * inc && ((i + cols * j * inc + l * inc) / cols) * inc >= (i / cols) * inc))
                                {
                                    inPoint = false;
                                }*/
                                if (!inPoint) break;
                            }
                            if (!inPoint) break;
                        }
                        if (inPoint) { 
                            points++; 
                            data[i] = k;
                        }
                    }
                    if (data[i] == k)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                if ((l!=0 || j!=0) && (i + cols * j + l > 0 && i + cols * j + l < mat && (i % cols  + l) < cols && (i % cols  + l) >= 0 && (data[i + cols * j + l] == 255)))
                                {
                                    data[i + cols * j + l] = k;
                                    points++;
                                }
                            }
                        }
                        if (i > 0)
                        {
                            x = i % (cols);
                            y = i / (cols);
                            xs[k]++;
                            ys[k]++;
                            width[k] += x;
                            height[k] += y;
                        }
                    }
                }
                k++;
                if (k <= maxPoints)
                {
                    Array.Resize(ref xs, xs.Length + 1);
                    Array.Resize(ref ys, ys.Length + 1);
                    Array.Resize(ref width, width.Length + 1);
                    Array.Resize(ref height, height.Length + 1);
                }
            }

            bool isCir;

            /*for (int j = 1; j <= k; j++)
            {
                xs[j]=0;
                ys[j]=0;
                width[j] =0;
                height[j] =0;

                for (int i = 0; i < (cols) * (rows); i++)
                {
                    if (data[i] == j)
                    {
                        isCir = true;
                        x = i % (cols);
                        y = i / (cols);
                        xs[j]++;
                        ys[j]++;
                        width[j] += x;
                        height[j] += y;
                    }
                }
            }*/

            for (int l = 1; l < k; l++)
            {
                if (xs[l] > 0 && ys[l] > 0)
                {
                    mx = width[l] / xs[l];
                    my = height[l] / ys[l];
                    for (int i = -pSize; i <= pSize; i++)
                    {
                        int j = 0;
                        if (((my + i) * cols + mx + j) < cols * rows && ((my + i) * cols + mx + j) > 0)
                        {
                            dataFil[((my + i) * cols + mx + j)] = 240;
                        }
                    }
                    for (int j = -pSize; j <= pSize; j++)
                    {
                        int i =  0;
                        if (((my + i) * cols + mx + j) < cols * rows && ((my + i) * cols + mx + j) > 0)
                        {
                            dataFil[((my + i) * cols + mx + j)] = 240;
                        }
                    }

                }
            }


            int mainC = 0, mainR = 0, addC = 0, addR = 0, mainChan = 0, addChan = 0;
            mainChan = frame.NumberOfChannels;
            addChan = valFilter.NumberOfChannels;

            mainC = frame.Cols;
            addC = valFilter.Cols;
            mainR = frame.Rows;
            addR = valFilter.Rows;

            for (int i = mainChan - 1; i < mainR * mainC * mainChan; i += mainChan)
            {
                if (dataFil[i * addChan / mainChan] == 255)
                {
                    dataOut[i] = 0;
                    dataOut[i - 1] = 0;
                    dataOut[i - 2] = 255;
                }
                /**/if (data[i * addChan / mainChan] == 1)
                {
                    dataOut[i] = 255;
                    dataOut[i - 1] = 0;
                    dataOut[i - 2] = 0;
                }
                if (data[i * addChan / mainChan] == 2)
                {
                    dataOut[i] = 0;
                    dataOut[i - 1] = 255;
                    dataOut[i - 2] = 0;
                }
                if (data[i * addChan / mainChan] == 3)
                {
                    dataOut[i] = 255;
                    dataOut[i - 1] = 255;
                    dataOut[i - 2] = 0;
                }
                if (dataFil[i * addChan / mainChan] == 240)
                {
                    dataOut[i] = Convert.ToByte(255-dataOut[i]);
                    dataOut[i - 1] = Convert.ToByte(255 - dataOut[i - 1]);
                    dataOut[i - 2] = Convert.ToByte(255 - dataOut[i - 2]);
                }
            }

            //valFilter.SetTo(dataFil);

            frame.SetTo(dataOut);
            //addFilter(frame, valFilter);

            //frameOut = new Mat();

            imageBox1.Image = frame;


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
            /*frame.Dispose();
            frameHsv.Dispose();
            valFilter.Dispose();*/
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

        private void trackVal_Scroll(object sender, EventArgs e)
        {
            Val = trackVal.Value;
        }

        private void trackValMax_Scroll(object sender, EventArgs e)
        {
            ValMax = trackValMax.Value;
        }
    }
}
