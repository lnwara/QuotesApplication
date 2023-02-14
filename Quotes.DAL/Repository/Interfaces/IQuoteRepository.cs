using System;
using System.Linq.Expressions;
using Quotes.Models;

namespace Quotes.DAL.Repository
{
	public interface IQuoteRepository : IRepository<QuotesModel>
    {
        IEnumerable<QuotesModel> listQuotes(long? authorId=null);

        QuotesModel? GetRandomQuote();
    }
}

