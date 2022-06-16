using System.Text.Json.Serialization;

namespace VSporCore.Toolkit.Results
{
    public interface IResult
    {
        [JsonIgnore]
        bool IsSuccess { get; }
        string Message { get; }
        Error Error { get; }
    }
}
