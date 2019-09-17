public static class ByteToCodeCS
{
    public static string ToString(byte b) { if (b > 99) { return b.ToString(); } else if (b > 9) { return "0" + b.ToString(); } else { return "00" + b.ToString(); } }
    public static string ToString(byte b, bool Decorate) { return (Decorate ? global::ByteToCodeCS.ToString(b) : b.ToString()); }

    public static string ToCode(ref byte[] Array, uint Ident = 0U, uint MaxPerLine = 0U, bool Decorate = false, bool SkipIdentFirst = true)
    {
        if (Array == null || Array.Length == 0) { Array = new byte[] { 0 }; }
        global::System.Text.StringBuilder b = new System.Text.StringBuilder(Array.Length * 4 + 1024);
        if (Ident > 0U && !SkipIdentFirst) { b.Append(new string(' ', (int)Ident)); }
        const string command = "return new byte[] { ";
        b.Append(command);
        Ident += (uint)command.Length;
        global::System.Collections.Generic.IEnumerator<byte> bEnum = (Array as global::System.Collections.Generic.IEnumerable<byte>).GetEnumerator();
        bEnum.MoveNext();
        b.Append(global::ByteToCodeCS.ToString(bEnum.Current, Decorate));
        uint cnt = 1U;
        string lBrk = new string(' ', (int)Ident);
        while (bEnum.MoveNext())
        {
            b.Append(',');
            if (MaxPerLine > 0U && cnt == MaxPerLine)
            {
                cnt = 1U;
                b.AppendLine();
                b.Append(lBrk);
            } else { b.Append(' '); }
            b.Append(global::ByteToCodeCS.ToString(bEnum.Current, Decorate));
        }
        b.Append(" };");
        return b.ToString();
    }

    public static string ToCode(string FilePath, uint Ident = 0U, uint MaxPerLine = 0U, bool Decorate = false, bool SkipIdentFirst = true)
    {
        byte[] fCnt = global::System.IO.File.ReadAllBytes(FilePath);
        return global::ByteToCodeCS.ToCode(ref fCnt, Ident: Ident, MaxPerLine: MaxPerLine, Decorate: Decorate, SkipIdentFirst: SkipIdentFirst);
    }
}