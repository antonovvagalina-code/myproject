using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Monitor
{
    static void Main()
    {
        string processName = "notepad";
        bool wasRunning = false;

        while (true)
        {
            bool isRunning = Process.GetProcessesByName(processName).Length > 0;

            if (isRunning != wasRunning)
            {
                string message;

                if (isRunning)
                    message = $"{DateTime.Now}: Процесс {processName} запущен";
                else
                    message = $"{DateTime.Now}: Процесс {processName} завершен";

                File.AppendAllText("log.txt", message + Environment.NewLine);

                Console.WriteLine(message);
                wasRunning = isRunning;
            }

            Thread.Sleep(2000);
        }
    }
}