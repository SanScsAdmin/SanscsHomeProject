using System;
using Sanscs.Model;

namespace Sanscs.Homework.DAL.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        SanscsHomeworkPlatformdbEntities Get();
    }
}
