using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Servies
{
     public interface IListServies
    {
        List<DoList> List();
        DoList Get(int id);
        DoList Add(DoList model);
        DoList Edit(int id, DoList model);
        DoList Delete(int id);
    }
}
