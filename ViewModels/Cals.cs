
namespace lab4.ViewModels
{
	internal class Calc
	{
		public static string Calculate(string? num1, string? num2, string? op)
		{
			var romanNum1 = new RomanNumberExtend(num1);
			var romanNum2 = new RomanNumberExtend(num2);
			switch(op)
			{
				case "+": return (romanNum1 + romanNum2).ToString();
				case "-": return (romanNum1 - romanNum2).ToString();
				case "*": return (romanNum1 * romanNum2).ToString();
				case "/": return (romanNum1 / romanNum2).ToString();
				default: return "";
			}
		}
	}
}
