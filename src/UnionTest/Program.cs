using System.Diagnostics;
using System.Text.Json;
using UnionTest;

Console.WriteLine("=== C# 15 Union Type Stress Test ===");
Console.WriteLine();

// --- Union100 テスト ---
Console.WriteLine("--- Union100 (100 cases) ---");

// 最初のケース
Union100 u1 = new Case1(1);
var result1 = u1.Value switch
{
    Case1 c => $"Case1: {c.Value}",
    _ => "other"
};
Console.WriteLine($"  Case1 assign & match: {result1}");

// 中間のケース
Union100 u50 = new Case50(50);
var result50 = u50.Value switch
{
    Case50 c => $"Case50: {c.Value}",
    _ => "other"
};
Console.WriteLine($"  Case50 assign & match: {result50}");

// 最後のケース
Union100 u100 = new Case100(100);
var result100 = u100.Value switch
{
    Case100 c => $"Case100: {c.Value}",
    _ => "other"
};
Console.WriteLine($"  Case100 assign & match: {result100}");

// 全ケースをループで代入・検証
var sw100 = Stopwatch.StartNew();
int verified100 = 0;
for (int i = 1; i <= 100; i++)
{
    Union100 u = i switch
    {
        1 => new Case1(i),
        2 => new Case2(i),
        3 => new Case3(i),
        4 => new Case4(i),
        5 => new Case5(i),
        6 => new Case6(i),
        7 => new Case7(i),
        8 => new Case8(i),
        9 => new Case9(i),
        10 => new Case10(i),
        11 => new Case11(i),
        12 => new Case12(i),
        13 => new Case13(i),
        14 => new Case14(i),
        15 => new Case15(i),
        16 => new Case16(i),
        17 => new Case17(i),
        18 => new Case18(i),
        19 => new Case19(i),
        20 => new Case20(i),
        21 => new Case21(i),
        22 => new Case22(i),
        23 => new Case23(i),
        24 => new Case24(i),
        25 => new Case25(i),
        26 => new Case26(i),
        27 => new Case27(i),
        28 => new Case28(i),
        29 => new Case29(i),
        30 => new Case30(i),
        31 => new Case31(i),
        32 => new Case32(i),
        33 => new Case33(i),
        34 => new Case34(i),
        35 => new Case35(i),
        36 => new Case36(i),
        37 => new Case37(i),
        38 => new Case38(i),
        39 => new Case39(i),
        40 => new Case40(i),
        41 => new Case41(i),
        42 => new Case42(i),
        43 => new Case43(i),
        44 => new Case44(i),
        45 => new Case45(i),
        46 => new Case46(i),
        47 => new Case47(i),
        48 => new Case48(i),
        49 => new Case49(i),
        50 => new Case50(i),
        51 => new Case51(i),
        52 => new Case52(i),
        53 => new Case53(i),
        54 => new Case54(i),
        55 => new Case55(i),
        56 => new Case56(i),
        57 => new Case57(i),
        58 => new Case58(i),
        59 => new Case59(i),
        60 => new Case60(i),
        61 => new Case61(i),
        62 => new Case62(i),
        63 => new Case63(i),
        64 => new Case64(i),
        65 => new Case65(i),
        66 => new Case66(i),
        67 => new Case67(i),
        68 => new Case68(i),
        69 => new Case69(i),
        70 => new Case70(i),
        71 => new Case71(i),
        72 => new Case72(i),
        73 => new Case73(i),
        74 => new Case74(i),
        75 => new Case75(i),
        76 => new Case76(i),
        77 => new Case77(i),
        78 => new Case78(i),
        79 => new Case79(i),
        80 => new Case80(i),
        81 => new Case81(i),
        82 => new Case82(i),
        83 => new Case83(i),
        84 => new Case84(i),
        85 => new Case85(i),
        86 => new Case86(i),
        87 => new Case87(i),
        88 => new Case88(i),
        89 => new Case89(i),
        90 => new Case90(i),
        91 => new Case91(i),
        92 => new Case92(i),
        93 => new Case93(i),
        94 => new Case94(i),
        95 => new Case95(i),
        96 => new Case96(i),
        97 => new Case97(i),
        98 => new Case98(i),
        99 => new Case99(i),
        100 => new Case100(i),
        _ => throw new InvalidOperationException()
    };

    // Value プロパティ経由でパターンマッチして値を検証
    var val = u.Value switch
    {
        Case1 c => c.Value,
        Case2 c => c.Value,
        Case3 c => c.Value,
        Case4 c => c.Value,
        Case5 c => c.Value,
        Case6 c => c.Value,
        Case7 c => c.Value,
        Case8 c => c.Value,
        Case9 c => c.Value,
        Case10 c => c.Value,
        Case11 c => c.Value,
        Case12 c => c.Value,
        Case13 c => c.Value,
        Case14 c => c.Value,
        Case15 c => c.Value,
        Case16 c => c.Value,
        Case17 c => c.Value,
        Case18 c => c.Value,
        Case19 c => c.Value,
        Case20 c => c.Value,
        Case21 c => c.Value,
        Case22 c => c.Value,
        Case23 c => c.Value,
        Case24 c => c.Value,
        Case25 c => c.Value,
        Case26 c => c.Value,
        Case27 c => c.Value,
        Case28 c => c.Value,
        Case29 c => c.Value,
        Case30 c => c.Value,
        Case31 c => c.Value,
        Case32 c => c.Value,
        Case33 c => c.Value,
        Case34 c => c.Value,
        Case35 c => c.Value,
        Case36 c => c.Value,
        Case37 c => c.Value,
        Case38 c => c.Value,
        Case39 c => c.Value,
        Case40 c => c.Value,
        Case41 c => c.Value,
        Case42 c => c.Value,
        Case43 c => c.Value,
        Case44 c => c.Value,
        Case45 c => c.Value,
        Case46 c => c.Value,
        Case47 c => c.Value,
        Case48 c => c.Value,
        Case49 c => c.Value,
        Case50 c => c.Value,
        Case51 c => c.Value,
        Case52 c => c.Value,
        Case53 c => c.Value,
        Case54 c => c.Value,
        Case55 c => c.Value,
        Case56 c => c.Value,
        Case57 c => c.Value,
        Case58 c => c.Value,
        Case59 c => c.Value,
        Case60 c => c.Value,
        Case61 c => c.Value,
        Case62 c => c.Value,
        Case63 c => c.Value,
        Case64 c => c.Value,
        Case65 c => c.Value,
        Case66 c => c.Value,
        Case67 c => c.Value,
        Case68 c => c.Value,
        Case69 c => c.Value,
        Case70 c => c.Value,
        Case71 c => c.Value,
        Case72 c => c.Value,
        Case73 c => c.Value,
        Case74 c => c.Value,
        Case75 c => c.Value,
        Case76 c => c.Value,
        Case77 c => c.Value,
        Case78 c => c.Value,
        Case79 c => c.Value,
        Case80 c => c.Value,
        Case81 c => c.Value,
        Case82 c => c.Value,
        Case83 c => c.Value,
        Case84 c => c.Value,
        Case85 c => c.Value,
        Case86 c => c.Value,
        Case87 c => c.Value,
        Case88 c => c.Value,
        Case89 c => c.Value,
        Case90 c => c.Value,
        Case91 c => c.Value,
        Case92 c => c.Value,
        Case93 c => c.Value,
        Case94 c => c.Value,
        Case95 c => c.Value,
        Case96 c => c.Value,
        Case97 c => c.Value,
        Case98 c => c.Value,
        Case99 c => c.Value,
        Case100 c => c.Value,
        null => -1,
        _ => -1
    };

    if (val == i) verified100++;
}
sw100.Stop();
Console.WriteLine($"  All 100 cases verified: {verified100}/100 ({sw100.ElapsedMilliseconds}ms)");
Console.WriteLine();

