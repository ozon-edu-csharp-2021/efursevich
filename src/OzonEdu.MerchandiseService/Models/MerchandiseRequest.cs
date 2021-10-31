namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseRequest
    {
        public MerchandiseRequest(long id, string status, int size)
        {
            Id = id;
            Status = status;
            Size = size;
        }
        public long Id { get; }
        public string Status { get; }
        public int Size { get; }
    }
}