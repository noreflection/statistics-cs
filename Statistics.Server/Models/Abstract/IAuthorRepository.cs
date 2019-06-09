using System.Collections.Generic;

namespace Statistics.Server.Models.Abstract
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Authors { get; }
        void SaveAuthor(Author author);
    }
}