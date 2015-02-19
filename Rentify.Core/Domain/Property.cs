namespace Rentify.Core.Domain
{
    public class Property
    {
        public Property()
        {
            Overview = new PropertyOverview();
        }

        public PropertyOverview Overview { get; set; } 
    }
}