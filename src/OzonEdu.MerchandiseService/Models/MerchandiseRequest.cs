using System;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseRequest
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MerchPackageType  { get; }
        public int ClothingSize { get; }
        public string RequestStatus { get; }
        public DateTime CreatedAt { get; }
        public DateTime CompletedAt { get; }
        
        public MerchandiseRequest(long id, string firstName, string lastName, string merchPackageType, int clothingSize, 
            string requestStatus, DateTime createdAt, DateTime completedAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MerchPackageType = merchPackageType;
            ClothingSize = clothingSize;
            RequestStatus = requestStatus;
            CreatedAt = createdAt;
            CompletedAt = completedAt;
        }
    }
}