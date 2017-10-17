using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour {

	public Inventory inventory;
	public List<string> items = new List<string>();
	public List<TextMesh> ui = new List<TextMesh>();
	public TextMesh textmesh;
	void Start () {
		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
	}

	public void AddItem(string name){
		items.Add (name);
		UpdateUI ();
	}
	public void RemoveItem(string name){
		items.Remove (name);
		UpdateUI ();
	}
	public void UpdateUI(){
		for (int i = 0; i < ui.Count; i++) {
			Destroy (ui [i]);
		}
		ui.Clear ();
		for (int i = 0; i < items.Count; i++) {
			TextMesh newText = Instantiate (textmesh, new Vector3 (0, i, 0), Quaternion.identity);
			newText.text = items [i];
			ui.Add (newText);
		}
	}
}
