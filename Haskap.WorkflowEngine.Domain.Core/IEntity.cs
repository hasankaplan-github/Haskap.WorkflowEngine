﻿using Haskap.DddBase.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core
{
    public interface IEntity : IEntity<Guid>
    {
    }
}
