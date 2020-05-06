using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopDatabaseImplement.Implements
{
    public class AssemblyLogic : IAssemblyLogic
    {
        public void CreateOrUpdate(AssemblyBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Assembly element = context.Assemblies.FirstOrDefault(rec =>
                        rec.Name == model.AssemblyName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть сборка с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Assemblies.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Assembly();
                            context.Assemblies.Add(element);
                        }
                        element.Name = model.AssemblyName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var AssemblyDetails = context.AssemblyDetails.Where(rec
                            => rec.AssemblyId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.AssemblyDetails.RemoveRange(AssemblyDetails.Where(rec =>
                            !model.AssemblyDetails.ContainsKey(rec.DetailId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateDetail in AssemblyDetails)
                            {
                                updateDetail.Count =
                                model.AssemblyDetails[updateDetail.DetailId].Item2;
                                model.AssemblyDetails.Remove(updateDetail.DetailId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var ad in model.AssemblyDetails)
                        {
                            context.AssemblyDetails.Add(new AssemblyDetail
                            {
                                AssemblyId = element.Id,
                                DetailId = ad.Key,
                                Count = ad.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
        }

        public void Delete(AssemblyBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по деталям при удалении сборки
                        context.AssemblyDetails.RemoveRange(context.AssemblyDetails.Where(rec =>
                        rec.AssemblyId == model.Id));
                        Assembly element = context.Assemblies.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Assemblies.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<AssemblyViewModel> Read(AssemblyBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                return context.Assemblies
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new AssemblyViewModel
                {
                    Id = rec.Id,
                    AssemblyName = rec.Name,
                    Price = rec.Price,
                    AssemblyDetails = context.AssemblyDetails
                .Include(recAD => recAD.Detail)
                .Where(recAD => recAD.AssemblyId == rec.Id)
                .ToDictionary(recAD => recAD.DetailId, recAD => 
                (recAD.Detail?.DetailName, recAD.Count))
                })
                .ToList();
            }
        }
    }
}

