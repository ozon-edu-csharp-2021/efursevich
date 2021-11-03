namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseRequestCreationModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MerchPackageType  { get; }
        public int ClothingSize { get; }
        public MerchandiseRequestCreationModel(string firstName, string lastName, string merchPackageType, int clothingSize)
        {
            FirstName = firstName;
            LastName = lastName;
            MerchPackageType = merchPackageType;
            ClothingSize = clothingSize;
        }
    }
}