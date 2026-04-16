namespace ResultBoxUnion;

public record UnitValue
{
    public static UnitValue None => new();
    public static UnitValue Unit => new();

    public static ResultBox<UnitValue> WrapTry(Action action)
    {
        try
        {
            action();
            return new UnitValue();
        }
        catch (Exception e)
        {
            return e;
        }
    }

    public static async Task<ResultBox<UnitValue>> WrapTry(Func<Task> action)
    {
        try
        {
            await action();
            return new UnitValue();
        }
        catch (Exception e)
        {
            return e;
        }
    }
}
