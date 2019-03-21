using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;

namespace Segmentation
{
    public static class SegmentationBitmap
    {
        public static Bitmap RunSeparation(Bitmap sourceBitmap, SegmentationType type, Connectivity connectivity, double delta, IntensivityStandard standard, ColorsOfSegments colorsOfSegments, CancellationToken token)
        {
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            Pixel[,] graphFromSourceBitmap = BuildGraphByImage(sourceBitmap);
            
            // Получаем набор связных ребер для данного пикселя           
            IList<Edge> collectionOfEdges = GetEdges(graphFromSourceBitmap, connectivity);

            // Присваиваем им вес в зависимости от выбранного способа сегментации и сортируем их по возрастанию
            collectionOfEdges = SortEdges(collectionOfEdges, type, standard);

            // Создадим коллекцию для будующих сегментов, первым сегментом будет первое ребро из нашего полученного graphFromSoueceBitmap.
            List<Tree> segments = new List<Tree>() { new Tree(collectionOfEdges.First()) };

            // На начальном этапе имеется набор минимальных деревьев, состоящих из одного ребра, имеющего свой вес. Объекты отсортированы по возрастанию.
            // Делаем обход по всем пикселям, объединяя соседние в деревья (либо соседние деревья в одно), если они удовлетворяют критерию похожести            
            foreach (var edge in collectionOfEdges)
            {
                token.ThrowIfCancellationRequested();
                if (edge.EndPixel.Root == null && edge.StartPixel.Root == null)
                {
                    //Оба пикселя ребра не принадлежат ни одному из сегментов, значит такого сегмента еще нет и его необходимо создать
                    segments.Add(new Tree(edge));
                }                
                else if (edge.StartPixel.Root != null && edge.EndPixel.Root == null)
                {
                    Tree tree = GetTreeByRoot(edge.StartPixel.Root, segments);
                    // Первый пиксель ребра содержится в каком то сегменте, нужно проверить на возможноть присоединения ребра к treeOfStartPixel
                    if (Math.Abs(edge.Weight - tree.MaxWeightEdge.Weight) > delta)
                    {
                        // Перепад больше заданного параметра delta, поэтому мы не присоединяем это ребро к treeOfStartPixel,
                        // переходим к рассмотрению следующего ребра
                        continue;
                    }
                    else
                    {
                        // Перепад удовлетворяет заданному параметру delta, поэтому мы присоединяем это ребро к treeOfStartPixel
                        tree.AddEdge(edge.StartPixel, edge.EndPixel);
                    }
                }
                else if (edge.StartPixel.Root == null && edge.EndPixel.Root != null)
                {
                    Tree tree = GetTreeByRoot(edge.EndPixel.Root, segments);
                    // Второй пиксель ребра содержится в каком то сегменте, нужно проверить на возможноть присоединения ребра к treeOfEndPixel
                    if (Math.Abs(edge.Weight - tree.MaxWeightEdge.Weight) > delta)
                    {
                        // Перепад больше заданного параметра delta, поэтому мы не присоединяем это ребро к treeOfStartPixel,
                        // переходим к рассмотрению следующего ребра
                        continue;
                    }
                    else
                    {
                        // Перепад удовлетворяет заданному параметру delta, поэтому мы присоединяем это ребро к treeOfStartPixel
                        tree.AddEdge(edge.EndPixel, edge.StartPixel);
                    }
                }
                else if (edge.EndPixel.Root.Equals(edge.StartPixel.Root))
                {
                    // Точки этого ребра уже содержаться в одном дереве, поэтому переходим к следующему ребру
                    continue;
                }
                else
                {
                    Tree firstTree = GetTreeByRoot(edge.StartPixel.Root, segments);
                    Tree secondTree = GetTreeByRoot(edge.EndPixel.Root, segments);
                    // Пиксели ребра содержатся в разных сегментах, нужно проверить возможность их объединения
                    if (Math.Abs(edge.Weight - firstTree.MaxWeightEdge.Weight) > delta ||
                        Math.Abs(edge.Weight - secondTree.MaxWeightEdge.Weight) > delta)
                    {
                        // Если перепад на границе и внутри хотя бы одного сегмента больше заданного параметра delta, 
                        // тогда эти сегменты не объединяются и переходим к рассмотрению следующего ребра
                    }
                    else
                    {
                        // Перепад на границе удовлетворяет заданному параметру delta, нужно объединить эти сегменты
                        // Сначала добавим ребро к графу
                        firstTree.AddEdge(edge);                                               
                        // Потом присоединим второе дерево
                        firstTree.Join(secondTree);
                        // Удалим сегмент после его присоединения
                        segments.Remove(secondTree);
                    }
                }                
            }

            // Сгенерируем цвета для полученных областей
            InitiateColorSegments(segments, colorsOfSegments, token);

            // Заполним resultBitmap
            foreach(var tree in segments)
            {
                foreach(var pixel in tree.Pixels)
                {
                    resultBitmap.SetPixel(pixel.X, pixel.Y, tree.Color);
                }
            }

            return resultBitmap;
        }

