using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Juanda.SaveSystem;
public class SavedValuesEditorWindow : EditorWindow
{

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
        if (dataSerializer == null)
        {
            Debug.Log(dataSerializer);
            SetDataSerializer();
            return;
        }
        VisualElement root = rootVisualElement;
        for (int i = 0; i < dataSerializer.saveModuleIds.Count; i++)
        {
            var row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            Label idLabel = new Label(dataSerializer.saveModuleIds[i]);

            var column = new VisualElement();
            column.style.flexDirection = FlexDirection.Column;
            TextField valueLabel = new TextField();
            valueLabel.value = dataSerializer.saveModuleValues[i];

            column.Add(valueLabel);

            row.Add(idLabel);
            row.Add(column);



            root.Add(row);
        }
        var printButton = new Button(() =>
        {
            Debug.Log("Pressed");
        });

        printButton.text = "Save Changes";
        root.Add(printButton);
    }

}
