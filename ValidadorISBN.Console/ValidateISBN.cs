namespace ValidadorISBN.Console;

public class ValidateISBN
{
    private const int ISBNShortLength = 10;
    private const int ISBNLongLength = 13;
    private const int ISBNShortValidator = 11;
    private const int ISBNLongValidator = 10;

    public bool CheckISBN(string isbn)
    {
        if (isbn.Length == ISBNShortLength)
            return CheckISBNTenDigits(isbn);
        else if (isbn.Length == ISBNLongLength)
            return CheckISBNThirteenDigits(isbn);
        else
            throw new FormatException("ISBN number should have length of 10 or 13.");
    }

    private bool CheckISBNTenDigits(string isbn)
    {
        int total = 0;

        for (int i = 0; i < ISBNShortLength; i++)
        {
            char currentChar = isbn[i];

            if (!char.IsDigit(currentChar) && !(i == 9 && currentChar == 'X'))
                throw new FormatException("ISBN numbers can only have digits.");
            total += (currentChar == 'X' && i == 9) ? 10 : (int)(char.GetNumericValue(currentChar) * (ISBNShortLength - i));
        }

        return total % ISBNShortValidator == 0;
    }

    private bool CheckISBNThirteenDigits(string isbn)
    {
        int total = 0;

        for (int i = 0; i < ISBNLongLength; i++)
        {
            char currentChar = isbn[i];

            if (!char.IsDigit(currentChar))
            {
                throw new FormatException("ISBN numbers can only have digits.");
            }

            total += (i % 2 == 0) ? (int)char.GetNumericValue(currentChar) : (int)(char.GetNumericValue(currentChar) * 3);
        }

        return total % ISBNLongValidator == 0;
    }
}