using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour{
	public List<string> items = new List<string> ();
	public List<GameObject> objects = new List<GameObject> ();
	public GameObject GetItemObject(string name){
		if (items.Contains (name)) {
			int i = items.IndexOf (name);
			return objects [i];
		} else {
			print ("The item: " + name + " could not be found in the inventory");
			return null;
		}
	}
	public bool CheckItem(string name){
		if (items.Contains (name)) {
			return true;
		} else {
			return false;
		}
	}
}
