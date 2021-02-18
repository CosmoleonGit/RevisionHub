using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.alerts
{
    public struct Alert
    {
        public static void LoadAlerts()
        {
            alertForm = new AlertForm();

            alerts = new List<Alert>();

            DirectoryInfo di = Directory.CreateDirectory(Helper.directory + "Alerts");
            foreach (FileInfo foundFile in di.GetFiles("*", SearchOption.TopDirectoryOnly))
            {
                string[] lines = File.ReadAllLines(Helper.directory + "Alerts/" + foundFile.Name);

                if (lines.Length != 3) continue;

                if (DateTime.TryParse(lines[2], out DateTime dateTime))
                {
                    Alert alert = new Alert(lines[0], lines[1], dateTime);
                    alerts.Add(alert);

                    alertForm.AlertsList.Items.Add(alert.title);
                }
            }

            NotifyIcon = new NotifyIcon()
            {
                Text = "Revision Hub",
                Icon = Properties.Resources.Revision_Program,
                Visible = true
            };

            NotifyIcon.BalloonTipClicked += BalloonClick;

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);

                    int i = alerts.FindIndex(x => x.Ready && !x.editing);

                    if (i != -1)
                    {
                        alerts[i].DoAlert();
                        RemoveFromList(i);

                        Thread.Sleep(4000);
                    }
                }
            })
            {
                IsBackground = true
            };

            thread.Start();

            /*
            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);

                    int i = alerts.FindIndex(x => x.Ready && !x.editing);

                    if (i != -1)
                    {
                        alerts[i].DoAlert();
                        RemoveFromList(i);

                        Thread.Sleep(4000);
                    }

                    
                }
            }).Start();
            */
        }

        static AlertForm alertForm;

        public static void ShowForm()
        {
            alertForm.Show();
        }

        public static NotifyIcon NotifyIcon { get; private set; }

        private static void BalloonClick(object s, EventArgs e)
        {
            alertForm.Show();
            alertForm.BringToFront();
        }

        public static List<Alert> alerts;

        //public static Alert GetAlert(int index) => alerts[index];

        private static void AddToList(Alert alert)
        {
            alerts.Add(alert);
            alertForm.AlertsList.Items.Add(alert.title);
        }

        public static void EditToList(int index, Alert alert)
        {
            File.Delete(Helper.directory + "Alerts/" + alerts[index].title);
            SaveAlert(alert);

            alerts[index] = alert;
            alertForm.AlertsList.Items[index] = alert.title;
        }

        public static void RemoveFromList(int index)
        {
            File.Delete(Helper.directory + "Alerts/" + alerts[index].title);

            alerts.RemoveAt(index);

            if (!alertForm.IsDisposed && alertForm.Loaded)
            {
                alertForm.Invoke(new Action(() =>
                {
                    alertForm.AlertsList.Items.RemoveAt(index);
                }));
            } else
            {
                alertForm.AlertsList.Items.RemoveAt(index);
            }
        }

        public static void CreateAlert(Alert alert)
        {
            SaveAlert(alert);
            AddToList(alert);
        }

        private static void SaveAlert(Alert alert)
        {
            string[] lines = new string[3];

            lines[0] = alert.title;
            lines[1] = alert.message;
            lines[2] = alert.alertTime.ToString();

            File.WriteAllLines(Helper.directory + "Alerts/" + alert.title, lines);
        }

        public Alert(string _title, string _message, DateTime _alertTime)
        {
            title = _title;
            message = _message;
            alertTime = _alertTime;
            editing = false;
        }

        public readonly string title, message;
        public readonly DateTime alertTime;

        public bool Ready => DateTime.Now > alertTime;

        public bool editing;

        public void DoAlert()
        {
            NotifyIcon.BalloonTipTitle = title;
            NotifyIcon.BalloonTipText = message;
            NotifyIcon.ShowBalloonTip(15);
        }
    }
}