        private static Pixel[,] BuildGraphByImage(Bitmap image)
        {
            Pixel[,] graph = new Pixel[image.Width, image.Height];

            // Проходим по всем пикселям и строим граф по исходному изображению
            for (int row = 0; row < image.Height; row++)
                for (int column = 0; column < image.Width; column++)
                {
                    graph[column, row] = new Pixel(column, row, image.GetPixel(column, row));
                }
            return graph;
        }

        private static IList<Edge> GetEdges(Pixel[,] graphImage, Connectivity connectType)
        {
            List<Edge> edges = new List<Edge>();
            int columnCount = graphImage.GetLength(0);
            int rowCount = graphImage.GetLength(1);
            int correction = 1;

            if (connectType == Connectivity.Four)
            {
                // Создаем ребра для центральных пикселей
                for(int row = 0; row < rowCount - 1; row++)
                {
                    for (int column = 0; column < columnCount - 1; column++)
                    {
                        // Правый горизонтальный пиксель
                        edges.Add(new Edge(graphImage[column, row], graphImage[column + correction, row]));
                        // Нижний вертикальный пиксель
                        edges.Add(new Edge(graphImage[column, row], graphImage[column, row + correction]));
                    }
                }
                // Создаем ребра для правограничных пикселей
                for(int row = 0; row < rowCount - 1; row++)
                {
                    edges.Add(new Edge(graphImage[columnCount - 1, row], graphImage[columnCount - 1, row + correction]));
                }
                // Создаем ребра для последней строки пикселей
                for (int column = 0; column < columnCount - 1; column++)
                {
                    edges.Add(new Edge(graphImage[column, rowCount - correction], graphImage[column + correction, rowCount - correction]));
                }
                //for (int row = 0; row < rowCount; row++)
                //{
                //    for (int column = 0; column < columnCount; column++)
                //    {
                //        if (((column + correction) < columnCount) && row < rowCount)
                //        {
                //            // Правый горизонтальный пиксель
                //            edges.Add(new Edge(graphImage[column, row], graphImage[column + correction, row]));
                //        }
                //        if (column < columnCount && ((row + correction) < rowCount))
                //        {
                //            // Нижний вертикальный пиксель
                //            edges.Add(new Edge(graphImage[column, row], graphImage[column, row + correction]));
                //        }
                //    }
                //}
            }
            else if (connectType == Connectivity.Eight)
            {
                // Создаем ребра для центральных пикселей
                for(int row = 0; row < rowCount - 1; row++)
                {
                    for(int column = 1; column < columnCount - 1; column++ )
                    {
                        edges.Add(new Edge(graphImage[column,row], graphImage[column + correction, row]));
                        for(int indexColumn = column - 1; indexColumn <= column + 1; indexColumn++)
                        {
                            edges.Add(new Edge(graphImage[column, row], graphImage[indexColumn, row + correction]));
                        }
                    }
                }
                // Создаем ребра для лево- и право- граничных пикселей
                for (int row = 0; row < rowCount - 1; row++)
                {
                    // Левограничные
                    edges.Add(new Edge(graphImage[0, row], graphImage[1, row]));
                    edges.Add(new Edge(graphImage[0, row], graphImage[1, row + correction]));
                    edges.Add(new Edge(graphImage[0, row], graphImage[0, row + correction]));
                    // Правограничные
                    edges.Add(new Edge(graphImage[columnCount - correction, row], graphImage[columnCount - correction, row + correction]));
                    edges.Add(new Edge(graphImage[columnCount - correction, row], graphImage[columnCount - 2, row + correction]));
                }
                // Создаем ребра для последней строки пикселей
                for(int column = 0; column < columnCount - 1; column++)
                {
                    edges.Add(new Edge(graphImage[column, rowCount - correction], graphImage[column + correction, rowCount - correction]));
                }
            }
            return edges;
        }

