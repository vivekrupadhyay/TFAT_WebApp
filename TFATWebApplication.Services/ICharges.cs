using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using TFATWebApplication;
namespace TFATWebApplication.Services
{
   public  interface ICharges
    {
       IEnumerable<Cha> getAllArticles();
    }
}
