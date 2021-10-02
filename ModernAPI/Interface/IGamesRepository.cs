using Modern.Object.Models;
using System.Collections.Generic;

namespace ModernAPI.Interface
{
    public interface IGamesRepository
    {
        List<Game> GetGamesList();
    }
}
