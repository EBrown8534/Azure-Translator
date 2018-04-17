using System;

namespace AzureTranslator
{
    public class ClipboardTextChangedEventArgs : EventArgs
    {
        public string Old { get; set; }
        public string New { get; set; }

        public ClipboardTextChangedEventArgs(string old, string @new)
        {
            Old = old;
            New = @new;
        }
    }
}
