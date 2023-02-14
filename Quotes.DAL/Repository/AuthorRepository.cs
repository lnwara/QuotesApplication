using System;
using Quotes.Models;

namespace Quotes.DAL.Repository
{
	public class AuthorRepository : Repository<AuthorModel>, IAuthorRepository
    {
        private ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}

