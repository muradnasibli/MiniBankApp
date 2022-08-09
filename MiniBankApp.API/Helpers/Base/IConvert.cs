namespace MiniBankApp.API.Helpers.Base;

public interface IConvert<T>
{
    string Serialize(T entity);
    T Deserialize(string data);
}