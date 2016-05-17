using System;
using System.Collections.Generic;
using System.IO;

internal class PopulateList
{
	public PopulateList()
	{
	}

    // Reads from a text file and populates a list of string arrays based on a split
    // as defined in the question. If the inputs are malformed in some manner there 
    // is no attempt to recover -- just report an exception and quit.

    internal static List<Command> getData(String fileName)
    {
        FileStream inputFile = null;
        StreamReader inputLine = null;
        List<Command> commandList = new List<Command>();

        try
        {
            inputFile = new FileStream(fileName, FileMode.Open);
            inputLine = new StreamReader(inputFile);
            String rawInputText;
            String[] splitInput = null;

            while ((rawInputText = inputLine.ReadLine()) != null)
            {
                splitInput = rawInputText.Split(' ', ',');

                if (splitInput.Length == 6)
                    commandList.Add(new Command("toggle",
                        Convert.ToInt32(splitInput[1]),
                        Convert.ToInt32(splitInput[2]),
                        Convert.ToInt32(splitInput[4]),
                        Convert.ToInt32(splitInput[5])));
                else if (splitInput.Length == 7)
                    commandList.Add(new Command(splitInput[1],
                        Convert.ToInt32(splitInput[2]),
                        Convert.ToInt32(splitInput[3]),
                        Convert.ToInt32(splitInput[5]),
                        Convert.ToInt32(splitInput[6])));
            }
        }

        catch (IOException e)
        {
            Console.WriteLine("Cannot open file: " + e.Message + ".");
            throw e;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: Input file is malformed.");
            throw e;
        }

        finally
        {
            if (inputFile != null) inputFile.Close();
            if (inputLine != null) inputLine.Close();
        }

        return commandList;
    }
}