using System;

namespace Job.Customer.ExecuteCustomer.Models
{
    public class LogJobErroModel
    {
        public string StackTrace { get; set; }
        public string TipoException { get; set; }
        public DateTime OcorreuEm { get; set; }
        public string Area { get; set; }
        public string Mensagem { get; set; }
    }
}
