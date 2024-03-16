namespace StokTakipAPI.DataAccess.Abstract;
public interface IQuery<T>
{
    IQueryable<T> Query();
}
