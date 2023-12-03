using System.Text.RegularExpressions;
const string pattern = @"\D+";
var input = File.ReadAllLines("./input.txt");
var gearRatios = new List<int>();

for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        if (input[i][j] == '*')
        {
            FindAdjacentPartNumbers(j,i);
        }
    }
}
Console.WriteLine(gearRatios.Sum());

void FindAdjacentPartNumbers(int x, int y)
{
    var topRow = input[y-1].Substring(x-3, 7);
    var middleRow = input[y].Substring(x-3, 7);
    var bottomRow = input[y + 1].Substring(x-3, 7);

    topRow = StripIncompleteNumbers(topRow);
    middleRow= StripIncompleteNumbers(middleRow);
    bottomRow = StripIncompleteNumbers(bottomRow);

    var topNumbers = Regex.Split(topRow, pattern);
    var middleNumbers = Regex.Split(middleRow, pattern);
    var bottomNumbers = Regex.Split(bottomRow, pattern);

    List<string> list = new List<string>();
    list.AddRange(topNumbers);
    list.AddRange(middleNumbers);
    list.AddRange(bottomNumbers);

    if (list.Count(f => !string.IsNullOrEmpty(f)) == 2)
    {
        var gearRatio = list.Where(g => !string.IsNullOrEmpty(g)).Select(int.Parse).Aggregate(1,(acc, val) => acc * val);
        gearRatios.Add(gearRatio);
    }
}

string StripIncompleteNumbers(string rowNumbers)
{
    var returnRow = rowNumbers;
    if (rowNumbers[1] == '.')
    {
        char[] returnRowChars = returnRow.ToCharArray();
        returnRowChars[0] = '.';
        returnRow = new string(returnRowChars);
    }
    if (rowNumbers[2] == '.')
    {
        char[] returnRowChars = returnRow.ToCharArray();
        returnRowChars[0] = '.';
        returnRowChars[1] = '.';
        returnRow = new string(returnRowChars);
    }
    if (rowNumbers[5] == '.')
    {
        char[] returnRowChars = returnRow.ToCharArray();
        returnRowChars[6] = '.';
        returnRow = new string(returnRowChars);
    }
    if (rowNumbers[4] == '.')
    {
        char[] returnRowChars = returnRow.ToCharArray();
        returnRowChars[5] = '.';
        returnRowChars[6] = '.';
        returnRow = new string(returnRowChars);
    }
    return returnRow;
}


