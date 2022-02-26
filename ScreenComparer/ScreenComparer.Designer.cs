
namespace ScreenComparer
{
    partial class ScreenComparer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenComparer));
            this.btn_pos1 = new System.Windows.Forms.Button();
            this.btn_pos2 = new System.Windows.Forms.Button();
            this.label_copyright = new System.Windows.Forms.Label();
            this.label_debugger = new System.Windows.Forms.Label();
            this.label_mousePos = new System.Windows.Forms.Label();
            this.timerMouse = new System.Windows.Forms.Timer(this.components);
            this.label_Pos1 = new System.Windows.Forms.Label();
            this.label_Pos2 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.timerComparer = new System.Windows.Forms.Timer(this.components);
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.label_Interval = new System.Windows.Forms.Label();
            this.label_Timer = new System.Windows.Forms.Label();
            this.timerUpdater = new System.Windows.Forms.Timer(this.components);
            this.textBox_Interval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.progressBar_Compare = new System.Windows.Forms.ProgressBar();
            this.radioButton_LeftClick = new System.Windows.Forms.RadioButton();
            this.radioButton_RightClick = new System.Windows.Forms.RadioButton();
            this.button_ShowBox = new System.Windows.Forms.Button();
            this.textBox_Debugger = new System.Windows.Forms.RichTextBox();
            this.label_Compare = new System.Windows.Forms.Label();
            this.checkBox_OnlyInProcess = new System.Windows.Forms.CheckBox();
            this.textBox_ProcessName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TimeToWait = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Wait = new System.Windows.Forms.Label();
            this.textBox_Pos1X = new System.Windows.Forms.TextBox();
            this.textBox_Pos2X = new System.Windows.Forms.TextBox();
            this.textBox_Pos1Y = new System.Windows.Forms.TextBox();
            this.textBox_Pos2Y = new System.Windows.Forms.TextBox();
            this.comboBox_Keys = new System.Windows.Forms.ComboBox();
            this.comboBox_Modifiers = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_pos1
            // 
            this.btn_pos1.Location = new System.Drawing.Point(12, 12);
            this.btn_pos1.Name = "btn_pos1";
            this.btn_pos1.Size = new System.Drawing.Size(114, 23);
            this.btn_pos1.TabIndex = 0;
            this.btn_pos1.Text = "Set Position 1";
            this.btn_pos1.UseVisualStyleBackColor = true;
            this.btn_pos1.Click += new System.EventHandler(this.btn_pos1_Click);
            // 
            // btn_pos2
            // 
            this.btn_pos2.Location = new System.Drawing.Point(12, 67);
            this.btn_pos2.Name = "btn_pos2";
            this.btn_pos2.Size = new System.Drawing.Size(114, 23);
            this.btn_pos2.TabIndex = 1;
            this.btn_pos2.Text = "Set position 2";
            this.btn_pos2.UseVisualStyleBackColor = true;
            this.btn_pos2.Click += new System.EventHandler(this.btn_pos2_Click);
            // 
            // label_copyright
            // 
            this.label_copyright.AutoSize = true;
            this.label_copyright.Location = new System.Drawing.Point(8, 558);
            this.label_copyright.Name = "label_copyright";
            this.label_copyright.Size = new System.Drawing.Size(238, 13);
            this.label_copyright.TabIndex = 3;
            this.label_copyright.Text = "© 2021 made with ♥  by Napakalaking Halimaw";
            // 
            // label_debugger
            // 
            this.label_debugger.AutoSize = true;
            this.label_debugger.Location = new System.Drawing.Point(8, 318);
            this.label_debugger.Name = "label_debugger";
            this.label_debugger.Size = new System.Drawing.Size(54, 13);
            this.label_debugger.TabIndex = 4;
            this.label_debugger.Text = "Debugger";
            // 
            // label_mousePos
            // 
            this.label_mousePos.AutoSize = true;
            this.label_mousePos.Location = new System.Drawing.Point(221, 318);
            this.label_mousePos.Name = "label_mousePos";
            this.label_mousePos.Size = new System.Drawing.Size(140, 13);
            this.label_mousePos.TabIndex = 5;
            this.label_mousePos.Text = "MousePos: X: 1920 Y: 1080";
            // 
            // timerMouse
            // 
            this.timerMouse.Enabled = true;
            this.timerMouse.Tick += new System.EventHandler(this.timerMouse_Tick);
            // 
            // label_Pos1
            // 
            this.label_Pos1.AutoSize = true;
            this.label_Pos1.Location = new System.Drawing.Point(12, 38);
            this.label_Pos1.Name = "label_Pos1";
            this.label_Pos1.Size = new System.Drawing.Size(100, 13);
            this.label_Pos1.TabIndex = 8;
            this.label_Pos1.Text = "Position 1: X: 0 Y: 0";
            // 
            // label_Pos2
            // 
            this.label_Pos2.AutoSize = true;
            this.label_Pos2.Location = new System.Drawing.Point(12, 93);
            this.label_Pos2.Name = "label_Pos2";
            this.label_Pos2.Size = new System.Drawing.Size(136, 13);
            this.label_Pos2.TabIndex = 9;
            this.label_Pos2.Text = "Position 2: X: 1920 Y: 1040";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(278, 211);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(83, 13);
            this.label_state.TabIndex = 10;
            this.label_state.Text = "State: Waiting...";
            this.label_state.Click += new System.EventHandler(this.label_state_Click);
            // 
            // timerComparer
            // 
            this.timerComparer.Tick += new System.EventHandler(this.timerComparer_Tick);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(11, 263);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 8;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(92, 263);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 9;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // label_Interval
            // 
            this.label_Interval.AutoSize = true;
            this.label_Interval.Location = new System.Drawing.Point(268, 224);
            this.label_Interval.Name = "label_Interval";
            this.label_Interval.Size = new System.Drawing.Size(93, 13);
            this.label_Interval.TabIndex = 16;
            this.label_Interval.Text = "Interval: Waiting...";
            this.label_Interval.Click += new System.EventHandler(this.label_Interval_Click);
            // 
            // label_Timer
            // 
            this.label_Timer.AutoSize = true;
            this.label_Timer.Location = new System.Drawing.Point(277, 263);
            this.label_Timer.Name = "label_Timer";
            this.label_Timer.Size = new System.Drawing.Size(84, 13);
            this.label_Timer.TabIndex = 17;
            this.label_Timer.Text = "Timer: Waiting...";
            // 
            // timerUpdater
            // 
            this.timerUpdater.Interval = 1000;
            this.timerUpdater.Tick += new System.EventHandler(this.timerUpdater_Tick);
            // 
            // textBox_Interval
            // 
            this.textBox_Interval.Location = new System.Drawing.Point(15, 139);
            this.textBox_Interval.Name = "textBox_Interval";
            this.textBox_Interval.Size = new System.Drawing.Size(100, 20);
            this.textBox_Interval.TabIndex = 2;
            this.textBox_Interval.Text = "100";
            this.textBox_Interval.TextChanged += new System.EventHandler(this.textBox_Interval_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Update interval (ms)";
            // 
            // timerCountdown
            // 
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // progressBar_Compare
            // 
            this.progressBar_Compare.Location = new System.Drawing.Point(12, 292);
            this.progressBar_Compare.Name = "progressBar_Compare";
            this.progressBar_Compare.Size = new System.Drawing.Size(350, 23);
            this.progressBar_Compare.TabIndex = 20;
            // 
            // radioButton_LeftClick
            // 
            this.radioButton_LeftClick.AutoSize = true;
            this.radioButton_LeftClick.Checked = true;
            this.radioButton_LeftClick.Location = new System.Drawing.Point(263, 28);
            this.radioButton_LeftClick.Name = "radioButton_LeftClick";
            this.radioButton_LeftClick.Size = new System.Drawing.Size(69, 17);
            this.radioButton_LeftClick.TabIndex = 5;
            this.radioButton_LeftClick.TabStop = true;
            this.radioButton_LeftClick.Text = "Left Click";
            this.radioButton_LeftClick.UseVisualStyleBackColor = true;
            // 
            // radioButton_RightClick
            // 
            this.radioButton_RightClick.AutoSize = true;
            this.radioButton_RightClick.Location = new System.Drawing.Point(263, 51);
            this.radioButton_RightClick.Name = "radioButton_RightClick";
            this.radioButton_RightClick.Size = new System.Drawing.Size(76, 17);
            this.radioButton_RightClick.TabIndex = 6;
            this.radioButton_RightClick.TabStop = true;
            this.radioButton_RightClick.Text = "Right Click";
            this.radioButton_RightClick.UseVisualStyleBackColor = true;
            // 
            // button_ShowBox
            // 
            this.button_ShowBox.Location = new System.Drawing.Point(173, 263);
            this.button_ShowBox.Name = "button_ShowBox";
            this.button_ShowBox.Size = new System.Drawing.Size(75, 23);
            this.button_ShowBox.TabIndex = 10;
            this.button_ShowBox.Text = "Show Box";
            this.button_ShowBox.UseVisualStyleBackColor = true;
            this.button_ShowBox.Click += new System.EventHandler(this.button_ShowBox_Click);
            // 
            // textBox_Debugger
            // 
            this.textBox_Debugger.Location = new System.Drawing.Point(12, 334);
            this.textBox_Debugger.Name = "textBox_Debugger";
            this.textBox_Debugger.ReadOnly = true;
            this.textBox_Debugger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textBox_Debugger.Size = new System.Drawing.Size(351, 221);
            this.textBox_Debugger.TabIndex = 24;
            this.textBox_Debugger.TabStop = false;
            this.textBox_Debugger.Text = "";
            // 
            // label_Compare
            // 
            this.label_Compare.AutoSize = true;
            this.label_Compare.Location = new System.Drawing.Point(262, 250);
            this.label_Compare.Name = "label_Compare";
            this.label_Compare.Size = new System.Drawing.Size(100, 13);
            this.label_Compare.TabIndex = 25;
            this.label_Compare.Text = "Compare: Waiting...";
            // 
            // checkBox_OnlyInProcess
            // 
            this.checkBox_OnlyInProcess.AutoSize = true;
            this.checkBox_OnlyInProcess.Location = new System.Drawing.Point(263, 74);
            this.checkBox_OnlyInProcess.Name = "checkBox_OnlyInProcess";
            this.checkBox_OnlyInProcess.Size = new System.Drawing.Size(99, 17);
            this.checkBox_OnlyInProcess.TabIndex = 7;
            this.checkBox_OnlyInProcess.Text = "Only in Process";
            this.checkBox_OnlyInProcess.UseVisualStyleBackColor = true;
            // 
            // textBox_ProcessName
            // 
            this.textBox_ProcessName.Location = new System.Drawing.Point(15, 237);
            this.textBox_ProcessName.Name = "textBox_ProcessName";
            this.textBox_ProcessName.Size = new System.Drawing.Size(100, 20);
            this.textBox_ProcessName.TabIndex = 4;
            this.textBox_ProcessName.Text = "javaw";
            this.textBox_ProcessName.TextChanged += new System.EventHandler(this.textBox_ProcessName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Process name";
            // 
            // textBox_TimeToWait
            // 
            this.textBox_TimeToWait.Location = new System.Drawing.Point(15, 188);
            this.textBox_TimeToWait.Name = "textBox_TimeToWait";
            this.textBox_TimeToWait.Size = new System.Drawing.Size(100, 20);
            this.textBox_TimeToWait.TabIndex = 3;
            this.textBox_TimeToWait.Text = "500";
            this.textBox_TimeToWait.TextChanged += new System.EventHandler(this.textBox_TimeToWait_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Time to wait (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Type of click";
            // 
            // label_Wait
            // 
            this.label_Wait.AutoSize = true;
            this.label_Wait.Location = new System.Drawing.Point(281, 237);
            this.label_Wait.Name = "label_Wait";
            this.label_Wait.Size = new System.Drawing.Size(80, 13);
            this.label_Wait.TabIndex = 32;
            this.label_Wait.Text = "Wait: Waiting...";
            this.label_Wait.Click += new System.EventHandler(this.label_Wait_Click);
            // 
            // textBox_Pos1X
            // 
            this.textBox_Pos1X.Location = new System.Drawing.Point(144, 14);
            this.textBox_Pos1X.Name = "textBox_Pos1X";
            this.textBox_Pos1X.Size = new System.Drawing.Size(44, 20);
            this.textBox_Pos1X.TabIndex = 11;
            this.textBox_Pos1X.Text = "0";
            this.textBox_Pos1X.TextChanged += new System.EventHandler(this.textBox_Pos1X_TextChanged);
            // 
            // textBox_Pos2X
            // 
            this.textBox_Pos2X.Location = new System.Drawing.Point(144, 67);
            this.textBox_Pos2X.Name = "textBox_Pos2X";
            this.textBox_Pos2X.Size = new System.Drawing.Size(44, 20);
            this.textBox_Pos2X.TabIndex = 13;
            this.textBox_Pos2X.Text = "1920";
            this.textBox_Pos2X.TextChanged += new System.EventHandler(this.textBox_Pos2X_TextChanged);
            // 
            // textBox_Pos1Y
            // 
            this.textBox_Pos1Y.Location = new System.Drawing.Point(194, 14);
            this.textBox_Pos1Y.Name = "textBox_Pos1Y";
            this.textBox_Pos1Y.Size = new System.Drawing.Size(44, 20);
            this.textBox_Pos1Y.TabIndex = 12;
            this.textBox_Pos1Y.Text = "0";
            this.textBox_Pos1Y.TextChanged += new System.EventHandler(this.textBox_Pos1Y_TextChanged);
            // 
            // textBox_Pos2Y
            // 
            this.textBox_Pos2Y.Location = new System.Drawing.Point(194, 67);
            this.textBox_Pos2Y.Name = "textBox_Pos2Y";
            this.textBox_Pos2Y.Size = new System.Drawing.Size(44, 20);
            this.textBox_Pos2Y.TabIndex = 14;
            this.textBox_Pos2Y.Text = "1080";
            this.textBox_Pos2Y.TextChanged += new System.EventHandler(this.textBox_Pos2Y_TextChanged);
            // 
            // comboBox_Keys
            // 
            this.comboBox_Keys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Keys.Enabled = false;
            this.comboBox_Keys.FormattingEnabled = true;
            this.comboBox_Keys.Location = new System.Drawing.Point(263, 163);
            this.comboBox_Keys.Name = "comboBox_Keys";
            this.comboBox_Keys.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Keys.TabIndex = 16;
            this.comboBox_Keys.SelectedIndexChanged += new System.EventHandler(this.comboBox_Keys_SelectedIndexChanged);
            // 
            // comboBox_Modifiers
            // 
            this.comboBox_Modifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Modifiers.Enabled = false;
            this.comboBox_Modifiers.FormattingEnabled = true;
            this.comboBox_Modifiers.Location = new System.Drawing.Point(263, 123);
            this.comboBox_Modifiers.Name = "comboBox_Modifiers";
            this.comboBox_Modifiers.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Modifiers.TabIndex = 15;
            this.comboBox_Modifiers.SelectedIndexChanged += new System.EventHandler(this.comboBox_Modifiers_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Emergency Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "+";
            // 
            // ScreenComparer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(375, 580);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Modifiers);
            this.Controls.Add(this.comboBox_Keys);
            this.Controls.Add(this.textBox_Pos2Y);
            this.Controls.Add(this.textBox_Pos1Y);
            this.Controls.Add(this.textBox_Pos2X);
            this.Controls.Add(this.textBox_Pos1X);
            this.Controls.Add(this.label_Wait);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_TimeToWait);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ProcessName);
            this.Controls.Add(this.checkBox_OnlyInProcess);
            this.Controls.Add(this.label_Compare);
            this.Controls.Add(this.textBox_Debugger);
            this.Controls.Add(this.button_ShowBox);
            this.Controls.Add(this.radioButton_RightClick);
            this.Controls.Add(this.radioButton_LeftClick);
            this.Controls.Add(this.progressBar_Compare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Interval);
            this.Controls.Add(this.label_Timer);
            this.Controls.Add(this.label_Interval);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.label_Pos2);
            this.Controls.Add(this.label_Pos1);
            this.Controls.Add(this.label_mousePos);
            this.Controls.Add(this.label_debugger);
            this.Controls.Add(this.label_copyright);
            this.Controls.Add(this.btn_pos2);
            this.Controls.Add(this.btn_pos1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ScreenComparer";
            this.Text = "Screen Comparer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pos1;
        private System.Windows.Forms.Button btn_pos2;
        private System.Windows.Forms.Label label_copyright;
        private System.Windows.Forms.Label label_debugger;
        private System.Windows.Forms.Label label_mousePos;
        private System.Windows.Forms.Timer timerMouse;
        private System.Windows.Forms.Label label_Pos1;
        private System.Windows.Forms.Label label_Pos2;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label label_Interval;
        private System.Windows.Forms.Label label_Timer;
        private System.Windows.Forms.TextBox textBox_Interval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar_Compare;
        private System.Windows.Forms.RadioButton radioButton_LeftClick;
        private System.Windows.Forms.RadioButton radioButton_RightClick;
        private System.Windows.Forms.Button button_ShowBox;
        private System.Windows.Forms.RichTextBox textBox_Debugger;
        public System.Windows.Forms.Timer timerComparer;
        public System.Windows.Forms.Timer timerUpdater;
        public System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.Label label_Compare;
        private System.Windows.Forms.CheckBox checkBox_OnlyInProcess;
        private System.Windows.Forms.TextBox textBox_ProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TimeToWait;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Wait;
        private System.Windows.Forms.TextBox textBox_Pos1X;
        private System.Windows.Forms.TextBox textBox_Pos2X;
        private System.Windows.Forms.TextBox textBox_Pos1Y;
        private System.Windows.Forms.TextBox textBox_Pos2Y;
        private System.Windows.Forms.ComboBox comboBox_Keys;
        private System.Windows.Forms.ComboBox comboBox_Modifiers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

