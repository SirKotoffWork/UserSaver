using Microsoft.EntityFrameworkCore;
using UserSaver.DAL.Context;
using UserSaver.DAL.Model;

namespace UserSaver.BLL;

public class CrudOperations : ICrud<User>
{
    private ApplicationDbContext db = new();

    //public CrudOperations(ApplicationDbContext db)
    //{
    //    this.db = db;
    //}

    public bool Create(User user)
    {
        try
        {
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(User user)
    {
        try
        {
            db.Users.Update(user);
            db.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public IEnumerable<User> GetAllUser()
    {
        return db.Users.ToList();
    }


    public bool Delete(int id)
    {
        try
        {
            if (id != null)
            {
                User user = db.Users.FirstOrDefault(p => p.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            return true;
        }
        catch (Exception e)
        {
        }

        return false;
    }


    public User GetUser(int id)
    {
        try
        {
            if (id != null)
            {
                User user = db.Users.FirstOrDefault(p => p.Id == id);
                return user;
            }

        }
        catch (Exception e)
        {
        }

        return null;
    }

}