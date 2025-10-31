using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MauiApp20.Services
{
    public interface IConnectivityService
    {
        bool IsConnected { get; }
        event EventHandler<bool> ConnectivityChanged;
    }
}
