// (c) 2022 Ervin Peters (coder@ervnet.de)

namespace No._13
{
    public interface IFragment
    {
        int cntCharsParsed { get; }

        CompareResults compare(IFragment right);
    }
}