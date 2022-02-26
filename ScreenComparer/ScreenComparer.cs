using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ScreenComparer
{
    public partial class ScreenComparer : Form
    {
        public ScreenComparer()
        {
            InitializeComponent();
            textBox_Pos2X.Text = Screen.PrimaryScreen.WorkingArea.Width.ToString();
            textBox_Pos2Y.Text = Screen.PrimaryScreen.WorkingArea.Height.ToString();

            var keys = Enum.GetValues(typeof(Keys));
            foreach (var key in keys)
            {
                comboBox_Keys.Items.Add(key);
                if (key.ToString() == "Home")
                    comboBox_Keys.SelectedItem = key;
            }

            var modifiers = Enum.GetValues(typeof(KeyModifiers));
            foreach(var modifier in modifiers)
            {
                comboBox_Modifiers.Items.Add(modifier);
                if (modifier.ToString() == "Alt")
                    comboBox_Modifiers.SelectedItem = modifier;
            }

            registeredHotKey = HotKeyManager.RegisterHotKey(Keys.Home, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);

            Debug(MessageType.Info, "Version: " + Application.ProductVersion);
            Debug(MessageType.Info, "Emergency Code is WIP");
        }

        private void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            btn_Stop.PerformClick();
            Debug(MessageType.Success, "EMERGENCY CODE EXECUTED! STOPPING EVERYTHING!");
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        // Cursor getter
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        // Foreground setter
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        // Foreground getter
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        // Desktop getter
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        // Desktop setter
        [DllImport("user32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        // Cursor setter
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        // Keyboard simulator
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const int KEYEVENTF_KEYUP = 0x0002;

        // Mouse simulator
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public enum State
        {
            Stopped,
            Running
        }

        public enum MessageType
        {
            Info,
            Success,
            Warning,
            Error,
            Critical
        }

        bool boxFormed = false;
        int x1 = 0, y1 = 0, x2 = Screen.PrimaryScreen.WorkingArea.Width, y2 = Screen.PrimaryScreen.WorkingArea.Height;
        int interval = 100;
        int time = 0, timeCompare = 0;
        int countdown = 5;
        int timeToWait = 500;
        int registeredHotKey;
        Image screen, screen2;
        Bitmap image1, image2;
        Process p;

        #region Functions
        public async void Clicker(int x, int y)
        {
            SetCursorPos(x, y);
            this.Refresh();
            Application.DoEvents();
            if (GetMouseClick() == "left_click")
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);

                await TaskWait();

                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            }
            else if (GetMouseClick() == "right_click")
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);

                await TaskWait();

                mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
            }
            else
            {
                Debug(MessageType.Error, "No mouse button to click was found!");
            }
        }

        public void Debug(MessageType type, string message)
        {
            switch (type)
            {
                case MessageType.Info:
                    textBox_Debugger.SelectionColor = Color.Black;
                    textBox_Debugger.AppendText(DateTime.Now.ToString("HH:mm:ss") + " Info: " + message + "\r\n");
                    break;

                case MessageType.Warning:
                    textBox_Debugger.SelectionColor = Color.DarkOrange;
                    textBox_Debugger.AppendText(DateTime.Now.ToString("HH:mm:ss") + " Warn: " + message + "\r\n");
                    break;

                case MessageType.Error:
                    textBox_Debugger.SelectionColor = Color.Red;
                    textBox_Debugger.AppendText(DateTime.Now.ToString("HH:mm:ss") + " Error: " + message + "\r\n");
                    break;

                case MessageType.Critical:
                    textBox_Debugger.SelectionColor = Color.Crimson;
                    textBox_Debugger.AppendText(DateTime.Now.ToString("HH:mm:ss") + " Critical: " + message + "\r\n");
                    btn_Stop.PerformClick();
                    break;

                case MessageType.Success:
                    textBox_Debugger.SelectionColor = Color.Green;
                    textBox_Debugger.AppendText(DateTime.Now.ToString("HH:mm:ss") + " Info: " + message + "\r\n");
                    break;

                default:
                    break;
            }

            textBox_Debugger.SelectionStart = textBox_Debugger.Text.Length;
            textBox_Debugger.ScrollToCaret();
        }

        public void CreateScreenshotBox()
        {
            Debug(MessageType.Info, "Creating visualization...");

            if(x1 == x2 || y1 == y2 || x2 == 0 || y2 == 0)
            {
                Debug(MessageType.Error, "All box coordinates have not been set yet!");
                return;
            }

            if(x2 < x1 || y2 < y1)
            {
                Debug(MessageType.Critical, "Coordinates of Position2 is more than coordinates of Position1! You can't do that!");
                return;
            } 

            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);

            SolidBrush b = new SolidBrush(Color.FromArgb(127, Color.Red));
            g.FillRectangle(b, new Rectangle(x1, y1, x2 - x1, y2 - y1));

            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);
            boxFormed = true;
        }

        public void CompareScreenshots(int timerCount)
        {
            if (checkBox_OnlyInProcess.Checked)
                LockProcess(textBox_ProcessName.Text);

            if(timerCount % 2 == 0)
            {
                image1 = new Bitmap(CaptureScreen(1)/*, new Size(16, 16)*/);
            }
            else
            {
                image2 = new Bitmap(CaptureScreen(2)/*, new Size(16, 16)*/);
            }

            if(image1 == null || image2 == null)
            {
                return;
            }

            Debug(MessageType.Info, "Performing comparison...");

            string image1_ref, image2_ref;
            bool mismatch = false;
            progressBar_Compare.Visible = true;
            progressBar_Compare.Value = 0;
            progressBar_Compare.Maximum = image1.Width;

            if (image1.Width == image2.Width && image1.Height == image2.Height)
            {
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        image1_ref = image1.GetPixel(x, y).ToString();
                        image2_ref = image2.GetPixel(x, y).ToString();
                        if(image1_ref != image2_ref)
                        {
                            mismatch = true;
                            break;
                        }
                    }
                    progressBar_Compare.Value++;
                }

                if(mismatch)
                {
                    Debug(MessageType.Info, "There was a mismatch detected! Performing " + GetMouseClick());
                    Clicker(((x2 - x1) / 2) + x1, ((y2 - y1) / 2) + y1);
                }
            }
            else
            {
                Debug(MessageType.Critical, "Screenshots are not the same size! This should not have happened :O");
            }

            image1 = null;
            image2 = null;
        }

        public Image CaptureScreen(int screenNum)
        {
            try
            {
                // Create a new Bitmap object
                Bitmap captureBitmap = new Bitmap(x2 - x1, y2 - y1, PixelFormat.Format32bppArgb);

                // Create a rectangle object which will caputre the current screen
                Rectangle captureRectangle = Screen.PrimaryScreen.Bounds;

                // Create new graphics object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                // Copy image from screen
                captureGraphics.CopyFromScreen(x1, y1, 0, 0, captureRectangle.Size); // sourceX = x2 - x1 ; sourceY = y2 - y1

                // Save the image
                if(screenNum == 1)
                {
                    screen = captureBitmap;
                }
                else
                {
                    screen2 = captureBitmap;
                }

                Debug(MessageType.Success, "Screenshot successfully captured!");
                return screenNum == 1 ? screen : screen2;
            }
            catch (Exception ex)
            {
                Debug(MessageType.Error, ex.Message);
                return null;
            }
        }

        public bool LockProcess(string processName)
        {
            if (p != null)
            {
                if (GetForegroundWindow() != p.Handle)
                {
                    SetForegroundWindow(p.MainWindowHandle);
                    return true;
                }
            }
            else
            {
                Debug(MessageType.Info, "Trying to find " + processName + " process...");
                p = Process.GetProcessesByName(processName.ToLower()).FirstOrDefault();
                if (p != null)
                {
                    Debug(MessageType.Info, "Process found! Forcing the " + p.MainWindowTitle + "[" + p.Id + "]" + " to the foreground!");
                    SetForegroundWindow(p.MainWindowHandle);
                    return true;
                }
                else
                {
                    Debug(MessageType.Critical, "Process " + processName + " could not be found!");
                    return false;
                }
            }

            return false;
        }

        public async Task TaskWait()
        {
            await Task.Delay(timeToWait);
        }
        #endregion

        #region Get / Set functions
        /*async Task<bool> SetPosition()
        {
            textBox_Debugger.Text += "Namier myš na tvoju požadovanú pozíciu a stlač C (pre zrušenie stlač A)\r\n";
            while (Keyboard.IsKeyUp(Key.A))
            {
                if(Keyboard.IsKeyDown(Key.C))
                {
                    Point cursor_pos = GetCursorPosition();

                    if (!cursor_pos.IsEmpty)
                    {
                        textBox_Debugger.Text += "Cursor Position captured!\r\n";
                        return true;
                    }
                    else
                        return false;
                }
                await Task.Delay(100);
            }

            return false;
        }*/

        public int SetEmergencyCode()
        {
            return -1;
        }

        public static Point GetCursorPosition()
        {
            return GetCursorPos(out POINT lpPoint) ? lpPoint : Point.Empty;
        }

        State GetState()
        {
            return timerComparer.Enabled ? State.Running : State.Stopped;
        }

        int GetInterval(string txtInterval)
        {
            return int.TryParse(txtInterval, out interval) ? interval : timerComparer.Interval;
        }

        string GetMouseClick()
        {
            if (radioButton_LeftClick.Checked)
                return "left_click";
            else if (radioButton_RightClick.Checked)
                return "right_click";
            else
                return "null";
        }
        #endregion

        #region Buttons
        private void btn_pos1_Click(object sender, EventArgs e)
        {
            if (!timerCountdown.Enabled)
                timerCountdown.Start();
        }

        private void btn_pos2_Click(object sender, EventArgs e)
        {
            if (!timerCountdown.Enabled)
                timerCountdown.Start();
        }

        private void button_ShowBox_Click(object sender, EventArgs e)
        {
            CreateScreenshotBox();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (timerComparer.Enabled || timerUpdater.Enabled)
            {
                Debug(MessageType.Warning, "ScreenComparer is already running!");
                return;
            }

            if(timeToWait < 0)
            {
                Debug(MessageType.Critical, "Time to Wait is not a number!");
                return;
            }

            if(interval < 100)
            {
                Debug(MessageType.Warning, "Interval is less than 100ms! Be advised that this can cause serious CPU processing!");
            }

            if (checkBox_OnlyInProcess.Checked)
                if (!LockProcess(textBox_ProcessName.Text))
                    return;

            timerComparer.Start();
            timerUpdater.Start();
            label_state.Text = "State: " + GetState();
            label_Interval.Text = "Interval: " + timerComparer.Interval.ToString() + " ms";
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            timerComparer.Stop();
            timerUpdater.Stop();
            timerCountdown.Stop();
            time = 0;
            timeCompare = 0;
            progressBar_Compare.Value = 0;
            label_state.Text = "State: " + GetState();
        }
        #endregion

        #region Text Boxes
        private void textBox_Interval_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Interval.Text == "" || textBox_Interval.Text.Trim() == string.Empty)
            {
                return;
            }

            if (timerComparer.Enabled || timerUpdater.Enabled)
                btn_Stop.PerformClick();

            timerComparer.Interval = GetInterval(textBox_Interval.Text);
            label_Interval.Text = "Interval: " + timerComparer.Interval + " ms";
        }

        private void textBox_ProcessName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ProcessName.Text.EndsWith(".exe"))
            {
                Debug(MessageType.Warning, "You don't need to include .exe at the end.");
                textBox_ProcessName.Text = textBox_ProcessName.Text.Replace(".exe", "");
            }
        }

        private void textBox_TimeToWait_TextChanged(object sender, EventArgs e)
        {
            if (textBox_TimeToWait.Text == "" || textBox_TimeToWait.Text.Trim() == string.Empty)
            {
                return;
            }

            int.TryParse(textBox_TimeToWait.Text, out timeToWait);
            label_Wait.Text = "Wait: " + timeToWait + " ms";
        }

        private void textBox_Pos1X_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Interval.Text == "" || textBox_Interval.Text.Trim() == string.Empty)
            {
                return;
            }

            int.TryParse(textBox_Pos1X.Text, out x1);
            label_Pos1.Text = "Position 1: X: " + x1 + " Y: " + y1;

        }

        private void textBox_Pos1Y_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Interval.Text == "" || textBox_Interval.Text.Trim() == string.Empty)
            {
                return;
            }

            int.TryParse(textBox_Pos1Y.Text, out y1);
            label_Pos1.Text = "Position 1: X: " + x1 + " Y: " + y1;
        }

        private void textBox_Pos2X_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Interval.Text == "" || textBox_Interval.Text.Trim() == string.Empty)
            {
                return;
            }

            int.TryParse(textBox_Pos2X.Text, out x2);
            label_Pos2.Text = "Position 2: X: " + x2 + " Y: " + y2;
        }

        private void textBox_Pos2Y_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Interval.Text == "" || textBox_Interval.Text.Trim() == string.Empty)
            {
                return;
            }

            int.TryParse(textBox_Pos2Y.Text, out y2);
            label_Pos2.Text = "Position 2: X: " + x2 + " Y: " + y2;
        }
        #endregion

        #region Combo Boxes
        private void comboBox_Modifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*registeredHotKey = */SetEmergencyCode();
        }

        private void comboBox_Keys_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*registeredHotKey = */SetEmergencyCode();
        }
        #endregion

        #region Labels
        private void label_state_Click(object sender, EventArgs e)
        {
            label_state.Text = "Loading...";
            this.Refresh();
            label_state.Text = "State: " + GetState();
        }

        private void label_Wait_Click(object sender, EventArgs e)
        {
            label_Wait.Text = "Loading...";
            this.Refresh();
            label_Wait.Text = "Wait: " + timeToWait + " ms";
        }

        private void label_Interval_Click(object sender, EventArgs e)
        {
            label_Interval.Text = "Loading...";
            this.Refresh();
            label_Interval.Text = "Interval: " + timerComparer.Interval.ToString() + " ms";
        }
        #endregion

        #region Timers
        private void timerComparer_Tick(object sender, EventArgs e)
        {
            timeCompare++;
            label_Compare.Text = "Compare: " + timeCompare.ToString() + "ms";
            CompareScreenshots(timeCompare);
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            if (countdown == 0)
            {
                timerCountdown.Stop();
                countdown = 5;

                Point cursor_pos = GetCursorPosition();

                if (!cursor_pos.IsEmpty)
                {
                    if (btn_pos1.Focused)
                    {
                        label_Pos1.Text = "Position 1: X: " + cursor_pos.X + " Y: " + cursor_pos.Y;
                        textBox_Pos1X.Text = cursor_pos.X.ToString();
                        textBox_Pos1Y.Text = cursor_pos.Y.ToString();
                        x1 = cursor_pos.X;
                        y1 = cursor_pos.Y;
                        Debug(MessageType.Success, "Cursor position1 captured");
                    }
                    else if (btn_pos2.Focused)
                    {
                        label_Pos2.Text = "Position 2: X: " + cursor_pos.X + " Y: " + cursor_pos.Y;
                        textBox_Pos2X.Text = cursor_pos.X.ToString();
                        textBox_Pos2Y.Text = cursor_pos.Y.ToString();
                        x2 = cursor_pos.X;
                        y2 = cursor_pos.Y;
                        Debug(MessageType.Success, "Cursor position2 captured");
                    }
                    else
                    {
                        Debug(MessageType.Warning, "None of the buttons focused!");
                    }
                }
            }
            else
            {
                Debug(MessageType.Info, "The screen will be taken in: " + countdown + "s");
                countdown--;
            }
        }

        private void timerMouse_Tick(object sender, EventArgs e)
        {
            label_mousePos.Text = "MousePos: " + GetCursorPosition().ToString();
        }

        private void timerUpdater_Tick(object sender, EventArgs e)
        {
            time++;
            label_Timer.Text = "Timer: " + time.ToString() + "s";

            if (x1 != 0 && y1 != 0 && x2 != 0 && y2 != 0 && !boxFormed)
            {
                CreateScreenshotBox();
            }
        }
        #endregion
    }
}
