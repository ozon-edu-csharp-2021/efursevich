using System;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.SeedWork;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchRequest : Entity, IAggregateRoot
    {
        public long Id { get; }
        public ClothingSize ClothingSize { get; }
        public MerchType MerchType  { get; }
        public long EmployeeId { get; }
        public RequestStatus RequestStatus { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime CompletedAt { get; private set; }
        
        public MerchRequest(long id, ClothingSize clothingSize, MerchType merchType, long employeeId)
        {
            Id = id;
            ClothingSize = clothingSize ?? throw new ArgumentNullException(nameof(clothingSize));
            MerchType = merchType ?? throw new ArgumentNullException(nameof(merchType));
            EmployeeId = employeeId;
            RequestStatus = RequestStatus.Submitted;
            CreatedAt = DateTime.UtcNow;
            CompletedAt = DateTime.MinValue.ToUniversalTime();
        }

        public void SetStatusNotEnoughRequiredItems()
        {
            if (RequestStatus.Equals(RequestStatus.Submitted))
            {
                RequestStatus = RequestStatus.NotEnoughRequiredItems;
            }
            else
            {
                throw new MerchRequestStatusException($"Only \"Submitted\" status can be changed to \"NotEnoughRequiredItems\"");
            }
        }
        
        public void SetStatusStockConfirmed()
        {
            if (RequestStatus.Equals(RequestStatus.Submitted) || RequestStatus.Equals(RequestStatus.NotEnoughRequiredItems))
            {
                RequestStatus = RequestStatus.StockConfirmed;
            }
            else
            {
                throw new MerchRequestStatusException($"Only \"Submitted\" and \"NotEnoughRequiredItems\" status can be changed to \"StockConfirmed\"");
            }
        }
        
        public void CompleteRequest()
        {
            if (RequestStatus.Equals(RequestStatus.StockConfirmed))
            {
                RequestStatus = RequestStatus.Completed;
                CompletedAt = DateTime.UtcNow;
            }
            else
            {
                throw new MerchRequestStatusException($"Only \"StockConfirmed\" status can be changed to \"Completed\"");
            }
        }
    }
}