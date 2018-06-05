namespace Lykke.ServiceClient {
    public interface IResultMapper<out T> {
        T MapTo();
    }

    public interface IResultMapper {
        T MapTo<T>();
    }
}