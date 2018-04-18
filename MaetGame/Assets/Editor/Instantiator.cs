using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Instantiator {

	static void make(float x, float y, string type)
	{
		if (type.Equals ("Start")) {
			GameObject go1 = PrefabUtility.InstantiatePrefab(Resources.Load("Player2")) as GameObject;
			go1.transform.position = new Vector2 (x+0.5f, y+0.5f);
			go1.transform.localScale = new Vector3 (1, 1, 1);
			return;
		}
		GameObject go = PrefabUtility.InstantiatePrefab(Resources.Load(type)) as GameObject;
		go.transform.position = new Vector2 (x+0.5f, y+0.5f);
		go.transform.localScale = new Vector3 (1, 1, 1);
	}

	static void makeRect(float x, float y, float w, float h, string type){
		int ix = (int)x;
		int iy = (int)y;
		int ih = (int)h;
		int iw = (int)w;
		for (int i = ix; i < ix+iw; i++) {
			for (int j = iy; j < iy+ih; j++) {
				make(i, j, type);
			}
		}
	}

	static void build_level(string path)
	{
		Debug.Log ("Decode level");
		LevelObjects lvlo = JsonUtility.FromJson<LevelObjects> (File.ReadAllText (path));
		EditorSceneManager.NewScene (NewSceneSetup.EmptyScene, NewSceneMode.Single);
		GameObject go1 = PrefabUtility.InstantiatePrefab(Resources.Load("Main Camera")) as GameObject;
		makeRect (-6, -4, 13, 9, "FloorTile");
		foreach(Object b in lvlo.Objects){
			Bounds block = b.Box;
			makeRect (block.X, block.Y, block.W, block.H, b.Type);

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