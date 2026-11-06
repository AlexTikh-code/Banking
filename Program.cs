using Banking;

try
{
    Account accountInvalid = new Account("Jane Doe", "654321", -500m);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Error creating account: {ex.Message}");
}

try
{
    Account accountEmpty = new Account("", "123456", 1000m);
}
catch (InvalidAccountDataException ex)
{
    Console.WriteLine($"Error creating account: {ex.Message}");
}

try
{
    Account accountNull = new Account("Jane Doe", null, 1000m);
}
catch (InvalidAccountDataException ex)
{
    Console.WriteLine($"Error creating account: {ex.Message}");
}

Account accountDefault = new Account("John Doe", "123456");
ShowAccount(accountDefault);


Account account = new Account("John Doe", "123456", 1000m);
ShowAccount(account);

account.Deposit(500m);
ShowAccount(account);

try
{
    account.Deposit(-500m);
}
catch (InvalidAccountOperationException ex)
{
    Console.WriteLine($"Error depositing funds: {ex.Message}");
}
ShowAccount(account);

account.Withdraw(200m);
ShowAccount(account);

try
{
    account.Withdraw(-200m);
}
catch (InvalidAccountOperationException ex)
{
    Console.WriteLine($"Error withdrawing funds: {ex.Message}");
}   
ShowAccount(account);

bool isWithdrawn = account.Withdraw(2000m);
if (isWithdrawn )
{
    Console.WriteLine("Funds withdrawn successfully.");
}
else
{
    Console.WriteLine("Insufficient funds for withdrawal.");
}
ShowAccount(account);

static void ShowAccount(Account? account)
{
    if (account is null)                
    {
        return;
    }

    Console.WriteLine($"Account created: {account.Name}, {account.AccountNumber}, {account.Balance}");
}