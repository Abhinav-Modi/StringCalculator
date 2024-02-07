using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorLib.test
{
    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "1,2", 3 };
            yield return new object[] { "1\n2,3", 6 };
            yield return new object[] { "2,1001", 2 };
            yield return new object[] { "//;\n1;2", 3 };
            yield return new object[] { "//[***]\n1***2***3", 6 };
            yield return new object[] { "//[*][%]\n1*2%3", 6 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
