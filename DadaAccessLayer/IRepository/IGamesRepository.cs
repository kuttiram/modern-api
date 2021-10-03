using Modern.Object.Models;
using System.Collections.Generic;

namespace Modern.DadaAccessLayer.IRepository
{
    public interface IGamesRepository
    {
        List<Game> GetGamesList();
    }
}
