using System;
using System.Linq;
using System.Threading.Tasks; // Thread.sleep() can be used for lowering fps
using CmdGraphicLibrary; //Library that I wrote it's uploaded on github github.com/jardee

namespace CMDTicTacToe
{
        //Main
        class Program
        {
            static void Main(string[] args)
            {
                new TicTacToeGame().Start();
            }
        }

        class TicTacToeGame
        {
            #region Variables

            CmdGraphic _canvas = new CmdGraphic(20, 40);
            Scenes _actualScene = Scenes.Menu;
            Coordinates _pointer = new Coordinates { x = 0, y = 1 };
            char _pointerChar = '>';
            bool _lockX = true;
            bool _lockY = false;
            bool _drawCursor = true;
            Cell[] _board = new Cell[9];
            char _player = 'x';

            #endregion

            //Constructor
            public TicTacToeGame()
            {
                InitializeBoard();
            }

            //Initial point and main game loop
            public void Start()
            {
                //hide prompt
                Console.CursorVisible = false;

                //game loop
                while (true)
                {
                    //Catch pressed keys
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);//true don't print char on console
                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (!_lockY)
                                    _pointer.y--;
                                break;

                            case ConsoleKey.DownArrow:
                                if (!_lockY)
                                    _pointer.y++;
                                break;

                            case ConsoleKey.RightArrow:
                                if (!_lockX)
                                    _pointer.x++;
                                break;

                            case ConsoleKey.LeftArrow:
                                if (!_lockX)
                                    _pointer.x--;
                                break;

                            case ConsoleKey.N:
                                if (_actualScene == Scenes.End)
                                    InitializeMenu();
                                break;

                            case ConsoleKey.Y:
                                if (_actualScene == Scenes.End)
                                    Environment.Exit(0);
                                break;

                            case ConsoleKey.Spacebar:

                                switch (_actualScene)
                                {
                                    case Scenes.Menu:
                                        MenuLogic();
                                        break;

                                    case Scenes.Game:
                                        GameLogic();
                                        break;
                                }

                                break;

                            case ConsoleKey.Escape:
                                InitializeMenu();
                                //Restart();
                                break;

                            default:
                                break;
                        }
                    }



                    _canvas.Fill(' ');

                    //Draw actual scene
                    switch (_actualScene)
                    {
                        case Scenes.Menu:
                            DrawMenu();
                            break;
                        case Scenes.Game:
                            DrawBoard();
                            break;
                        case Scenes.Win:
                            DrawEndGame();
                            break;
                        case Scenes.About:
                            AboutScene();
                            break;
                        case Scenes.End:
                            DrawEndGame();
                            break;
                    }

                    //check if someone win or draw
                    CheckForWinner();

                //print pointer
                if (_drawCursor)
                    _canvas.DrawCharAt(_pointer.x, _pointer.y, _pointerChar);


