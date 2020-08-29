namespace CloudManager.Common.Helper
{
    public interface ISerializeHelper
    {
        T Deserialize<T>(string content);
        string Serialize<T>(T data);
    }
}