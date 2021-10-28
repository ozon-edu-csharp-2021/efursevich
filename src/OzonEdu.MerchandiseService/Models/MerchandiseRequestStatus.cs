namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseRequestStatus
    {
        public MerchandiseRequestStatus(string status)
        {
            Status = status;
        }
        public string Status { get; }
    }
}