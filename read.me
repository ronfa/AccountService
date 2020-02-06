# Account Service

The account service is a simple .NET core webapi simulating an accounting system.

  - The API exposes an 3 endpoint to retrieve customer / account / transaction data
  - The API exposes an endpoint for adding a new account for an existing customer
  - The API exposes an endpoint for adding a transaction for an existing account
 
# Notes
 
  - An in-memory db is used, with data already populated (3 customers, each with several accounts)
  - Basic unit tests were put in place to test the controllers

# How to run
 
  - Open the solution file in visual studio
  - Hit F5 (or run), the "AccountService" webapi project is already selected as startup project
  - A browser windnow will show, already calling the /api/customer/1 GET endpoint
  - You can then use Postman to make a POST call (postman collection can be found in the "postman" folder) 

# Examples
Here are several examples for api endpoints:

#### Get Customer
Returns all details about a customer with id 1. This includes all accounts, balances and transactions
```sh
GET /api/customer/1

Response:
{
    "id": 1,
    "name": "John",
    "surname": "Bryan",
    "accounts": [
        {
            "id": 1,
            "customerId": 1,
            "transactions": [
                {
                    "id": 1,
                    "accountId": 1,
                    "amount": 2.55,
                    "timestamp": "2020-02-06T20:25:28.6191343Z",
                    "description": "Monthly Credit"
                },
                {
                    "id": 2,
                    "accountId": 1,
                    "amount": 50.21,
                    "timestamp": "2020-01-27T20:25:28.6195365Z",
                    "description": "Transaction ref: 458711"
                },
                {
                    "id": 3,
                    "accountId": 1,
                    "amount": -20.61,
                    "timestamp": "2019-12-18T13:45:28.619589Z",
                    "description": "Starbucks Schiphol"
                }
            ],
            "balance": 32.15
        },
        {
            "id": 2,
            "customerId": 1,
            "transactions": [
                {
                    "id": 4,
                    "accountId": 2,
                    "amount": 450,
                    "timestamp": "2020-02-06T20:25:28.6195985Z",
                    "description": "ABN Credit"
                },
                {
                    "id": 5,
                    "accountId": 2,
                    "amount": -2.21,
                    "timestamp": "2020-01-17T20:25:28.6195989Z",
                    "description": "NS Trains"
                },
                {
                    "id": 6,
                    "accountId": 2,
                    "amount": -330.61,
                    "timestamp": "2019-10-19T20:25:28.6195989Z",
                    "description": "Intertoys"
                }
            ],
            "balance": 117.18
        }
    ],
    "balance": 149.33
}
```

#### Get Account
Returns account details transactions
```sh
GET /api/account/1

Response:
{
    "id": 1,
    "customerId": 1,
    "transactions": [
        {
            "id": 1,
            "accountId": 1,
            "amount": 2.55,
            "timestamp": "2020-02-06T20:25:28.6191343Z",
            "description": "Monthly Credit"
        },
        {
            "id": 2,
            "accountId": 1,
            "amount": 50.21,
            "timestamp": "2020-01-27T20:25:28.6195365Z",
            "description": "Transaction ref: 458711"
        },
        {
            "id": 3,
            "accountId": 1,
            "amount": -20.61,
            "timestamp": "2019-12-18T13:45:28.619589Z",
            "description": "Starbucks Schiphol"
        }
    ],
    "balance": 32.15
}
```

#### Get Transaction
Returns details about a single transaction
```sh
GET /api/transaction/1

Response:
{
    "id": 1,
    "accountId": 1,
    "amount": 2.55,
    "timestamp": "2020-02-06T20:25:28.6191343Z",
    "description": "Monthly Credit"
}
```

#### Add Account to existing customer
Adds an account to existing customer, with an option for initial credit
```sh
POST /api/account
Body:
{
	"CustomerId": 1,
	"InitialCredit": 30.00
}
```

Response:
```sh
{
    "id": 6,
    "customerId": 1,
    "transactions": [
        {
            "id": 14,
            "accountId": 6,
            "amount": 30,
            "timestamp": "2020-02-06T20:33:38.323937Z",
            "description": "Initial credit topup"
        }
    ],
    "balance": 30
}
```

#### Add transaction to existing account
Adds an account to existing customer, with an option for initial credit
```sh
POST /api/transaction
Body:
{
	"AccountId": 1,
	"Amount": 30.00,
	"Description": "Top up",
	"Amount": 30.00,
	"Timestamp": "2020-02-06T20:33:38.323937Z"
}
```

Response:
```sh
{
    "id": 14,
    "accountId": 1,
    "amount": 30,
    "timestamp": "2020-02-06T20:33:38.323937Z",
    "description": "Top up"
}
```