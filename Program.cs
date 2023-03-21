#region code
Console.Clear();

Resistor r = new(args[0]);
Console.WriteLine($"ohm: {r.GetValue()}, percentage: {r.GetTolerance()}");
 
#endregion
