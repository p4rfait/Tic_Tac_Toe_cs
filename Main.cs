using System;
using System.Threading;
using MainMenu;

namespace Main;

public class MainClass
{
  public static void Main(string[] args)
  {
    ClaseMainMenu MainMenu = new ClaseMainMenu();

    /*Esto simplemente obtiene el tamano de la ventana para saber si es optima,
      si no lo es no se ejecuta,
      Siempre hago esto cuando imprimo un titulo con arte ascii*/
      
    if (Console.WindowWidth < 55 || Console.WindowHeight < 30)
    {
      Console.ForegroundColor=ConsoleColor.DarkRed;
      Console.WriteLine("La ventana es demasiado chica para ejecutar el programa");
      return;
    };
    //Llama a nuestro menu de titulo
    MainMenu.TitleMenu();
  }
}