using System.Text.RegularExpressions;
const string pattern = @"\D+";
var input = File.ReadAllLines("./input.txt");
var navigationCoordinates = new List<(int, int)> { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
var partNumbers = new List<int>();

for (int i = 0; i < input.Length; i++)
{
    var numbers = Regex.Split(input[i], pattern);
    var index = -1;
    foreach (var number in numbers)
    {
        index = GetIndexOf(number, i, index);
        if (IncludePartNumber(number, index, i))
        {
            partNumbers.Add(int.Parse(number));
        }
    }
}

int GetIndexOf(string number, int rowNumber, int indexOffset)
{
    return input[rowNumber].IndexOf(number, indexOffset + 1, StringComparison.InvariantCultureIgnoreCase);

}

bool IncludePartNumber(string number, int indexX, int y)
{
    if (!string.IsNullOrEmpty(number))
    {
        for (int i = 0; i < number.Length; i++)
        {
            foreach (var coordinate in navigationCoordinates)
            {
                if (indexX + coordinate.Item1 >= 0 && y + coordinate.Item2 >= 0 &&
                    indexX + coordinate.Item1 < input[0].Length && y + coordinate.Item2 < input.Length)
                {
                    var t = input[y + coordinate.Item2][indexX + coordinate.Item1];
                    if (t != '.' && !Char.IsDigit(t))
                    {
                        return true;
                    }
                }
            }
            indexX++;
        }
    }
    return false;
}

Console.WriteLine(partNumbers.Sum());