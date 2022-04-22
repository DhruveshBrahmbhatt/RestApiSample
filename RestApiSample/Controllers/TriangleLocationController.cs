using Microsoft.AspNetCore.Mvc;
using RestApiSample.BusinessLogic;
using RestApiSample.Models;
using System;

namespace RestApiSample.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TriangleLocationController : ControllerBase
  {
    private readonly ITriangleLocationProvider p_TriangleLocationProviderArg;

    public TriangleLocationController(ITriangleLocationProvider triangleLocationProviderArg)
    {
      p_TriangleLocationProviderArg = triangleLocationProviderArg;
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult GetTriangleVertices(Char rowNameArg, Int32 columnNumberArg)
    {
      TriangleVertices triangleVertices = p_TriangleLocationProviderArg.GetTriangleCoordinates(new GridLocation() { RowName = rowNameArg, ColumnNumber = columnNumberArg });
      if (triangleVertices == null)
        return NotFound();

      return Ok(triangleVertices);
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult GetTriangleGridLocation(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
    {
      String gridLocation = p_TriangleLocationProviderArg.GetTriangleGridLocation(v1X, v1Y, v2X, v2Y, v3X, v3Y);
      if (gridLocation == p_TriangleLocationProviderArg.INVALID_INPUT_COORDINATES)
        return NotFound();

      return Ok(gridLocation);
    }
  }
}
