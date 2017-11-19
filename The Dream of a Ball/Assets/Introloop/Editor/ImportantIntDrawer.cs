/* 
/// Copyright (c) 2015 Sirawat Pitaksarit, Exceed7 Experiments LP 
/// http://www.exceed7.com/introloop
*/

using UnityEditor;
using UnityEngine;
using System;

[CustomPropertyDrawer (typeof(ImportantIntAttribute))]
public class ImportantIntDrawer : PropertyDrawer
{
	
	public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
	{
		ImportantIntAttribute attr = (ImportantIntAttribute)attribute;
		string modifiedLabel = label.text;
		if(attr.unit != null)
		{
			modifiedLabel += " (" + attr.unit +  ")";
		}
		
        Rect positionUse = position;
		EditorGUI.BeginChangeCheck();

        positionUse.width = position.width/7f*5;

		int val = EditorGUI.IntField(positionUse,modifiedLabel, prop.intValue);

        positionUse.width = position.width/7f*1;
        positionUse.x = position.x + position.width/7f*5;

        if(GUI.Button(positionUse,"-"))
        {
            val -= attr.stepSize;
        }

        positionUse.width = position.width/7f*1;
        positionUse.x = position.x + position.width/7f*6;
        if(GUI.Button(positionUse,"+"))
        {
            val += attr.stepSize;
        }

		if(EditorGUI.EndChangeCheck())
		{
			if(val < 0)
            {
				val = 0;
            }
			prop.intValue = val;
		}
	}

}
