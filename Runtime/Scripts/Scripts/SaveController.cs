using UnityEngine;
namespace Juanda.SaveSystem
{
    public class SaveController : MonoBehaviour
    {
        public static SaveManager saveManager = new SaveManager();

        [ContextMenu("Save Game")]
        public static void SaveGame()
        {
            saveManager.SaveGame();
        }
        [ContextMenu("Load Game")]
        public static void LoadGame()
        {
            saveManager.LoadGame();
        }
        [ContextMenu("Erase Progress")]
        public static void EraseProgress()
        {
            PlayerPrefs.DeleteAll();
        }

        [ContextMenu("Debug Json")]
        public static void DebugJsonStored()
        {
            string json = PlayerPrefs.GetString("SAVE_DATA","");

            if(string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("There is not json stored!");
                return;
            }

            Debug.Log(json);
        }
}
}
