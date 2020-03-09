using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.NET
{
    class IndexException : ArgumentException // класс Exception, используется когда индекс массива выходит за область определения
    {
        public IndexException(string str, Exception inner) : base(str, inner) { }
        public IndexException(string message) : base(message) { }
    }
}
