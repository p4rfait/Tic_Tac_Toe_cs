using System;
using System.Threading;
using MainMenu;

namespace Main;

public class MainClass
{
  public static void Main(string[] args)
  {
    ClaseMainMenu MainMenu = new ClaseMainMenu();
    
    OperatingSystem os = Environment.OSVersion;
    if (os.Platform == PlatformID.Win32NT)
    {Console.SetWindowSize(55,30);}

    Console.Title="Tic-Tac-Toe_cs";

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