
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks; 
using UnityEngine;

public static class SaveDataPerson  
{
    public static async Task SaveDataAsync(GameObject data, string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using(FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await Task.Run(() => formatter.Serialize(stream,data));
        }
    }
    public static async Task<PersonData> LoadDataAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return await Task.Run(() => formatter.Deserialize(stream)) as PersonData;
            } 
        }
        return null;
    }
}
