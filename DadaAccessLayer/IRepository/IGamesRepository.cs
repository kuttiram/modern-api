using Modern.Object.Models;
using System.Collections.Generic;

namespace Modern.DataAccessLayer.IRepository
{
    public interface IGamesRepository
    {
        List<Game> GetGamesList();
    }
}
