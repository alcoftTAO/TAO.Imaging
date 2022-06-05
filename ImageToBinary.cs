using System;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections.Generic;

namespace TAO.Imaging
{
    public static class ImageTo
    {
        public static byte[] ImgToByte(string path)
        {
            /*
             * You write the image path and you receive a byte array.
             */

            try
            {
                Image img = Image.FromFile(@path);
                MemoryStream ms = new MemoryStream();

                img.Save(ms, ImageFormat.Jpeg);

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool[] ImgToBits(string path, bool floatingValueIsFalse = true)
        {
            /*
             * You write the image path and you receive a bool array.
             * 
             * False = 0
             * True = 1
             */

            try
            {
                byte[] a = ImgToByte(path);
                List<bool> bl = new List<bool>();

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == 255)
                    {
                        bl.Add(true);
                    }
                    else if (a[i] == 0)
                    {
                        bl.Add(false);
                    }
                    else
                    {
                        if (floatingValueIsFalse)
                        {
                            bl.Add(false);
                        }
                        else
                        {
                            bl.Add(true);
                        }
                    }
                }

                return bl.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
