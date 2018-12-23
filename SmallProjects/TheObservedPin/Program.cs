using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
Alright, detective, one of our colleagues successfully observed our target person, Robby the robber. We followed him to a secret warehouse, where we assume to find all the stolen stuff. The door to this warehouse is secured by an electronic combination lock. Unfortunately our spy isn't sure about the PIN he saw, when Robby entered it.

The keypad has the following layout:

┌───┬───┬───┐
│ 1 │ 2 │ 3 │
├───┼───┼───┤
│ 4 │ 5 │ 6 │
├───┼───┼───┤
│ 7 │ 8 │ 9 │
└───┼───┼───┘
    │ 0 │
    └───┘
He noted the PIN 1357, but he also said, it is possible that each of the digits he saw could actually be another adjacent digit (horizontally or vertically, but not diagonally). E.g. instead of the 1 it could also be the 2 or 4. And instead of the 5 it could also be the 2, 4, 6 or 8.

He also mentioned, he knows this kind of locks. You can enter an unlimited amount of wrong PINs, they never finally lock the system or sound the alarm. That's why we can try out all possible (*) variations.

* possible in sense of: the observed PIN itself and all variations considering the adjacent digits

Can you help us to find all those variations? It would be nice to have a function, that returns an array (or a list in Java) of all variations for an observed PIN with a length of 1 to 8 digits. We could name the function getPINs (get_pins in python). But please note that all PINs, the observed one and also the results, must be strings, because of potentially leading '0's. We already prepared some test cases for you.

Detective, we count on you!
 **/

//TO-DO shorten it by using .aggregate() LINQ
namespace TheObservedPin
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GetPINs("1234"))
                Console.WriteLine(item);

            Console.ReadKey();
        }

        public static List<string> GetPINs(string observed)
        {
            List<string> possiblePins = new List<string>();
            List<List<string>> possibilities = new List<List<string>>();

            foreach (char x in observed) possibilities.Add(Possible(x));

            int howMuch = possibilities.Count;
            int howMuchTwo = 1;

            foreach (var item in possibilities)
            {
                howMuchTwo *= item.Count;
            }

            int[] pointers = new int[howMuch];
            int[] StaticPointers = new int[howMuch];



            for (int i = 0; i < howMuch; i++)
            {
                pointers[i] = 0;
                StaticPointers[i] = possibilities[i].Count;
            }


            for (int ix = 0; ix < howMuchTwo; ix++)
            {
                string tmp = "";

                for (int i = 0; i < howMuch; i++)
                    tmp += possibilities[i].ElementAt(pointers[i]);

                pointers[howMuch - 1]++;

                for (int i = pointers.Length - 1; i > 0; i--)
                {

                    if (pointers[i] == StaticPointers[i])
                    {
                        pointers[i] = 0;
                        pointers[i - 1]++;
                    }


                }

                possiblePins.Add(tmp);
                //Console.WriteLine(tmp);
            }
            //Console.WriteLine("{0} / {1}", possiblePins.Count, howMuchTwo);
            return possiblePins;
        }

        public static List<string> Possible(char x)
        {
            List<string> tmp = new List<string>();
            switch (x)
            {
                case '0':
                    tmp.Add("0");
                    tmp.Add("8");
                    break;
                case '1':
                    tmp.Add("1");
                    tmp.Add("2");
                    tmp.Add("4");
                    break;
                case '2':
                    tmp.Add("1");
                    tmp.Add("2");
                    tmp.Add("3");
                    tmp.Add("5");
                    break;
                case '3':
                    tmp.Add("2");
                    tmp.Add("3");
                    tmp.Add("6");
                    break;
                case '4':
                    tmp.Add("1");
                    tmp.Add("4");
                    tmp.Add("5");
                    tmp.Add("7");
                    break;
                case '5':
                    tmp.Add("2");
                    tmp.Add("4");
                    tmp.Add("5");
                    tmp.Add("6");
                    tmp.Add("8");
                    break;
                case '6':
                    tmp.Add("3");
                    tmp.Add("5");
                    tmp.Add("6");
                    tmp.Add("9");
                    break;
                case '7':
                    tmp.Add("4");
                    tmp.Add("7");
                    tmp.Add("8");
                    break;
                case '8':
                    tmp.Add("5");
                    tmp.Add("7");
                    tmp.Add("8");
                    tmp.Add("9");
                    tmp.Add("0");
                    break;
                case '9':
                    tmp.Add("6");
                    tmp.Add("9");
                    tmp.Add("8");
                    break;
            }
            return tmp;
        }
    }
}
