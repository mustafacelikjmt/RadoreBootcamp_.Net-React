namespace Radore.Services.ProductAPI.Models
{
    public class HubMessageModel
    {
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public bool IsRead { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string Time => TimeStamp.ToString("HH:mm:ss");
    }
}