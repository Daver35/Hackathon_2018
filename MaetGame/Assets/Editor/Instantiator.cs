using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Instantiator {

	static GameObject make(float x, float y, string type)
	{
		Object.Instantiate(Resources.Load(type), new Vector2(x,y), Quaternion.identity);
	}	

	static void build_level(string path)
	{
		LevelObjects lvlo = JsonUtility.FromJson<LevelObjects> (File.ReadAllText (path));

		foreach(Box b : lvlo.Object){
			make(b.box_bounds.x, b.box_bounds.y, b.type);
		}

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
