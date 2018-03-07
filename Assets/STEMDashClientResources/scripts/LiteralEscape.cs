using System;

class LiteralEscape
{
    public string escapeCharacter(string text, char character)
    {
        string escapedString = "";
        string escChar = "";
        bool validChar = true;
        switch(character)
        {
            case '\"':
                escChar = "\\\"";
                break;
            case '\\':
                escChar = "\\\\";
                break;
            default:
                escapedString = text;
                validChar = false;
                break;
        }
        if (validChar)
        {
            string[] parsedString = text.Split(character);
            if (parsedString.Length > 0)
            {
                for (int i = 0; i < parsedString.Length; i++)
                {
                    Console.WriteLine("Split text: " + parsedString[i]);
                    if (i != parsedString.Length - 1)
                        parsedString[i] = (parsedString[i] + escChar);
                    escapedString += parsedString[i];
                }
            }
        }
        return escapedString; 
    }
}
