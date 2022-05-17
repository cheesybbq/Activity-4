using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIModel.Models;

namespace APIModel.Controllers
{
    public class ScheduleController : ApiController
    {
        //CRUD - Create, Read, Update, Delete against our DB
        public IEnumerable<Schedule> GetAllSchedule()
        {
            IPTEntities dbcontext = new IPTEntities();
            var schedules = dbcontext.Schedule;
            return schedules;
        }

        public void PostSchedule(Schedule model)
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
            dbcontext.SaveChanges();
        }
        public void Put(string id, Schedule model)
        {
            IPTEntities dbcontext = new IPTEntities();
            var schedule = dbcontext.Schedule.Where(m => m.ScheduleId == id).FirstOrDefault();
            schedule.Subject = model.Subject;
            schedule.Days = model.Days;
            schedule.Time = model.Time;
            schedule.Room = model.Room; 
            schedule.Teacher = model.Teacher;
            dbcontext.SaveChanges();
        }

        public void Delete(string id)
        {
            IPTEntities dbcontext = new IPTEntities();
            var schedule = dbcontext.Schedule.Where(m => m.ScheduleId == id).FirstOrDefault();
            dbcontext.Schedule.Remove(schedule);
            dbcontext.SaveChanges();
             
        }
        
    }
}