// --- Union500 テスト ---
Console.WriteLine("--- Union500 (500 cases) ---");

// 最初のケース
Union500 u501 = new Case501(501);
var result501 = u501.Value switch
{
    Case501 c => $"Case501: {c.Value}",
    _ => "other"
};
Console.WriteLine($"  Case501 assign & match: {result501}");

// 中間のケース
Union500 u750 = new Case750(750);
var result750 = u750.Value switch
{
    Case750 c => $"Case750: {c.Value}",
    _ => "other"
};
Console.WriteLine($"  Case750 assign & match: {result750}");

// 最後のケース
Union500 u1000 = new Case1000(1000);
var result1000 = u1000.Value switch
{
    Case1000 c => $"Case1000: {c.Value}",
    _ => "other"
};
Console.WriteLine($"  Case1000 assign & match: {result1000}");

// 代表的なケースをサンプリングで検証
var sw500 = Stopwatch.StartNew();
int verified500 = 0;

Union500 test1 = new Case501(501);
if (test1.Value is Case501 { Value: 501 }) verified500++;

Union500 test2 = new Case600(600);
if (test2.Value is Case600 { Value: 600 }) verified500++;

Union500 test3 = new Case700(700);
if (test3.Value is Case700 { Value: 700 }) verified500++;

Union500 test4 = new Case800(800);
if (test4.Value is Case800 { Value: 800 }) verified500++;

