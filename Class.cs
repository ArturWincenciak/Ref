internal class Class
{
    public double DoubleProp { get; set; }
    public string StrProp { get; set; } = string.Empty;
    public SecondStruct StructInClassProp { get; set; }

    public override string ToString() => 
        $"[{nameof(DoubleProp)}: {DoubleProp}, " +
        $"{nameof(StrProp)}: {StrProp}, " +
        $"{nameof(StructInClassProp)}: {StructInClassProp}]";
}