namespace ResultBoxUnion;

public union ResultBox<TValue>(TValue, Exception) where TValue : notnull
{
    public bool IsSuccess => this is TValue;

    public TValue GetValue() => this switch
    {
        TValue v => v,
        Exception => throw new ResultsInvalidOperationException("no value"),
        null => throw new ResultsInvalidOperationException("no value")
    };

    public Exception GetException() => this switch
    {
        Exception e => e,
        TValue => throw new ResultsInvalidOperationException("no exception"),
        null => new ResultValueNullException()
    };

    public static ResultBox<TValue> OutOfRange => new ResultValueNullException();

    public static ResultBox<TValue> Ok(TValue value) => value;
    public static ResultBox<TValue> FromValue(TValue value) => value;
    public static ResultBox<TValue> FromValue(Func<TValue> value) => value();

    public static async Task<ResultBox<TValue>> FromValue(Func<Task<TValue>> value) =>
        await value();

    public static async Task<ResultBox<TValue>> FromValue(Task<TValue> value) =>
        await value;

    public static ResultBox<TValue> FromException(Exception exception) => exception;
    public static ResultBox<TValue> Error(Exception exception) => exception;

    public ResultBox<TwoValues<TValue, TValue2>> Append<TValue2>(TValue2 value2) where TValue2 : notnull =>
        this switch
        {
            TValue v => new TwoValues<TValue, TValue2>(v, value2),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static ResultBox<TValue> WrapTry(Func<TValue> func, Func<Exception, Exception>? exceptionMapper = null)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return exceptionMapper?.Invoke(e) ?? e;
        }
    }

    public static async Task<ResultBox<TValue>> WrapTry(
        Func<Task<TValue>> func,
        Func<Exception, Exception>? exceptionMapper = null)
    {
        try
        {
            return await func();
        }
        catch (Exception e)
        {
            return exceptionMapper?.Invoke(e) ?? e;
        }
    }
}

public static class ResultBox
{
    public static ResultBox<UnitValue> Start => Ok(ResultBoxUnion.UnitValue.None);
    public static ResultBox<UnitValue> UnitValue => Start;

    public static ResultBox<TValue> FromValue<TValue>(TValue value) where TValue : notnull => value;
    public static ResultBox<TValue> Ok<TValue>(TValue value) where TValue : notnull => value;

    public static async Task<ResultBox<TValue>> FromValue<TValue>(Task<TValue> value)
        where TValue : notnull => await value;

    public static async Task<ResultBox<TValue>> FromValue<TValue>(Func<Task<TValue>> value)
        where TValue : notnull => await value();

    public static ResultBox<UnitValue> Error(Exception exception) => exception;

    public static ResultBox<TValue> Error<TValue>(Exception exception) where TValue : notnull =>
        exception;

    public static ResultBox<TValue> FromException<TValue>(Exception exception) where TValue : notnull =>
        exception;

    public static async Task<ResultBox<TValue>> FromException<TValue>(Task<Exception> exception)
        where TValue : notnull => await exception;

    public static Task<ResultBox<TValueResult>> WrapTry<TValueResult>(
        Func<Task<TValueResult>> func,
        Func<Exception, Exception>? exceptionMapper = null) where TValueResult : notnull =>
        ResultBox<TValueResult>.WrapTry(func, exceptionMapper);

    public static ResultBox<TValueResult> WrapTry<TValueResult>(
        Func<TValueResult> func,
        Func<Exception, Exception>? exceptionMapper = null) where TValueResult : notnull =>
        ResultBox<TValueResult>.WrapTry(func, exceptionMapper);

    public static void LogResult<TValue>(ResultBox<TValue> result) where TValue : notnull =>
        LogResult(result, "");

    public static void LogResult<TValue>(ResultBox<TValue> result, string marking) where TValue : notnull
    {
        var prefix = string.IsNullOrWhiteSpace(marking) ? "" : marking + " ";
        switch (result)
        {
            case TValue:
                Console.WriteLine(prefix + "Value: " + result.GetValue());
                break;
            case Exception:
                Console.WriteLine(prefix + "Error: " + result.GetException().Message);
                break;
        }
    }

