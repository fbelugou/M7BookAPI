using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces;
public interface ISecurityService
{

    /// <summary>
    /// Permet de se connecter à l'API renvoie un token
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>Token en Base64</returns>
    public Task<string> SignIn(string username, string password);


}
