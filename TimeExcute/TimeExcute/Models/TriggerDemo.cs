using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeExcute.Models
{
    public class SchedulerDemo
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<JobDemo>().Build();
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("triggerName", "groupName")
              .WithSimpleSchedule(t =>
                t.WithIntervalInSeconds(5)
                 .RepeatForever())
                 .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}