namespace RestaurantClassLib;

/// <summary>
/// Class that contains information about the success or error response
/// </summary>
public class ResponseInformation
{
    #region Properties

    public bool Success { get; set; }

    public string? Message { get; set; }

    public bool Failure { get => !Success; }

    #endregion
}