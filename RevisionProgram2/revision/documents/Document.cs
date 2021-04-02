using RevisionProgram2.dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.documents
{
    class Document : Revision
    {
        internal const string documentVersion = "1";

        readonly string name, path;
        public Document(string _name, string _dir)
        {
            name = _name;
            path = _dir + "/" + _name;
        }

        public static void Create(string dir, Action onNameGet, Action<string, string> onFinish)
        {
            // Take name input for the document.
            TextInput.GetInput("Enter a name for your document.", "Document", docName =>
            {
                onNameGet();

                if (docName == "")
                {
                    onFinish("", dir);
                    return;
                }

                var editor = new DocumentForm(docName);

                editor.onFinish = () =>
                {
                    if (editor.DialogResult == DialogResult.OK)
                    {
                        if (editor.Save(dir + "/" + docName))
                            onFinish(docName, dir);
                        else
                            onFinish("", dir);
                    }
                    else 
                        onFinish("", dir);

                };

                editor.Show();
            }, "", s =>
            {
                return TextInput.dirNameValid(s) && !Helper.Exists(dir + s);
            });
        }

        public override void Start(Action onFinish = null)
        {
            //var document = new Document(name, dir);
            if (TryLoadText())
            {
                var docForm = new DocumentForm(name, text);

                docForm.onFinish = () =>
                {
                    docForm.Save(path);

                    onFinish();
                };

                docForm.Show();
            }
            
        }

        public static void Duplicate(string from, string dir, Action onNameGet, Action<string, string> onFinish)
        {
            TextInput.GetInput("Enter a name for your document.", "Document", docName =>
            {
                onNameGet();

                if (docName == "")
                {
                    onFinish("", dir);
                    return;
                }

                var document = new Document(from, dir);
                if (!document.TryLoadText()) return;

                var editor = new DocumentForm(docName, document.text);

                editor.onFinish = () =>
                {
                    if (editor.DialogResult == DialogResult.OK)
                    {
                        if (editor.Save(dir + "/" + docName))
                            onFinish(docName, dir);
                        else
                            onFinish("", dir);
                    }
                    else
                        onFinish("", dir);

                };

                editor.Show();
            }, "", s =>
            {
                return TextInput.dirNameValid(s) && !Helper.Exists(dir + s);
            });
        }

        string text;

        bool TryLoadText()
        {
            try
            {
                var lineList = new List<string>();
                Queue<string> lineQueue = new Queue<string>();

                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    lineQueue.Enqueue(line);
                }

                lineQueue.Dequeue();
                lineQueue.Dequeue();

                string rS = "";
                while (lineQueue.Count > 0)
                {
                    if (rS != "") rS += Environment.NewLine;
                    rS += lineQueue.Dequeue();
                }

                text = rS;
                return true;
            } catch (Exception ex)
            {
                Helper.Error("Failed to open document.", ex.Message);
                return false;
            }
        }
    }
}
