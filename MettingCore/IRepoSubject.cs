﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCore
{
    public interface IRepoSubject : IRepoGeneric<Subject>
    {
        public Subject getByRefNumber(string refId);
    }
}
