// (c) 2022 QSOFT Development

namespace No._06
{
    public static class StartOfPaketDetector
    {
        public static int findStart(string data, int uniqueSequenceLength)
        {
            int seqStartIdx = 0;
            int checkIdx = 1;
            while (checkIdx < data.Length && checkIdx - seqStartIdx < uniqueSequenceLength)
            {
                char c = data[checkIdx];
                int tmpIdx = seqStartIdx;
                while (tmpIdx < checkIdx)
                {
                    if (c == data[tmpIdx])
                        seqStartIdx = tmpIdx + 1;
                    tmpIdx++;
                }

                checkIdx++;
            }

            return seqStartIdx + uniqueSequenceLength;
        }
    }
}