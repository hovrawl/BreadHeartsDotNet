using BreadFramework.Game;

namespace BreadFramework.Data;

public partial class Items
{
    public partial class KHFM
    {

        public static KHFM Potion = new ItemPotion();

        private sealed class ItemPotion : KHFM
        {
            public override long Address => 0x110223;
            public override string Name => "Potion";
        
            public ItemPotion() : base("Potion", 0)
            {
            }
        }

    }
}
