using System;

namespace RestApiSample.Models
{
  /// <summary>
  /// This class contains variables of grid location.
  /// </summary>
  public class GridLocation
  {
    /// <summary>
    /// Row name of grid cell (A - J)
    /// </summary>
    public Char RowName { get; set; }

    /// <summary>
    /// Column number of grid cell (1 - 12)
    /// </summary>
    public Int32 ColumnNumber { get; set; }
  }
}
