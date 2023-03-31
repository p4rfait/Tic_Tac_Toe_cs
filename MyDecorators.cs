namespace MyDecorators;
public class ClaseDecorators
{
    //Funcion para imprimir arte ascii centrado 
    public void Displaylogo(bool animation, int vel = 75)
    {                
        string[] logo = {
        " _______________  _________  _____  __________  ____ ",
        "/_  __/  _/ ___/ /_  __/ _ |/ ___/ /_  __/ __ \\/ __/ ",
        " / / _/ // /__    / / / __ / /__    / / / /_/ / _/   ",
        "/_/ /___/\\___/   /_/ /_/ |_\\___/   /_/  \\____/___/.cs",
        "",
        "Por: Tomas Armando Campos",
        "Github: https://github.com/p4rfait",
        ""
        };
        
        //ciclo for que se repite por cada "linea" de el array(logo)
        for (int i = 0; i < logo.Length; i++)
            {
                /*Si, aqui hay cosas matematicas
                - x = el ancho ancho de la terminal - longitud de string de la "linea" [i] / 2
                - x busca el centro de la terminal*/
            int x = (Console.WindowWidth - logo[i].Length) / 2;
                /*- y = la altura de la terminal / el ancho de la terminal + [i]
                - y baja linea por linea con respecto a la cantidad de "lineas" que tenga el array(logo)*/
            int y = Console.WindowHeight / Console.WindowWidth + i;

            //posiciona el cursor con los valores de x,y que seria el x = centro de la terminal, y = linea tras linea 
            Console.SetCursorPosition(x, y);
            /* si el parametro animation es verdadero se toma un tiempo (vel) 
            en imprimir cada linea para simular animacion de cascada*/
            if (animation)
                {
                    Thread.Sleep(vel);
                }
            //Finalmente imprime una "linea" de el array(logo) con su posicion determinada por x,y
            Console.ForegroundColor=ConsoleColor.Black;
            Console.WriteLine(logo[i]);
            }
    }

    //funcion para crear separador
    public void Separator(int linesQty, bool JumpLine = false)
    {
        Console.ForegroundColor=ConsoleColor.Black;
        Console.WriteLine(new string('-', linesQty)+new string(JumpLine?"\n":""));
    }
}