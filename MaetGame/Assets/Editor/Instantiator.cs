using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class Instantiator {

	static void make(float x, float y, string type)
	{
		Debug.Log (type);
		GameObject go = PrefabUtility.InstantiatePrefab(Resources.Load(type)) as GameObject;
		go.transform.position = new Vector2 (x, y);
		go.transform.localScale = new Vector2 (1, 1);
	}	

	static void build_level(string path)
	{
		Debug.Log ("Decode level");
		LevelObjects lvlo = JsonUtility.FromJson<LevelObjects> (File.ReadAllText (path));

		foreach(Object b in lvlo.Objects){
			make(b.Box.X, b.Box.Y, b.Type);
		}

	}

	[MenuItem ("Assets/build_level")]
	public static void action_level(){
		//Debug.Log ("action");
		//Debug.Log (AssetDatabase.GetAssetPath (Selection.activeObject));
		build_level (AssetDatabase.GetAssetPath (Selection.activeObject));
	}



	[System.Serializable]
	private class LevelObjects{
		public List<Object> Objects;
	}

	[System.Serializable]
	private class Object{
		public Bounds Box;
		public string Type;
		public List<Attribute> Attributes;

	}

	[System.Serializable]
	private class Bounds{
		public float X;
		public float Y;
		public float W;
		public float H;
	}

	[System.Serializable]
	private class Attribute{
		public string name;
		public string value;
	}

}
