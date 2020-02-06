namespace Banking.Services.Resources
{
    public class AddAccountResponse : BaseResponse
    {
        public AccountResource Account { get; private set; }

        private AddAccountResponse(bool success, string message, AccountResource account) : base(success, message)
        {
            Account = account;
        }

        public AddAccountResponse(AccountResource account) : this(true, string.Empty, account)
        { }

        public AddAccountResponse(string message) : this(false, message, null)
        { }
    }
}
