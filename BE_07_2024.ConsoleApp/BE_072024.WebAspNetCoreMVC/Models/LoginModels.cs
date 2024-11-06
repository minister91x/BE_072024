namespace BE_072024.WebAspNetCoreMVC.Models
{
    public class LoginRequestData
    {
      public string? UserName { get; set; }
      public string? PassWord { get; set; }
    }

    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string? ReturnMessage { get; set; }
    }

    public class LoginResponseData: ReturnData
    {
      
        public string? token { get; set; }
    }
}
