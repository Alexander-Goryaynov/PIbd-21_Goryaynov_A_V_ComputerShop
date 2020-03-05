using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopFileImplement.Implements
{
    public class AssemblyLogic : IAssemblyLogic
    {
        private readonly FileDataListSingleton source;
        public AssemblyLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(AssemblyBindingModel model)
        {
            Assembly element = source.Assemblies.FirstOrDefault(rec => rec.AssemblyName == model.AssemblyName &&
            rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сборка с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Assemblies.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Assemblies.Count > 0 ? source.Details.Max(rec => rec.Id) : 0;
                element = new Assembly { Id = maxId + 1 };
                source.Assemblies.Add(element);
            }
            element.AssemblyName = model.AssemblyName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.AssemblyDetails.RemoveAll(rec => rec.AssemblyId == model.Id && !model.AssemblyDetails.ContainsKey(rec.DetailId));
            // обновили количество у существующих записей
            var updateDetails = source.AssemblyDetails.Where(rec => rec.AssemblyId == model.Id && model.AssemblyDetails.ContainsKey(rec.DetailId));
            foreach (var updateDetail in updateDetails)
            {
                updateDetail.Count = model.AssemblyDetails[updateDetail.DetailId].Item2;
                model.AssemblyDetails.Remove(updateDetail.DetailId);
            }
            // добавили новые
            int maxADId = source.AssemblyDetails.Count > 0 ? source.AssemblyDetails.Max(rec => rec.Id) : 0;
            foreach (var ad in model.AssemblyDetails)
            {
                source.AssemblyDetails.Add(new AssemblyDetail
                {
                    Id = ++maxADId,
                    AssemblyId = element.Id,
                    DetailId = ad.Key,
                    Count = ad.Value.Item2
                });
            }
        }
        public void Delete(AssemblyBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.AssemblyDetails.RemoveAll(rec => rec.AssemblyId == model.Id);
            Assembly element = source.Assemblies.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Assemblies.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<AssemblyViewModel> Read(AssemblyBindingModel model)
        {
            return source.Assemblies
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new AssemblyViewModel
            {
                Id = rec.Id,
                AssemblyName = rec.AssemblyName,
                Price = rec.Price,
                AssemblyDetails = source.AssemblyDetails
            .Where(recAD => recAD.AssemblyId == rec.Id)
            .ToDictionary(recAD => recAD.DetailId, recAD =>
            (source.Details.FirstOrDefault(recD => recD.Id == recAD.DetailId)?.DetailName, recAD.Count))
            })
            .ToList();
        }
    }
}
