using RevisionProgram2.dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.packs
{
    public struct Pack
    {
        static readonly string savePath = $"{Helper.directory}temp/PackList.txt";

        public static void ShowPacks()
        {
            Directory.CreateDirectory(Helper.directory + "temp");

            bool worked = false;
            WaitingForm.BeginWait("Downloading pack data...", () =>
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile($"https://github.com/CosmoleonGit/RevisionHub/raw/master/Packs/_List.txt", savePath);
                    }
                    
                    worked = true;
                }
                catch (Exception ex)
                {
                    Helper.Error("Failed to load pack data.", "Reason: " + ex.Message);
                }
            });

            if (worked)
            {
                var packList = new List<Pack>();
                var lineQueue = new Queue<string>();

                string[] lines = File.ReadAllLines(savePath);

                File.Delete(savePath);

                foreach (string line in Helper.SplitByLine(lines, "-"))
                {
                    lineQueue.Enqueue(line);
                }

                while(lineQueue.Count > 0)
                {
                    string name = lineQueue.Dequeue();
                    string desc = lineQueue.Dequeue();

                    packList.Add(new Pack(name, desc));
                }

                var packsForm = new PacksForm(packList.ToArray());
                packsForm.Show();
            }
        }

        public Pack(string _name, string _desc)
        {
            packName = _name;
            description = _desc;
        }

        public readonly string packName, description;
    }
}
