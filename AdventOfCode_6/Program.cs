using System;
using System.Collections.Generic;

// based on http://adventofcode.com/day/6
// this handles parts one and two at the same time

namespace AdventOfCode_6
{
    public class Program
    {

        // main program, build a command list from inputs, use that to populate a 3d array of lights, then report the results
        public static void Main(string[] args)
        {
            parseFile(Constants.inputFileName);
            Console.ReadKey();
        }

        // this function is really just an intermediary that allows testing on non-static filenames
        public static int[] parseFile(String fileName)
        {
            int[] numLights = sumTotalLights(processCommands(PopulateList.getData(fileName)));
            return numLights;
        }

        // builds a 3d array and reads through the command list
        private static int[,,] processCommands(List<Command> commands)
        {
            int[,,] lights = new int[2, Constants.xGridLength, Constants.yGridLength];

            foreach (var item in commands)
                iterate(item.getXstart(), item.getYstart(), item.getXend(), item.getYend(), lights, item.getCommand());

            return lights;
        }

        // modifies the given array depending on the commands given
        private static void iterate(int x_start, int y_start, int x_end, int y_end, int[,,] lights, String command)
        {
            for (int x = x_start; x <= x_end; x++)
            {
                for (int y = y_start; y <= y_end; y++)
                {
                    switch (command)
                    {
                        case ("on"):
                            lights[0, x, y] = 1;
                            lights[1,x, y] += 1;
                            break;
                        case ("off"):
                            lights[0, x, y] = 0;
                            if (lights[1, x, y] > 0)
                                lights[1, x, y] -= 1;
                            break;
                        case ("toggle"):
                            lights[0, x, y] = (int)(lights[0, x, y]^1);
                            lights[1, x, y] += 2;
                            break;
                        default:
                            break; // do nothing
                    }
                }
            }
        }

        // walks through each array and counts the sum of lights per instructions for each part of the question
        private static int[] sumTotalLights(int[,,] lights)
        {
            int[] numLights = { 0, 0 };

            for (int x = 0; x < Constants.xGridLength; x++)
                for (int y = 0; y < Constants.yGridLength; y++)
                {
                    numLights[0] += lights[0, x, y];
                    numLights[1] += lights[1, x, y];
                }

            Console.WriteLine("The total number of lights switched on at the end of part 1 is {0}.", numLights[0].ToString("N0"));
            Console.WriteLine("The total brightness for all lights at the end of part 2 is {0}.", numLights[1].ToString("N0"));

            return numLights;
        }
    }
}
