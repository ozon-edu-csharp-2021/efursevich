namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseRequestCreationModel
    {
        public MerchandiseRequestCreationModel(int size)
        {
            Size = size;
        }
        public int Size { get; }
    }
}