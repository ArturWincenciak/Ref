internal struct SecondStruct
{
    public float FloatProp { get; set; }

    public override string ToString() => 
        $"[{nameof(FloatProp)}: {FloatProp}]";
}