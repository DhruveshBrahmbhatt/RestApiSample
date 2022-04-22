using System.Drawing;

namespace RestApiSample.Models
{
  /// <summary>
  /// This class contains vertices of triangle.
  /// </summary>
  public class TriangleVertices
  {
    /// <summary>
    /// Triangle vertex #1 at right-angle.
    /// </summary>
    public Point V1 { get; set; }

    /// <summary>
    /// Triangle vertex #2 
    /// </summary>
    public Point V2 { get; set; }

    /// <summary>
    /// Triangle vertex #3
    /// </summary>
    public Point V3 { get; set; }
  }
}
