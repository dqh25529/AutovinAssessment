// See https://aka.ms/new-console-template for more information
using Assessments;
//Create a bank
Bank myBank = new Bank("Dawn's Bank", "My test bank");
//add some accounts
string jsCheckingId = myBank.AddAccount("Jane Smith", AccountTypes.Checking);
Console.WriteLine("Jane Smith's Checking account ID: " + jsCheckingId);
string jsInvestmentId = myBank.AddAccount("Jane Smith", AccountTypes.Investment, InvestmentTypes.Individual);
Console.WriteLine("Jane Smith's Investment account ID: " + jsInvestmentId);
string ffInvestmentId = myBank.AddAccount("Fred Freeman", AccountTypes.Investment, InvestmentTypes.Individual);
Console.WriteLine("Fred Freeman's Investment account ID: " + ffInvestmentId);
string jrInvestmentId = myBank.AddAccount("James's Retirement", AccountTypes.Investment, InvestmentTypes.Corporate);
Console.WriteLine("James's Retirement account ID: " + jrInvestmentId);

//deposit some amount to each account
decimal jsCheckingAmount = myBank.Deposit(jsCheckingId, 500.00m);
Console.WriteLine("Jane Smith deposits to cheking account: " + jsCheckingId + " $" + jsCheckingAmount);
decimal jsInvestmentAmount = myBank.Deposit(jsInvestmentId, 800.00m);
Console.WriteLine("Jane Smith deposits to individual investment account: " + jsInvestmentId + " $" + jsInvestmentAmount);
decimal ffDepositAmount = myBank.Deposit(ffInvestmentId, 1000.00m);
Console.WriteLine("Fred Freeman deposits to individual investment account: " + jsInvestmentId + " $" + ffDepositAmount);
decimal jrDepositAmount = myBank.Deposit(jrInvestmentId, 2000.00m);
Console.WriteLine("James's Retirement deposits to corporate investment account: " + jsInvestmentId + " $" + jrDepositAmount);

//negative deposit
decimal jsNegativeAmount = myBank.Deposit(jsCheckingId, -100.00m);
Console.WriteLine("Jane Smith deposits negative to cheking account: " + jsCheckingId + " $" + jsNegativeAmount);

//Withdraw
decimal jsWithdrawFromChecking = myBank.Withdaw(jsCheckingId, 100.00m);
Console.WriteLine("Jane Smith withdras from cheking account: " + jsCheckingId + " $" + jsWithdrawFromChecking);
//Withdraw negative
decimal jsWithdrawNegative = myBank.Withdaw(jsCheckingId, -100.00m);
Console.WriteLine("Jane Smith withdraws negative from cheking account: " + jsCheckingId + " $" + jsWithdrawNegative);
//Withdraw over amount
decimal jsWithdrawOver = myBank.Withdaw(jsCheckingId, 500.00m);
Console.WriteLine("Jane Smith withdraws over amount from cheking account: " + jsCheckingId + " $" + jsWithdrawOver);
//Investment individual withdraw more than $500
decimal jsWithdrawFromInvestment = myBank.Withdaw(jsInvestmentId, 550.00m);
Console.WriteLine("Jane Smith withdraws from cheking account: " + jsCheckingId + " $" + jsWithdrawFromInvestment);

//Transfer
//From the same owner
decimal jsTransfer = myBank.Transfer(jsCheckingId, jsInvestmentId, 100.00m);
Console.WriteLine("Jane Smith transfers amount: " + " $" + jsTransfer  + " from checking "+ jsCheckingId + " to investment " + jsInvestmentId);
//From the diff owner
decimal jrTojs = myBank.Transfer(jrInvestmentId, jsInvestmentId, 200.00m);
Console.WriteLine("James's Retirement transfers amount: " + " $" + jrTojs + " from accountg " + jrInvestmentId + " to account " + jsInvestmentId);
//transfer to invalid account
decimal jrTojsInvalid = myBank.Transfer(jrInvestmentId, "test 123 Account", 200.00m);
Console.WriteLine("James's Retirement transfers amount: " + " $" + jrTojsInvalid + " from accountg " + jrInvestmentId + " to account " + "test 123 Account");

