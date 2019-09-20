using EventsExploration.Events;
using System;
using System.ComponentModel;
using System.Threading;

namespace EventsExploration.Components
{
  public class SyncButton
  {
    private BackgroundWorker _worker = new BackgroundWorker();

    public SyncButton()
    {
      Click += HandleClick;
      _worker.DoWork += HandleWorkDone;
    }

    private void HandleWorkDone(object sender, DoWorkEventArgs e)
    {
      Thread.Sleep(TimeSpan.FromSeconds(2));
      // We do some long lived thing and get data
      var args = new SyncButtonEventArgs(new string[] { "Stuff", "Things" });
      AttachmentsLoaded?.Invoke(this, args);
    }

    public void SimulateClick()
    {
      Click?.Invoke(this, null);
    }

    private void HandleClick(object sender, EventArgs e)
    {
      _worker.RunWorkerAsync();
    }

    public event EventHandler<SyncButtonEventArgs> AttachmentsLoaded;
    public event EventHandler Click;
  }
}
