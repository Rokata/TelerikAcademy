using System;

struct Point3D
{
    private static readonly Point3D o = new Point3D(0, 0, 0);
    private double x;
    private double y;
    private double z;

    public static Point3D O
    {
        get { return o; }
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double Z
    {
        get { return z; }
        set { z = value; }
    }

    public Point3D(double x, double y, double z) : this() {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString()
    {
        return string.Format("Point coords: {{{0}, {1}, {2}}}", this.x, this.y, this.z);
    }
}
