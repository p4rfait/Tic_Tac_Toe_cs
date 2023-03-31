//Esto solo almacena el formato de un mensaje de error para evitar estar escribiendo su estructura a cada rato
namespace ErrorMessages;
public class ClaseErrorMessages
{
	public void Message(string message, bool HideCursor = true, string message2 ="Pulsa la tecla [Enter] para continuar...")
	{
		if (HideCursor == true)
		{
			Console.CursorVisible = false;
		}
		Console.ForegroundColor=ConsoleColor.DarkRed;
		Console.WriteLine("\n"+message+"\n");
		Console.ForegroundColor=ConsoleColor.Black;
		Console.WriteLine(message2);
		while (Console.ReadKey().Key != ConsoleKey.Enter) {}
	}
}