namespace ResultBoxUnion;

public static class ScanExtensions
{
    #region Scan Nothing

    public static ResultBox<TValue> Scan<TValue>(this ResultBox<TValue> result, Action action)
        where TValue : notnull
    {
        action();
        return result;
    }

    public static async Task<ResultBox<TValue>> Scan<TValue>(this ResultBox<TValue> result, Func<Task> actionAsync)
        where TValue : notnull
    {
        await actionAsync();
        return result;
    }

    public static ResultBox<TValue> Scan<TValue, TValueToIgnore>(this ResultBox<TValue> result, Func<TValueToIgnore> actionAsync)
        where TValue : notnull
    {
        actionAsync();
        return result;
    }

    public static async Task<ResultBox<TValue>> Scan<TValue, TValueToIgnore>(this ResultBox<TValue> result, Func<Task<TValueToIgnore>> actionAsync)
        where TValue : notnull
    {
        await actionAsync();
        return result;
    }

    public static async Task<ResultBox<TValue>> Scan<TValue>(this Task<ResultBox<TValue>> resultTask, Action action)
        where TValue : notnull => (await resultTask).Scan(action);

    public static async Task<ResultBox<TValue>> Scan<TValue>(this Task<ResultBox<TValue>> resultTask, Func<Task> actionAsync)
        where TValue : notnull => await (await resultTask).Scan(actionAsync);

    public static async Task<ResultBox<TValue>> Scan<TValue, TValueToIgnore>(this Task<ResultBox<TValue>> resultTask, Func<TValueToIgnore> actionAsync)
        where TValue : notnull => (await resultTask).Scan(actionAsync);

    public static async Task<ResultBox<TValue>> Scan<TValue, TValueToIgnore>(this Task<ResultBox<TValue>> resultTask, Func<Task<TValueToIgnore>> actionAsync)
        where TValue : notnull => await (await resultTask).Scan(actionAsync);

    #endregion

    #region Scan Result

    public static ResultBox<TValue> ScanResult<TValue>(this ResultBox<TValue> result, Action<ResultBox<TValue>> action)
        where TValue : notnull
    {
        action(result);
        return result;
    }

    public static async Task<ResultBox<TValue>> ScanResult<TValue>(this ResultBox<TValue> result, Func<ResultBox<TValue>, Task> actionAsync)
        where TValue : notnull
    {
        await actionAsync(result);
        return result;
    }

    public static ResultBox<TValue> ScanResult<TValue, TValueToIgnore>(this ResultBox<TValue> result, Func<ResultBox<TValue>, TValueToIgnore> actionAsync)
        where TValue : notnull
    {
        actionAsync(result);
        return result;
    }

    public static async Task<ResultBox<TValue>> ScanResult<TValue, TValueToIgnore>(this ResultBox<TValue> result, Func<ResultBox<TValue>, Task<TValueToIgnore>> actionAsync)
        where TValue : notnull
    {
        await actionAsync(result);
        return result;
    }

    public static async Task<ResultBox<TValue>> ScanResult<TValue>(this Task<ResultBox<TValue>> result, Action<ResultBox<TValue>> action)
        where TValue : notnull
    {
        var res = await result;
        action(res);
        return res;
    }

    public static async Task<ResultBox<TValue>> ScanResult<TValue>(this Task<ResultBox<TValue>> result, Func<ResultBox<TValue>, Task> actionAsync)
        where TValue : notnull
    {
        var res = await result;
        await actionAsync(res);
        return res;
    }

    public static async Task<ResultBox<TValue>> ScanResult<TValue, TValueToIgnore>(this Task<ResultBox<TValue>> result, Func<ResultBox<TValue>, TValueToIgnore> actionAsync)
        where TValue : notnull
    {
        var res = await result;
        actionAsync(res);
        return res;
    }

    public static async Task<ResultBox<TValue>> ScanResult<TValue, TValueToIgnore>(this Task<ResultBox<TValue>> result, Func<ResultBox<TValue>, Task<TValueToIgnore>> actionAsync)
        where TValue : notnull
    {
        var res = await result;
        await actionAsync(res);
        return res;
    }

    #endregion

    #region Scan Value and Error

    public static ResultBox<TValue> Scan<TValue>(
        this ResultBox<TValue> result,
        Action<TValue> action,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        switch (result)
        {
            case Exception e:
                actionError?.Invoke(e);
                break;
            case TValue v:
                action(v);
                break;
        }
        return result;
    }

    public static async Task<ResultBox<TValue>> Scan<TValue>(
        this ResultBox<TValue> result,
        Func<TValue, Task> actionAsync,
        Func<Exception, Task>? actionErrorAsync = null)
        where TValue : notnull
    {
        switch (result)
        {
            case Exception e:
                if (actionErrorAsync is not null) await actionErrorAsync(e);
                break;
            case TValue v:
                await actionAsync(v);
                break;
        }
        return result;
    }

    public static ResultBox<TValue> Scan<TValue, TValueToIgnore>(
        this ResultBox<TValue> result,
        Func<TValue, TValueToIgnore> actionAsync,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        switch (result)
        {
            case Exception e:
                actionError?.Invoke(e);
                break;
            case TValue v:
                actionAsync(v);
                break;
        }
        return result;
    }

