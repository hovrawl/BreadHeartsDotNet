namespace BreadFramework.Data;

public partial class Items
{
    public partial class KHIIFM
    {
        public static KHIIFM Potion = new ItemPotion();

        private sealed class ItemPotion : KHIIFM
        {
            public override long Address => 0x110223;
            public override string Name => "Potion";
        
            public ItemPotion() : base("Potion", 0)
            {
            }
        }
    }
}