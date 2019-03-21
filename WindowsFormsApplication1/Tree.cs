using System.Collections.Generic;
using System.Drawing;

namespace Segmentation
{
    public class Tree
    {
        public Pixel Root { get; private set; }
        public List<Pixel> Pixels { get; private set; }
        public List<Edge> Edges { get; private set; }
        public Edge MaxWeightEdge { get; private set; }
        public Color Color { get; private set; }

        public Tree(Edge edge)
        {
            edge.StartPixel.SetRoot(edge.StartPixel);
            Root = edge.StartPixel;            
            Pixels = new List<Pixel>() { edge.StartPixel, edge.EndPixel };
            edge.EndPixel.SetRoot(edge.StartPixel);
            Edges = new List<Edge>() { edge };
            MaxWeightEdge = edge;
        }

        public void AddEdge(Pixel existPixel, Pixel newPixel)
        {
            newPixel.SetRoot(Root);
            Pixels.Add(newPixel);
            Edge newEdge = new Edge(existPixel, newPixel);
            Edges.Add(newEdge);
            if (newEdge.Weight > MaxWeightEdge.Weight)
            {
                MaxWeightEdge = newEdge;
            }            
        }

        public void AddEdge(Edge edge)
        {           
            Edges.Add(edge);
        }

        public void Join(Tree tree)
        {
            foreach (var pixel in tree.Pixels)
            {
                pixel.SetRoot(Root);
                Pixels.Add(pixel);
            }

            foreach (var edge in tree.Edges)
            {
                Edges.Add(edge);
            }

            if (tree.MaxWeightEdge.Weight > MaxWeightEdge.Weight)
            {
                MaxWeightEdge = tree.MaxWeightEdge;
            }
        }

        public void SetColor(Color color)
        {
            Color = color;
        }
    }
}
