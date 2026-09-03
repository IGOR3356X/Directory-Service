namespace DirectoryService.SharedProj;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

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
    private readonly TValue _value = default!;
    private Result(TValue value) => _value = value;
    private Result(Errors error) : base(error){}
    
    public new static Result<TValue> Failure(Errors error) => new(error);

    public static Result<TValue> Success(TValue value) => new (value);

    // public static implicit operator Result<TValue>(Errors error) => Failure(error);
    //
    // public static implicit operator Result<TValue>(TValue value) => Success(value);
    //
    // public static implicit operator TValue(Result<TValue> result) => result._value;
    //
    // private readonly TValue Value = IsSuccess ? _value : throw new InvalidOperationException();
}