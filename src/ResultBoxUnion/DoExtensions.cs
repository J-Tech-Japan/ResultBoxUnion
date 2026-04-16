namespace ResultBoxUnion;

public static class DoExtensions
{
    #region Do Nothing

    public static ResultBox<TValue> Do<TValue>(this ResultBox<TValue> result, Action action)
        where TValue : notnull
    {
        action();
        return result;
    }

    public static async Task<ResultBox<TValue>> Do<TValue>(this ResultBox<TValue> result, Func<Task> actionAsync)
        where TValue : notnull
    {
        await actionAsync();
        return result;
    }

    public static ResultBox<TValue> Do<TValue, TValueToIgnore>(this ResultBox<TValue> result, Func<TValueToIgnore> actionAsync)
        where TValue : notnull
    {
        actionAsync();
        return result;
    }

    public static async Task<ResultBox<TValue>> Do<TValue, TValueToIgnore>(this ResultBox<TValue> result, Func<Task<TValueToIgnore>> actionAsync)
        where TValue : notnull
    {
        await actionAsync();
        return result;
    }

    public static async Task<ResultBox<TValue>> Do<TValue>(this Task<ResultBox<TValue>> result, Action action)
        where TValue : notnull => (await result).Do(action);

    public static async Task<ResultBox<TValue>> Do<TValue>(this Task<ResultBox<TValue>> result, Func<Task> actionAsync)
        where TValue : notnull => await (await result).Do(actionAsync);

    public static async Task<ResultBox<TValue>> Do<TValue, TValueToIgnore>(this Task<ResultBox<TValue>> result, Func<TValueToIgnore> actionAsync)
        where TValue : notnull => (await result).Do(actionAsync);

    public static async Task<ResultBox<TValue>> Do<TValue, TValueToIgnore>(this Task<ResultBox<TValue>> result, Func<Task<TValueToIgnore>> actionAsync)
        where TValue : notnull => await (await result).Do(actionAsync);

    #endregion

    #region Do Result

    public static ResultBox<TValue> DoResult<TValue>(this ResultBox<TValue> result, Action<ResultBox<TValue>> action)
        where TValue : notnull
    {
        action(result);
        return result;
    }

    public static async Task<ResultBox<TValue>> DoResult<TValue>(this ResultBox<TValue> result, Func<ResultBox<TValue>, Task> actionAsync)
        where TValue : notnull
    {
        await actionAsync(result);
        return result;
    }

    public static async Task<ResultBox<TValue>> DoResult<TValue>(this Task<ResultBox<TValue>> result, Action<ResultBox<TValue>> action)
        where TValue : notnull
    {
        var res = await result;
        action(res);
        return res;
    }

    public static async Task<ResultBox<TValue>> DoResult<TValue>(this Task<ResultBox<TValue>> result, Func<ResultBox<TValue>, Task> actionAsync)
        where TValue : notnull
    {
        var res = await result;
        await actionAsync(res);
        return res;
    }

    #endregion

    #region Do Value and Error

    public static ResultBox<TValue> Do<TValue>(
        this ResultBox<TValue> result,
        Action<TValue> action,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        switch (result)
        {
            case Exception e: actionError?.Invoke(e); break;
            case TValue v: action(v); break;
        }
        return result;
    }

    public static async Task<ResultBox<TValue>> Do<TValue>(
        this ResultBox<TValue> result,
        Func<TValue, Task> actionAsync,
        Func<Exception, Task>? actionErrorAsync = null)
        where TValue : notnull
    {
        switch (result)
        {
            case Exception e: if (actionErrorAsync is not null) await actionErrorAsync(e); break;
            case TValue v: await actionAsync(v); break;
        }
        return result;
    }

    public static ResultBox<TValue> Do<TValue, TValueToIgnore>(
        this ResultBox<TValue> result,
        Func<TValue, TValueToIgnore> actionAsync,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        switch (result)
        {
            case Exception e: actionError?.Invoke(e); break;
            case TValue v: actionAsync(v); break;
        }
        return result;
    }

    public static async Task<ResultBox<TValue>> Do<TValue>(
        this Task<ResultBox<TValue>> result,
        Action<TValue> action,
        Action<Exception>? actionError = null)
        where TValue : notnull => (await result).Do(action, actionError);

    public static async Task<ResultBox<TValue>> Do<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, Task> actionAsync,
        Action<Exception>? actionError = null)
        where TValue : notnull
    {
        var res = await result;
        switch (res)
        {
            case Exception e: actionError?.Invoke(e); break;
            case TValue v: await actionAsync(v); break;
        }
        return res;
    }

    #endregion

    #region Do TwoValues

    public static ResultBox<TwoValues<T1, T2>> Do<T1, T2>(
        this ResultBox<TwoValues<T1, T2>> result,
        Action<T1, T2> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull
        => Do(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<TwoValues<T1, T2>>> Do<T1, T2>(
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

    public static async Task<ResultBox<TwoValues<T1, T2>>> Do<T1, T2>(
        this Task<ResultBox<TwoValues<T1, T2>>> result,
        Action<T1, T2> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<TwoValues<T1, T2>>> Do<T1, T2>(
        this Task<ResultBox<TwoValues<T1, T2>>> result,
        Func<T1, T2, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull
        => await (await result).Scan(async values => await values.CallAction(action), actionErrorAsync);

    #endregion

    #region Do ThreeValues

    public static ResultBox<ThreeValues<T1, T2, T3>> Do<T1, T2, T3>(
        this ResultBox<ThreeValues<T1, T2, T3>> result,
        Action<T1, T2, T3> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => Do(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Do<T1, T2, T3>(
        this ResultBox<ThreeValues<T1, T2, T3>> result,
        Func<T1, T2, T3, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => await Do(result, async values => await values.CallAction(action), actionErrorAsync);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Do<T1, T2, T3>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> result,
        Action<T1, T2, T3> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Do<T1, T2, T3>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> result,
        Func<T1, T2, T3, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => await (await result).Scan(async values => await values.CallAction(action), actionErrorAsync);

    #endregion

    #region Do FourValues

    public static ResultBox<FourValues<T1, T2, T3, T4>> Do<T1, T2, T3, T4>(
        this ResultBox<FourValues<T1, T2, T3, T4>> result,
        Action<T1, T2, T3, T4> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => Do(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Do<T1, T2, T3, T4>(
        this ResultBox<FourValues<T1, T2, T3, T4>> result,
        Func<T1, T2, T3, T4, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => await Do(result, async values => await values.CallAction(action), actionErrorAsync);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Do<T1, T2, T3, T4>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> result,
        Action<T1, T2, T3, T4> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Do<T1, T2, T3, T4>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> result,
        Func<T1, T2, T3, T4, Task> action, Func<Exception, Task>? actionErrorAsync = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => await (await result).Scan(async values => await values.CallAction(action), actionErrorAsync);

    #endregion

    #region Do FiveValues

    public static ResultBox<FiveValues<T1, T2, T3, T4, T5>> Do<T1, T2, T3, T4, T5>(
        this ResultBox<FiveValues<T1, T2, T3, T4, T5>> result,
        Action<T1, T2, T3, T4, T5> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => Do(result, values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Do<T1, T2, T3, T4, T5>(
        this Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> result,
        Action<T1, T2, T3, T4, T5> action, Action<Exception>? actionError = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => (await result).Scan(values => values.CallAction(action), actionError);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Do<T1, T2, T3, T4, T5>(
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
