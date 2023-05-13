using System.Text.RegularExpressions;

namespace CompanyEmployee.Business.Helpers;

public static class Extensions
{
    public static bool IsOnlyLetters(this string word)
    {
        return Regex.IsMatch(word, @"^[a-zA-Z]+$");
    }
}
