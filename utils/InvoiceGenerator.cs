namespace GeradorNotaFiscal.utils
{
    public class InvoiceGenerator
    {
        public static string GenerateInvoiceNumber()
        {
            var random = new Random();
            return $"{DateTime.UtcNow:yyyyMMdd}-{random.Next(1000, 9999)}";
        }
    }
}
