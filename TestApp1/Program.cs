bool active = true;

Console.CancelKeyPress += Console_CancelKeyPress;
void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
{
    active = false;
    e.Cancel = true;
}

async Task WriteDate(string fn)
{
    var dt = DateTime.Now;
    string s = $"{dt.ToLongDateString()} {dt.ToLongTimeString()} " + string.Join(';', args) + " # " + Environment.GetEnvironmentVariable("VAL_9");
    Console.WriteLine(s);
    await File.WriteAllTextAsync(fn, s);
}

while (active)
{
    await WriteDate("text1.txt");
    await Task.Delay(1000);
}

await WriteDate("end.txt");
Console.WriteLine("exit");