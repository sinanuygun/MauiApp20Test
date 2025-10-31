using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MauiApp20.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsConnected => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        public event EventHandler<bool> ConnectivityChanged;
        public ConnectivityService()
        {
            Connectivity.Current.ConnectivityChanged += OnConnectivityChanged;
        }
        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(this, e.NetworkAccess == NetworkAccess.Internet);
        }
    }
}
