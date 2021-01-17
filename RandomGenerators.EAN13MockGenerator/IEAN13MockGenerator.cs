using System.Collections.Generic;

namespace RandomGenerators.EAN13MockGenerator
{
    public interface IEAN13MockGenerator
    {
        string GenerateEAN13();
        List<string> GenerateEAN13Bulk(int count);
    }
}