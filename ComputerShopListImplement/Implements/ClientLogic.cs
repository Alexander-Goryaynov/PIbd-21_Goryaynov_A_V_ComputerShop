using System;
using System.Collections.Generic;
using System.Text;
using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;

namespace ComputerShopListImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly DataListSingleton source;
        public ClientLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client tempClient = (model.Id.HasValue) ? null : new Client { Id = 1 };
            foreach (var client in source.Clients)
            {
                if (client.Email == model.Email && client.Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким именем");
                }
                if (!model.Id.HasValue && client.Id >= tempClient.Id)
                {
                    tempClient.Id = client.Id + 1;
                }
                else if (model.Id.HasValue && client.Id == model.Id)
                {
                    tempClient = client;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempClient == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, tempClient);
            }
            else
            {
                source.Clients.Add(CreateModel(model, tempClient));
            }
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.Email = model.Email;
            client.Password = model.Password;
            client.FIO = model.FIO;
            return client;
        }

        private ClientViewModel CreateViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                FIO = client.FIO
            };
        }

        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; i++)
            {
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (model != null)
                {
                    if (client.Id == model.Id)
                    {
                        result.Add(CreateViewModel(client));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(client));
            }
            return result;
        }
    }
}
