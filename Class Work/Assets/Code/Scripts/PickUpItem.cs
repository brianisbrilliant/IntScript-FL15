/* Built by Brian Foster Fall 2015 for IN 157
	1. you need to attach the player to the public Transform variable.
	2. the player needs a sphere collider the size of the reach of the player.
	3. the sphere collider needs to be a trigger.
	4. You need to make a tag named "Item" and assign all pick-upable objects that tag.
 */

using UnityEngine;
using System.Collections.Generic;

public class PickUpItem : MonoBehaviour {

	public Transform player;
	public List<Collider> items;
	public int itemCount = 0, currentItem;
	bool pickUp;
	
	// if you press 'Q' it will let go of the last item.
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)) {
			itemCount--;
			ShowCurrentItem(itemCount);
			items[itemCount].transform.parent = null;
			items.RemoveAt(itemCount);
			ShowCurrentItem(itemCount-1);
			itemCount = items.Count;
		}

		// show only 1 item
		if(Input.GetKeyDown(KeyCode.Alpha1))
			ShowCurrentItem(0);
		else if(Input.GetKeyDown(KeyCode.Alpha2))
			ShowCurrentItem(1);
		else if(Input.GetKeyDown(KeyCode.Alpha3))
			ShowCurrentItem(2);
		else if(Input.GetKeyDown(KeyCode.Alpha4))
			ShowCurrentItem(3);
		else 
			Debug.Log("That number is not supported.");
	}

	// this displays a text box saying "Press 'E'".
	/*void OnGUI() {
		if(pickUp) {
			GUI.Box(new Rect(Screen.width/2,Screen.height/2, 75,25), "Press 'E'");
		}
	}*/

	// if an object tagged 'Item' is inside the player sphere collider
	// if the player presses 'E' then it changes the parent to the player and adds the item to a list.
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Item") {
			pickUp = true;
				other.transform.SetParent(player);			// now the object follows the player
				other.transform.localPosition = new Vector3(0.4f,0.4f,1);		// puts the object in front of the player
				other.transform.localRotation = Quaternion.identity;			// makes the object point forward
				if(other.gameObject.name == "Pistol") {
					Debug.Log("Hello Quickdraw!");
					items.Insert(0, other);
				}
				else if(other.gameObject.name == "Sniper") {
					Debug.Log("Hello Headshot!");
					items.Insert(5, other);
				}
				else {
					items.Add(other);
				}							// adds item to list
				ShowCurrentItem(itemCount);					// makes sure item just added is showing
				itemCount = items.Count;					// updates the iterator
		}
	}

	// this turns off the OnGUI text display when the item is outside of the player's reach.
	void OnTriggerExit () {
		pickUp = false;
	}

	public void ShowCurrentItem(int itemNum) {
		currentItem = itemNum;
		// set only 1 item to active.
		for(int i = 0; i < items.Count; i++) {
			if(i == itemNum)
				items[i].gameObject.SetActive(true);
			else
				items[i].gameObject.SetActive(false);
		}
	}
}