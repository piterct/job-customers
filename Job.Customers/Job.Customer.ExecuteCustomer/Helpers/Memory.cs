using System;

namespace Job.Customer.ExecuteCustomer.Helpers
{
    public static class Memory
    {
        public static void SuspendProcessInMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
