/* Built by Brian Foster Fall 2015 for IN 157
	1. you need to attach the player to the public Transform variable.
	2. the player needs a sphere collider the size of the reach of the player.
	3. the sphere collider needs to be a trigger.
	4. You need to make a tag named "Item" and assign all pick-upable objects that tag.
 */

using UnityEngine;
using System.Collections.Generic;

public class PickUpItemSwitch : MonoBehaviour {

	public Transform player;
	public List<Collider> items;
	public int itemCount = 0, currentItem;
	
	// if you press 'Q' it will let go of the last item.
	void Update () {
		if(Input.anyKey) {
			switch(Input.inputString) {
				case "1":
					ShowCurrentItem(0);
					break;
				case "2":
					ShowCurrentItem(1);
					break;
				case "3":
					ShowCurrentItem(2);
					break;
				case "4":
					ShowCurrentItem(3);
					break;
				case "5":
					ShowCurrentItem(4);
					break;
				default:
					print("You don't have that item!");
					break;
			}	// end of switch statement
		}	// end of if(Input.anyKey)

		if(Input.GetKeyDown(KeyCode.Q)) {
			print("Item dropped!");
			items[currentItem].transform.parent = null;
			items[currentItem] = null;
			ShowCurrentItem(currentItem-1);
			itemCount = items.Count;
		}

		if(Input.GetButtonDown("Fire1")) {
			ShootBullets();
		}

	}	// end of Update()

	// if an object tagged 'Item' enters the player sphere collider
	// then it changes the parent to the p a list.
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Item") {

			other.transform.SetParent(player);								// now the object follows the player
			other.transform.localPosition = new Vector3(0.4f,0.4f,1);		// puts the object in front of the player
			other.transform.localRotation = Quaternion.identity;			// makes the object point forward

			switch(other.gameObject.name) {
				case "Pistol":
					print ("Pistol picked UP");
					items[0] = other;
					currentItem = 0;
					ShowCurrentItem(currentItem);						
					break;
				case "Sniper":
					print ("Sniper picked up");
					items[1] = other;
					currentItem = 1;
					ShowCurrentItem(currentItem);	
					break;
				case "Shotgun":
					print ("BoomStick");
					items[2] = other;
					currentItem = 2;
					ShowCurrentItem(currentItem);	
					break;
				case "Rocket Launcher":
					print ("Rocket Boots!");
					items[3] = other;
					currentItem = 3;
					ShowCurrentItem(currentItem);	
					break;
				case "Minigun":
					print ("Brrrap");
					items[4] = other;
					currentItem = 4;
					ShowCurrentItem(currentItem);	
					break;
				default:
					print("Generic item picked up");
					items.Add(other);
					break;
			}	// end of switch statement
		}	// end of if(tag == item) statement
	}	// end of OnTriggerEnter()


	public void ShowCurrentItem(int itemNum) {
		currentItem = itemNum;
		// set only 1 item to active.
		for(int i = 0; i < items.Count; i++) {
			if(items[i] == null)
				Debug.Log("Nothing here!");
			else if(i == itemNum)
				items[i].gameObject.SetActive(true);
			else
				items[i].gameObject.SetActive(false);
		}
	}	// end of ShowCurrentItem()

	void ShootBullets() {
		items[currentItem].GetComponent<Instantiate>().Shoot();
		   
	}	// end of ShootBullets()
}	// end of file