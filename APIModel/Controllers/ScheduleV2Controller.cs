using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIModel.Models;

namespace APIModel.Controllers
{
    public class ScheduleV2Controller : ApiController
    {
        //CRUD - Create, Read, Update, Delete against our DB
        public HttpResponseMessage Get()
        {
            IPTEntities dbcontext = new IPTEntities();
            var schedule = dbcontext.Schedule.ToList();
            var response = Request.CreateResponse<List<Schedule>>(HttpStatusCode.Accepted, schedule);
            return response;
        }

        public string Post(Schedule model)
        {
            IPTEntities dbcontext = new IPTEntities();
            Schedule schedule = new Schedule();
            schedule.ScheduleId = model.ScheduleId;
            schedule.Subject = model.Subject;
            schedule.Days = model.Days;
            schedule.Time = model.Time;
            schedule.Room = model.Room;
            schedule.Teacher = model.Teacher;
            dbcontext.Schedule.Add(schedule);
            int x = dbcontext.SaveChanges();
            if(x>0)
            {
                return "Data has been added successfully";
            }
            else
            {
                return "Failed to add the item";
            }
        }
        public string Put(string id, Schedule model)
        {
            IPTEntities dbcontext = new IPTEntities();
            var schedule = dbcontext.Schedule.Where(m => m.ScheduleId == id).FirstOrDefault();
            schedule.Subject = model.Subject;
            schedule.Days = model.Days;
            schedule.Time = model.Time;
            schedule.Room = model.Room;
            schedule.Teacher = model.Teacher;
            int x = dbcontext.SaveChanges();
            if (x > 0)
            {
                return "Data has been updated successfully";
            }
            else
            {
                return "Failed to update the item";
            }
        }

        public string Delete(string id)
        {
            IPTEntities dbcontext = new IPTEntities();
            var schedule = dbcontext.Schedule.Where(m => m.ScheduleId == id).FirstOrDefault();
            dbcontext.Schedule.Remove(schedule);
            int x = dbcontext.SaveChanges();
            if (x > 0)
            {
                return "Data has been deleted successfully";
            }
            else
            {
                return "Failed to delete the item";
            }

        }

    }
}
