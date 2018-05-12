﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Entities.BLL
{
    [DataContract]
    [KnownType(typeof(UserBLL))]
    public class UserBLL : GlobalUserBLL
    {
        [DataMember]
        public SummaryBLL UserSummary { get; set; }
       
    }
}