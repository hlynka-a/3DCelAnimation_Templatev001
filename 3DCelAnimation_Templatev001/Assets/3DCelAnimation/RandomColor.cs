using UnityEngine;
using System.Collections;

/*	

Class: RandomColor.cs

Purpose:
- assigns random color to materials of children of the gameobject this script is applied to
- only applied to show capabilities of "VisibleFrame.cs" script, can be removed as desired
- colors are only applied to immediate children, not to sub-children or itself

 */

public class RandomColor : MonoBehaviour {

	void Start () {
	
		Color c = Color.white;

		foreach (Transform t in this.transform) {

			int rand = Random.Range (0,8);
			switch (rand)
			{
			case 0:
				c = Color.black;
				break;
			case 1:
				c = Color.blue;
				break;
			case 2:
				c = Color.cyan;
				break;
			case 3:
				c = Color.gray;
				break;
			case 4:
				c = Color.green;
				break;
			case 5:
				c = Color.magenta;
				break;
			case 6:
				c = Color.red;
				break;
			case 7:
				c = Color.yellow;
				break;
			default:
				c = Color.white;
				break;
			}

			if (t.GetComponent<Renderer>() != null)
				t.GetComponent<Renderer>().material.color = c;
		}
	}

}
