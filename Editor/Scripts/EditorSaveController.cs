namespace Juanda.SaveSystem.Editor
{
    using UnityEditor;
    public class EditorSaveController
    {
        [MenuItem("Utilities/Save System/Save Progress")]
        public static void SaveGameEditor()
        {
            SaveController.SaveGame();
        }
        [MenuItem("Utilities/Save System/Load Progress")]
        public static void LoadGameEditor()
        {
            SaveController.LoadGame();
        }
        [MenuItem("Utilities/Save System/Delete Progress")]
        public static void DeleteGameEditor()
        {
            SaveController.EraseProgress();
        }
        [MenuItem("Utilities/Save System/Debug Progress")]
        public static void DebugProgressEditor()
        {
            SaveController.DebugJsonStored();
        }
    }
}
