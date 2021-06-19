using System;
using System.Diagnostics;
using System.Timers;

namespace JET.Utilities.App
{
	public class ProcessMonitor
	{
		private Timer monitor;
		private readonly string processName;
		private readonly Action<ProcessMonitor> aliveCallback;
		private readonly Action<ProcessMonitor> exitCallback;

		public ProcessMonitor(string processName, double interval, Action<ProcessMonitor> aliveCallback, Action<ProcessMonitor> exitCallback)
		{
			monitor = new Timer(interval);
			monitor.Elapsed += OnPollEvent;
			monitor.AutoReset = true;

			this.processName = processName;
			this.aliveCallback = aliveCallback;
			this.exitCallback = exitCallback;
		}

		public void Start()
		{
			monitor.Enabled = true;
		}

		public void Stop()
		{
			monitor.Enabled = false;
		}

		private void OnPollEvent(object source, ElapsedEventArgs e)
		{
			Process[] clientProcess = Process.GetProcessesByName(processName);

			// client instances still running
			if (clientProcess.Length > 0)
			{
				aliveCallback(this);
				return;
			}

			// all client instances stopped running
			exitCallback(this);
		}
	}
}
