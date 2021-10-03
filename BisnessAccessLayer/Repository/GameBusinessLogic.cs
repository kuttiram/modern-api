using Modern.BisnessAccessLayer.IRepository;
using Modern.DadaAccessLayer.IRepository;
using Modern.Object.Models;
using System.Collections.Generic;

namespace Modern.BisnessAccessLayer.Repository
{
    public class GameBusinessLogic : IGameBusinessLogic
    {
        private readonly IGamesRepository _gamesRepository;
        public GameBusinessLogic(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public List<Game> GetGamesList()
        {
            return this._gamesRepository.GetGamesList();
        }
    }
}
