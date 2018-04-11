using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SoftTeam.SoftBar.Core.Misc
{
    #region Enums
    public enum CandidatePriority
    {
        High,
        Medium,
        Low
    }
    #endregion

    public class ProcessCapture
    {
        #region Process capture interop stuff
        [Flags]
        public enum ProcessAccessFlags : int
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags,
            [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpExeName, ref uint lpdwSize);
        #endregion

        #region Fields
        List<string> _capturedProcesses = new List<string>();
        #endregion

        #region Capture/EndCapture
        public void Capture()
        {
            // Capture all processes
            _capturedProcesses.Clear();
            Process[] allProcceses = Process.GetProcesses();

            foreach (var process in allProcceses)
            {
                var fileName = GetExecutablePath((UIntPtr)process.Id);

                if (!string.IsNullOrEmpty(fileName) && !_capturedProcesses.Contains(fileName))
                    _capturedProcesses.Add(fileName);
            }
        }

        public List<ExecutableCandidate> EndCapture()
        {
            List<ExecutableCandidate> result = new List<ExecutableCandidate>();

            // Capture difference
            Process[] allProcceses = Process.GetProcesses();

            foreach (var process in allProcceses)
            {
                var fileName = GetExecutablePath((UIntPtr)process.Id);

                if (!string.IsNullOrEmpty(fileName) && !_capturedProcesses.Contains(fileName))
                {
                    CandidatePriority priority = CandidatePriority.Medium;

                    if (fileName.ToLower().Contains("program"))
                        priority = CandidatePriority.High;
                    if (fileName.ToLower().Contains("windows") || fileName.ToLower().Contains("system"))
                        priority = CandidatePriority.Low;

                    result.Add(new ExecutableCandidate(fileName, priority));
                }
            }

            return result;
        }
        #endregion

        #region GetExecutablePath
        /// <summary>
        /// See https://stackoverflow.com/questions/3399819/access-denied-while-getting-process-path/3654195#3654195
        /// </summary>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        private static string GetExecutablePath(UIntPtr dwProcessId)
        {
            StringBuilder buffer = new StringBuilder(1024);
            IntPtr hprocess = OpenProcess((int)ProcessAccessFlags.QueryLimitedInformation, false, (int)dwProcessId);
            if (hprocess != IntPtr.Zero)
            {
                try
                {
                    uint size = (uint)buffer.Capacity;
                    if (QueryFullProcessImageName(hprocess, 0, buffer, ref size))
                    {
                        return buffer.ToString();
                    }
                }
                finally
                {
                    CloseHandle(hprocess);
                }
            }
            return string.Empty;
        }
        #endregion
    }

    public class ExecutableCandidate
    {
        public string Path { get; set; }
        public CandidatePriority Priority { get; set; }

        public ExecutableCandidate(string path, CandidatePriority priority)
        {
            Path = path;
            Priority = priority;
        }
    }
}
