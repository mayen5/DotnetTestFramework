﻿
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 

        private Guid _errorId;

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error;

            // Write the log to a storage
            // ...

            // Generate a unique identifier for the error
            _errorId = Guid.NewGuid();
            OnErrorLogged();
        }

        protected virtual void OnErrorLogged()
        {
            ErrorLogged?.Invoke(this, _errorId);
        }
    }
}