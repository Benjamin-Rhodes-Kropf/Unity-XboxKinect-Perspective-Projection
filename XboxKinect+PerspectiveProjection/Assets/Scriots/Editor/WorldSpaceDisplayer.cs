using UnityEditor;
using UnityEngine;

public class WorldSpaceDisplayer : EditorWindow
{
    [MenuItem("Ben Tools/World Space Displayer")]
    public static void Setup()
    {
        var win = GetWindow<WorldSpaceDisplayer>();
        win.titleContent = new GUIContent("World Space!");
    }

    void OnEnable()
    {
        autoRepaintOnSceneChange = true;
    }

    void OnGUI()
    {
        var selected = Selection.activeTransform;
        if (!selected)
        {
            GUILayout.Label("Select something!");
            return;
        }

        // todo: don't use IMGUI / OnGUI / GUILayout! Use UI Toolkit / UIBuilder - https://docs.unity3d.com/Manual/UIBuilder.html
        var pos = selected.position;
        EditorGUILayout.SelectableLabel(pos.x.ToString());
        EditorGUILayout.SelectableLabel(pos.y.ToString());
        EditorGUILayout.SelectableLabel(pos.z.ToString());
    }
}
