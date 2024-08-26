using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.User
{
    public interface IUserRepository: IGenericRepository<biz.matteria.Entities.AuthUser>
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash, string password);
        string BuildToken(biz.matteria.Entities.AuthUser user);

        System.String GenerateRandom();


        List<biz.matteria.Models.AuthUser.AuthUserService> GetUsersAdmon(string descripcion, int pais);

        List<biz.matteria.Entities.AuthUser> GetUsers();

        biz.matteria.Entities.AuthUser GetUserById(int id);
    }


}
