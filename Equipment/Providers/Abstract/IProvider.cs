namespace Core.Providers
{
    public interface IProvider<in TKey, out TValue>
    {
        TValue Get(TKey key);
    }
}