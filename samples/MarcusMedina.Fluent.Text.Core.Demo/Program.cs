using System.Text;
using MarcusMedina.Fluent.Text.Core.Builders;
using MarcusMedina.Fluent.Text.Core.Extensions.Casing;
using MarcusMedina.Fluent.Text.Core.Extensions.Counting;
using MarcusMedina.Fluent.Text.Core.Extensions.DataFormat;
using MarcusMedina.Fluent.Text.Core.Extensions.Extraction;
using MarcusMedina.Fluent.Text.Core.Extensions.LineEndings;
using MarcusMedina.Fluent.Text.Core.Extensions.Manipulation;
using MarcusMedina.Fluent.Text.Core.Extensions.Pattern;
using MarcusMedina.Fluent.Text.Core.Extensions.Validation;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("=== Fluent Text Core Demo ===\n");

var phrase = "fluent text builders make strings delightful";
Console.WriteLine("Casing playground:");
Console.WriteLine($"  Original     : {phrase}");
Console.WriteLine($"  Title        : {phrase.ToTitleCase()}");
Console.WriteLine($"  Camel        : {phrase.ToCamelCase()}");
Console.WriteLine($"  Kebab        : {phrase.ToKebabCase()}");
Console.WriteLine($"  Alternating  : {phrase.ToAlternatingCase()}");
Console.WriteLine($"  Name case    : {"mcarthur o'brien".ToNameCase()}\n");

var builder = FluentTextBuilder.From("demo pipeline").Build();
Console.WriteLine($"Builder echo   : {builder}\n");

var telemetry = "Deploy 42 ships 2025-03-01. Contact ops@fluent.dev or +46 555 44 33. #launch ready?";
Console.WriteLine("Extraction + counting:");
Console.WriteLine($"  Letters      : {telemetry.CountLetters()} | Digits: {telemetry.CountDigits()} | Words: {telemetry.CountWords()}");
Console.WriteLine($"  Dates        : {string.Join(", ", telemetry.ExtractDates())}");
Console.WriteLine($"  Emails       : {string.Join(", ", telemetry.ExtractEmails())}");
Console.WriteLine($"  Phones       : {string.Join(", ", telemetry.ExtractPhoneNumbers())}");
Console.WriteLine($"  Hashtags     : {string.Join(", ", telemetry.ExtractHashtags())}");
Console.WriteLine($"  Mentions     : {string.Join(", ", "Ping @deploy and @support".ExtractMentions())}\n");

var csvLine = new[] { "Name", "Role", "Quote: \"hi\"" }.ToCsvLine();
Console.WriteLine("Data formats:");
Console.WriteLine($"  CSV line     : {csvLine}");
Console.WriteLine($"  Round-trip   : {string.Join(" | ", csvLine.SplitCsvLine())}\n");

var layout = " Line one\r\nLine two\nLine three ";
Console.WriteLine("Line endings + manipulation:");
Console.WriteLine($"  Unix endings : {layout.ToUnixLineEndings().Replace("\n", "⏎")}");
Console.WriteLine($"  Collapsed WS : {"Fluent   text\t demo".CollapseWhitespace()}");
Console.WriteLine($"  Masked key   : {"FLUENT-1234-DEMO".Mask(7, 4)}\n");

var environment = "preview-east";
Console.WriteLine("Pattern helpers:");
Console.WriteLine($"  Between dev-prod? {environment.Between("dev", "prod")}");
Console.WriteLine($"  LIKE '%-east'?   {environment.IsLike("%-east")}");
Console.WriteLine($"  In allowed set?  {environment.In(new[] { "preview-east", "prod-eu" })}\n");

Console.WriteLine("Validation snippets:");
Console.WriteLine($"  \"\".IsEmpty()            => {"".IsEmpty()}");
Console.WriteLine($"  \"   \".IsWhiteSpace()      => {"   ".IsWhiteSpace()}");
Console.WriteLine($"  \"text\".IsNullOrEmpty()  => {"text".IsNullOrEmpty()}\n");

Console.WriteLine("Demo complete — string utilities ready for exploration.");
