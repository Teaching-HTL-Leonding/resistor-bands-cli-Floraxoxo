public class Iban
{
    private string countryCode;
    private string checksum;
    private string nationalCheck;
    public string bankCode;
    public string accountNumber;

    public string BuildIban()
    {
        string ibanCode = $"{countryCode}{checksum}{bankCode}{accountNumber}{nationalCheck}";
        return ibanCode;
    }
    public string GiveBankInfo()
    {
        string bankInfo = $"{bankCode} {accountNumber}";
        return bankInfo;
    }
    private bool CheckIfCorrectInput(string stringToCheck)
    {
        for (int i = 0; i < stringToCheck.Length; i++)
        {
            if (!Char.IsDigit(stringToCheck[i]))
            {
                return false;
            }
        }
        return true;
    }
    public Iban(string bankNumber, string accNumber)
    {
        countryCode = "NO"; checksum = "00"; nationalCheck = "7";
        if (!CheckIfCorrectInput(bankNumber)) { throw new ArgumentException("Your Bank Number contains a Letter. Please try again"); }
        else if (bankNumber.Length > 4) { throw new ArgumentException("Your Bank Number is too long. Please try again!"); }
        bankCode = bankNumber;
        if (!CheckIfCorrectInput(accNumber)) { throw new ArgumentException("Your Account Number contains a Letter. Please try again"); }
        else if (accNumber.Length > 6) { throw new ArgumentException("Your Account Number is too long. Please try again!"); }
        accountNumber = accNumber;
    }
    public Iban(string bankInfo)
    {
        countryCode = bankInfo.Substring(0, 2); bankInfo = bankInfo.Substring(2);
        if (countryCode != "NO") { throw new ArgumentException("Wrong country code. Please try again!"); }
        checksum = bankInfo.Substring(0, 2); bankInfo = bankInfo.Substring(2);
        if (checksum != "00") { throw new ArgumentException("Wrong check sum. Please try again!"); }
        bankCode = bankInfo.Substring(0, 4); bankInfo = bankInfo.Substring(4);
        if (!CheckIfCorrectInput(bankCode)) { throw new ArgumentException("Your bank code contains letters. Please try again!"); }
        accountNumber = bankInfo.Substring(0, 6);
        if (!CheckIfCorrectInput(accountNumber)) { throw new ArgumentException("Your bank account contains a letter. Please try again!"); }
        bankInfo = bankInfo.Substring(6);
        if (bankInfo != "7") { throw new ArgumentException("Wrong national check. Please try again!"); }
        bankInfo = bankInfo.Substring(1);
        if (bankInfo != "") { throw new ArgumentException("Your bank Info is too long. Please try again!"); }
        Console.WriteLine(GiveBankInfo());
    }
}