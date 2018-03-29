using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Threading;

namespace SoftTeam.SoftBar.Core.Misc
{
    public class CommandLineHelper : IDisposable
    {
        #region Fields
        private string _application = "";
        private string _document = "";
        private string _parameters = "";
        private bool _runAsAdministrator = false;
        private Exception _lastExecutionException = null;
        #endregion

        #region Constructors
        public CommandLineHelper()
        {
        }

        public CommandLineHelper(string application, string document, string parameters, bool runAsAdministrator)
        {
            Application = application;
            Document = document;
            Parameters = parameters;
            RunAsAdministrator = runAsAdministrator;
        }
        #endregion

        #region Properties
        public string Application { get => _application; set => _application = value; }
        public string Document { get => _document; set => _document = value; }
        public string Parameters { get => _parameters; set => _parameters = value; }
        public bool RunAsAdministrator { get => _runAsAdministrator; set => _runAsAdministrator = value; }

        public Exception LastExecutionException { get => _lastExecutionException; set => _lastExecutionException = value; }

        private string CommandLineString
        {
            get
            {
                if (string.IsNullOrEmpty(Parameters))
                    return $"{_application} {_document}";
                else
                {
                    var parameters = _parameters.Replace("%%document%%", _document);
                    return $"{_application} {parameters}";
                }
            }
        }
        #endregion

        #region Misc functions
        public bool Execute()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Verb = "runas";
            startInfo.FileName = CommandLineString;
            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                _lastExecutionException = ex;
                //User denied access
                return false;
            }
            return true;
        }

        public static void ExecuteCommandLine(string commandLine)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + commandLine;
            process.StartInfo = startInfo;
            process.Start();
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Executes a shell command synchronously.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="command">string command</param></span>
        /// <span class="code-SummaryComment"><returns>string, as output of the command.</returns></span>
        public static void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);
            }
            catch
            {
                // Log the exception
            }
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Execute the command Asynchronously.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="command">string command.</param></span>
        public static void ExecuteCommandAsync(string command)
        {
            try
            {
                //Asynchronously start the Thread to process the Execute command request.
                Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
                //Make the thread as background thread.
                objThread.IsBackground = true;
                //Set the Priority of the thread.
                objThread.Priority = ThreadPriority.AboveNormal;
                //Start the thread.
                objThread.Start(command);
            }
            //catch (ThreadStartException objException)
            //{
            //    // Log the exception
            //}
            //catch (ThreadAbortException objException)
            //{
            //    // Log the exception
            //}
            //catch (Exception objException)
            //{
            //    // Log the exception
            //}
            catch
            {

            }
        }

        public bool CanExecute()
        {
            if (!string.IsNullOrEmpty(_application) && !string.IsNullOrEmpty(_document))
                return false;

            if (!File.Exists(_application))
                return false;

            return true;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
        }
        #endregion  
    }
}
