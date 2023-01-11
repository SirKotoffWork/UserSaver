using UserSaver.DAL.Model;

namespace UserSaver.BLL;

public interface ICrud<T>
{
    bool Create(T user);
    bool Update(T user);
    bool Delete(int id);
    IEnumerable<T> GetAllUser();
    T GetUser(int id);
}