using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace PUNTO_VOTACION.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new PUNTO_VOTACION.App(), args);
            host.Run();
        }
    }
}
