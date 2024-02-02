using Microsoft.EntityFrameworkCore.Storage;

namespace Homework1.API.Models.UnitOfWorks
{
    public interface IUnitOfWork
    {
        int Commit(); //savechange yerine transaction da daha çok commit ifadesi kullanılır.
        Task<int> CommitAsync();
        IDbContextTransaction BeginTransaction(); // unitofwork üzerinden transaction başlatabiliriz.
    }
}
