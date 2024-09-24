﻿namespace Alfateam.Core.Exceptions
{
    public class Exception404 : Exception
    {
        public string Error { get; set; }
        public Exception404(string error)
        {
            Error = error;
        }
    }
}