using System;
using System.IO;

class Program
{
    private static bool isLogged = false;

    static void Main()
    {
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            watcher.Path = "/proj";  
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("İzleme başladı. Çıkmak için 'q' tuşuna basın.");
            while (Console.Read() != 'q') ;
        }
    }

private static void OnChanged(object source, FileSystemEventArgs e)
{
    LogToFile($"{e.FullPath} üzerinde değişiklik oldu.");

    string targetDirectory;
    if (Directory.Exists(e.FullPath)) 
    {
        targetDirectory = e.FullPath;
    }
    else 
    {
        targetDirectory = Path.GetDirectoryName(e.FullPath);
    }

    System.Diagnostics.Process.Start("/bin/bash", $"-c \"cd {targetDirectory} && touch deneme1.txt && dotnet run\"");




}

    private static void LogToFile(string message)
    {
        string logPath = "/var/log/watcher-log.txt";  
        using (StreamWriter sw = File.AppendText(logPath))
        {
            sw.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}


