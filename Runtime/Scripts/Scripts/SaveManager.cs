using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Juanda.SaveSystem
{
    public class SaveManager
    {
        [SerializeField] private Dictionary<string,string> saveableModulesDictionary = new Dictionary<string,string>();
        [ContextMenu("Save Game")]
        public void SaveGame()
        {
            saveableModulesDictionary.Clear();
            Isaveable[] saveModules = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<Isaveable>().ToArray();
        
            foreach(var module in saveModules)
            {
                saveableModulesDictionary[module.GetModuleID()] = JsonUtility.ToJson(module.GetModuleData()); 
            }

            string saveJson = JsonUtility.ToJson(new DataSerializer(saveableModulesDictionary));

            PlayerPrefs.SetString("SAVE_DATA",saveJson);
            PlayerPrefs.Save();
        }

        public void LoadGame()
        {
            string jsonSaved = PlayerPrefs.GetString("SAVE_DATA");
            Isaveable[] saveModules = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<Isaveable>().ToArray();

            DataSerializer dataSerializer = JsonUtility.FromJson<DataSerializer>(jsonSaved);

            Dictionary<string,string> formatedDictionary = dataSerializer.GetFormatedDataToDictionary();
            foreach(var module in saveModules)
            {
                module.SetModuleValues(formatedDictionary[module.GetModuleID()]);
            }
        }

    }
}
