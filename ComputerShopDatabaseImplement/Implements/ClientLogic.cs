using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopDatabaseImplement.Models;

namespace ComputerShopDatabaseImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                Client client = context.Clients.FirstOrDefault(rec =>
                    rec.Email == model.Email && rec.Id != model.Id);
                if (client != null)
                {
                    throw new Exception("Уже есть клиент с такой почтой");
                }
                if (model.Id.HasValue)
                {
                    client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (client == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    client = new Client();
                    context.Clients.Add(client);
                }
                client.FIO = model.FIO;
                client.Email = model.Email;
                client.Password = model.Password;
                context.SaveChanges();
            }        
        }
        public void Delete(ClientBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                return context.Clients
                .Where(rec => (model == null) || (rec.Id == model.Id) || 
                        (rec.Email.Equals(model.Email) && (rec.Password.Equals(model.Password))))
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Email = rec.Email,
                    Password = rec.Password
                })
                .ToList();
            }
        }
    }
}
