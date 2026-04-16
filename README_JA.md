# ResultBoxUnion

[English](README.md) | **日本語**

C# 15 の **Union 型** を使った Railway-oriented programming ライブラリ (.NET 11)。

[ResultBoxes](https://github.com/J-Tech-Japan/ResultBoxes) を `union` キーワードで全面的に再構築したものです。

## コアコンセプト

```csharp
// ResultBox<TValue> は union: TValue か Exception のどちらか
public union ResultBox<TValue>(TValue, Exception) where TValue : notnull;
```

内部の nullable フィールドや `IsSuccess` フラグは不要 — 型そのものが値またはエラーを表現します。

## クイックスタート

```csharp
using ResultBoxUnion;

// 結果の作成
ResultBox<int> success = 42;                              // 値からの暗黙変換
ResultBox<int> failure = new Exception("something wrong"); // 例外からの暗黙変換

// パターンマッチング（網羅的！）
var message = success switch
{
    int value    => $"値: {value}",
    Exception ex => $"エラー: {ex.Message}",
};

// Railway チェーン
var result = ResultBox.FromValue(10)
    .Remap(x => x * 2)                    // 20
    .Conveyor(x => ResultBox.Ok(x + 5))   // 25
    .Verify(x => x > 0
        ? ExceptionOrNone.None
        : new ArgumentException("正の値が必要です"));
```

## Railway パイプライン例

```csharp
// 複数の値を結合
var result = ResultBox.FromValue("hello")
    .Combine(greeting => ResultBox.Ok(greeting.Length))  // TwoValues<string, int>
    .Remap((greeting, len) => $"{greeting} は {len} 文字");

// 非同期パイプライン
var asyncResult = await ResultBox.Start
    .Conveyor(_ => FetchUserAsync(userId))
    .Combine(user => LoadOrdersAsync(user.Id))
    .Remap((user, orders) => new UserSummary(user.Name, orders.Count));

// Rescue でエラーから復帰
var rescued = ResultBox<int>.Error(new TimeoutException())
    .Rescue(ex => ex is TimeoutException
        ? ValueOrException<int>.FromValue(0)   // デフォルト値で復帰
        : ValueOrException<int>.Exception);     // エラーを維持

// Scan/Do で副作用
var logged = ResultBox.FromValue(42)
    .Scan(v => Console.WriteLine($"値: {v}"))
    .Do(v => Console.WriteLine($"処理中: {v}"));
```

## 使用している Union 型

| 型 | 宣言 | 用途 |
|---|------|------|
| `ResultBox<T>` | `union(T, Exception)` | 成功または失敗 |
| `ExceptionOrNone` | `union(Exception, UnitValue)` | 例外の有無 |
| `OptionalValue<T>` | `union(T, NoneValue)` | オプショナル値 |
| `ValueOrException<T>` | `union(T, ExceptionMarker)` | エラー復帰ヘルパー |

## 従来の ResultBoxes との違い

| 観点 | ResultBoxes (従来) | ResultBoxUnion (本ライブラリ) |
|------|-------------------|---------------------------|
| コア型 | `record ResultBox<T>` | `union ResultBox<T>(T, Exception)` |
| 成功判定 | `IsSuccess` プロパティ (内部フラグ) | `this is TValue` (パターンマッチ) |
| 値の格納 | nullable フィールド + Exception フィールド | union の Value プロパティ (どちらか一方) |
| 暗黙変換 | `implicit operator` を手動定義 | union が自動提供 |
| パターンマッチ | `{ IsSuccess: true }` パターン | `case TValue v =>` / `case Exception e =>` |
| ターゲット | .NET 8 / 9 / 10 | .NET 11+ のみ |

## 要件

- .NET 11 Preview 3+
- C# 15 (`LangVersion preview`)

## ライセンス

[MIT](LICENSE)
