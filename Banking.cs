using System;

namespace Banking;

public class Account(string? name, string? accountNumber, decimal initialBalance = 0m)
{
    public string Name { get; } = ValidateString(name, nameof(name));

    public string AccountNumber { get; } = ValidateString(accountNumber, nameof(accountNumber));

    public decimal Balance { get; private set; } = ValidateInitialBalance(initialBalance);

    public void Deposit(decimal amount)
    {
        if (amount <= 0m)
        {
            throw new InvalidAccountOperationException(
                "Deposit amount must be greater than zero.");
        }

        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0m)
        {
            throw new InvalidAccountOperationException(
                "Withdrawal amount must be greater than zero.");
        }

        if (amount > Balance)
        {
            return false;
        }

        Balance -= amount;
        return true;
    }

    private static string ValidateString(string value, string paramName) =>
        !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new InvalidAccountDataException(
                $"'{paramName}' cannot be null, empty, or whitespace.");

    private static decimal ValidateInitialBalance(decimal initialBalance) =>
        initialBalance >= 0m
            ? initialBalance
            : throw new ArgumentOutOfRangeException(
                nameof(initialBalance),
                "Initial balance cannot be negative.");
}

public class InvalidAccountDataException : Exception
{
    public InvalidAccountDataException() { }
    public InvalidAccountDataException(string message) : base(message) { }
    public InvalidAccountDataException(string message, Exception innerException)
        : base(message, innerException) { }
}

public class InvalidAccountOperationException : Exception
{
    public InvalidAccountOperationException() { }
    public InvalidAccountOperationException(string message) : base(message) { }
    public InvalidAccountOperationException(string message, Exception innerException)
        : base(message, innerException) { }
}