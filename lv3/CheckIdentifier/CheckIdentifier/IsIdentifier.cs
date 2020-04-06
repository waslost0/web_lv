using System;

namespace CheckIdentifier
{
    public class IsIdentifier
    {
        public int InvalidIndex { get; private set; } = -1;
        public bool IsEmpty { get; private set; } = false;

        public bool IsValidIdentifier(string value)
        {
            return true;
        }

    }
}