                //redraw on screen
                Console.SetCursorPosition(0, 0);
                    Console.Write(_canvas.GetBuffer());
                }
            }

            #region GameLogic

            private void InitializeBoard()
            {
                _board[0] = new Cell() { Cords = new Coordinates() { x = 0, y = 0 }, State = States.empty, Changed = false };
                _board[1] = new Cell() { Cords = new Coordinates() { x = 5, y = 0 }, State = States.empty, Changed = false };
                _board[2] = new Cell() { Cords = new Coordinates() { x = 10, y = 0 }, State = States.empty, Changed = false };
                _board[3] = new Cell() { Cords = new Coordinates() { x = 0, y = 5 }, State = States.empty, Changed = false };
                _board[4] = new Cell() { Cords = new Coordinates() { x = 5, y = 5 }, State = States.empty, Changed = false };
                _board[5] = new Cell() { Cords = new Coordinates() { x = 10, y = 5 }, State = States.empty, Changed = false };
                _board[6] = new Cell() { Cords = new Coordinates() { x = 0, y = 10 }, State = States.empty, Changed = false };
                _board[7] = new Cell() { Cords = new Coordinates() { x = 5, y = 10 }, State = States.empty, Changed = false };
                _board[8] = new Cell() { Cords = new Coordinates() { x = 10, y = 10 }, State = States.empty, Changed = false };
            }

            private void InitializeMenu()
            {
                _pointer = new Coordinates() { x = 0, y = 1 };
                _pointerChar = '>';
                _lockX = true;
                _lockY = false;
                _drawCursor = true;
                InitializeBoard();
                _actualScene = Scenes.Menu;
            }

            private void AboutScene()
            {
                _canvas.DrawTextHorizontally(3, 2, " Gra wykonana przez Dominik B.");
                _canvas.DrawTextHorizontally(3, 3, "Na potrzeby zadania z przedmiotu");
                _canvas.DrawTextHorizontally(3, 4, "    Podstawy Programowania");
                _canvas.DrawTextHorizontally(3, 6, "         ESC to menu");
            }

            private void MenuLogic()
            {
                if (_pointer.y == 1)
                {
                    _pointerChar = 'x';
                    _lockX = false;
                    _actualScene = Scenes.Game;
                }
                else if (_pointer.y == 2)
                {
                    _lockX = true;
                    _lockY = true;
                    _drawCursor = false;
                    _actualScene = Scenes.About;
                }
                else if (_pointer.y == 3)
                {
                    _lockX = true;
                    _lockY = true;
                    _drawCursor = false;
                    _actualScene = Scenes.End;
                }
            }

            #region CheckIfCursorIsInBoundsOfSquares
            private void GameLogic()
            {
                //1
                if (_pointer.x >= 0 && _pointer.y >= 0 && _pointer.x <= 3 && _pointer.y <= 3 && !_board[0].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[0].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[0].State = States.o;
                    }

                    _board[0].Changed = true;
                }
                //2
                if (_pointer.x >= 5 && _pointer.y >= 0 && _pointer.x <= 8 && _pointer.y <= 3 && !_board[1].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[1].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[1].State = States.o;
                    }

                    _board[1].Changed = true;
                }
                //3
                if (_pointer.x >= 10 && _pointer.y >= 0 && _pointer.x <= 13 && _pointer.y <= 3 && !_board[2].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[2].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[2].State = States.o;
                    }

                    _board[2].Changed = true;
                }
                //4
                if (_pointer.x >= 0 && _pointer.y >= 5 && _pointer.x <= 3 && _pointer.y <= 8 && !_board[3].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[3].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[3].State = States.o;
                    }

                    _board[3].Changed = true;
                }
                //5
                if (_pointer.x >= 5 && _pointer.y >= 5 && _pointer.x <= 8 && _pointer.y <= 8 && !_board[4].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[4].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[4].State = States.o;
                    }

                    _board[4].Changed = true;
                }
                //6
                if (_pointer.x >= 10 && _pointer.y >= 5 && _pointer.x <= 13 && _pointer.y <= 8 && !_board[5].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[5].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[5].State = States.o;
                    }

                    _board[5].Changed = true;
                }
                //7
                if (_pointer.x >= 0 && _pointer.y >= 10 && _pointer.x <= 3 && _pointer.y <= 13 && !_board[6].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[6].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[6].State = States.o;
                    }

                    _board[6].Changed = true;
                }
                //8
                if (_pointer.x >= 5 && _pointer.y >= 10 && _pointer.x <= 8 && _pointer.y <= 13 && !_board[7].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[7].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[7].State = States.o;
                    }

                    _board[7].Changed = true;
                }
                //9
                if (_pointer.x >= 10 && _pointer.y >= 10 && _pointer.x <= 13 && _pointer.y <= 13 && !_board[8].Changed)
                {
                    if (_player == 'x')
                    {
                        _board[8].State = States.x;
                        _player = 'o';
                    }
                    else if (_player == 'o')
                    {
                        _player = 'x';
                        _board[8].State = States.o;
                    }

                    _board[8].Changed = true;
                }
            }
            #endregion

            private void DrawEndGame()
            {
                _canvas.DrawTextHorizontally(3, 2, "   Exit ?");
                _canvas.DrawTextHorizontally(3, 3, "    Y/N");
            }

            #region ConditionsToWin
            private void CheckForWinner()
            {
                if (_board[0].State == States.o && _board[1].State == States.o && _board[2].State == States.o)
                    Winner('o');
                if (_board[0].State == States.x && _board[1].State == States.x && _board[2].State == States.x)
                    Winner('x');

                if (_board[3].State == States.o && _board[4].State == States.o && _board[5].State == States.o)
                    Winner('o');
                if (_board[3].State == States.x && _board[4].State == States.x && _board[5].State == States.x)
                    Winner('x');

                if (_board[6].State == States.o && _board[7].State == States.o && _board[8].State == States.o)
                    Winner('o');
                if (_board[6].State == States.x && _board[7].State == States.x && _board[8].State == States.x)
                    Winner('x');

                if (_board[0].State == States.o && _board[3].State == States.o && _board[6].State == States.o)
                    Winner('o');
                if (_board[0].State == States.x && _board[3].State == States.x && _board[6].State == States.x)
                    Winner('x');

                if (_board[1].State == States.o && _board[4].State == States.o && _board[7].State == States.o)
                    Winner('o');
                if (_board[1].State == States.x && _board[4].State == States.x && _board[7].State == States.x)
                    Winner('x');

                if (_board[2].State == States.o && _board[5].State == States.o && _board[8].State == States.o)
                    Winner('o');
                if (_board[2].State == States.x && _board[5].State == States.x && _board[8].State == States.x)
                    Winner('x');

                if (_board[0].State == States.o && _board[4].State == States.o && _board[8].State == States.o)
                    Winner('o');
                if (_board[0].State == States.x && _board[4].State == States.x && _board[8].State == States.x)
                    Winner('x');

                if (_board[6].State == States.o && _board[4].State == States.o && _board[2].State == States.o)
                    Winner('o');
                if (_board[6].State == States.x && _board[4].State == States.x && _board[2].State == States.x)
                    Winner('x');


                if (_board.All(x => x.State != States.empty))
                {
                    _lockX = true;
                    _lockY = true;
                    _canvas.DrawTextHorizontally(0, 7, "      DRAW       ");
                    _canvas.DrawTextHorizontally(0, 8, "   ESC to menu   ");
                }


            }
            #endregion

            private void Restart()
            {
                throw new NotImplementedException();
            }

            private void PrintXAt(int x, int y)
            {
                _canvas.DrawCharAt(x, y, '\\');
                _canvas.DrawCharAt(x + 1, y + 1, '\\');
                _canvas.DrawCharAt(x + 2, y + 2, '\\');
                _canvas.DrawCharAt(x + 3, y + 3, '\\');

                _canvas.DrawCharAt(x + 3, y, '/');
                _canvas.DrawCharAt(x + 2, y + 1, '/');
                _canvas.DrawCharAt(x + 1, y + 2, '/');
                _canvas.DrawCharAt(x, y + 3, '/');
            }

            private void PrintOAt(int x, int y)
            {
                _canvas.DrawCharAt(x + 1, y, '-');
                _canvas.DrawCharAt(x + 2, y, '-');
                _canvas.DrawCharAt(x + 3, y + 1, '|');
                _canvas.DrawCharAt(x + 3, y + 2, '|');
                _canvas.DrawCharAt(x + 2, y + 3, '-');
                _canvas.DrawCharAt(x + 1, y + 3, '-');
                _canvas.DrawCharAt(x, y + 1, '|');
                _canvas.DrawCharAt(x, y + 2, '|');
            }

            private void DrawMenu()
            {
                _canvas.DrawTextHorizontally(1, 1, "Game Start!");
                _canvas.DrawTextHorizontally(1, 2, "About");
                _canvas.DrawTextHorizontally(1, 3, "Exit");

            }

            private void DrawBoard()
            {
                _canvas.DrawHorizontalLine(0, 4, 14, '-');
                _canvas.DrawHorizontalLine(0, 9, 14, '-');
                _canvas.DrawVerticalLine(4, 0, 14, '|');
                _canvas.DrawVerticalLine(9, 0, 14, '|');


                foreach (Cell x in _board)
                {
                    if (x.State == States.x)
                        PrintXAt(x.Cords.x, x.Cords.y);
                    if (x.State == States.o)
                        PrintOAt(x.Cords.x, x.Cords.y);

                }

                _canvas.DrawTextHorizontally(0, 14, "Current player: " + _player);
            }

            private void Winner(char Player)
            {

                _canvas.DrawTextHorizontally(0, 7, "   Winner: " + Player + "  ");
                _canvas.DrawTextHorizontally(0, 8, "  ESC to menu   ");
                _lockX = true;
                _lockY = true;

            }
            #endregion

            #region Structs

            enum States
            {
                x,
                o,
                empty
            }
            enum Scenes
            {
                Menu,
                Game,
                Win,
                About,
                End
            }

            struct Coordinates
            {
                public int x;
                public int y;
            }

            struct Cell
            {
                public Coordinates Cords;
                public States State;
                public bool Changed;
            }

            #endregion

        }
    }
