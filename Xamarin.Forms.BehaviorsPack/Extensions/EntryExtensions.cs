using System;
using Xamarin.Forms;

public static class EntryExtensions
{
    public static string ValidatedText(this Entry entry)
    {
        return entry?.Text ?? string.Empty;
    }
}
