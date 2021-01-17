using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGenerators.EAN13MockGenerator
{
    public class EAN13MockGenerator : IEAN13MockGenerator
    {
        public Random RandomInt = new Random(Guid.NewGuid().GetHashCode());

        public List<string> GenerateEAN13Bulk(int count)
        {
            var ean13Bulk = new List<string>();
            
            for (int i = 0; i < count; i++)
            {
                ean13Bulk.Add(GenerateEAN13());
            }

            return ean13Bulk;
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }

        public string GenerateEAN13()
        {
            var ean13STringBuilder = new StringBuilder();

            GenerateFirst12Digits(ean13STringBuilder);
            var checkSum = CalculateChecksum(ean13STringBuilder);
            ean13STringBuilder.Append(checkSum);

            return ean13STringBuilder.ToString();
        }

        private static void GenerateFirst12Digits(StringBuilder ean13STringBuilder)
        {
            Random RandomInt = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 12; i++)
            {
                ean13STringBuilder.Append(RandomInt.Next(10));
            }
        }

        private int CalculateChecksum(StringBuilder first12digits)
        {
            int[] ean13 = { 1, 3 }; // Parity pattern 
            int sum = 0;
            for (int i = 0; i < first12digits.Length; i++)
            {
                sum += int.Parse(first12digits[i].ToString()) * ean13[i % 2];
            }

            int checksum = 10 - sum % 10;
            if (checksum == 10)
            {
                checksum = 0;
            }

            return checksum;
        }

    }
}
