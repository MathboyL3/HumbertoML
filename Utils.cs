using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HumbertoML.Utility
{
    public static class Utils
    {
        public static float[] GetRandoms(int length)
        {
            var result = new float[length];
            for(int i = 0; i < length; i++)
                result[i] = Random.Shared.NextSingle() * 2 - 1;
            return result;
        }

        public static void Randomize(float[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Random.Shared.NextSingle() * 2 - 1;
        }

        /// <summary>
        /// Save a object to a file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public static void Save(this object obj, string fileName)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(fileName))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj, obj.GetType());
            }

            //var json = JsonConvert.SerializeObject(obj);
            //File.WriteAllText(fileName, json);
        }

        /// <summary>
        /// Loads a json file;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T Load<T>(this string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });
        }


        public static void Print(this Array arr)
        {
            Console.WriteLine($"[{string.Join(',', arr.Cast<object>())}]");
        }

        public static float[] Maximize(this float[] arr)
        {
            float max = arr.Max();
            return arr.Select(x => x < max ? 0f : 1f).ToArray();
        }

        public static int IndexOf(this float[] arr, float f)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == f)
                    return i;

            return -1;
        }
    }
}
