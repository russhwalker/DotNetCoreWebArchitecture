﻿using System;

namespace DotNetCoreWebArchitecture.Core.Models
{
    public class LogEntry
    {
        public int LogEntryId { get; set; }
        public string UserName { get; set; }
        public string Host { get; set; }
        public string IpAddress { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string RequestUrl { get; set; }
        public string FormRequestData { get; set; }
        public DateTime CreateDate { get; set; }
    }
}