using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSY_Game
{
    public class Binary_DataManager : MonoBehaviour
    {
        public static void BinaryDataSave<T>(T Data, string path)
        {
            FileStream fileStream = new FileStream(path,FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream,Data);
            fileStream.Close();
        }
        public static T BinaryDataRead<T>(string path)
        {
            if (File.Exists(path))
            {
                FileStream fileStream = new FileStream(path,FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                T value =(T)formatter.Deserialize(fileStream);
                return value;
            }
            return default;
        }
    }
}