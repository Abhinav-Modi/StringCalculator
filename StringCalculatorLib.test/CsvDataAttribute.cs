using System;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace StringCalculatorLib.test
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CsvDataAttribute : DataAttribute
    {
        private readonly string _filePath;
        private readonly bool _hasHeaders;

        public CsvDataAttribute(string filePath, bool hasHeaders = false)
        {
            _filePath = filePath;
            _hasHeaders = hasHeaders;
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            var parameterTypes = parameters.Select(p => p.ParameterType).ToArray();

            using (var csvFile = new StreamReader(_filePath))
            {
                if (_hasHeaders)
                    csvFile.ReadLine(); // Skip header row if present

                string line;
                while ((line = csvFile.ReadLine()) != null)
                {
                    var rowValues = line.Split(',');
                    yield return ConvertParameters(rowValues, parameterTypes);
                }
            }
        }

        private static object[] ConvertParameters(string[] values, Type[] parameterTypes)
        {
            var result = new object[parameterTypes.Length];
            for (var idx = 0; idx < parameterTypes.Length; idx++)
            {
                result[idx] = ConvertParameter(values[idx], parameterTypes[idx]);
            }

            return result;
        }

        private static object ConvertParameter(string value, Type parameterType)
        {
            if (parameterType == typeof(int))
                return int.TryParse(value, out var result) ? result : default(int);

            if (parameterType == typeof(string))
                return value;

            throw new NotSupportedException($"Conversion for type '{parameterType}' is not supported.");
        }
    }
}
