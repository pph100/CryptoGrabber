using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CryptoGrabber
{
    public class App : Application
    {
        public static CryptoItemManager CryptoItemManager { get; private set; }
        public static AssetManager AssetManager { get; private set; }
        // public static AssetHistoryManager AssetHistoryManager { get; private set; }

        [System.Obsolete]
        public App()
        {
            _debug("App()", "about to create CryptoItemManager instance");
            CryptoItemManager = new CryptoItemManager(new CryptoService());

            _debug("App()", "about to create AssetManager instance");
            AssetManager = new AssetManager(new AssetService());

            _debug("App()", "about to create AssetHistoryManager instance");
            // AssetHistoryManager = new AssetHistoryManager(new AssetHistoryService());

        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        public static void _debug(
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        string message = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
#if DEBUG
            //do your logging here....
            Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "/" + memberName + ": " + message + " (in file " + sourceFilePath + "[" + sourceLineNumber + "])");
#endif
        }
    }
}
