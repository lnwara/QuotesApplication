using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quotes.Models;

namespace Quotes.DAL.Repository
{
	public class QuoteRepository : Repository<QuotesModel>,IQuoteRepository
    {
        private ApplicationDbContext _db;

        public QuoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<QuotesModel> listQuotes(long? authorId = null)
        {
            var query = _db.Quotes
           .Include(x => x.Author);
            if (authorId != null)
               return query.Where(a => a.AuthorId == authorId).ToList();

            return query.ToList();
        }

        public QuotesModel? GetRandomQuote() => _db.Quotes.OrderBy(r => Guid.NewGuid()).FirstOrDefault();
        
    }
}

