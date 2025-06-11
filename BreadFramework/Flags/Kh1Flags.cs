namespace BreadFramework.Flags;

public class Kh1Flags : GameFlagsBase
{
    public override FlagValueType FlagValueType { get; set; }
    public override string Description { get; set; }
    public override long Address { get; set; } = 0L;
    
    private Kh1Flags(string name, int value) : base(name, value)
    {
        
    }

    public static readonly Kh1Flags Sora = new SoraFlag();

    private sealed class SoraFlag : Kh1Flags
    {
        public SoraFlag() : base("Sora", 1)
        {
        }
    }

}