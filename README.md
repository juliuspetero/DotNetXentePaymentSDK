# Official Xente Payment REST SDK for .Net

## Installation

### Ways of installing the SDK

> 1. Using Visual IDE
>    On the Nuget Package Manager navigate to Browse Tab and key in XentePaymentSDK.Net
>    Select the latest version and click installed
> 2. Using .Net CLI
>    dotnet add package XentePaymentSDK.Net --version versionNumber
> 3. Using Nuget Package Manager Console
>    Install-Package xenteSDK.Net -Version versionNumber

## Usage

To write an application using the SDK

- Register for a developer account and get your apikey at [Xente Developer Portal](http://sandbox.developers.xente.co/).

- To use this package ensure you add the following using statement to your project file:

  ```
  using XentePaymentSDK.Net;
  ```

- The package neeeds to be configured with your Xente's Apikey and password

These are your authentication credentials or details,it is better to keep it safe

```
string apikey = "2E3B75363AD845478C457C11948A4F60";

string password = "syfa1524729jy";

Mode mode = Mode.Sandbox // or Mode.Production

```

- Initialized Xente class with your authentication credentials

  ```
  Xente xentePaymentGateWay = new XentePayment(apikey, password, mode);
  ```

- Create a transaction information with the following required parameters. The Metadata is optional property


            TransactionRequest transactionRequest = new TransactionRequest
            {
                PaymentProvider = "MTNMOBILEMONEYUG",
                Amount = "800",
                Message = "Loan payment",
                CustomerId = "256778418592",
                CustomerPhone = "256778418592",
                CustomerEmail = "juliuspetero@outlook.com",
                CustomerReference = "256778418592",
                BatchId = "Batch001",
                RequestId = Guid.NewGuid().ToString().Replace("-", string.Empty),
                Metadata = "extra information about transaction"
            };

- Create transaction and handle exception in case of any
  You will get an object of type TransactionProcessingResponse
  From which you extract the following properties

  > 1. Message
  > 2. Code
  > 3. Data
  > 4. CorrelationId

  > Data contains the following properties

  > 1. RequestId
  > 2. BatchId
  > 3. TransactionId
  > 4. Message
  > 5. CreatedOn

```
try
{
TransactionProcessingResponse transactionProcessingResponse = await xentePaymentGateway.Transactions.CreateTransaction(transactionRequest);
Console.WriteLine(transactionProcessingResponse.Message);
}
catch (Exception ex)
{
// Handling the exception appropriately, you can log it to a file, database etc.
throw new XenteException(ex.Message);
}

```

- Get Transaction Details with a specific transaction Id
  The object obtains from this command is similar with the one for Create Transaction
  The transaction Id comes from Xente Payment after every transaction

```
string transactionId = '9F38AB020C394EA5BC642C25A5CB16BF-256784378515';
try
{
TransactionDetailsResponse transactionDetailsResponse = xentePaymentGateway.Transactions.GetTransactionDetailsById
(transactionId);
Console.WriteLine(transactionDetailsResults.Message);
}
catch(Exception ex)
{
throw new XenteException(ex.Message);
}
```

- Get Transaction Details with a specific Request Id
  The object obtains from this command is similar with the one GetTransactionDetailsById
  The request Id is set by the user for every transaction

```
string requestId = "ajshsdget3635fwftw";
try
{
TransactionDetailsResponse transactionDetailsResponse = xentePaymentGateway.Transactions.GetTransactionDetailsByRequestId
(requestId);
Console.WriteLine(transactionDetailsResponse.Message);
}
catch(Exception ex)
{
throw new XenteException(ex.Message);
}

```

- List all Payment providers
  You get the lists of all the payment providers and their details

  On performing the operation, you get an object of type PaymentProvidersResponse which contains the following properties

  > 1. Message
  > 2. Code
  > 3. Data
  > 4. CorrelationId

  > Data contains the following properties

  > 1.  CurrentPage
  > 2.  PageSize
  > 3.  TotalPages
  > 4.  PreviousPage
  > 5.  NextPage

  > Collection has the following properties describing each payment provider

  > 1. PaymentId
  > 2. ImageUri
  > 3. Name
  > 4. Category
  > 5. ShortDescription
  > 6. LongDescription
  > 7. CountryCode
  > 8. CurrencyCode
  > 9. IsDeleted
  > 10. IsActive
  > 11. IsExternal

```
try
{
PaymentProvidersResponse paymentProvidersResponse = await xentePaymentGateWay.PaymentProviders.GetPaymentProviders();
foreach (PaymentProviderResponse paymentProviderResponse in paymentProvidersResponse.Data.Collection)
{
Console.WriteLine("Payment Provider with ID = {0}", paymentProviderResponse.PaymentId);
}
}
catch(Exception ex)
{
throw new XenteException();
}

```

- Get Account Details with a specific accountId
  You can retrieve your account details with your phone number as your accountId
  On performing the operation, you get an object of type AccountResponse which contains the following properties

  > 1. Message
  > 2. Code
  > 3. Data
  > 4. CorrelationId

  > Data contains the following properties

  > 1. CreatedOn
  > 2. ModifiedOn
  > 3. AccountId
  > 4. SubscriptionId
  > 5. AccountType
  > 6. CurrencyCode
  > 7. CountryCode
  > 8. AccountStatus
  > 9. Name
  > 10. ShortDescription
  > 11. LongDescription
  > 12. AlertLevel
  > 13. AlertChannel
  > 14. AlertEmailAddress
  > 15. AlertPhoneNumber
  > 16. CallBackUri
  > 17. Balance
  > 18. AccountPackage

```
string accountId = "2567783765366";

try
{
AccountResponse accountResponse = xentePaymentGateWay.Accounts.GetAccountDetailsById(accountId);
Console.WriteLine(accountResponse.Message);
}
catch(Exception ex)
{
throw new XenteException(ex.Message);
}

```

## Contributions

- If you would like to contribute, please fork the repo and send in a pull request.

### Refactory Team Xente

> 1. Olive Nakiyemba
> 2. Kintu Declan Trevor
> 3. Oketayot Julius Peter
