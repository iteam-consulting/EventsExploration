using System.Collections.Generic;

namespace EventsExploration.Events
{
  public class SyncButtonEventArgs
  {
    public IEnumerable<string> AttachmentNames { get; }

    public SyncButtonEventArgs(IEnumerable<string> names)
    {
      AttachmentNames = names;
    }
  }
}
