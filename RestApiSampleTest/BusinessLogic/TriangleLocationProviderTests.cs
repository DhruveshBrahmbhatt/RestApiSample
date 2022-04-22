using RestApiSample.BusinessLogic;
using RestApiSample.Models;
using System;
using System.Drawing;
using Xunit;

namespace RestApiSampleTest.BusinessLogic
{
  public class TriangleLocationProviderTests
  {
    private readonly TriangleLocationProvider p_TriangleLocationProvider;

    public TriangleLocationProviderTests()
    {
      p_TriangleLocationProvider = new TriangleLocationProvider();
    }

    #region Test methods of GetTriangleCoordinates 

    [Fact]
    public void GetTriangleCoordinates_Input_A0_Returns_Null()
    {
      // Arrange & Act
      TriangleVertices outputVertices = p_TriangleLocationProvider.GetTriangleCoordinates(new GridLocation() { RowName = 'A', ColumnNumber = 0 });

      // Assert
      Assert.True(outputVertices == null);
    }

    [Fact]
    public void GetTriangleCoordinates_Input_A1_Returns_Vertices()
    {
      // Arrange & Act
      TriangleVertices outputVertices = p_TriangleLocationProvider.GetTriangleCoordinates(new GridLocation() { RowName = 'A', ColumnNumber = 1 });
      TriangleVertices expectedVertices = new TriangleVertices() { V1 = new Point(0, 10), V2 = new Point(0, 0), V3 = new Point(10, 10) };

      // Assert
      Assert.Equal(outputVertices.V1, expectedVertices.V1);
      Assert.Equal(outputVertices.V2, expectedVertices.V2);
      Assert.Equal(outputVertices.V3, expectedVertices.V3);
    }

    [Fact]
    public void GetTriangleCoordinates_Input_A2_Returns_Vertices()
    {
      // Arrange & Act
      TriangleVertices outputVertices = p_TriangleLocationProvider.GetTriangleCoordinates(new GridLocation() { RowName = 'A', ColumnNumber = 2 });
      TriangleVertices expectedVertices = new TriangleVertices() { V1 = new Point(10, 0), V2 = new Point(0, 0), V3 = new Point(10, 10) };

      // Assert
      Assert.Equal(outputVertices.V1, expectedVertices.V1);
      Assert.Equal(outputVertices.V2, expectedVertices.V2);
      Assert.Equal(outputVertices.V3, expectedVertices.V3);
    }

    [Fact]
    public void GetTriangleCoordinates_Input_F11_Returns_Vertices()
    {
      // Arrange & Act
      TriangleVertices outputVertices = p_TriangleLocationProvider.GetTriangleCoordinates(new GridLocation() { RowName = 'F', ColumnNumber = 11 });
      TriangleVertices expectedVertices = new TriangleVertices() { V1 = new Point(50, 60), V2 = new Point(50, 50), V3 = new Point(60, 60) };

      // Assert
      Assert.Equal(outputVertices.V1, expectedVertices.V1);
      Assert.Equal(outputVertices.V2, expectedVertices.V2);
      Assert.Equal(outputVertices.V3, expectedVertices.V3);
    }

    [Fact]
    public void GetTriangleCoordinates_Input_F12_Returns_Vertices()
    {
      // Arrange & Act
      TriangleVertices outputVertices = p_TriangleLocationProvider.GetTriangleCoordinates(new GridLocation() { RowName = 'F', ColumnNumber = 12 });
      TriangleVertices expectedVertices = new TriangleVertices() { V1 = new Point(60, 50), V2 = new Point(50, 50), V3 = new Point(60, 60) };

      // Assert
      Assert.Equal(outputVertices.V1, expectedVertices.V1);
      Assert.Equal(outputVertices.V2, expectedVertices.V2);
      Assert.Equal(outputVertices.V3, expectedVertices.V3);
    }

    #endregion

    #region Test methods of GetTriangleCoordinates

    [Fact]
    public void GetTriangleGridLocation_Invalid_Input_Returns_Validation_Error()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(0, 0, 0, 0, 0, 0);

      // Assert
      Assert.True(gridLocation == p_TriangleLocationProvider.INVALID_INPUT_COORDINATES);
    }

    [Fact]
    public void GetTriangleGridLocation_Input_A1_Vertices_Returns_A1_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(0, 10, 0, 0, 10, 10);

      // Assert
      Assert.True(gridLocation == "A1");
    }

    [Fact]
    public void GetTriangleGridLocation_Input_A2_Vertices_Returns_A2_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(10, 0, 0, 0, 10, 10);

      // Assert
      Assert.True(gridLocation == "A2");
    }

    [Fact]
    public void GetTriangleGridLocation_Input_C1_Vertices_Returns_C1_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(0, 30, 0, 20, 10, 30);

      // Assert
      Assert.True(gridLocation == "C1");
    }

    [Fact]
    public void GetTriangleGridLocation_Input_C2_Vertices_Returns_C2_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(10, 20, 0, 20, 10, 30);

      // Assert
      Assert.True(gridLocation == "C2");
    }

    [Fact]
    public void GetTriangleGridLocation_Input_E11_Vertices_Returns_E11_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(50, 50, 50, 40, 60, 50);

      // Assert
      Assert.True(gridLocation == "E11");
    }

    [Fact]
    public void GetTriangleGridLocation_Input_E12_Vertices_Returns_E12_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(60, 40, 50, 40, 60, 50);

      // Assert
      Assert.True(gridLocation == "E12");
    }

    [Fact]
    public void GetTriangleGridLocation_Input_F11_Vertices_Returns_F11_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(50, 60, 50, 50, 60, 60);

      // Assert
      Assert.True(gridLocation == "F11");
    }

    [Fact]
    public void GetTriangleGridLocation_Input_F12_Vertices_Returns_F12_String()
    {
      // Arrange & Act
      String gridLocation = p_TriangleLocationProvider.GetTriangleGridLocation(60, 50, 50, 50, 60, 60);

      // Assert
      Assert.True(gridLocation == "F12");
    }

    #endregion
  }
}
