using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface ILogRepository
    {
        bool AddLogEntry();
    }
}