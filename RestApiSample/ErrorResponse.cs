using System;
using System.Text.Json;

namespace RestApiSample
{
  /// <summary>
  /// This class contains reponse message to pass in case of exception.
  /// </summary>
  public class ErrorResponse
  {
    public Int32 StatusCode { get; set; }

    public String Message { get; set; }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}
