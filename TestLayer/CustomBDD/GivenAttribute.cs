using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer.CustomBDD
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GivenAttribute : Attribute
    {
        public string Text { get; }
        public GivenAttribute(string text) => Text = text;
    }
}
