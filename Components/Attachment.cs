using System;
using System.Collections.Generic;
using System.Text;

namespace EventsExploration.Components
{
  public class Attachment
  {
    public string Name { get; private set; }

    public Attachment(string name)
    {
      Name = name;
    }

    public void Update(string name)
    {
      Name = name;
    }

    public event EventHandler Synced;
  }
}
