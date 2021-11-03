using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseRequestService : IMerchandiseRequestService
    {
        private readonly List<MerchandiseRequest> MerchandiseRequests = new()
        {
            new MerchandiseRequest(1, "Иван", "Кварцев", "Small", 44, 
                "Принят в обработку", DateTime.UtcNow, DateTime.MinValue.ToUniversalTime()),
            new MerchandiseRequest(2, "Олег", "Вилкин", "Medium", 46, 
                "Комплектуется", DateTime.UtcNow, DateTime.MinValue.ToUniversalTime()),
            new MerchandiseRequest(3, "Кирилл", "Горбин", "Medium", 48, 
                "Нужной позиции нет на складе", DateTime.UtcNow, DateTime.MinValue.ToUniversalTime()),
            new MerchandiseRequest(4, "Илья", "Корбут", "Full", 50, 
                "Готов к выдаче", DateTime.UtcNow, DateTime.MinValue.ToUniversalTime()),
            new MerchandiseRequest(5, "Слава", "Миркин", "Medium", 52, 
                "Завершен", DateTime.UtcNow, DateTime.UtcNow),
        };
        
        public Task<MerchandiseRequest> GetById(long id, CancellationToken _)
        {
            var request = MerchandiseRequests.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(request);
        }

        public Task<MerchandiseRequest> Add(MerchandiseRequestCreationModel model, CancellationToken _)
        {
            long id = MerchandiseRequests.Max(x => x.Id) + 1;
            string status = "Принят в обработку";
            DateTime createdAt = DateTime.UtcNow;
            DateTime completedAt = DateTime.UtcNow;
            MerchandiseRequest newMerchandiseRequest = new(id, model.FirstName, model.LastName, model.MerchPackageType, 
                model.ClothingSize, status, createdAt, completedAt);
            MerchandiseRequests.Add(newMerchandiseRequest);
            return Task.FromResult(newMerchandiseRequest);
        }
    }
}