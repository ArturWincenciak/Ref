internal struct FirstStruct
{
    public int IntProp { get; set; }
    public string StrProp { get; set; }
    public Class ClassProp { get; set; }
    public SecondStruct StructInStructProp { get; set; }

    public override string ToString() => 
        $"[{nameof(IntProp)}: {IntProp}, " +
        $"{nameof(StrProp)}: {StrProp}, " +
        $"{nameof(ClassProp)}: {ClassProp}, " +
        $"{nameof(StructInStructProp)}: {StructInStructProp}]";
}