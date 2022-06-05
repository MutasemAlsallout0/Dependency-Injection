using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Servies
{
    public class ListServies : IListServies
    {
        public static List<DoList> mylist = new();

        public List<DoList> List()
        {
            return mylist;
        }

        public DoList Get(int id)
        {
            return mylist.FirstOrDefault(x => x.id == id);
        }
        public DoList Add(DoList AList)
        {
            AList.id = DoList.currentid++;
            AList.InsertDate = DateTime.Now;
            mylist.Add(AList);
            return AList;
        }

        public DoList Edit(int id, DoList EList)
        {
            var oldValue = mylist.FirstOrDefault(x => x.id == id);
            if (oldValue == null)
                throw new Exception("Item Not Found!");
            oldValue.WhatToDo = EList.WhatToDo;
            oldValue.WhenToDo = EList.WhenToDo;
            oldValue.Notes = EList.Notes;
            return EList;
        }

       
        public DoList Delete(int id)
        {
            var oldValue = mylist.FirstOrDefault(x => x.id == id);
            if (oldValue == null)
                throw new Exception("Item Not Found!");
            mylist.Remove(oldValue);
            return oldValue;
        }
    }
}