    public static async Task<ResultBox<TValue>> Scan<TValue, TValueToVoid>(
        this ResultBox<TValue> result,
        Func<TValue, Task<TValueToVoid>> actionAsync,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        switch (result)
        {
            case Exception e:
                actionError?.Invoke(e);
                break;
            case TValue v:
                await actionAsync(v);
                break;
        }
        return result;
    }

    public static async Task<ResultBox<TValue>> Scan<TValue>(
        this Task<ResultBox<TValue>> result,
        Action<TValue> action,
        Action<Exception>? actionError = null)
        where TValue : notnull => (await result).Scan(action, actionError);

    public static async Task<ResultBox<TValue>> Scan<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, Task> actionAsync,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        var res = await result;
        switch (res)
        {
            case Exception e:
                actionError?.Invoke(e);
                break;
            case TValue v:
                await actionAsync(v);
                break;
        }
        return res;
    }

    public static async Task<ResultBox<TValue>> Scan<TValue, TValueToIgnore>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, TValueToIgnore> actionAsync,
        Action<Exception>? actionError = null)
        where TValue : notnull => (await result).Scan(actionAsync, actionError);

    public static async Task<ResultBox<TValue>> Scan<TValue, TValueToIgnore>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, Task<TValueToIgnore>> actionAsync,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        var res = await result;
        switch (res)
        {
            case Exception e:
                actionError?.Invoke(e);
                break;
            case TValue v:
                await actionAsync(v);
                break;
        }
        return res;
    }

    #endregion

    #region Scan TwoValues

    public static ResultBox<TwoValues<T1, T2>> Scan<T1, T2>(
        this ResultBox<TwoValues<T1, T2>> result,
        Action<T1, T2> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull
        => Scan(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<TwoValues<T1, T2>>> Scan<T1, T2>(
        this ResultBox<TwoValues<T1, T2>> result,
        Func<T1, T2, Task> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull
    {
        switch (result)
        {
            case Exception e: actionError?.Invoke(e); break;
            case TwoValues<T1, T2> v: await v.CallAction(action); break;
        }
        return result;
    }

    public static async Task<ResultBox<TwoValues<T1, T2>>> Scan<T1, T2>(
        this Task<ResultBox<TwoValues<T1, T2>>> result,
        Action<T1, T2> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<TwoValues<T1, T2>>> Scan<T1, T2>(
        this Task<ResultBox<TwoValues<T1, T2>>> result,
        Func<T1, T2, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull
        => await (await result).Scan(async values => await values.CallAction(action), actionErrorAsync);

    #endregion

    #region Scan ThreeValues

    public static ResultBox<ThreeValues<T1, T2, T3>> Scan<T1, T2, T3>(
        this ResultBox<ThreeValues<T1, T2, T3>> result,
        Action<T1, T2, T3> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => Scan(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Scan<T1, T2, T3>(
        this ResultBox<ThreeValues<T1, T2, T3>> result,
        Func<T1, T2, T3, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => await Scan(result, async values => await values.CallAction(action), actionErrorAsync);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Scan<T1, T2, T3>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> result,
        Action<T1, T2, T3> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Scan<T1, T2, T3>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> result,
        Func<T1, T2, T3, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => await (await result).Scan(async values => await values.CallAction(action), actionErrorAsync);

    #endregion

    #region Scan FourValues

    public static ResultBox<FourValues<T1, T2, T3, T4>> Scan<T1, T2, T3, T4>(
        this ResultBox<FourValues<T1, T2, T3, T4>> result,
        Action<T1, T2, T3, T4> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => Scan(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Scan<T1, T2, T3, T4>(
        this ResultBox<FourValues<T1, T2, T3, T4>> result,
        Func<T1, T2, T3, T4, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => await Scan(result, async values => await values.CallAction(action), actionErrorAsync);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Scan<T1, T2, T3, T4>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> result,
        Action<T1, T2, T3, T4> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Scan<T1, T2, T3, T4>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> result,
        Func<T1, T2, T3, T4, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => await (await result).Scan(async values => await values.CallAction(action), actionErrorAsync);

    #endregion

    #region Scan FiveValues

    public static ResultBox<FiveValues<T1, T2, T3, T4, T5>> Scan<T1, T2, T3, T4, T5>(
        this ResultBox<FiveValues<T1, T2, T3, T4, T5>> result,
        Action<T1, T2, T3, T4, T5> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => Scan(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Scan<T1, T2, T3, T4, T5>(
        this ResultBox<FiveValues<T1, T2, T3, T4, T5>> result,
        Func<T1, T2, T3, T4, T5, Task> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
    {
        switch (result)
        {
            case Exception e: actionError?.Invoke(e); break;
            case FiveValues<T1, T2, T3, T4, T5> v: await v.CallAction(action); break;
        }
        return result;
    }

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Scan<T1, T2, T3, T4, T5>(
        this Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> result,
        Action<T1, T2, T3, T4, T5> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Scan<T1, T2, T3, T4, T5>(
        this Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> result,
        Func<T1, T2, T3, T4, T5, Task> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
    {
        var res = await result;
        switch (res)
        {
            case Exception e: actionError?.Invoke(e); break;
            case FiveValues<T1, T2, T3, T4, T5> v: await v.CallAction(action); break;
        }
        return res;
    }

    #endregion
}
