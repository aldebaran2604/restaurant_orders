namespace RestaurantClassLib;

/// <summary>
/// Class that contains information about the success or error and result item response
/// </summary>
public class ResponseInformation<T> : ResponseInformation
{
    public T? ResultItem { get; set; }
}
