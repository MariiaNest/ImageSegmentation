using System;
using System.Drawing;

namespace Segmentation
{
    public class Pixel : IEquatable<Pixel>
    {
        public Pixel Root { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Color Color { get; private set; }

        public Pixel(int x, int y, Color color)
        {
            Root = null;
            X = x;
            Y = y;
            Color = color;
        }

        public void SetRoot(Pixel root)
        {
            Root = root;
        }

        public bool Equals(Pixel other)
        {
            if (other == null)
            {
                return false;
            }

            if ((this.X == other.X) && (this.Y == other.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region IEquatable

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Pixel pixelObj = (obj as Pixel);
            if (pixelObj == null)
            {
                return false;
            }
            else return Equals(pixelObj);
        }

        #endregion IEquatable
    }
}
