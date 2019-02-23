using System;

namespace MLA_task.BLL.Interface.Exceptions
{
    public class DemoServiceException : Exception
    {
        public ErrorType Error { get; set; }

        public DemoServiceException(ErrorType errorType)
        {
            Error = errorType;
        }

        public DemoServiceException(ErrorType errorType, string message) : base(message)
        {
            Error = errorType;
        }

        public DemoServiceException(ErrorType errorType, string message, Exception innerException) : base(message, innerException)
        {
            Error = errorType;
        }

        public enum ErrorType
        {
            WrongId,
            WrongName
        }
    }    
}