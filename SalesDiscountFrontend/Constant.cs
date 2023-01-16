using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoneyApp
{
    public static class Constant
    {
        public static string LocalhostUrl = "localhost";
        public static string Scheme = "http"; // or https
        public static string Port = "5140";
        public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/SalesDiscount/{{0}}";
    }
}
