using UnityEngine;
using System.Collections;
using System.IO;


public class FileIO : MonoBehaviour
{
	// String Variable
	string filePath;
	string lineRead;
	string data;

	// Array for char data type
	char[] ch;

	// Int values for prefab position
	float xdefault;
	float xVal;
	float zVal;

	StreamReader sReader;

	// Gameobject variable for the floor.
	public GameObject floorPrefab;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start ()
	{
		xVal = xdefault;
		zVal = 0;

		// Setting the file path in the directory
		filePath = Application.dataPath + Path.DirectorySeparatorChar + "Resources" + Path.DirectorySeparatorChar;

		//filePath = Resources.Load ("/Resources/TextFile.txt");
	
		// Read the contents from the text file
		sReader = new StreamReader (filePath+"TextFile.txt");

		// Read all the contents of the file
		data = File.ReadAllText(filePath + "TextFile.txt");

		ch = data.ToCharArray ();

		for (int i = 0; i < ch.Length; i++) 
		{
			if (ch [i] == '0') {
				Instantiate (floorPrefab, new Vector3 (xVal, 0, zVal), Quaternion.identity);
				xVal += 1;
			} 
			else if (ch [i] == 'p') {
				Instantiate (playerPrefab, new Vector3 (xVal, 0.75f, zVal), Quaternion.identity);
				Instantiate (floorPrefab, new Vector3 (xVal, 0, zVal), Quaternion.identity);
				xVal += 1;
			}

			else 
			{
				xVal = xdefault;
				zVal -= 1;
			}
		}

}

}
