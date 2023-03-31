//Hago uso de los demas archivos
using MyDecorators;
using Game;
using ErrorMessages;

namespace MainMenu;
public class ClaseMainMenu
{
	public void TitleMenu()
	{
		
		//Defino como llamare a las funciones dentro de los otros archivos
		ClaseDecorators Decorador = new ClaseDecorators();
		ClaseErrorMessages ErrorMessage = new ClaseErrorMessages();
		ClaseGame Game = new ClaseGame();

		//Preparo el fondo e imprimo el titulo 
		Console.BackgroundColor = ConsoleColor.White;
		Console.Clear();
		Console.CursorVisible = false;
		Decorador.Displaylogo(true);
		Console.CursorVisible = true;

		/*
		Bucle while + switch/case:
			Contempla la entrada de un valor nulo, valor numerico no valido y valor no numerico no valido
			esto evita que se procese un valor no valido que haga que el programa crashee
			siempre utilizo esta estructura en menus de seleccion multiple.
		*/
		bool isValidInput = false;				//Este booleano determina si el bucle continua o se corta false=continua, true=corta bucle
		while (!isValidInput)
		{
			Console.Clear();
			Decorador.Displaylogo(false);		//Imprimir logo sin animacion de cascada
			Decorador.Separator(5);
			Console.WriteLine("Que accion desea realizar?:");
			Decorador.Separator(5);
			Console.WriteLine("(1) Jugar");
			Console.WriteLine("(2) Salir");
			Decorador.Separator(5);
			Console.Write("> ");
			Console.CursorVisible = true;
			
			string? input = Console.ReadLine();
			if (Int16.TryParse(input, out short result))
			{
				short selecton = result;
				switch (selecton)
				{
					case 1:
						Game.StartGame();
						isValidInput = true;
						Console.ReadKey();
						break;
					case 2:
						Console.Clear();
						Environment.Exit(0);
						return;
					default:
						//Funcion personalizada para imprimir mensaje de error con formato (ver <ErrorMessages.cs>)
						ErrorMessage.Message("El número ingresado no corresponde a ninguna opción.");
						break;
				}
			}
			else
			{
				ErrorMessage.Message("La entrada no es un valor numérico válido.");
			}
		}
	}    
}