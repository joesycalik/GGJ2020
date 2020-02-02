
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EyeController))]
public class EyeControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EyeController mEye = (EyeController)target;

        if(GUILayout.Button("Blink")){
            mEye.Blink();
        }
    }
}
