using CommandLine;
using System.Text;


namespace ViServiceAdapter
{
    internal class Options
    {
        [Option('f', "filename", Required = true, HelpText = "Application file name")]
        public string FileName { get; set; }

        [Option('a', "arg", HelpText = "Application Arguments")]
        public string Arguments { get; set; } 

        [Option('s', "sname", HelpText = "Service Name", Default = "Vi Service Adapter")]
        public string ServiceName { get; set; }

        [Option('w', "path", HelpText = "Application Working Directory")]
        public string WorkingDirectory { get; set; }

        [Option('e', "environment", Separator = '&', HelpText = "Environment Variables")]
        public IEnumerable<string> EnvironmentVariables { get; set; }

        public string GetPath()
        {
            if (!string.IsNullOrEmpty(WorkingDirectory))
                return WorkingDirectory;
            return new FileInfo(FileName).Directory.FullName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"FileName = {FileName}");
            sb.AppendLine($"Path = {GetPath()}");
            sb.AppendLine($"ServiceName = {ServiceName}");
            sb.AppendLine($"Arguments = {Arguments ?? "NULL"}");
            sb.AppendLine($"WorkingDirectory = {WorkingDirectory ?? "NULL"}");
            sb.AppendLine($"EnvironmentVariables Count = {EnvironmentVariables?.Count()}");
            return sb.ToString();
        }
    }
}