Union500 test5 = new Case900(900);
if (test5.Value is Case900 { Value: 900 }) verified500++;

Union500 test6 = new Case1000(1000);
if (test6.Value is Case1000 { Value: 1000 }) verified500++;

sw500.Stop();
Console.WriteLine($"  Sample cases verified: {verified500}/6 ({sw500.ElapsedMilliseconds}ms)");
Console.WriteLine();

// ================================================================
// JSON シリアライズ / デシリアライズ テスト
// ================================================================
Console.WriteLine("=== JSON Serialization Tests ===");
Console.WriteLine();

var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

int serializePass = 0;
int serializeFail = 0;
int deserializePass = 0;
int deserializeFail = 0;

void TestJson<TUnion>(string label, TUnion original, Func<TUnion, bool> verify)
{
    Console.Write($"  [{label}] ");
    try
    {
        // シリアライズ
        var json = JsonSerializer.Serialize(original, jsonOptions);
        var compactJson = json.ReplaceLineEndings("").Replace("  ", "");
        Console.WriteLine($"Serialize: OK");
        Console.WriteLine($"    JSON: {compactJson}");
        serializePass++;

        // デシリアライズ
        try
        {
            var deserialized = JsonSerializer.Deserialize<TUnion>(json, jsonOptions);
            if (deserialized is not null && verify(deserialized))
            {
                Console.WriteLine($"    Deserialize: OK (round-trip verified)");
                deserializePass++;
            }
            else
            {
                var valueProp = deserialized?.GetType().GetProperty("Value");
                var innerVal = valueProp?.GetValue(deserialized);
                var innerType = innerVal?.GetType().FullName ?? "null";
                Console.WriteLine($"    Deserialize: FAIL (Value is {innerType}: {innerVal})");
                deserializeFail++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"    Deserialize: EXCEPTION ({ex.GetType().Name}: {ex.Message})");
            deserializeFail++;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Serialize: EXCEPTION ({ex.GetType().Name}: {ex.Message})");
        serializeFail++;
        deserializeFail++;
    }
    Console.WriteLine();
}

// --- パターン1: プリミティブ型のプロパティが異なる子型 ---
Console.WriteLine("--- Pattern 1: Different primitive properties ---");

PersonInfo p1 = new PersonName("Taro", "Yamada");
TestJson("PersonName", p1, d => d.Value is PersonName { First: "Taro", Last: "Yamada" });

PersonInfo p2 = new Age(30);
TestJson("Age", p2, d => d.Value is Age { Years: 30 });

PersonInfo p3 = new Email("test@example.com");
TestJson("Email", p3, d => d.Value is Email { Address: "test@example.com" });

// --- パターン2: コレクション・ネスト型を含む子型 ---
Console.WriteLine("--- Pattern 2: Collections and nested types ---");

ComplexData c1 = new StringTagList(["alpha", "beta", "gamma"]);
TestJson("StringTagList", c1, d => d.Value is StringTagList t && t.Tags.Count == 3 && t.Tags[0] == "alpha");

ComplexData c2 = new Coordinate(1.5, 2.5, 3.5);
TestJson("Coordinate", c2, d => d.Value is Coordinate { X: 1.5, Y: 2.5, Z: 3.5 });

ComplexData c3 = new Metadata(new Dictionary<string, string> { ["key1"] = "val1", ["key2"] = "val2" });
TestJson("Metadata", c3, d => d.Value is Metadata m && m.Properties.Count == 2 && m.Properties["key1"] == "val1");

// --- パターン3: record class vs record struct の混在 ---
Console.WriteLine("--- Pattern 3: record class vs record struct ---");

MixedUnion m1 = new ClassRecord("Alice", 42);
TestJson("ClassRecord", m1, d => d.Value is ClassRecord { Name: "Alice", Id: 42 });

MixedUnion m2 = new StructRecord(3.14, true);
TestJson("StructRecord", m2, d => d.Value is StructRecord { Value: 3.14, Flag: true });

MixedUnion m3 = new NullableRecord(null, null);
TestJson("NullableRecord(null,null)", m3, d => d.Value is NullableRecord { Label: null, Count: null });

MixedUnion m4 = new NullableRecord("Hello", 99);
TestJson("NullableRecord(values)", m4, d => d.Value is NullableRecord { Label: "Hello", Count: 99 });

// --- パターン4: 継承を含む record 型 ---
Console.WriteLine("--- Pattern 4: Inherited records ---");

AnimalUnion a1 = new BaseAnimal("Generic");
TestJson("BaseAnimal", a1, d => d.Value is BaseAnimal { Name: "Generic" });

AnimalUnion a2 = new DogAnimal("Rex", "Labrador");
TestJson("DogAnimal", a2, d => d.Value is DogAnimal { Name: "Rex", Breed: "Labrador" });

AnimalUnion a3 = new CatAnimal("Whiskers", true);
TestJson("CatAnimal", a3, d => d.Value is CatAnimal { Name: "Whiskers", Indoor: true });

// --- パターン5: 空・単一・多数プロパティの子型 ---
Console.WriteLine("--- Pattern 5: Empty, single, many properties ---");

VariedUnion v1 = new EmptyRecord();
TestJson("EmptyRecord", v1, d => d.Value is EmptyRecord);

VariedUnion v2 = new SingleProp("only");
TestJson("SingleProp", v2, d => d.Value is SingleProp { Solo: "only" });

var guid = Guid.Parse("12345678-1234-1234-1234-123456789abc");
var dt = new DateTime(2025, 6, 15, 10, 30, 0, DateTimeKind.Utc);
VariedUnion v3 = new ManyProps("aaa", 123, 4.56, true, dt, guid);
TestJson("ManyProps", v3, d => d.Value is ManyProps mp
    && mp.A == "aaa" && mp.B == 123 && mp.C == 4.56 && mp.D == true && mp.E == dt && mp.F == guid);

// --- パターン6: ジェネリック型を含む子型 ---
Console.WriteLine("--- Pattern 6: Generic-like types ---");

ResultUnion r1 = new StringResult("hello");
TestJson("StringResult", r1, d => d.Value is StringResult { Value: "hello" });

ResultUnion r2 = new IntResult(42);
TestJson("IntResult", r2, d => d.Value is IntResult { Value: 42 });

ResultUnion r3 = new ListResult([10, 20, 30]);
TestJson("ListResult", r3, d => d.Value is ListResult l && l.Items.Count == 3 && l.Items[1] == 20);

// --- サマリー ---
Console.WriteLine("=== JSON Test Summary ===");
Console.WriteLine($"  Serialize:   PASS={serializePass}, FAIL={serializeFail}");
Console.WriteLine($"  Deserialize: PASS={deserializePass}, FAIL={deserializeFail}");
Console.WriteLine();

Console.WriteLine("=== All tests completed ===");
