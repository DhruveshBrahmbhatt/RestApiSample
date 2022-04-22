using RestApiSample.Models;
using System;
using System.Drawing;

namespace RestApiSample.BusinessLogic
{
  /// <summary>
  /// This class contains logic to provide triangle location by coorinates or grid.
  /// </summary>
  public class TriangleLocationProvider : ITriangleLocationProvider
  {
    const Int32 NON_HYPOTENUSE_PX = 10;
    const char LOWER_A = 'a';
    const char LOWER_F = 'f';
    const char UPPER_A = 'A';
    const char UPPER_F = 'F';

    /// <summary>
    /// Property returns string to inform validation error.
    /// </summary>
    public String INVALID_INPUT_COORDINATES { get; set; } = "Invalid input coordinates";

    /// <summary>
    /// This function returns XY coordinates of 3 vertices of triangle.
    /// </summary>
    /// <param name="gridLocationArg">Grid location of triangle in row and column.</param>
    /// <returns>Vertices of triangle.</returns>
    public TriangleVertices GetTriangleCoordinates(GridLocation gridLocationArg)
    {
      try
      {
        if (((gridLocationArg.RowName >= UPPER_A && gridLocationArg.RowName <= UPPER_F)
              || gridLocationArg.RowName >= LOWER_A && gridLocationArg.RowName <= LOWER_F) == false) // return null, if rowname isn't between A-F or a-f
        {
          return null;
        }

        if ((gridLocationArg.ColumnNumber >= 1 && gridLocationArg.ColumnNumber <= 12) == false) // return null, if columnNumber isn't between 1-12
        {
          return null;
        }

        //  create instance for valid inputs of grid location
        TriangleVertices triangleVertices = new TriangleVertices();

        // Find rowIndex of the input row. RowName can be in lower or upper case. 
        int rowIndex = 0;
        if (gridLocationArg.RowName >= UPPER_A && gridLocationArg.RowName <= UPPER_F)
          rowIndex = gridLocationArg.RowName - UPPER_A;
        else if (gridLocationArg.RowName >= LOWER_A && gridLocationArg.RowName <= LOWER_F)
          rowIndex = gridLocationArg.RowName - LOWER_A;

        // Find location of right angle vertex; 1 = bottom left, 0 = top right.
        RightAngleVertexLocation rightAngleVertexLocation = (RightAngleVertexLocation)(gridLocationArg.ColumnNumber % 2);

        // Find column multiplier to calculate X location based on column number; e.g. 1 for columnNumber1, 10 for columnNumber11
        int columnMultplier = gridLocationArg.ColumnNumber / 2;

        int rightAngleVertex_X = columnMultplier * NON_HYPOTENUSE_PX;
        int rightAngleVertex_Y = (rowIndex * NON_HYPOTENUSE_PX) + ((int)rightAngleVertexLocation * NON_HYPOTENUSE_PX);

        triangleVertices.V1 = new Point(rightAngleVertex_X, rightAngleVertex_Y);

        if (rightAngleVertexLocation == RightAngleVertexLocation.BottomLeft)
        {
          triangleVertices.V2 = new Point(rightAngleVertex_X, rightAngleVertex_Y - NON_HYPOTENUSE_PX);

          triangleVertices.V3 = new Point(rightAngleVertex_X + NON_HYPOTENUSE_PX, rightAngleVertex_Y);
        }
        else
        {
          triangleVertices.V2 = new Point(rightAngleVertex_X - NON_HYPOTENUSE_PX, rightAngleVertex_Y);

          triangleVertices.V3 = new Point(rightAngleVertex_X, rightAngleVertex_Y + NON_HYPOTENUSE_PX);
        }

        return triangleVertices;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// This function calculates location of triangle using v1x, v1Y and v2Y coordinates.
    /// </summary>
    /// <param name="v1X">Right angle vertex X coordinate</param>
    /// <param name="v1Y">Right angle vertex Y coordinate</param>
    /// <param name="v2X">Vertex#2 X coordinate</param>
    /// <param name="v2Y">Vertex#2 Y coordinate</param>
    /// <param name="v3X">Vertex#3 X coordinate</param>
    /// <param name="v3Y">Vertex#3 Y coordinate</param>
    /// <returns>Location of triangle in grid</returns>
    public String GetTriangleGridLocation(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
    {
      try
      {
        // validate point at the right-angle is valid. It should between 0 and 60 and devisible by 10.
        if ((v1X % 10 != 0) || (v1Y % 10 != 0) || (v1X < 0) || (v1Y > 60))
        {
          return INVALID_INPUT_COORDINATES;
        }
        // validate top (or left) vertex 
        if ((v2X % 10 != 0) || (v2Y % 10 != 0) || (v2X < 0) || (v2Y > 60))
        {
          return INVALID_INPUT_COORDINATES;
        }
        // validate right (or bottom) vertex 
        if ((v3X % 10 != 0) || (v3Y % 10 != 0) || (v3X < 0) || (v3Y > 60))
        {
          return INVALID_INPUT_COORDINATES;
        }

        // validate v1 and v2 vertices. v1Y should be same as v2Y (right angle vertex at TopRight) or v1Y should be below v2Y (right angle vertex at BottomLeft)
        if (v1Y < v2Y)
        {
          return INVALID_INPUT_COORDINATES;
        }

        // Find location of right angle vertex based on v1 (rightAngleVertex) and v2
        RightAngleVertexLocation rightAngleVertexLocation = RightAngleVertexLocation.TopRight;
        if (v1Y > v2Y)  // v1 (rightAngleVertex) below v2
        {
          rightAngleVertexLocation = RightAngleVertexLocation.BottomLeft;
        }

        int columnNumber = 0, rowNumber = 0;

        switch (rightAngleVertexLocation)
        {
          case RightAngleVertexLocation.BottomLeft:
            columnNumber = (v1X / NON_HYPOTENUSE_PX * 2) + 1;       // (v1X / NON_HYPOTENUSE_PX * 2) = 'number of Non-hypotenuse sides'
            rowNumber = v1Y / NON_HYPOTENUSE_PX;
            break;
          case RightAngleVertexLocation.TopRight:
            columnNumber = v1X / NON_HYPOTENUSE_PX * 2;             // (v1X / NON_HYPOTENUSE_PX * 2) = 'number of Non-hypotenuse sides'
            rowNumber = (v1Y / NON_HYPOTENUSE_PX) + 1;
            break;
        }

        // Check for row & column calculated by the equations.
        if (rowNumber == 0 || columnNumber == 0)
        {
          return INVALID_INPUT_COORDINATES;
        }

        // validate side vertices (v2 and v3) based on rightAngleVertexLocation and its coordinates.
        switch (rightAngleVertexLocation)
        {
          case RightAngleVertexLocation.BottomLeft:
            if (v1X != v2X || v1Y != v3Y || v1Y != (v2Y + NON_HYPOTENUSE_PX) || v1X != (v3X - NON_HYPOTENUSE_PX))
            {
              return INVALID_INPUT_COORDINATES;
            }
            break;
          case RightAngleVertexLocation.TopRight:
            if (v1X != v3X || v1Y != v2Y || v1Y != (v3Y - NON_HYPOTENUSE_PX) || v1X != (v2X + NON_HYPOTENUSE_PX))
            {
              return INVALID_INPUT_COORDINATES;
            }
            break;
        }

        int rowName = UPPER_A + (rowNumber - 1);
        return ((char)rowName + columnNumber.ToString());
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
