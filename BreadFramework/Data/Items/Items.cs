using System.Collections.ObjectModel;
using BreadFramework.Game;

namespace BreadFramework.Data;

public partial class Items
{
    public partial class KHFM : KHItem
    {
        public override long Address { get; }
        public override string Name { get; }
        
        public KHFM(string name, int value) : base(name, value)
        {
            
        }
    }
    
    public partial class KHIIFM : KHItem
    {
        public override long Address { get; }
        public override string Name { get; }
        
        public KHIIFM(string name, int value) : base(name, value)
        {
            
        }
    }
}