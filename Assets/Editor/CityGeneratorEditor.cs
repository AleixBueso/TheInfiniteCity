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
        if (GUILayout.Button("Generate City"))
        {
            myScript.DeleteCity();
            myScript.GenerateCity(myScript.perlinNoise);
        }

        if (GUILayout.Button("Delete City"))
            myScript.DeleteCity();
    }
}
