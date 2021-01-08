using System;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApi.DbFactorySample.Utilities
{
    public static class StringExtentionMethods
    {
        public static T ToModelFromQueryString<T>(this string queryString)
        {
            var dictionary = HttpUtility.ParseQueryString(queryString);
            var json = JsonConvert.SerializeObject(dictionary.Cast<string>().ToDictionary(key => key, value => dictionary[value]));

            var model = JsonConvert.DeserializeObject<T>(json);

            return model;
        }

        public static string ToJson<T>(this T model)
        {
            return JsonConvert.SerializeObject(model);
        }


    }
}
