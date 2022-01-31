using System;

namespace runningcat
{
#if WINDOWS || LINUX
    
    public static class Program
    {
   
        [STAThread]
        static void Main()
        {
            using (var game = new runningcat())
                game.Run();
        }
    }
#endif
}
