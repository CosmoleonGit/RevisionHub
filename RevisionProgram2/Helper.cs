using RevisionProgram2.dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;

public static class Helper
{
    public static readonly string directory = $"C:/Users/{Environment.UserName}/Revision Hub/";
    static readonly string localDirectory = $"{directory}Revision/";
    public static string LocalDirectory
    {
        get
        {
            Directory.CreateDirectory(localDirectory);
            return localDirectory;
        }
    }

    public static readonly string twoLines = Environment.NewLine + Environment.NewLine;

    public static string[] SplitIntoLines(string s) =>
        s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

    public static string[] SplitByLine(string lines, string by) =>
        SplitByLine(SplitIntoLines(lines), by);

    public static string[] SplitByLine(string[] lines, string by)
    {
        List<string> strList = new List<string>();

        string newStr = "";
        foreach (string line in lines)
        {
            if (line == by)
            {
                strList.Add(newStr);
                newStr = "";
                continue;
            }

            if (newStr != "") newStr += Environment.NewLine;

            newStr += line;
        }

        if (newStr != "") strList.Add(newStr);

        return strList.ToArray();
    }

    public static readonly Random random = new Random();

    public static void ShuffleArray<T>(ref T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = random.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    public static bool Exists(string fullPath) =>
        File.Exists(fullPath) || Directory.Exists(fullPath);

    public static void Error(string s, string reason)
    {
        MsgBox.ShowWait($"{s + twoLines}Reason: {reason}\n\nIf you keep having problems please contact the developer.",
                    "Error", null, MsgBox.MsgIcon.ERROR);
    }

    public static float Clamp(float num, float min, float max)
    {
        return Math.Max(min, Math.Min(max, num));
    }
}

public static class Extensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.Shuffle(new Random());
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (rng == null) throw new ArgumentNullException("rng");

        return source.ShuffleIterator(rng);
    }

    private static IEnumerable<T> ShuffleIterator<T>(
        this IEnumerable<T> source, Random rng)
    {
        var buffer = source.ToList();
        for (int i = 0; i < buffer.Count; i++)
        {
            int j = rng.Next(i, buffer.Count);
            yield return buffer[j];

            buffer[j] = buffer[i];
        }
    }

    public static void ScaleFontToFit(this Control c, float minSize, float maxSize)
    {
        var label = new Label()
        {
            Text = c.Text,
            Font = c.Font,
            MaximumSize = new Size(c.Width, 0),
        };

        float fontSize = c.Font.Size;

        bool down = label.PreferredHeight > c.Height - 10;

        if (down && fontSize != minSize)
        {
            do
            {
                label.Font = new Font(c.Font.Name, fontSize, FontStyle.Bold);
                fontSize -= 0.25f;
            } while (fontSize > minSize && label.PreferredHeight > c.Height - 10);
        } else if (!down && fontSize != maxSize)
        {
            do
            {
                label.Font = new Font(c.Font.Name, fontSize, FontStyle.Bold);
                fontSize += 0.25f;
            } while (fontSize < maxSize && label.PreferredHeight < c.Height - 10);

            fontSize -= 0.25f;
        }

        c.Font = new Font(c.Font.Name, fontSize, FontStyle.Bold);
    }
}