﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.IO;

namespace TimeExcute.Models
{
    public class JobDemo : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var reportDirectory = string.Format("~/reports/{0}/", DateTime.Now.ToString("yyyy-MM"));
            reportDirectory = System.Web.Hosting.HostingEnvironment.MapPath(reportDirectory);
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            var dailyReportFullPath = string.Format("{0}report_{1}.log", reportDirectory, DateTime.Now.Day);
            var logContent = string.Format("{0}==>>{1}{2}", DateTime.Now, "create new log.", Environment.NewLine);
            File.AppendAllText(dailyReportFullPath, logContent);
            //throw new NotImplementedException();
        }
    }
}