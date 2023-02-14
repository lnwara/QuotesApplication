using System;
namespace Quotes.DAL.Repository
{
	public interface IUnitOfWork
	{
        IQuoteRepository Quote { get; }
        IAuthorRepository Author { get; }

        void Save();
    }
}

