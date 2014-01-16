using Sanscs.Homework.Model;
using System;

namespace Sanscs.Homework.DAL.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        SanscsHomeworkPlatformdbEntities Get();
    }
}
