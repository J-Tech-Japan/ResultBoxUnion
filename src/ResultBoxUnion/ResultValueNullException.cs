namespace ResultBoxUnion;

public class ResultValueNullException(string? msg = null)
    : Exception(msg ?? "result value is null");
