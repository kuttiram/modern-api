using Modern.Object.Models;
using System.Collections.Generic;

namespace Modern.BisnessAccessLayer.IRepository
{
    public interface IGameBusinessLogic
    {
        List<Game> GetGamesList();
    }
}
