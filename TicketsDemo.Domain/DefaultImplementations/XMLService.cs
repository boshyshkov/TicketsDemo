﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Domain.Interfaces;

namespace TicketsDemo.Domain.DefaultImplementations
{
    public class XMLService : IXMLService

    {
        public string GetXMLPath()
        {
            return "D:\\";
        }
    }
}
