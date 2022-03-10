public class RomanNumber : ICloneable, IComparable
{
    private ushort number;
    private string number_string;

    private static string GetRomanSymbol(ushort n)
    {
        switch (n)
        {
        case 1:
            return "I";
        case 4:
            return "IV";
        case 5:
            return "V";
        case 9:
            return "IX";
        case 10:
            return "X";
        case 40:
            return "XL";
        case 50:
            return "L";
        case 90:
            return "XC";
        case 100:
            return "C";
        case 400:
            return "CD";
        case 500:
            return "D";
        case 900:
            return "CM";
        case 1000:
            return "M";
        default:
            break;
        }
        return "??";
    }

    private static ushort GetNumberFromRoman(char num)
    {
        switch (num)
        {
        case 'I':
            return 1;
        case 'V':
            return 5;
        case 'X':
            return 10;
        case 'L':
            return 50;
        case 'C':
            return 100;
        case 'D':
            return 500;
        case 'M':
            return 1000;
        default:
            break;
        }
        return 0;
    }

    protected static ushort RomanToNumber(string? num)
    {
        if (num == null)
            throw new RomanNumberException("num should not be null!");
        int res_int = 0;
        int[] values = new int[] { 1000, 500, 100, 50, 10, 5, 1 };
        for (int i = 0; i < num.Length - 1; ++i)
        {
            if (GetNumberFromRoman(num[i]) < GetNumberFromRoman(num[i + 1]))
                res_int -= GetNumberFromRoman(num[i]);
            else
                res_int += GetNumberFromRoman(num[i]);
        }
        res_int += GetNumberFromRoman(num[^1]);
        return (ushort)res_int;
    }

    private static string NumberToRoman(ushort num)
    {
        ushort[] values = new ushort[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        string res = "";

        for (int i = 0; i < values.Length; ++i)
        {
            while (num >= values[i])
            {
                num -= values[i];
                res += GetRomanSymbol(values[i]);
            }
        }
        return res;
    }

    public RomanNumber(ushort n)
    {
        if (n == 0)
            throw new RomanNumberException("Number should not be zero!");
        number = n;
        number_string = NumberToRoman(number);
    }

    public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
    {
        ushort res;
        if (n1 == null || n2 == null)
            throw new RomanNumberException("Parameter should not be null");
        ushort number1 = RomanToNumber(n1.ToString());
        ushort number2 = RomanToNumber(n2.ToString());
        checked
        {
            res = (ushort)(number1 + number2);
        }
        return new RomanNumber(res);
    }

    public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
    {
        ushort res;
        if (n1 == null || n2 == null)
            throw new RomanNumberException("Parameter should not be null");
        ushort number1 = RomanToNumber(n1.ToString());
        ushort number2 = RomanToNumber(n2.ToString());
        if (number1 <= number2)
            throw new RomanNumberException("First parameter should not be less than second");
        res = (ushort)(number1 - number2);
        return new RomanNumber(res);
    }

    public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
    {
        ushort res;
        if (n1 == null || n2 == null)
            throw new RomanNumberException("Parameter should not be null");
        ushort number1 = RomanToNumber(n1.ToString());
        ushort number2 = RomanToNumber(n2.ToString());
        checked
        {
            res = (ushort)(number1 * number2);
        }        
        return new RomanNumber(res);
    }

    public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
    {
        ushort res;
        if (n1 == null || n2 == null)
            throw new RomanNumberException("Parameter should not be null");
        ushort number1 = RomanToNumber(n1.ToString());
        ushort number2 = RomanToNumber(n2.ToString());
        if (number1 < number2)
            throw new RomanNumberException("First parameter should not be less than second");
        res = (ushort)(number1 / number2);
        return new RomanNumber(res);
    }

    public override string ToString()
    {
        return number_string;
    }

    public object Clone()
    {
        return new RomanNumber(number);
    }

    public int CompareTo(object? obj)
    {
        if (obj == null)
            throw new RomanNumberException("obj should not be null!");
        if (obj is RomanNumber num)
            return number.CompareTo(RomanToNumber(num.ToString()));
        else
            throw new RomanNumberException("Wrong object");
    }
}
