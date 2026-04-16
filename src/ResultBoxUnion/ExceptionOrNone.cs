namespace ResultBoxUnion;

public union ExceptionOrNone(Exception, UnitValue)
{
    public bool HasException => this is Exception;

    public static ExceptionOrNone None => ResultBoxUnion.UnitValue.None;

    public static ExceptionOrNone FromException(Exception exception) => exception;
}
