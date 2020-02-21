using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopListImplement.Implements
{
    public class AssemblyLogic : IAssemblyLogic
    {
        private readonly DataListSingleton source;
        public AssemblyLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(AssemblyBindingModel model)
        {
            Assembly tempAssembly = model.Id.HasValue ? null : new Assembly { Id = 1 };
            foreach (var assembly in source.Assemblies)
            {
                if (assembly.AssemblyName == model.AssemblyName && assembly.Id != model.Id)
                {
                    throw new Exception("Уже есть сборка с таким названием");
                }
                if (!model.Id.HasValue && assembly.Id >= tempAssembly.Id)
                {
                    tempAssembly.Id = assembly.Id + 1;
                }
                else if (model.Id.HasValue && assembly.Id == model.Id)
                {
                    tempAssembly = assembly;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempAssembly == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempAssembly);
            }
            else
            {
                source.Assemblies.Add(CreateModel(model, tempAssembly));
            }
        }
        public void Delete(AssemblyBindingModel model)
        {
            // удаляем записи по деталям при удалении сборки
            for (int i = 0; i < source.AssemblyDetails.Count; ++i)
            {
                if (source.AssemblyDetails[i].AssemblyId == model.Id)
                {
                    source.AssemblyDetails.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Assemblies.Count; ++i)
            {
                if (source.Assemblies[i].Id == model.Id)
                {
                    source.Assemblies.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Assembly CreateModel(AssemblyBindingModel model, Assembly assembly)
        {
            assembly.AssemblyName = model.AssemblyName;
            assembly.Price = model.Price;
            //обновляем существующие детали и ищем максимальный идентификатор
            int maxADId = 0;
            for (int i = 0; i < source.AssemblyDetails.Count; ++i)
            {
                if (source.AssemblyDetails[i].Id > maxADId)
                {
                    maxADId = source.AssemblyDetails[i].Id;
                }
                if (source.AssemblyDetails[i].AssemblyId == assembly.Id)
                {
                    // если в модели пришла запись детали с таким id
                    if (model.AssemblyDetails.ContainsKey(source.AssemblyDetails[i].DetailId))
                    {
                        // обновляем количество
                        source.AssemblyDetails[i].Count = model.AssemblyDetails[source.AssemblyDetails[i].DetailId].Item2;
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                        model.AssemblyDetails.Remove(source.AssemblyDetails[i].DetailId);
                    }
                    else
                    {
                        source.AssemblyDetails.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var ad in model.AssemblyDetails)
            {
                source.AssemblyDetails.Add(new AssemblyDetail
                {
                    Id = ++maxADId,
                    AssemblyId = assembly.Id,
                    DetailId = ad.Key,
                    Count = ad.Value.Item2
                });
            }
            return assembly;
        }
        public List<AssemblyViewModel> Read(AssemblyBindingModel model)
        {
            List<AssemblyViewModel> result = new List<AssemblyViewModel>();
            foreach (var assembly in source.Assemblies)
            {
                if (model != null)
                {
                    if (assembly.Id == model.Id)
                    {
                        result.Add(CreateViewModel(assembly));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(assembly));
            }
            return result;
        }
        private AssemblyViewModel CreateViewModel(Assembly assembly)
        {
            // требуется дополнительно получить список деталей для сборки с названиями и их количество
            Dictionary<int, (string, int)> assemblyDetails = new Dictionary<int, (string, int)>();
            foreach (var ad in source.AssemblyDetails)
            {
                if (ad.AssemblyId == assembly.Id)
                {
                    string detailName = string.Empty;
                    foreach (var detail in source.Details)
                    {
                        if (ad.DetailId == detail.Id)
                        {
                            detailName = detail.DetailName;
                            break;
                        }
                    }
                    assemblyDetails.Add(ad.DetailId, (detailName, ad.Count));
                }
            }
            return new AssemblyViewModel
            {
                Id = assembly.Id,
                AssemblyName = assembly.AssemblyName,
                Price = assembly.Price,
                AssemblyDetails = assemblyDetails
            };
        }
    }
}
