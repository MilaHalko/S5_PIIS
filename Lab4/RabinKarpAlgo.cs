namespace Lab4;

public class RabinKarpAlgo
{
    private int _templateSize;
    private int _templateHash;
    private string _text;
    private string _template;

    private int GetHash(string str)
    {
        int hash = 0;
        foreach (var symbol in str)
        {
            hash += symbol;
        }
        return hash / 6;
    }

    public int CountEntries(string template, string text)
    {
        _text = text.ToLower();
        _template = template.ToLower();
        _templateSize = _template.Length;
        _templateHash = GetHash(_template);
        int entries = 0;
        
        for (int i = 0; i <= _text.Length - _templateSize; i++)
        {
            string subString = _text.Substring(i, _templateSize);
            int subStringHash = GetHash(subString);
            if (subStringHash == _templateHash && subString == _template)
            {
                entries++;
                i += _templateSize - 1;
            }
        }

        return entries;
    }
}