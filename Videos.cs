using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Drawing;

namespace TAO.Imaging
{
    public static class Videos
    {
        public static void DrawVideoOnConsole(DirectoryInfo info, int FPS, DrawType type)
        {
            FileInfo[] files = info.GetFiles();
            string[] frames = new string[files.Length];

            Console.Clear();

            for (int i = 0; i < frames.Length; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Frame " + i.ToString() + " / " + frames.Length);

                frames[i] = Images.BitmapToASCII(Images.ImageToBitmap(Image.FromFile(files[i].FullName), Console.WindowWidth, Console.WindowHeight), type);
            }

            Console.Clear();

            for (int i = 0; i < frames.Length; i++)
            {
                Console.CursorVisible = false;

                Console.SetCursorPosition(0, 0);
                Console.Write(frames[i]);

                Thread.Sleep(1000 / FPS);
            }
        }
    }
}
