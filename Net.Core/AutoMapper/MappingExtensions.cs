namespace Net.API.Configuration.AutoMapper
{
    public static partial class MappingExtensions
    {
        public static TDes Map<TDes>(this object source)
        {
            return (TDes)source;
        }
    }
}
