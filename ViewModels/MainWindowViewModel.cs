using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;

using Avalonia.Controls;
using Avalonia.Interactivity;

using lab4.Views;

namespace lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
	public string greeting = "?";

	public MainWindowViewModel()
	{
		string? num1 = null;
		string? num2 = null;
		string? op = null;

		bool nextNum = false;

		OnClickCommand = ReactiveCommand.Create<string>((str) => 
			{
				if ("+-*/=".Contains(str))
				{
					if (op == null) 
					{
						op = str;
						Greeting = num1 + op;
						nextNum = !nextNum;
					}
					else if (str == "=")
					{
						try
						{
							Greeting = Calc.Calculate(num1, num2, op);
						}
						catch (RomanNumberException)
						{
							Greeting = "Error!";
						}
							
						num1 = null;
						num2 = null;
						op = null;
						nextNum = false;
					}
					else
					{
						Console.WriteLine("Why r u here?");
					}

				}
				else
				{
					if (nextNum == false)
					{
						num1 += str;
						Greeting = num1;
					}
					else
					{
						num2 += str;
						Greeting = num1 + op + num2;
					}
				}
				
			});
	}

        public string Greeting 
	{
		set
		{
			this.RaiseAndSetIfChanged(ref greeting, value);
		}
		get
		{
			return greeting;
		}
	}

    	public ReactiveCommand<string,Unit> OnClickCommand {get;}
    }
}
