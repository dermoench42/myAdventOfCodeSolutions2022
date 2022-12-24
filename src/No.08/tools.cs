// (c) 2022 Ervin Peters (coder@ervnet.de)

namespace No._08
{
    public static class Tools
    {
        public static T[] initializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
    }
}