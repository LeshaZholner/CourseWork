using AutoMapper;
using NLayerApp.BLL.BusinessModels;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public PhoneDTO GetPhone(int? id)
        {
            if(id == null)
            {
                throw new ValidatorException("Id is not correct","");
            }
            var phone = Database.Phones.Get(id.Value);
            if(phone == null)
            {
                throw new ValidatorException($"Phone '{id}' not found", "");
            }
            return new PhoneDTO { Company = phone.Company, Id = phone.Id, Name = phone.Name, Price = phone.Price };
        }

        public IEnumerable<PhoneDTO> GetPhones()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Phone, PhoneDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Phone>, List<PhoneDTO>>(Database.Phones.GetAll());
        }

        public void MakeOrder(OrderDTO orderDTO)
        {
            var phone = Database.Phones.Get(orderDTO.PhoneId);
            if(phone == null)
            {
                throw new ValidatorException($"Phone '{orderDTO.PhoneId}' not found", "");
            }

            decimal sum = new Discount(0.1m).getDiscountPrice(phone.Price);
            var order = new Order()
            {
                Date = DateTime.Now,
                Address = orderDTO.Address,
                PhoneId = orderDTO.PhoneId,
                Sum = sum,
                PhoneNumber = orderDTO.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
