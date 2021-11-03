using System;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseRequestStatus
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MerchPackageType  { get; }
        public int ClothingSize { get; }
        public string RequestStatus { get; }
        public DateTime CreatedAt { get; }
        public DateTime CompletedAt { get; }
        
        public MerchandiseRequestStatus(string firstName, string lastName, string merchPackageType, int clothingSize, 
            string requestStatus, DateTime createdAt, DateTime completedAt)
        {
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