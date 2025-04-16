namespace Itmo.ObjectOrientedProgramming.Lab4;

public enum Result
{
    Success,
    Failure,
}

public class ResultType
{
    public Result Result { get; }

    public string Message { get; } = string.Empty;

    public ResultType(string message, Result result)
    {
        Message = message;
        Result = result;
    }

    public ResultType(Result result)
    {
        Result = result;
        if (result == Result.Success)
        {
            Message = "Success!";
        }
    }
}