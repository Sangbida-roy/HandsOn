// See https://aka.ms/new-console-template for more information
using System.ServiceProcess;
using System.Timers;
using Timer = System.Timers.Timer;
using WindowsServiceDotNetCore;
internal class LoggingService : ServiceBase
{
    private Timer _timer;
    public LoggingService()
    {

        _timer = new Timer(); //initialize
    }

    protected override void OnStart(string[] args)
    {
        //no heavy lifting task. Only start a function here. 
        _timer.Enabled = true;
        _timer.Interval = TimeSpan.FromSeconds(1).TotalMilliseconds;
        _timer.Elapsed += _timer_Elapsed;

        base.OnStart(args);
        Logger.Log("Window Service is started");

    }
    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        _timer.Interval = TimeSpan.FromSeconds(10).TotalMilliseconds;
        BatchJob();
    }
    public void BatchJob()
    {
        Logger.Log("Batch Job Started");
    }

    protected override void OnStop()
    {
        //close class, dispose object, ssending them to null or Idisposeable
        _timer.Enabled = false;
        _timer.Dispose();
        _timer = null;
        base.OnStop();
        Logger.Log("Window Service is stopped");
    }
}