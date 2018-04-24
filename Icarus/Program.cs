using System;
using System.Collections.Generic;
using System.Linq;

namespace Icarus
{
    class Program
    {


        static void Main(string[] args)
        {

            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            var startingPosition = int.Parse(Console.ReadLine());
            var damage = 1;

            var input = Console.ReadLine();

            while (!input.Equals("Supernova"))
            {
                var tokens = input.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                var direction = tokens[0];
                var steps = int.Parse(tokens[1]);


                switch (direction)
                {
                    case "left":
                        if (startingPosition - steps >= 0)
                        {
                            for (int i = 0; i < steps; i++)
                            {
                                sequence[startingPosition - 1] -= damage;
                                startingPosition--;
                            }
                        }

                        else
                        {
                            while (steps > 0)
                            {
                                startingPosition--;
                                if (startingPosition < 0)
                                {
                                    damage++;
                                    startingPosition = sequence.Count - 1;
                                }

                                sequence[startingPosition] -= damage;
                                steps--;
                            }

                           
                        }

                        break;

                    case "right":

                        if (startingPosition + steps <= sequence.Count - 1)
                        {
                            for (int i = 0; i < steps; i++)
                            {
                                sequence[startingPosition + 1] -= damage;
                                startingPosition++;
                            }

                        }

                        else
                        {
                            while (steps > 0)
                            {
                                startingPosition++;

                                if (startingPosition > sequence.Count - 1)
                                {
                                    damage++;
                                    startingPosition = 0;
                                }
                            }
                            sequence[startingPosition] -= damage;
                            steps--;
                            break;
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

    }
}

