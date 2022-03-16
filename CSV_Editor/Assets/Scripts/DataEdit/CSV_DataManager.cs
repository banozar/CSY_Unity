using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

using UnityEngine;
namespace CSY_Game
{
    [System.Serializable]
    public class TestData
    {
        public int ID;
        public string Name;
    }
    public class CSV_DataManager : MonoBehaviour
    {
        public static void CSVDataSave(string[][] data, string path)
        {
            string delimiter = ".";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.AppendLine(string.Join(delimiter, data[i]));
            }
            StreamWriter streamWriter = File.CreateText(path);
            streamWriter.WriteLine(stringBuilder);
            streamWriter.Close();
        }
        public static TestData[] CSVDataRead(string path)
        {
            List<Dictionary<string, object>> da = CSVReader.Read(path);
            TestData[] value = new TestData[da.Count];
            for (int i = 0; i < da.Count; i++)
            {
                value[i] = new TestData();
            }
            return value;
        }
    }
}
