using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CinemaClient.Helpers.InternetAvailability
{
    public static class InternetAvailability
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);

        public static bool IsInternetAvailable() => InternetGetConnectedState(out _, 0);
    }
}
