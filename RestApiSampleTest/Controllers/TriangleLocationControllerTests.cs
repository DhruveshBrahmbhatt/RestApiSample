using Microsoft.AspNetCore.Mvc;
using RestApiSample.BusinessLogic;
using RestApiSample.Controllers;
using Xunit;

namespace RestApiSampleTest.Controllers
{
  public class TriangleLocationControllerTests
  {
    private readonly TriangleLocationController p_TriangleLocationController;
    private readonly TriangleLocationProvider p_TriangleLocationProvider;

    public TriangleLocationControllerTests()
    {
      p_TriangleLocationProvider = new TriangleLocationProvider();
      p_TriangleLocationController = new TriangleLocationController(p_TriangleLocationProvider);
    }

    [Fact]
    public void GetTriangleVertices_NotFound_Result()
    {
      // Arrange & Act
      IActionResult actionResult = p_TriangleLocationController.GetTriangleVertices('A', 0);

      // Assert
      Assert.True(actionResult is NotFoundResult);
    }

    [Fact]
    public void GetTriangleVertices_Ok_Result()
    {
      // Arrange & Act
      IActionResult actionResult = p_TriangleLocationController.GetTriangleVertices('A', 1);

      // Assert
      Assert.True(actionResult is OkObjectResult);
    }

    [Fact]
    public void GetTriangleGridLocation_NotFound_Result()
    {
      // Arrange & Act
      IActionResult actionResult = p_TriangleLocationController.GetTriangleGridLocation(0, 0, 0, 0, 0, 0);

      // Assert
      Assert.True(actionResult is NotFoundResult);
    }

    [Fact]
    public void GetTriangleGridLocation_Ok_Result()
    {
      // Arrange & Act
      IActionResult actionResult = p_TriangleLocationController.GetTriangleGridLocation(0, 10, 0, 0, 10, 10);

      // Assert
      Assert.True(actionResult is OkObjectResult);
    }
  }
}
