using System;
using System.Collections.Generic;
using PathNamespace;
using System.IO;

static class PathStorage
{
    public static void SaveToFile(Path_ p)
    {
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            foreach (Point3D point in p.Path) writer.WriteLine("{0} {1} {2}", point.X, point.Y, point.Z);
        }
    }

    public static Path_ ReadFromFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            Path_ path = new Path_();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] nums = line.Split(' ');
                path.AddPointToPath(new Point3D(double.Parse(nums[0]), double.Parse(nums[1]), double.Parse(nums[2])));
            }

            return path;
        }
    }
}
