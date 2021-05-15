using System;
using System.Windows.Forms;

public class AppWaitCursor : IDisposable
{
    private readonly Control eventControl;
    private readonly Form caller;

    public AppWaitCursor(Form callerForm = null, object eventSender = null)
    {
        eventControl = eventSender as Control;
        caller = callerForm;
        if (eventControl != null)
            eventControl.Enabled = false;

        if(caller != null)
        {
            caller.UseWaitCursor = true;
        }
        else
        {
            Application.UseWaitCursor = true;
        }

        Application.DoEvents();
    }

    public void Dispose()
    {
        if (eventControl != null)
        {
            eventControl.Enabled = true;
        }

        if(caller != null)
        {
            caller.UseWaitCursor = false;
        }
        Cursor.Current = Cursors.Default;
        Application.UseWaitCursor = false;
    }
}