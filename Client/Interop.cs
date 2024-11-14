using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace mdmontesinos.Module.Issue4812
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
