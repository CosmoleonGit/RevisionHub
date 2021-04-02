using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.assessments
{
    public enum SortMode
    {
        Normal,
        Reverse,
        Shuffle
    }

    public abstract class Assess : Revision
    {
        public Assess(string _name, string _dir)
        {
            name = _name;
            path = _dir + "/" + _name;

            string desc = "";
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();
                version = reader.ReadLine();
                desc = reader.ReadLine();

                string n;
                while ((n = reader.ReadLine()) != char.MaxValue.ToString())
                {
                    desc += Environment.NewLine + n;
                }
            }

            description = desc;
        }

        public Assess(string path) : this(Path.GetFileName(path), Path.GetDirectoryName(path)) { }

        public readonly string name;
        protected readonly string path;

        public string description;
        protected string version;

        protected Panel settingsPanel;

        internal enum SortType
        {
            NORMAL,
            REVERSE,
            SHUFFLE
        }

        public abstract void CreateSettingsPanel(Panel panel);

        public override void Start(Action onFinish = null)
        {
            var assessForm = new AssessForm(this);

            assessForm.onFinish = () =>
            {
                if (assessForm.DialogResult == DialogResult.OK)
                    Begin(onFinish);
                else
                    onFinish?.Invoke();
            };

            assessForm.Show();
        }

        protected abstract void Begin(Action onFinish = null);
    }
}
