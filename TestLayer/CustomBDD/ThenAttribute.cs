using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer.CustomBDD
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ThenAttribute : Attribute
    {
        public string Text { get; }
        public ThenAttribute(string text) => Text = text;
    }
}
