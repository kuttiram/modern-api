using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;
using Modern.DataAccessLayer.Repository;
using System;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace Modern.DataAccessLayer.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Modern_DataContext _context;
        private readonly ILogger _logger;
        private IDbContextTransaction _objTran;
        private string _errorMessage = string.Empty;
        public IUserRepository user => new UserRepository(_context);
        public IKeyRepository keyInfo => new KeyRepository(_context);
        public IHomeTitleRepository homeTitle => new HomeTitleRepository(_context);
        public IPageContentRepository contentBanner => new PageContentRepository(_context);

        public UnitOfWork(Modern_DataContext context, ILoggerFactory loggerFactory)
        {
            this._context = context;
            this._logger = loggerFactory.CreateLogger("logs");
            //this.keyInfo = keyRepository;
            //this.user = userRepository;
            //this.homeTitle = homeTitleRepository;
            //_keyRepository = new GenericRepository<KeyHasKey>(_context, _logger);
            //_userRepository = new GenericRepository<UserUserInfo>(_context, _logger);
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        //This CreateTransaction() method will create a database Trnasaction so that we can do database operations by
        //applying do evrything and do nothing principle
        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        //If all the Transactions are completed successfuly then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            _objTran.Commit();
        }

        //If atleast one of the Transaction is Failed then we need to call this Rollback() 
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }
    }
}
