/*Starting Final Project today
Specifications are in Canvas
Prof. Runyan will not be in class today
*/ 

/*
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class AddImages : MonoBehaviour {

	List<Texture2D> images;
	List<GameObject> signs;

	void Start() {
		// create 1000 cubes for signs
		signs = new List<GameObject>(1000);

		// take .targa files from textures folder and put them in a List
		DirectoryInfo dir = new DirectoryInfo("Assets/Materials/GameGraphics");
		FileInfo[] files = dir.GetFiles(".");
		foreach (FileInfo file in files) {
			images.Add(file);
		} 

		// assign boxes the textures in the folder.
		for(int i = 0; i < signs.Count; i++) {
			signs[i].GetComponent<Renderer>().material = images[i];
			// assigns position of cube, every 100 it adds
			for(int j = 0; i < 100; j++){
				signs[i].transform.position = new Vector3(i, j, 0);
			}
		}
	}
}
*/