    public static ResultBox<TValue> CheckNull<TValue>(TValue? value, Exception? exception = null)
        where TValue : notnull => value switch
    {
        not null => value,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static ResultBox<TValue> CheckNull<TValue>(TValue? value, Exception? exception = null)
        where TValue : struct => value switch
    {
        { } v => v,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static async Task<ResultBox<TValue>> CheckNull<TValue>(Task<TValue?> value, Exception? exception = null)
        where TValue : notnull => await value switch
    {
        { } v => (ResultBox<TValue>)v,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static async Task<ResultBox<TValue>> CheckNull<TValue>(Task<TValue?> value, Exception? exception = null)
        where TValue : struct => await value switch
    {
        { } v => (ResultBox<TValue>)v,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static ResultBox<TValue> CheckNull<TValue>(Func<TValue?> valueFunc, Exception? exception = null)
        where TValue : notnull => valueFunc() switch
    {
        { } value => value,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static ResultBox<TValue> CheckNull<TValue>(Func<TValue?> valueFunc, Exception? exception = null)
        where TValue : struct => valueFunc() switch
    {
        { } value => (ResultBox<TValue>)value,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static async Task<ResultBox<TValue>> CheckNull<TValue>(
        Func<Task<TValue?>> valueFunc,
        Exception? exception = null) where TValue : notnull => await valueFunc() switch
    {
        { } value => (ResultBox<TValue>)value,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static async Task<ResultBox<TValue>> CheckNull<TValue>(
        Func<Task<TValue?>> valueFunc,
        Exception? exception = null) where TValue : struct => await valueFunc() switch
    {
        { } value => (ResultBox<TValue>)value,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static ResultBox<TValue> CheckNullWrapTry<TValue>(
        Func<TValue?> func,
        Func<Exception, Exception>? exceptionMapper = null) where TValue : notnull
    {
        try
        {
            return func() switch
            {
                { } value => value,
                _ => ResultBox<TValue>.Error(new ResultValueNullException(typeof(TValue).Name))
                    .RemapException(e => exceptionMapper?.Invoke(e) ?? e)
            };
        }
        catch (Exception e)
        {
            return exceptionMapper?.Invoke(e) ?? e;
        }
    }

    public static ResultBox<TValue> CheckNullWrapTry<TValue>(
        Func<TValue?> func,
        Func<Exception, Exception>? exceptionMapper = null) where TValue : struct
    {
        try
        {
            var result = func();
            return result.HasValue switch
            {
                true => (ResultBox<TValue>)result.Value,
                _ => ResultBox<TValue>.Error(new ResultValueNullException(typeof(TValue).Name))
                    .RemapException(e => exceptionMapper?.Invoke(e) ?? e)
            };
        }
        catch (Exception e)
        {
            return exceptionMapper?.Invoke(e) ?? e;
        }
    }

    public static async Task<ResultBox<TValue>> CheckNullWrapTry<TValue>(
        Func<Task<TValue?>> funcAsync,
        Func<Exception, Exception>? exceptionMapper = null) where TValue : notnull
    {
        try
        {
            return await funcAsync() switch
            {
                { } value => value,
                _ => ResultBox<TValue>.Error(new ResultValueNullException(typeof(TValue).Name))
                    .RemapException(e => exceptionMapper?.Invoke(e) ?? e)
            };
        }
        catch (Exception e)
        {
            return exceptionMapper?.Invoke(e) ?? e;
        }
    }

    public static async Task<ResultBox<TValue>> CheckNullWrapTry<TValue>(
        Func<Task<TValue?>> funcAsync,
        Func<Exception, Exception>? exceptionMapper = null) where TValue : struct
    {
        try
        {
            return await funcAsync() switch
            {
                { } value => (ResultBox<TValue>)value,
                _ => ResultBox<TValue>.Error(new ResultValueNullException(typeof(TValue).Name))
                    .RemapException(e => exceptionMapper?.Invoke(e) ?? e)
            };
        }
        catch (Exception e)
        {
            return exceptionMapper?.Invoke(e) ?? e;
        }
    }

    public static ResultBox<TValue> CheckOptionalEmpty<TValue>(
        OptionalValue<TValue> optionalValue,
        Exception? exception) where TValue : notnull => optionalValue switch
    {
        TValue v => v,
        _ => (ResultBox<TValue>)(exception ?? new ResultValueNullException(typeof(TValue).Name))
    };

    public static ResultBox<TValue> CheckOptionalEmpty<TValue>(OptionalValue<TValue> optionalValue)
        where TValue : notnull => CheckOptionalEmpty(optionalValue, null);

    public static ResultBox<TCasted> Cast<TOriginal, TCasted>(ResultBox<TOriginal> resultBox)
        where TCasted : notnull where TOriginal : notnull => resultBox switch
    {
        TOriginal v => v is TCasted castedValue
            ? (ResultBox<TCasted>)castedValue
            : new InvalidCastException($"Cannot cast value to {typeof(TCasted).Name}"),
        Exception e => e,
        null => new ResultValueNullException()
    };
}
