public class Resistor
{
    private const int BLACK = 0, BROWN = 1, RED = 2, ORANGE = 3, YELLOW = 4, GREEN = 5, BLUE = 6, VIOLET = 7, GRAY = 8, WHITE = 9;

    public string Color1;
    public string Color2;
    public string Color3;
    public string Color4;
    public string Color5 = "";
    public int number1, number2, number3, number5;
    public double number4;
    public bool fiveColors = false;

    private bool TryConvertColorToDigit(string color, out int number)
    {
        switch (color)
        {
            case "bla": number = BLACK; return true;
            case "bro": number = BROWN; return true;
            case "red": number = RED; return true;
            case "ora": number = ORANGE; return true;
            case "yel": number = YELLOW; return true;
            case "gre": number = GREEN; return true;
            case "blu": number = BLUE; return true;
            case "vio": number = VIOLET; return true;
            case "gra": number = GRAY; return true;
            case "whi": number = WHITE; return true;
            default: number = -1; return false;
        }
    }

    private bool TryGetToleranceFromColor(string color, out double number4)
    {
        switch (color)
        {
            case "bro": number4 = 1; return true;
            case "red": number4 = 2; return true;
            case "gre": number4 = 0.5; return true;
            case "blu": number4 = 0.25; return true;
            case "vio": number4 = 0.10; return true;
            case "gra": number4 = 0.05; return true;
            case "gol": number4 = 5; return true;
            case "sil": number4 = 10; return true;
            default: number4 = -1; return false;
        }
    }

    private void UseMethods()
    {
        TryConvertColorToDigit(Color1, out number1);
        TryConvertColorToDigit(Color2, out number2);
        if (fiveColors) {TryConvertColorToDigit(Color5, out number5);}
        if (number1 == -1|| number2 == -1 || number5 == -1) {Console.WriteLine("Wrong Input");}
        TryConvertColorToDigit(Color3, out number3);
        if (number3 == -1) {Console.WriteLine("Wrong Multiplicator");}
        
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

    public double TryGetValue()
    {
        UseMethods();
        double digit = number1 * 10;
        digit += number2;
        if (fiveColors) { digit *= 10; digit += number5; }
        digit *= Math.Pow(10, number3);
        return digit;
    }

    public double TryGetTolerance()
    {
        TryGetToleranceFromColor(Color4, out number4);
        if (number4 == -1) {Console.WriteLine("Wrong Tolerance. Please try again!");}
        return number4;
    }
}