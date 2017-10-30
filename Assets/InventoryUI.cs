﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour {
	public Inventory inventory;
	public List<string> items = new List<string>();
	public List<TextMesh> itemNames = new List<TextMesh>();
	public List<TextMesh> itemCount = new List<TextMesh> ();
	public TextMesh nameText;
	public TextMesh countText;
	public GameObject invSpace;
	public Transform thing;
	public List<GameObject> spaces = new List<GameObject>();
	void Start () {
		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
	}
	public void AddItem(string name){
		items.Add (name);
	}
	public void RemoveItem(string name){
		items.Remove (name);
	}
	public void UpdateUI(){
		if (!inventory.active) {
			for (int i = 0; i < itemNames.Count; i++) {
				Destroy (itemNames [i]);
				Destroy (itemCount [i]);
				Destroy (spaces [i]);
			}
			spaces.Clear ();
			itemNames.Clear ();
			itemCount.Clear ();
			CreateInventory ();
			for (int i = 0; i < items.Count; i++) {
				TextMesh newText = Instantiate (countText, new Vector3 (spaces [i].transform.position.x + 0.5f, spaces [i].transform.position.y + 0.5f, spaces [i].transform.position.z), Quaternion.identity);
				print (inventory.inventory [items [i]]);
				newText.text = "" + inventory.inventory [items [i]];
				newText.fontSize = 30;
				itemCount.Add (newText);
				TextMesh newText2 = Instantiate (nameText, spaces [i].transform.position, Quaternion.identity);
				newText2.text = items [i];
				newText2.fontSize = 30;
				itemNames.Add (newText2);
				itemNames [i].transform.SetParent (thing);
				itemCount [i].transform.SetParent (thing);
				spaces [i].transform.SetParent (thing);
			}
		} 
	}
	public void HideInventory(){
		if (!inventory.active) {
			for (int i = 0; i < itemNames.Count; i++) {
				Destroy (itemNames [i]);
				Destroy (itemCount [i]);
				Destroy (spaces [i]);
			}
		}
		inventory.active = true;
	}
	void CreateInventory(){
		int y = 0;
		int x = 0;
		for (int i = 0; i < items.Count; i++) {
			x += 2;
			if(i % 2 == 0){
				y += 2;
				x = 0;
			}
			GameObject obj = Instantiate (invSpace, new Vector3 (thing.transform.position.x + x,thing.transform.position.y + y, 0), Quaternion.identity);
			spaces.Add (obj);
		}
	}
}
