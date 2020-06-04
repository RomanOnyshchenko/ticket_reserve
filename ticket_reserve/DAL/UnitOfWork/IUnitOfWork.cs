using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IclientRepository clients { get; }
        IsellerRepository sellers { get; }
        IticketRepository tickets { get; }
        IorderRepository orders   { get; }
        void Save();

    }
}
