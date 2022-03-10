using System;
using System.Collections.Generic;
using System.Text;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        public string Result => "-";

	public string num1 = "";
	public string num2 = "";
	public string operation = "";

	/*
	public void OnButtonClick() //object sender, RoutedEventArgs e)
	{
		Console.WriteLine("Hellloooo");
	}
	*/
    }
}
