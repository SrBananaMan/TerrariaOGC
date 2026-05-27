using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TerrariaOGC;

namespace Terraria
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
#if USE_ORIGINAL_CODE
			Marshal.PrelinkAll(typeof(Main));
			ThreadPool.SetMinThreads(0, 0);
			ThreadPool.SetMaxThreads(0, 0);
#else
            Environment.SetEnvironmentVariable("FNA3D_FORCE_DRIVER", "opengl"); // Found to not cause issues on Win11 if you had D3D11 set.
            Environment.SetEnvironmentVariable("FNA3D_BACKBUFFER_SCALE_NEAREST", "1");
#endif

            using (Main TheGame = new Main())
            {
                try
                {
                    TheGame.Run();
                }
                catch (Exception Ex)
                {
                    using (StreamWriter ErrorWriter = new StreamWriter("client-crashlog.txt", append: true))
                    {
                        ErrorWriter.WriteLine(DateTime.Now);
                        ErrorWriter.WriteLine(Ex);

                        var Tracer = new StackTrace(Ex, true);
                        for (int i = 0; i < Tracer.FrameCount; i++)
                        {
                            StackFrame frame = Tracer.GetFrame(i);
                            ErrorWriter.WriteLine(frame.GetMethod());
                            ErrorWriter.WriteLine(frame.GetFileLineNumber());
                        }

                        ErrorWriter.WriteLine("");
                    }

#if !USE_ORIGINAL_CODE
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Content")))
                    {
                        using (var extractionForm = new Extraction())
                        {
                            if (extractionForm.ShowDialog() != DialogResult.OK)
                                return;
                        }
                    }

                    using (Main game = new Main())
                    {
                        game.Run();
                    }
#endif
                }
            }
        }
    }
}
