using RevisionProgram2.specialControls;
using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.tools
{
    public partial class TimerStopwatch : Form
    {
        public TimerStopwatch()
        {
            InitializeComponent();
        }

        private void TimerStopwatch_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            TypeCombo.Text = "Stopwatch";

            LoadLbl(HourLbl, 23);
            LoadLbl(MinuteLbl, 59);
            LoadLbl(SecondLbl, 59);
        }

        private void LoadLbl(EditableLabel label, int limit)
        {
            label.canChange = new Func<bool>(() => { return !TimerMain.Enabled; });

            label.correct = new Func<string, string, string>((string x, string y) =>
            {
                if (x == "") return x;

                if (!int.TryParse(y, out int i)) return x;

                if (i < 0) return "00";
                if (i > limit) return limit.ToString();

                return y;
            });

            label.TextChanged += (s, e) =>
            {
                CheckReset();
            };
        }

        //int tSec;

        bool flash;
        bool ended;

        DateTime lastTime;

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            DateTime current;
            while (((current = DateTime.Now) - lastTime).TotalSeconds >= 1)
            {
                lastTime = current;

                UpdateTimer();
            }

            /*
            if (tSec != DateTime.Now.Second)
            {
                tSec = DateTime.Now.Second;

                UpdateTimer();
                
            }
            */
            
        }

        void UpdateTimer()
        {
            if (TypeCombo.SelectedIndex == 0)
            {
                if (HourLbl.Text != "23" || MinuteLbl.Text != "59" || SecondLbl.Text != "59")
                {
                    SecondLbl.Text = AddZero(int.Parse(SecondLbl.Text) + 1);

                    if (SecondLbl.Text == "60")
                    {
                        SecondLbl.Text = "00";
                        MinuteLbl.Text = AddZero(int.Parse(MinuteLbl.Text) + 1);

                        if (MinuteLbl.Text == "60")
                        {
                            MinuteLbl.Text = "00";
                            HourLbl.Text = AddZero(int.Parse(HourLbl.Text) + 1);
                        }
                    }
                }

            }
            else
            {
                if (HourLbl.Text != "00" || MinuteLbl.Text != "00" || SecondLbl.Text != "00")
                {
                    SecondLbl.Text = AddZero(int.Parse(SecondLbl.Text) - 1);

                    if (SecondLbl.Text == "0-1")
                    {
                        SecondLbl.Text = "59";
                        MinuteLbl.Text = AddZero(int.Parse(MinuteLbl.Text) - 1);

                        if (MinuteLbl.Text == "0-1")
                        {
                            MinuteLbl.Text = "59";
                            HourLbl.Text = AddZero(int.Parse(HourLbl.Text) - 1);
                        }
                    }
                }
                else
                {
                    if (!ended)
                    {
                        ended = true;

                        Show();
                        BringToFront();

                        new SoundPlayer(Properties.Resources.Beeping).Play();
                    }
                    flash ^= true;

                    BackPanel.BackColourName = flash ? "StopwatchFlash" : "FormColour";

                    Theme.ChangeControl(BackPanel);
                }

            }
        }

        private string AddZero(int i)
        {
            string s = "";
            if (i < 10) s = "0";
            s += i;
            return s;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            SetRunning(!TimerMain.Enabled);
        }

        private void SetRunning(bool running)
        {
            if (running)
            {
                //tSec = DateTime.Now.Second;
                lastTime = DateTime.Now;
                TimerMain.Start();
                StartBtn.Text = "Stop";
                
            } else
            {
                flash = false;
                ended = false;

                BackPanel.BackColourName = "FormColour";
                Theme.ChangeControl(BackPanel);

                TimerMain.Stop();
                StartBtn.Text = "Start";
            }

            CheckReset();
        }

        private void TimerStopwatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void TypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRunning(false);
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            HourLbl.Text = "00";
            MinuteLbl.Text = "00";
            SecondLbl.Text = "00";
        }

        private void PartLbl_TextChanged(object sender, EventArgs e)
        {
            CheckReset();
        }

        void CheckReset() =>
            ResetBtn.Enabled = !TimerMain.Enabled && (HourLbl.Text != "00" || MinuteLbl.Text != "00" || SecondLbl.Text != "00");
    }

    internal class TimerBackPanel : Panel, IColourSpecific
    {
        [Description("Back colour name for panel."), Category("Data")]
        public string BackColourName { get; set; }

        public void UpdateTheme(Theme theme)
        {
            if (!string.IsNullOrEmpty(BackColourName)) BackColor = theme.GetColour(BackColourName);
        }
    }
}
