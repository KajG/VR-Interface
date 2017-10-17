using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public Dictionary<string, int> inventory = new Dictionary<string, int>();
	public int numb;
	public string word;
	public ItemDatabase itemdatabase;
	public InventoryUI inventoryui;
	void Start () {
		itemdatabase = GameObject.Find ("Main Camera").GetComponent<ItemDatabase> ();
		inventoryui = GameObject.Find ("Main Camera").GetComponent<InventoryUI> ();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			if (inventory.ContainsKey (word)) {
				inventory [word] += numb;
			} else {
				inventory.Add (word, numb);
				inventoryui.AddItem (word);
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			if (CheckItem ()) {
				Instantiate (itemdatabase.GetItemObject (word), new Vector3 (0, 0, 0), Quaternion.identity);
				inventory [word]--;
				if (inventory [word] <= 0) {
					inventory.Remove (word);
					inventoryui.RemoveItem (word);
				}
			}
		}
	}
	public bool CheckItem(){
		if (inventory.ContainsKey (word)) {
			return true;
		} else {
			return false;
		}
	}
}
