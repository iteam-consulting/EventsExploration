using EventsExploration.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsExploration
{
  class Program
  {
    private static bool _isSyncing = false;
    private static List<Attachment> _attachments = new List<Attachment>();

    static void Main(string[] args)
    {
      var button = new SyncButton();
      button.Click += HandleSyncButtonClicked;
      button.AttachmentsLoaded += HandleAttachmentsLoaded;
      button.SimulateClick();

      Console.ReadLine();
    }

    private static void HandleSyncButtonClicked(object sender, EventArgs e)
    {
      _isSyncing = true;
    }

    private static void HandleAttachmentsLoaded(object sender, Events.SyncButtonEventArgs e)
    {
      _isSyncing = false;

      foreach (var name in e.AttachmentNames)
      {
        if (_attachments.Any(a => a.Name == name))
        {
          _attachments.Single(a => a.Name == name).Update(name);
        }
        else
        {
          var attachment = new Attachment(name);
          attachment.Synced += HandleAttachmentSycned;
        }

        Console.WriteLine(name);
      }

      // resort controls
    }

    private static void HandleAttachmentSycned(object sender, EventArgs e)
    {
      // resort the controls
    }
  }
}
