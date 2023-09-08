using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TemplateScript))]
public class EditorTemplate : Editor
{
	//variables for GUI elements
	float objectSize = 0.5f;
	float objectRotation = 0;
	float objectXPosition = 0;
	float objectYPosition = 70;


	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

		TemplateScript _templateScript = (TemplateScript)target;   //TemplateScript class object

		if (GUILayout.Button("Save"))  // Button for Save Data
		{
			_templateScript.SaveData();
			GUI.changed = true;
		}
		else if (GUILayout.Button("Load")) // Button for Load Data
		{
			_templateScript.LoadData();
			GUI.changed = true;
		}

		GUILayout.Label("Image Size");
		objectSize = GUILayout.HorizontalSlider(objectSize, 0.0f, 1.0f);                           // Slider for control image size
		_templateScript.SetImageSize(objectSize);

		GUILayout.Space(10);

		GUILayout.Label("Image Rotation");
		objectRotation = GUILayout.HorizontalSlider(objectRotation, 0.0f, 360f);                   // Slider for control image rotation
		_templateScript.SetImageRotation(objectRotation);

		GUILayout.Space(10);

		GUILayout.Space(10);
		GUILayout.Label("Image Position");
		GUILayout.Space(5);
		GUILayout.Label("X position");
		objectXPosition = GUILayout.HorizontalSlider(objectXPosition, -10.0f, 10f);                 // Slider for control image x position
		_templateScript.SetImageXPosition(objectXPosition);
		GUILayout.Space(10);
		GUILayout.Label("Y position");
		objectYPosition = GUILayout.HorizontalSlider(objectYPosition, 40f, 105f);                   // Slider for control image y position
		_templateScript.SetImageYPosition(objectYPosition);


		GUILayout.Space(10);

		if (GUI.changed)
		{
			EditorUtility.SetDirty(_templateScript);
		}
	}
}
