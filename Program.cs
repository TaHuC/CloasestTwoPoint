using System;
using System.Collections.Generic;
using System.Linq;

namespace CloasestTwoPoint
{
	public class MainClass
	{
		public static void Main()
		{
			var n = int.Parse(Console.ReadLine());

			var points = new List<Point>();


			for (var i = 0; i < n; i++)
			{
				var currentPoint = Console.ReadLine()
										  .Split(' ')
										  .Select(double.Parse)
										  .ToArray();

				points.Add(new Point 
				{
					X = (int)currentPoint[0],
					Y = (int)currentPoint[1]
				});
			}

			var minDist = double.MaxValue;
			Point firstPointMin = null;
			Point secondPointMin = null;

			for (var i = 0; i < points.Count - 1; i++)
			{
				for (var j = i + 1; j < points.Count; j++)
				{
					var firstPoint = points[i];
					var secoondPoint = points[j];

					var currentDist = CalculateDist(firstPoint, secoondPoint);

					if (currentDist < minDist)
					{
						minDist = currentDist;
						firstPointMin = firstPoint;
						secondPointMin = secoondPoint;
					}
				}
			}

			Console.WriteLine($"{minDist:F3}");
			Console.WriteLine($"({firstPointMin.X}, {firstPointMin.Y})");
			Console.WriteLine($"({secondPointMin.X}, {secondPointMin.Y})");
		}

		public static double CalculateDist(Point firstPoint, Point secondPoint)
		{
			var calcX = firstPoint.X - secondPoint.X;
			var calcY = firstPoint.Y - secondPoint.Y;

			var powX = Math.Pow(calcX, 2);
			var powY = Math.Pow(calcY, 2);

			return Math.Sqrt(powX + powY);
		}
	}
}
