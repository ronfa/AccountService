namespace Banking.Services.Resources
{
    public class AddTransactionResponse : BaseResponse
    {
        public TransactionResource Transaction { get; private set; }

        private AddTransactionResponse(bool success, string message, TransactionResource transaction) : base(success, message)
        {
            Transaction = transaction;
        }

        public AddTransactionResponse(TransactionResource transaction) : this(true, string.Empty, transaction)
        { }

        public AddTransactionResponse(string message) : this(false, message, null)
        { }
    }
}
