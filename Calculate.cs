public class Resistor
{
    private const int BLACK = 0, BROWN = 1, RED = 2, ORANGE = 3, YELLOW = 4, GREEN = 5, BLUE = 6, VIOLET = 7, GRAY = 8, WHITE = 9;

    public string Color1;
    public string Color2;
    public string Color3;
    public string Color4;
    public string Color5 = "";
    public bool fiveColors = false;

    private int ConvertColorToDigit(string color)
    {
        switch (color)
        {
            case "bla": return BLACK;
            case "bro": return BROWN;
            case "red": return RED;
            case "ora": return ORANGE;
            case "yel": return YELLOW;
            case "gre": return GREEN;
            case "blu": return BLUE;
            case "vio": return VIOLET;
            case "gra": return GRAY;
            case "whi": return WHITE;
            default: return -1;
        }
    }

    private double GetToleranceFromColor(string color)
    {
        switch (color)
        {
            case "bro": return 1;
            case "red": return 2;
            case "gre": return 0.5;
            case "blu": return 0.25;
            case "vio": return 0.10;
            case "gra": return 0.05;
            case "gol": return 5;
            case "sil": return 10;
            default: return -1;
        }
    }

    public Resistor(string text)
    {
        text = text.Replace("-", "").ToLower();
        Color1 = text.Substring(0, 3);
        text = text.Substring(3);
        Color2 = text.Substring(0, 3);
        text = text.Substring(3);
        if (text.Length > 0) { fiveColors = true; Color5 = text.Substring(0, 3); text = text.Substring(3); }
        Color3 = text.Substring(0, 3);
        text = text.Substring(3);
        Color4 = text;
    }

    public double GetValue()
    {
        double digit = ConvertColorToDigit(Color1) * 10;
        digit += ConvertColorToDigit(Color2);
        if (fiveColors) { digit *= 10; digit += ConvertColorToDigit(Color5); }
        digit *= Math.Pow(10, ConvertColorToDigit(Color3));
        return digit;
    }

    public double GetTolerance()
    {
        return GetToleranceFromColor(Color4);
    }
}