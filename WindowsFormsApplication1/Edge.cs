using System;

namespace Segmentation
{
    public class Edge : IEquatable<Edge>
    {
        public Pixel StartPixel { get; private set; }
        public Pixel EndPixel { get; private set; }
        public double Weight { get; set; }

        public Edge(Pixel startPixel, Pixel endPixel)
        {
            StartPixel = startPixel;
            EndPixel = endPixel;
        }

        public bool Equals(Edge other)
        {
            if (other == null)
            {
                return false;
            }

            if ((this.StartPixel.Equals(other.StartPixel) && this.EndPixel.Equals(other.EndPixel)) ||
                (this.StartPixel.Equals(other.EndPixel) && this.EndPixel.Equals(other.StartPixel)))
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
            Edge edgeObj = (obj as Edge);
            if (edgeObj == null)
            {
                return false;
            }
            else return Equals(edgeObj);
        }

        #endregion IEquatable
    }
}
