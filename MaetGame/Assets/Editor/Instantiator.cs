using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class Instantiator {

	static void make(float x, float y, string type)
	{
		GameObject go = PrefabUtility.InstantiatePrefab(Resources.Load(type)) as GameObject;
		go.transform.position = new Vector2 (x, y);
	}	

	static void build_level(string path)
	{
		LevelObjects lvlo = JsonUtility.FromJson<LevelObjects> (File.ReadAllText (path));

		foreach(Box b in lvlo.Object){
			make(b.box_bounds.x, b.box_bounds.y, b.type);
		}

	}

	[ContextMenu ("build_level")]
	static void action_level(){
		build_level (AssetDatabase.GetAssetPath (Selection.activeObject));
	}

	[System.Serializable]
	private class LevelObjects{
		public List<Box> Object;
	}

	[System.Serializable]
	private class Box{
		public Bounds box_bounds;
		public string type;
		public List<Attribute> attributes;

	}

	[System.Serializable]
	private class Bounds{
		public float x;
		public float y;
		public float w;
		public float h;
	}

	[System.Serializable]
	private class Attribute{
		public string name;
		public string value;
	}

}
