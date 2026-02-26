using System.Collections.Generic;
namespace Juanda.SaveSystem
{
    [System.Serializable]
    public class DataSerializer
    {
        public List<string> saveModuleIds = new List<string>();
        public List<string> saveModuleValues = new List<string>();

        public DataSerializer(Dictionary<string,string> baseDataToSave)
        {
            foreach(var key in baseDataToSave)
            {
                saveModuleIds.Add(key.Key);
                saveModuleValues.Add(key.Value);
            }
        }

        public Dictionary<string,string> GetFormatedDataToDictionary()
        {
            Dictionary<string,string> dictionaryToReturn = new Dictionary<string, string>();

            for(int i = 0; i< saveModuleIds.Count;i++)
            {
                dictionaryToReturn[saveModuleIds[i]] = saveModuleValues[i];
            }

            return dictionaryToReturn;
        }
    }
}