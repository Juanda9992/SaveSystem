using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
namespace Juanda.SaveSystem.Editor
{

    public class SavedValuesEditorWindow : EditorWindow
    {
        private List<TextField> textFieldsList = new List<TextField>();
        private DataSerializer dataSerializer;

        private DataSerializer data1;
        [MenuItem("Utilities/Save System/Open Saved Elements Window")]
        public static void ShowEditorWindow()
        {
            SavedValuesEditorWindow savedValuesEditorWindow = GetWindow<SavedValuesEditorWindow>();
            savedValuesEditorWindow.Show();
        }

        private void SetDataSerializer()
        {
            string json = PlayerPrefs.GetString("SAVE_DATA");
            dataSerializer = JsonUtility.FromJson<DataSerializer>(json);
        }

        private void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            if (dataSerializer == null)
            {
                SetDataSerializer();

                if (dataSerializer == null)
                {
                    Label label = new Label("There is not data saved in the PlayerPrefs!");
                    root.Add(label);
                    return;
                }
            }

            root.Clear();
            for (int i = 0; i < dataSerializer.saveModuleIds.Count; i++)
            {
                //Row that contains both save id and it´s value
                var row = new VisualElement();
                row.style.flexDirection = FlexDirection.Row;


                Label idLabel = new Label(dataSerializer.saveModuleIds[i]);
                idLabel.style.unityFontStyleAndWeight = FontStyle.Bold;

                TextField valueLabel = new TextField();
                valueLabel.value = dataSerializer.saveModuleValues[i];

                textFieldsList.Add(valueLabel);

                row.Add(idLabel);
                row.Add(valueLabel);

                root.Add(row);
            }
            var printButton = new Button(() =>
            {
                SaveFromButton();
            });

            printButton.text = "Save Changes";
            root.Add(printButton);
        }

        private void SaveFromButton()
        {
            for (int i = 0; i < dataSerializer.saveModuleValues.Count; i++)
            {
                dataSerializer.saveModuleValues[i] = textFieldsList[i].value;
            }

            string jsonToSave = JsonUtility.ToJson(dataSerializer);

            PlayerPrefs.SetString("SAVE_DATA", jsonToSave);

            Debug.Log("Changes Saved!");
        }

    }
}