namespace GeradorNotaFiscal.utils;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class DataProtectionConverter : ValueConverter<string, string>
{
    public DataProtectionConverter(IDataProtector protector)
        : base(
            v => protector.Protect(v),
            v => protector.Unprotect(v),
            convertsNulls: false
            )
    {
    }
}

