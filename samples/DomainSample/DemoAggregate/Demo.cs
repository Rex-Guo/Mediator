using System;
using System.Collections.Generic;
using System.Text;

namespace DomainSample.DemoAggregate
{
    public class Demo
    {
        public Demo(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }
    }
}