# ResultBoxUnion

Railway-oriented programming library for C# using **C# 15 Union Types** (.NET 11).

A reimagination of [ResultBoxes](https://github.com/J-Tech-Japan/ResultBoxes) built entirely on the `union` keyword.

## Core Concept

```csharp
// ResultBox<TValue> is a union: either a TValue or an Exception
public union ResultBox<TValue>(TValue, Exception) where TValue : notnull;
```

No more `IsSuccess` flag checks with internal nullable fields — the type itself **is** the value or the error.

## Quick Start

```csharp
using ResultBoxUnion;

// Create results
ResultBox<int> success = 42;                              // implicit from value
ResultBox<int> failure = new Exception("something wrong"); // implicit from exception

// Pattern matching (exhaustive!)
var message = success switch
{
    int value    => $"Got {value}",
    Exception ex => $"Error: {ex.Message}",
};

// Railway chaining
var result = ResultBox.FromValue(10)
    .Remap(x => x * 2)                    // 20
    .Conveyor(x => ResultBox.Ok(x + 5))   // 25
    .Verify(x => x > 0
        ? ExceptionOrNone.None
        : new ArgumentException("must be positive"));
```

## Railway Pipeline Example

```csharp
// Combine multiple values
var result = ResultBox.FromValue("hello")
    .Combine(greeting => ResultBox.Ok(greeting.Length))  // TwoValues<string, int>
    .Remap((greeting, len) => $"{greeting} has {len} chars");

// Async pipeline
var asyncResult = await ResultBox.Start
    .Conveyor(_ => FetchUserAsync(userId))
    .Combine(user => LoadOrdersAsync(user.Id))
    .Remap((user, orders) => new UserSummary(user.Name, orders.Count));

// Error recovery with Rescue
var rescued = ResultBox<int>.Error(new TimeoutException())
    .Rescue(ex => ex is TimeoutException
        ? ValueOrException<int>.FromValue(0)   // recover with default
        : ValueOrException<int>.Exception);     // keep the error

// Side effects with Scan/Do
var logged = ResultBox.FromValue(42)
    .Scan(v => Console.WriteLine($"Value: {v}"))
    .Do(v => Console.WriteLine($"Processing: {v}"));
```

## Union Types Used

| Type | Declaration | Purpose |
|------|------------|---------|
| `ResultBox<T>` | `union(T, Exception)` | Success or failure |
| `ExceptionOrNone` | `union(Exception, UnitValue)` | Optional exception |
| `OptionalValue<T>` | `union(T, NoneValue)` | Optional value |
| `ValueOrException<T>` | `union(T, ExceptionMarker)` | Recovery helper |

## Requirements

- .NET 11 Preview 3+
- C# 15 (`LangVersion preview`)

## License

[MIT](LICENSE)
