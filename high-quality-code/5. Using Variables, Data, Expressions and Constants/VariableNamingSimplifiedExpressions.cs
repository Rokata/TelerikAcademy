public class Size
{
  public double Width; 
  public double Height;
  
  public Size(double width, double height)
  {
    this.Width = width;
    this.Height = height;
  }
}

public static Size GetRotatedSize(Size oldSize, double angleOfTheFigureRotated)
{
  double angleCos = Math.Cos(angleOfTheFigureRotated);
  double angleCosAbs = Math.Abs(angleCos);
  double angleSin = Math.Sin(angleOfTheFigureRotated);
  double angleSinAbs = Math.Sin(angleSin);
  double width = angleCosAbs * oldSize.width + angleSinAbs * oldSize.height;
  double height = angleSinAbs * oldSize.width + angleCosAbs * oldSize.height;
  Size rotatedSize = new Size(width, height);
	
  return rotatedSize;
}