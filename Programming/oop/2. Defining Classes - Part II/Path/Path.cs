using System;
using System.Collections.Generic;
using PathNamespace;

class Path_
{
    private List<Point3D> path;

    public List<Point3D> Path
    {
        get { return path; }
    }

    public Path_(List<Point3D> path)
    {
        this.path = path;
    }

    public Path_()
    {
        this.path = new List<Point3D>();
    }

    public void AddPointToPath(Point3D point)
    {
        this.path.Add(point);
    }
}


