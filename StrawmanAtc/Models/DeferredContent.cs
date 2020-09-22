using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class DeferredContent
    {
        public DeferredContent(string identifier, string mimeType)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException($"'{nameof(identifier)}' cannot be null or empty", nameof(identifier));
            }

            if (string.IsNullOrEmpty(mimeType))
            {
                throw new ArgumentException($"'{nameof(mimeType)}' cannot be null or empty", nameof(mimeType));
            }

            Identifier = identifier;
            MimeType = mimeType;
        }

        public string Identifier { get; }
        public string MimeType { get; }
    }
}
