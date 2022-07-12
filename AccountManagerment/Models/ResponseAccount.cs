namespace AccountManagerment.Models
{
    public class ResponseAccount
    {
        public string status { get; set; }
        public List<Account> data { get; set; }
        public string message { get; set; }
    }
}
