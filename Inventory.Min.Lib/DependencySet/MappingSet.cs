using AutoMapper;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.Lib;

public class MappingSet 
    : ModelHelper.AppMappings
{
    public MappingSet(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap() =>
        new (
        c => 
        {
            c.CreateMap<ItemInsertArgs, Item>();
            c.CreateMap<ItemUpdateArgs, ItemUpdate>();
        });
}