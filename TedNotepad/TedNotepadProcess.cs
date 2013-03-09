using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace SofTest402.TeamTiga.FinalProject
{
    class TedNotepadProcess
    {
        Process proc = new Process();

        public void StartAUT(string autPath)
        {
            int procCount = 0;
            proc.StartInfo.FileName = autPath;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            proc.StartInfo.WorkingDirectory = System.Environment.CurrentDirectory;
            proc.Start();
            proc.WaitForInputIdle(TedNotepadConstant.WAIT_FOR_INPUT_IDLE);
            

            while (!proc.Responding && procCount < 50)
            {
                Thread.Sleep(TedNotepadConstant.THREAD_SLEEP);
                procCount++;
            }
        }

        public void CloseAUT()
        {
            if (!proc.HasExited)
            {
                proc.CloseMainWindow();
                proc.WaitForExit(TedNotepadConstant.WAIT_FOR_EXIT);
                if (!proc.HasExited)
                {
                    proc.Kill();
                }
            }
        }
    }
}
