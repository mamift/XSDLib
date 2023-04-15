namespace W3C.XSD
{
    public partial class localElement
    {
        public localElement WithDefaultMinAndMaxValues()
        {
            this.minOccurs = 0;
            this.maxOccurs = byte.MaxValue;
            return this;
        }
    }
}