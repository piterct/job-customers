using System;

namespace Job.Customer.ExecuteCustomer.Models
{
    public class LogJobErrorModel
    {
        public string StackTrace { get; set; }
        public string TypeException { get; set; }
        public DateTime Date { get; set; }
        public string Area { get; set; }
        public string Message { get; set; }
    }
}
