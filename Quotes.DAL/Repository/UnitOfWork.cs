using System;
namespace Quotes.DAL.Repository
{
	public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
		{
            _db = db;
            Quote = new QuoteRepository(_db);
            Author = new AuthorRepository(_db);
        }

        public IQuoteRepository Quote { get; private set; }

        public IAuthorRepository Author { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

