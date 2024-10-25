namespace BE_072024.WebAspNetCoreMVC.Models
{
    public class LoginRequestData
    {
      public string UserName { get; set; }
      public string PassWord { get; set; }
    }

    public class ReturnData
    {
        public int ResponseCode { get; set; }
        public string ResponseMes { get; set; }
    }

    public class LoginResponseData: ReturnData
    {
        public string token { get; set; }
    }
}
