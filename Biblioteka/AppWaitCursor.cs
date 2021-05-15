using System;
using System.Windows.Forms;

/// <summary>
/// Klasa ustawiająca kursor ładowania.
/// </summary>
public class AppWaitCursor : IDisposable
{
    /// <summary>
    /// Kontrolka, która wywołała kosztowną operację.
    /// </summary>
    private readonly Control eventControl;
    /// <summary>
    /// Formularz, na którym zostanie ustawiony kursor ładowania.
    /// </summary>
    private readonly Form caller;

    /// <summary>
    /// Konstruktor.
    /// </summary>
    /// <param name="callerForm">Formularz wykonujący kosztowną operację.</param>
    /// <param name="eventSender">Kontrolka, która wywołała kosztowną operację.</param>
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

    /// <summary>
    /// Funkcja interfejsu IDisposable. Pozwala na usunięcie kursora ładowania.
    /// </summary>
    public void Dispose()
    {
        if (eventControl != null)
        {
            eventControl.Enabled = true;
        }

        if (caller != null)
        {
            caller.UseWaitCursor = false;
        }
        else
        {
            Cursor.Current = Cursors.Default;
        }
        Application.UseWaitCursor = false;
    }
}