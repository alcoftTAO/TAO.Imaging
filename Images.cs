using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TAO.Imaging
{
    public static class Images
    {
        public static string BitmapToASCII(Bitmap image, DrawType type)
        {
            string[] ASCIIChars = new string[]
            {
                "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", " "
            };
            string ASCIIContent;

            bool isSpaceLine = false;
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int red, green, blue;
                    red = green = blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    Color gray = Color.FromArgb(red, green, blue);

                    if (!isSpaceLine)
                    {
                        int index = (gray.R * (ASCIIChars.Length - 1)) / 255;
                        int t = 0;

                        if (type == DrawType.BlackOnWhite)
                        {
                            t = index;
                        }
                        else if (type == DrawType.WhiteOnBlack)
                        {
                            t = ASCIIChars.Length - index - 1;
                        }

                        sb.Append(ASCIIChars[t]);
                    }
                }

                if (!isSpaceLine)
                {
                    sb.AppendLine();
                    isSpaceLine = true;
                }
                else
                {
                    isSpaceLine = false;
                }
            }

            ASCIIContent = sb.ToString();
            sb = null;
            image = null;

            return ASCIIContent;
        }

        public static Bitmap ImageToBitmap(Image img, int width, int height)
        {
            return new Bitmap(img, width, height);
        }
    }

    public enum DrawType
    {
        WhiteOnBlack = 0,
        BlackOnWhite = 1
    }
}
