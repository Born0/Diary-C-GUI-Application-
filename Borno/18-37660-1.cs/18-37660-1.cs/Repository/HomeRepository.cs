using _18_36449_1.cs.Entities;
using _18_36449_1.cs.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_36449_1.cs.Repository
{
    class HomeRepository: IRepository<EventEntity>, IDisposable
    {
        DataAccess db = new DataAccess();
        SqlDataReader reader;

        public bool Insert(EventEntity evnt)
        {
            string sql = "Insert Into Events values('"+evnt.Date+ "','" + evnt.Title + "','"+evnt.ModDate+"','" + evnt.Importance+"','"+evnt.Description+"')";
           
            int result = db.ExecuteQuery(sql);

            if (result > 0)
            {
                
                return true;
            }
            else
            {
               
                return false;
            }
        }
        public bool Update(EventEntity evnt)
        {
            string sql = "Update Events Set ModDate='"+evnt.Date+"',Importance='"+evnt.Importance+"',Description='"+evnt.Description+"' Where Title='"+evnt.Title+"'";
            int result = db.ExecuteQuery(sql);

            if (result > 0)
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        public EventEntity Get(EventEntity evnt)
        {
            string sql = "Select * From Events Where Title='"+evnt.Title+"'";
           
            reader = db.GetData(sql);

            if (reader.Read())
            {
                evnt.Date = reader["Date"].ToString();
                evnt.Title = reader["Title"].ToString();
                evnt.Importance = reader["Importance"].ToString();
                evnt.Description = reader["Description"].ToString();
                evnt.ModDate = reader["ModDate"].ToString();
                db.Dispose();
                return evnt;
            }
            else
                return null;

        }

        public bool Delete(EventEntity evnt)
        {
            string sql = "Delete From Events Where Title='"+evnt.Title+"'";
            //db = new DataAccess();
            int result = db.ExecuteQuery(sql);
            if (result > 0)
            {
                //db.Dispose();
                return true;
            }
            else
            {
                //db.Dispose();
                return false;
            }
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<EventEntity> GetAll()
        {
            string sql = "Select * From Events";
            reader = db.GetData(sql);
            List<EventEntity> allEvents = new List<EventEntity>();
            while(reader.Read())
            {
                EventEntity eventEntity = new EventEntity();
                eventEntity.Title = reader["Title"].ToString();
                eventEntity.Date = reader["Date"].ToString();
                eventEntity.ModDate = reader["ModDate"].ToString();
                eventEntity.Importance = reader["Importance"].ToString();
                eventEntity.Description = reader["Description"].ToString();

                allEvents.Add(eventEntity);
                
            }
            return allEvents;
        }
    }
}
