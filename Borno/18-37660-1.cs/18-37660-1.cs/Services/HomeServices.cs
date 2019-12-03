using _18_36449_1.cs.Entities;
using _18_36449_1.cs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_36449_1.cs.Services
{
    class HomeServices
    {
        HomeRepository hr = new HomeRepository();

        public bool CreatEvent(EventEntity evnt)
        {
            return hr.Insert(evnt);
        }

        public EventEntity SearchTitle(EventEntity evnt)
        {
            return hr.Get(evnt);
        }

        public bool Delete(EventEntity evnt)
        {
            return hr.Delete(evnt);
        }

        public bool Edit(EventEntity evnt)
        {
            return hr.Update(evnt);
        }

        public List<EventEntity> GetAllEvents()
        {
            return hr.GetAll();
        }
    }
}
