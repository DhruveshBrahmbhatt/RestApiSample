using RestApiSample.Models;
using System;

namespace RestApiSample.BusinessLogic
{
  /// <summary>
  /// This interface provides methods for implementing inside triangle location logic class.
  /// </summary>
  public interface ITriangleLocationProvider
  {
    /// <summary>
    /// Abstract of method that provides XY coordinates of point 1, 2 and 3.
    /// </summary>
    /// <param name="gridLocationArg"></param>
    /// <returns></returns>
    public TriangleVertices GetTriangleCoordinates(GridLocation gridLocationArg);

    /// <summary>
    /// Abstract of method that provides location of triangle in grid for the given XY coordinates.
    /// </summary>
    /// <param name="v1X"></param>
    /// <param name="v1Y"></param>
    /// <param name="v2X"></param>
    /// <param name="v2Y"></param>
    /// <param name="v3X"></param>
    /// <param name="v3Y"></param>
    /// <returns></returns>
    public String GetTriangleGridLocation(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y);

    /// <summary>
    /// Abstract property returns error string.
    /// </summary>
    public String INVALID_INPUT_COORDINATES { get; set; }
  }
}
