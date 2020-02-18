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
        public List<AssemblyViewModel> GetList()
        {
            List<AssemblyViewModel> result = new List<AssemblyViewModel>();
            for (int i = 0; i < source.Assemblies.Count; ++i)
            {
                // требуется дополнительно получить список деталей для сборки и их количество
                List<AssemblyDetailViewModel> AssemblyDetails = new List<AssemblyDetailViewModel>();
                for (int j = 0; j < source.AssemblyDetails.Count; ++j)
                {
                    if (source.AssemblyDetails[j].AssemblyId == source.Assemblies[i].Id)
                    {
                        string DetailName = string.Empty;
                        for (int k = 0; k < source.Details.Count; ++k)
                        {
                            if (source.AssemblyDetails[j].DetailId == source.Details[k].Id)
                            {
                                DetailName = source.Details[k].DetailName;
                                break;
                            }
                        }
                        AssemblyDetails.Add(new AssemblyDetailViewModel
                        {
                            Id = source.AssemblyDetails[j].Id,
                            AssemblyId = source.AssemblyDetails[j].AssemblyId,
                            DetailId = source.AssemblyDetails[j].DetailId,
                            DetailName = DetailName,
                            Count = source.AssemblyDetails[j].Count
                        });
                    }
                }
                result.Add(new AssemblyViewModel
                {
                    Id = source.Assemblies[i].Id,
                    AssemblyName = source.Assemblies[i].AssemblyName,
                    Price = source.Assemblies[i].Price,
                    AssemblyDetails = AssemblyDetails
                });
            }
            return result;
        }
        public AssemblyViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Assemblies.Count; ++i)
            {
                // требуется дополнительно получить список деталей для сборки и их количество
                List<AssemblyDetailViewModel> AssemblyDetails = new List<AssemblyDetailViewModel>();
                for (int j = 0; j < source.AssemblyDetails.Count; ++j)
                {
                    if (source.AssemblyDetails[j].AssemblyId == source.Assemblies[i].Id)
                    {
                        string DetailName = string.Empty;
                        for (int k = 0; k < source.Details.Count; ++k)
                        {
                            if (source.AssemblyDetails[j].DetailId == source.Details[k].Id)
                            {
                                DetailName = source.Details[k].DetailName;
                                break;
                            }
                        }
                        AssemblyDetails.Add(new AssemblyDetailViewModel
                        {
                            Id = source.AssemblyDetails[j].Id,
                            AssemblyId = source.AssemblyDetails[j].AssemblyId,
                            DetailId = source.AssemblyDetails[j].DetailId,
                            DetailName = DetailName,
                            Count = source.AssemblyDetails[j].Count
                        });
                    }
                }
                if (source.Assemblies[i].Id == id)
                {
                    return new AssemblyViewModel
                    {
                        Id = source.Assemblies[i].Id,
                        AssemblyName = source.Assemblies[i].AssemblyName,
                        Price = source.Assemblies[i].Price,
                        AssemblyDetails = AssemblyDetails
                    };
                }
            }
            throw new Exception("Деталь не найдена");
        }
        public void AddElement(AssemblyBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Assemblies.Count; ++i)
            {
                if (source.Assemblies[i].Id > maxId)
                {
                    maxId = source.Assemblies[i].Id;
                }
                if (source.Assemblies[i].AssemblyName == model.AssemblyName)
                {
                    throw new Exception("Уже есть сборка с таким названием");
                }
            }
            source.Assemblies.Add(new Assembly
            {
                Id = maxId + 1,
                AssemblyName = model.AssemblyName,
                Price = model.Price
            });
            // детали для сборки
            int maxPCId = 0;
            for (int i = 0; i < source.AssemblyDetails.Count; ++i)
            {
                if (source.AssemblyDetails[i].Id > maxPCId)
                {
                    maxPCId = source.AssemblyDetails[i].Id;
                }
            }
            // убираем дубли по деталям
            for (int i = 0; i < model.AssemblyDetails.Count; ++i)
            {
                for (int j = 1; j < model.AssemblyDetails.Count; ++j)
                {
                    if (model.AssemblyDetails[i].DetailId ==
                    model.AssemblyDetails[j].DetailId)
                    {
                        model.AssemblyDetails[i].Count +=
                        model.AssemblyDetails[j].Count;
                        model.AssemblyDetails.RemoveAt(j--);
                    }
                }
            }
            // добавляем детали
            for (int i = 0; i < model.AssemblyDetails.Count; ++i)
            {
                source.AssemblyDetails.Add(new AssemblyDetail
                {
                    Id = ++maxPCId,
                    AssemblyId = maxId + 1,
                    DetailId = model.AssemblyDetails[i].DetailId,
                    Count = model.AssemblyDetails[i].Count
                });
            }
        }
        public void UpdElement(AssemblyBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Assemblies.Count; ++i)
            {
                if (source.Assemblies[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Assemblies[i].AssemblyName == model.AssemblyName &&
                source.Assemblies[i].Id != model.Id)
                {
                    throw new Exception("Уже есть сборка с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Деталь не найдена");
            }
            source.Assemblies[index].AssemblyName = model.AssemblyName;
            source.Assemblies[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.AssemblyDetails.Count; ++i)
            {
                if (source.AssemblyDetails[i].Id > maxPCId)
                {
                    maxPCId = source.AssemblyDetails[i].Id;
                }
            }
            // обновляем существуюущие детали
            for (int i = 0; i < source.AssemblyDetails.Count; ++i)
            {
                if (source.AssemblyDetails[i].AssemblyId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.AssemblyDetails.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.AssemblyDetails[i].Id == model.AssemblyDetails[j].Id)
                        {
                            source.AssemblyDetails[i].Count = model.AssemblyDetails[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.AssemblyDetails.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.AssemblyDetails.Count; ++i)
            {
                if (model.AssemblyDetails[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.AssemblyDetails.Count; ++j)
                    {
                        if (source.AssemblyDetails[j].AssemblyId == model.Id &&
                        source.AssemblyDetails[j].DetailId == model.AssemblyDetails[i].DetailId)
                        {
                            source.AssemblyDetails[j].Count += model.AssemblyDetails[i].Count;
                            model.AssemblyDetails[i].Id = source.AssemblyDetails[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.AssemblyDetails[i].Id == 0)
                    {
                        source.AssemblyDetails.Add(new AssemblyDetail
                        {
                            Id = ++maxPCId,
                            AssemblyId = model.Id,
                            DetailId = model.AssemblyDetails[i].DetailId,
                            Count = model.AssemblyDetails[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаляем записи по деталям при удалении сборки
            for (int i = 0; i < source.AssemblyDetails.Count; ++i)
            {
                if (source.AssemblyDetails[i].AssemblyId == id)
                {
                    source.AssemblyDetails.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Assemblies.Count; ++i)
            {
                if (source.Assemblies[i].Id == id)
                {
                    source.Assemblies.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Деталь не найдена");
        }
    }
}
