using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CityGenerator))]
public class CityGeneratorEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        CityGenerator myScript = (CityGenerator)target;


        GUILayout.Label("City Funcionality", EditorStyles.boldLabel);
        if (GUILayout.Button("Generate City"))
        {
            myScript.DeleteCity();
            myScript.GenerateCity(myScript.perlinNoise);
        }

        if (GUILayout.Button("Delete City"))
            myScript.DeleteCity();

        GUILayout.Label("Enviroment Options", EditorStyles.boldLabel);
        if (GUILayout.Button("Set Day Time"))
            myScript.SetDayTime();

        if (GUILayout.Button("Set Noon Time"))
            myScript.SetNoonTime();

        if (GUILayout.Button("Set Night Time"))
            myScript.SetNightTime();
    }
}
