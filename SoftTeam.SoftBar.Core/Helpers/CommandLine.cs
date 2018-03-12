using System;
using System.Diagnostics;
using System.IO;

namespace SoftTeam.SoftBar.Core.Helpers
{
    public class CommandLineHelper
    {
        private string _application = "";
        private string _document = "";
        private string _parameters = "";
        private Exception _lastExecutionException = null;

        public CommandLineHelper()
        {
        }

        public CommandLineHelper(string application, string document, string parameters)
        {
            Application = application;
            Document = document;
            Parameters = parameters;
        }

        public string Application { get => _application; set => _application = value; }
        public string Document { get => _document; set => _document = value; }
        public string Parameters { get => _parameters; set => _parameters = value; }
        public Exception LastExecutionException { get => _lastExecutionException; set => _lastExecutionException = value; }
        
        public bool Execute()
        {
            try
            {
                Process.Start(CommandLineString);
                return true;
            }
            catch (Exception ex)
            {
                _lastExecutionException = ex;
                return false;
            }
        }

        private string CommandLineString
        {      
            get {
                if (string.IsNullOrEmpty(Parameters))
                    return $"{_application} {_document}";
                else
                {
                    var parameters = _parameters.Replace("%%document%%", _document);
                    return $"{_application} {parameters}";
                }
            }
        }

        public static void ExecuteCommandLine(string commandLine)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + commandLine;
            process.StartInfo = startInfo;
            process.Start();
        }

        public bool CanExecute()
        {
            if (!string.IsNullOrEmpty(_application) && !string.IsNullOrEmpty(_document))
                return false;

            if (!File.Exists(_application))
                return false;

            return true;
        }
    }
}
