namespace DirectoryService.SharedProj;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFalilure => !IsSuccess;

    public Errors Errors { get; set; }

    protected Result()
    {
        IsSuccess = true;
        Errors = Errors.None();
    }

    protected Result(Errors error)
    {
        IsSuccess = false;
        Errors = error;
    }

    public static Result Success() => new();

    public static Result Failure(Errors error) => new(error);
}
#pragma warning disable CA1000
public sealed class Result<TValue>: Result
{
    private Result(TValue value) => Value = value;
    private Result(Errors error) : base(error){}
    
    public new static Result<TValue> Failure(Errors error) => new(error);

    public static Result<TValue> Success(TValue value) => new (value);
    
    public TValue Value
    {
        get => IsSuccess ? field : throw new InvalidOperationException("Result is not success");
    } = default!;
}