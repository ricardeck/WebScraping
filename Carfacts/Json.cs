﻿using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace Carfacts
{
    class Json
    {
        public static string Serializar<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public static T DeSerializar<T>(string json)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            return (T)ser.ReadObject(ms);
        }
    }
}
