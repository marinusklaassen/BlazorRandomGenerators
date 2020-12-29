using System;
using System.Text;

namespace RandomGenerators.Travesty
{
    /// <summary>
    /// The TravestyGenerator class contains methods to deal with natural language processing by randomization of input text. 
    /// </summary>
    public class TravestyGenerator : ITravestyGenerator
    {
        public Random RandomInt = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// ProcessText transforms an input text into a pseudo text based on randomness and simple pattern matching.
        ///
        /// This method is loosely based on the Travesty program with in pascal this is described in the BYTE magazine issue of November 1984 VOL 9. NO.12.
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="characterSequenceMatchOrder"></param>
        /// <param name="maxLength"></param>
        /// <returns>Processed text.</returns>
        public string ProcessText(string inputText, int characterSequenceMatchOrder, int maxLength = 0)
        {
            if (!(characterSequenceMatchOrder > 0 && characterSequenceMatchOrder <= 9))
                throw new ArgumentException(String.Format(
                    "The method parameter '{0}' must be in the range of 1 and 9. The current value is {1}.",
                    characterSequenceMatchOrder,
                    nameof(characterSequenceMatchOrder)
                    ));

            if (inputText.Length < characterSequenceMatchOrder)
                throw new ArgumentException(String.Format(
                    "The method parameter '{0}' length cannot be smaller than the method parameter '{1}' length.",
                    nameof(characterSequenceMatchOrder),
                    nameof(inputText)
                    ));

            // If the maxLength is not set. Use inputText string length.
            maxLength = maxLength > 0 ? maxLength : inputText.Length;

            // Initial offset
            var offsetMatchString = RandomInt.Next(maxLength);

            var result = new StringBuilder();

            // The actual processing of the input text.
            while (result.Length < maxLength)
            {
                var matchString = GetSlice(inputText, characterSequenceMatchOrder, offsetMatchString);
                var searchOffset = RandomInt.Next(maxLength);

                for (int stringEnumerationIndex = 0; stringEnumerationIndex < inputText.Length; stringEnumerationIndex++)
                {
                    var searchIndex = (searchOffset + stringEnumerationIndex) % inputText.Length;
                    var slice = GetSlice(inputText, characterSequenceMatchOrder, searchIndex);
                    if (slice.Equals(matchString))
                    {
                        result.Append(slice);
                        offsetMatchString = searchIndex + characterSequenceMatchOrder;
                        break;
                    }

                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Helper method to get a wrapped slice from an input string.
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="sliceLength"></param>
        /// <param name="offset"></param>
        /// <returns>A slice from an input string.</returns>
        public string GetSlice(string inputText, int sliceLength, int offset)
        {
            var result = new StringBuilder();

            for (int sliceIncrement = 0; sliceIncrement < sliceLength; sliceIncrement++)
            {
                var charSliceIndex = (offset + sliceIncrement) % inputText.Length;
                result.Append(inputText[charSliceIndex]);
            }

            return result.ToString();
        }
    }
}
