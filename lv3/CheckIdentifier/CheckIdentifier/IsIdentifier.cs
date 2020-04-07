using System;

namespace CheckIdentifier
{
    public class IsIdentifier
    {
        public int InvalidIndex { get; private set; } = -1;
        public bool IsEmpty { get; private set; } = false;
        private static bool IsLetter(char ch)
        {
            return ('a' <= ch && ch <= 'z') || ('A' <= ch && ch <= 'Z');
        }

        public bool IsValidIdentifier(string value)
        {
            if (value.Length == 0)
            {
                IsEmpty = true;
                return false;
            }

            if (Char.IsDigit(value[0]))
            {
                InvalidIndex = 0;
                return false;
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (!(IsLetter(value[i]) || Char.IsDigit(value[i])))
                {
                    InvalidIndex = ++i;
                    return false;
                }
            }
            return true;
        }

    }
}