        private static IList<Edge> SortEdges(IList<Edge> workEdges, SegmentationType type, IntensivityStandard standard)
        {
            if (type == SegmentationType.Intensity)
            {
                foreach(var edge in workEdges)
                {
                    edge.Weight = Math.Abs(GetIntensityPixel(edge.StartPixel, standard) - GetIntensityPixel(edge.EndPixel, standard));
                }
            }
            else if (type == SegmentationType.Color)
            {
                foreach(var edge in workEdges)
                {
                    edge.Weight = GetDistColorEdge(edge);
                }
            }

            return workEdges.OrderBy(w => w.Weight).ToList();
        }

        private static double GetIntensityPixel(Pixel pixel, IntensivityStandard standard)
        {
            if (standard == IntensivityStandard.DigitalITU)
            {
                //Digital ITU BT.601
                return (pixel.Color.R * 0.299 + pixel.Color.G * 0.587 + pixel.Color.B * 0.114);
            }
            else if (standard == IntensivityStandard.Photometric)
            {
                //Photometric / digital ITU BT.709
                return (pixel.Color.R * 0.2126 + pixel.Color.G * 0.7152 + pixel.Color.B * 0.0722);
            }
            if (standard == IntensivityStandard.ApproximationFormula)
            {
                //Approximation formula
                return pixel.Color.R * 0.375 + pixel.Color.B * 0.5 + pixel.Color.G * 0.125;                
            }

            return Double.NaN;
        }

        private static double GetDistColorEdge(Edge edge)
        {
            Pixel i = edge.StartPixel;
            Pixel j = edge.EndPixel;
            return Math.Sqrt(Math.Pow(i.Color.R - j.Color.R, 2) + Math.Pow(i.Color.G - j.Color.G, 2) + Math.Pow(i.Color.B - j.Color.B, 2));
        }

        private static Tree GetTreeByRoot(Pixel root, List<Tree> segments)
        {
            for(int index = 0; index < segments.Count; index++)
            {
                if (segments[index].Root.Equals(root))
                {
                    return segments[index];
                }
            }
            return null;
        }
        
        private static void InitiateColorSegments(IList<Tree> segments, ColorsOfSegments colorsOfSegments,CancellationToken token)
        {
            if (colorsOfSegments == ColorsOfSegments.Random)
            {
                Random rand = new Random();
                foreach (var segment in segments)
                {
                    Color color;
                    do
                    {
                        token.ThrowIfCancellationRequested();
                        color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                    }
                    while (!IsUniqueColor(segments, color));
                    segment.SetColor(color);
                }
            }
            else
            {
                foreach (var segment in segments)
                {                    
                    segment.SetColor(segment.Root.Color);
                }
            }
        }

        private static bool IsUniqueColor(IList<Tree> segments, Color color)
        {
            for (int i = 0; i < segments.Count; i++)
            {
                if (segments[i].Color.IsEmpty)
                {
                    return true;
                }
                if (segments[i].Color.Equals(color))
                {
                    return false;
                }
            }
            return true;
        }
    }        
}
