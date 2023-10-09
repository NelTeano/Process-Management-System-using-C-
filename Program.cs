using System.Diagnostics;


    class Program
    {
        private static void ListProcesses()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                Console.WriteLine(p.ProcessName);
            }
        }


        private static void CreateProcesses(string path)
        {
            string executePath = path;
            ProcessStartInfo startInfo = new ProcessStartInfo(executePath);

            Process process = new Process();
            process.StartInfo = startInfo;
            try{
            
                process.Start();
                Console.WriteLine($"Successfully started {executePath} (PID: {process.Id}).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start {executePath}: {ex.Message}");
            }
        }

        private static void TerminateProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process processToKill in processes)
            {
                try
                {
                    processToKill.Kill();
                    processToKill.WaitForExit(); // Optionally wait for the process to finish
                    Console.WriteLine($"Successfully killed {processToKill.ProcessName} (PID: {processToKill.Id}).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to kill {processToKill.ProcessName} (PID: {processToKill.Id}): {ex.Message}");
                }
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a command (create/list/terminate/exit):");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "create":
                        Console.WriteLine("Enter the Program Path you want to Execute: ");
                        string File_Path = Console.ReadLine();

                        CreateProcesses(File_Path);
                        break;

                    case "list":
                        Console.WriteLine("These are the List of the Process : ");
                        ListProcesses();
                        break;

                    case "terminate":
                        Console.WriteLine("Enter the Process Name : ");
                        string TerminateName = Console.ReadLine();
                        TerminateProcess(TerminateName);
                        break;

                    case "exit":
                        Console.WriteLine("Execute Exit");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }

