public class Size
{
  private double width; 
  private double height;
  
  public Size(double width, double height)
  {
    this.width = width;
    this.height = height;
  }
  
  public double Width 
  {
	get { return width; }
	set { width = value; }
  }
  
  public double Height 
  {
	get { return height; }
	set { height = value; }
  }
}

public static Size GetRotatedSize(Size oldSize, double angleOfTheFigureRotated)
{
  double angleCos = Math.Cos(angleOfTheFigureRotated);
  double angleCosAbs = Math.Abs(angleCos);
  double angleSin = Math.Sin(angleOfTheFigureRotated);
  double angleSinAbs = Math.Sin(angleSin);
  double width = angleCosAbs * oldSize.Width + angleSinAbs * oldSize.Height;
  double height = angleSinAbs * oldSize.Width + angleCosAbs * oldSize.Height;
  Size rotatedSize = new Size(width, height);
	
  return rotatedSize;
}