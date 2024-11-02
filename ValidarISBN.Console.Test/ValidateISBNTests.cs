using ValidadorISBN.Console;

namespace ValidarISBN.Console.Test;

public class ValidateISBNTests
{
    private readonly ValidateISBN _validateISBN;
    public ValidateISBNTests()
    {
        _validateISBN = new ValidateISBN();    
    }

    [Fact]
    public void CheckValidateISBN()
    {
        bool result = _validateISBN.CheckISBN("0140449116");
        Assert.True(result);
    }

    [Fact]
    public void CheckInvalidISBN()
    {
        bool result = _validateISBN.CheckISBN("0140441927");
        Assert.False(result);
    }

    [Fact]
    
    public void CheckISBNLengthTenOrThirteen()
    {
        Assert.Throws<FormatException>(() => _validateISBN.CheckISBN("012345678"));
    }

    [Fact]
    public void CheckISBNNumeric()
    {
        Assert.Throws<FormatException>(() => _validateISBN.CheckISBN("helloworld"));
    }

    [Fact]
    public void CheckContainsX()
    {
        bool result = _validateISBN.CheckISBN("080442957X");
        Assert.True(result);
    }

    [Fact]
    public void CheckValidThirteenDigitISBN()
    {
        bool result = _validateISBN.CheckISBN("9780306406157");
        Assert.True(result);
    }
}