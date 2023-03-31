namespace Game;
using MyDecorators;
using ErrorMessages;

class ClaseGame
{
    bool tie = true;
    string? p1Name;
    string? p2Name;
    //public bool arrow;
    public string xx = " X ";
    public string oo = " O ";
    public string N = "   ";
    

    public void StartGame()
    {
        ClaseDecorators Decorador = new ClaseDecorators();
        ClaseErrorMessages ErrorMessage = new ClaseErrorMessages();

        //Cuadricula
        string[,] Grid = new string[3, 3] { 
            {  N ,  N ,  N  }, 
            {  N ,  N ,  N  }, 
            {  N ,  N ,  N  }
        };

        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

		Decorador.Displaylogo(false);
        Console.Write("Ingrese el nombre de el jugador 1\n>");
        p1Name = Console.ReadLine();
        Console.Write("\nIngrese el nombre de el jugador 2\n>");
        p2Name = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(p1Name))
        {
            p1Name="Jugador 1";
        }if(string.IsNullOrWhiteSpace(p2Name))
        {
            p2Name="Jugador 2";
        }

        bool isValidInput = false;				//Este booleano determina si el bucle continua o se corta false=continua, true=corta bucle
		while (!isValidInput)
		{
			Console.Clear();
			Decorador.Displaylogo(false);		//Imprimir logo sin animacion de cascada
			Decorador.Separator(21);
			Console.WriteLine("Quien Empiza?:");
			Decorador.Separator(21);
			Console.WriteLine("(1) "+p1Name);
			Console.WriteLine("(2) "+p2Name);
			Decorador.Separator(21);
			Console.Write("> ");
			Console.CursorVisible = true;
			
			string? input = Console.ReadLine();
			if (Int16.TryParse(input, out short result))
			{
				short selecton = result;
				switch (selecton)
				{
					case 1:
                        //NADA
						isValidInput = true;
						break;
					case 2: 
                        //swapear variables
                        (p1Name,p2Name)=(p2Name,p1Name);
						isValidInput = true;
						break;
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

        Console.Clear();
        GameLoop();

        /*Esta funcion dibujara la tabla con sus valores, hace uso de la funcion value (linea 40)*/
        void drawGrid(bool arrow,int selection=0){
            Console.ForegroundColor=ConsoleColor.Black;
            Console.Write(arrow?"\n  v":"\n  >");
            Console.WriteLine("   1   2   3 ");
            Console.WriteLine("    ╔═══╦═══╦═══╗");
            if (selection==1){Console.BackgroundColor=ConsoleColor.Green;}
            Console.Write("  1 ║"); value(Grid,0,0); Console.Write("║"); value(Grid,0,1); Console.Write("║"); value(Grid,0,2); Console.Write("║    \n");
            Console.BackgroundColor=ConsoleColor.White;
            Console.WriteLine("    ╠═══╬═══╬═══╣");
            if (selection==2){Console.BackgroundColor=ConsoleColor.Green;}
            Console.Write("  2 ║"); value(Grid,1,0); Console.Write("║"); value(Grid,1,1); Console.Write("║"); value(Grid,1,2); Console.Write("║    \n");
            Console.BackgroundColor=ConsoleColor.White;
            Console.WriteLine("    ╠═══╬═══╬═══╣");
            if (selection==3){Console.BackgroundColor=ConsoleColor.Green;}
            Console.Write("  3 ║"); value(Grid,2,0); Console.Write("║"); value(Grid,2,1); Console.Write("║"); value(Grid,2,2); Console.Write("║    \n");
            Console.BackgroundColor=ConsoleColor.White;
            Console.WriteLine("    ╚═══╩═══╩═══╝");
        }

        /*esta funcion tiene como parametros nuestro array 2d (Grid)
         que es de donde obtendra los valores para compararlos
         y asignar el color con el que se va a imprimir (x-rojo), (o-azul)
         y otros dos valor fila(row) y columna (column) 
         necesario para saber que valores obtenda de el array (Grid)*/
        void value (string[,] grid, int row, int column){
            string valor = grid[row,column];
            if (valor==xx)
            {
                Console.ForegroundColor=ConsoleColor.DarkRed;
            }
            else if (valor==oo)
            {
                Console.ForegroundColor=ConsoleColor.DarkBlue;
            }
            Console.Write(valor);
            Console.ForegroundColor=ConsoleColor.Black;
        }

        void GameLoop(){
            for(int i=0;i<9;i++)
            {
                if(i%2==0){
                    GetX:
                    Console.Clear();
                    drawGrid(true);
                    Decorador.Separator(21);
                    Console.WriteLine("Juega \""+p1Name+"\" [X]");
                    Decorador.Separator(21);
                    Console.Write("Ingrese la fila: ");
                    int x = Convert.ToInt16(Console.ReadLine());
                    
                    if(x<1 || x>3){
                        ErrorMessage.Message("Fila no valida, Intenta de nuevo");
                        goto GetX;
                    }

                    if((Grid[x-1,0]!=N) && (Grid[x-1,1]!=N) && (Grid[x-1,2]!=N))
                    {
                        ErrorMessage.Message("No hay ninguna casilla disponible en la fila ["+(x)+"]");
                        goto GetX;
                    }


                    GetY:
                    Console.Clear();
                    drawGrid(false,x);
                    Decorador.Separator(21);
                    Console.WriteLine("Juega \""+p1Name+"\" [X]");
                    Decorador.Separator(21);
                    Console.WriteLine("Nota: Puedes ingresar <0> para cambiar la fila");
                    Console.Write("\nIngrese la columna: ");
                    
                    int y = Convert.ToInt16(Console.ReadLine());
                    
                    if(y==0){
                        goto GetX;
                    }
                    else if(y<0 || y>3){
                        ErrorMessage.Message("Columna no valida, Intenta de nuevo");
                        goto GetY;
                    }
                    else if(Grid[x-1,y-1] != N){
                        ErrorMessage.Message("Esa casilla ya esta ocupada intente de nuevo");
                        goto GetY;
                    }
                    else{
                        Grid[x-1,y-1]=xx;
                    }
                    
                    if(CheckWin(Grid,xx))
                    {
                        Console.Clear();
                        drawGrid(true);
                        Console.WriteLine("HA GANADO "+p1Name);
                        tie = false;
                        break;
                    }
                }
                else{
                    GetX:
                    Console.Clear();
                    drawGrid(true);
                    Decorador.Separator(21);
                    Console.WriteLine("Juega \""+p2Name+"\" [O]");
                    Decorador.Separator(21);
                    Console.Write("Ingrese la fila: ");
                    int x = Convert.ToInt16(Console.ReadLine());
                    if(x<1 || x>3){
                        ErrorMessage.Message("Fila no valida, Intenta de nuevo");
                        goto GetX;
                    }

                    if((Grid[x-1,0]!=N) && (Grid[x-1,1]!=N) && (Grid[x-1,2]!=N))
                    {
                        ErrorMessage.Message("No hay ninguna casilla disponible en la fila ["+(x)+"]");
                        goto GetX;
                    }

                    GetY:
                    Console.Clear();
                    drawGrid(false,x);
                    Decorador.Separator(21);
                    Console.WriteLine("Juega \""+p2Name+"\" [O]");
                    Decorador.Separator(21);
                    Console.WriteLine("Nota: Puedes ingresar <0> para cambiar la fila");
                    Console.Write("\nIngrese la columna: ");
                    
                    int y = Convert.ToInt16(Console.ReadLine());

                    if(y==0){
                        goto GetX;
                    }
                    else if(y<0 || y>3){
                        ErrorMessage.Message("Columna no valida, Intenta de nuevo");
                        goto GetY;
                    }
                    else if(Grid[x-1,y-1] != N){
                        ErrorMessage.Message("Esa casilla ya esta ocupada intente de nuevo");
                        goto GetY;
                    }
                    else{
                        Grid[x-1,y-1]=oo;    
                    }

                    if(CheckWin(Grid,oo))
                    {
                        Console.Clear();
                        drawGrid(true);
                        Console.WriteLine("HA GANADO "+p2Name);
                        tie = false;
                        break;
                    }
                }
            }
            if(tie == true){
                Console.Clear();
                drawGrid(true);
                Console.WriteLine("     EMPATE!");
            }
        }

        //Checkear escenarios de victoria
        bool CheckWin(string[,] grid, string player)
        {
            //Checkear filas
            for (int row=0;row<3;row++)
            {
                if(grid[row,0]==player && grid[row,1]==player && grid[row,2]==player)
                {
                    return true;
                }
            }
            //Checkear columnas
            for(int column=0;column<3;column++)
            {
                if(grid[0,column]==player&&grid[1,column]==player&&grid[2,column]==player)
                {
                    return true;
                }    
            }

            if(grid[0,0]==player&&grid[1,1]==player&&grid[2,2]==player)
            {
                return true;
            }

            if(grid[2,0]==player&&grid[1,1]==player&&grid[0,2]==player)
            {
                return true;
            }
            return false;
        }
    }
}