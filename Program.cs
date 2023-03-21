#region code
Console.Clear();

Resistor r = new(args[0]);
Console.WriteLine($"ohm: {r.TryGetValue()}, percentage: {r.TryGetTolerance()}");
 
#endregion
