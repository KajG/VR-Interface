using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public Dictionary<string, int> inventory = new Dictionary<string, int>();
	public int numb;
	public string word;
	public ItemDatabase itemdatabase;
	public InventoryUI inventoryui;
	public bool active;
	void Start () {
		itemdatabase = GameObject.Find ("Main Camera").GetComponent<ItemDatabase> ();
		inventoryui = GameObject.Find ("Main Camera").GetComponent<InventoryUI> ();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			if (inventory.ContainsKey (word)) {
				inventory [word] += numb;
			} else if (itemdatabase.CheckItem(word)) {
				inventory.Add (word, numb);
				inventoryui.AddItem (word);
			} else {
				return;
			}
			inventoryui.UpdateUI ();
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			if (CheckItem ()) {
				Instantiate (itemdatabase.GetItemObject (word), new Vector3 (-5, 0, 0), Quaternion.identity);
				inventory [word]--;
				if (inventory [word] <= 0) {
					inventory.Remove (word);
					inventoryui.RemoveItem (word);
				}
			}
			inventoryui.UpdateUI ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			if (!active) {
				inventoryui.HideInventory ();
			} else {
				active = false;
				inventoryui.UpdateUI ();
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
