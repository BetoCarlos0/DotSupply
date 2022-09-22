using DotSupply.Models;

namespace DotSupply.Services.Interfaces
{
    public interface IDataGraphicService
    {
        public Task<List<ViewModelData>> Datas();
    }
}
