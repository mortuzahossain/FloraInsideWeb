namespace FloraWeb.Entity
{
    public class CommonResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMsg { get; set; }
        public string ResponseUserMsg { get; set; }
        public object ResponseData { get; set; }
    }
}