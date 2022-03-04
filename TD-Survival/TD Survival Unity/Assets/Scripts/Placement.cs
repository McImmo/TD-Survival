using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    private int selectedObjectInArray;
    private GameObject currentlySelectedObject;

    [SerializeField]
    private GameObject[] selectableObjects;

    private bool isAnObjectSelected = false;

	void Start ()
    {
        selectedObjectInArray = 0;
	}

	void Update ()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 spawnPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        //Baumodus wird mit e aktiviert
	    if (Input.GetKeyDown("e") && isAnObjectSelected == false)
        {
            currentlySelectedObject = (GameObject)Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
            isAnObjectSelected = true;
        }
        
        //Baumodus wird mit Rechtsklick beendet
        if (Input.GetMouseButtonDown(1) && isAnObjectSelected == true) //Rechtsklick
        {
            Destroy(currentlySelectedObject);
            isAnObjectSelected = false;
            selectedObjectInArray = 0;
        }

        //wenn der Baumodus aktiv ist kann zwischen unterhsciedlichen Gebaeuden hin und ger gescrollt werden
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && isAnObjectSelected == true)
        {
            selectedObjectInArray++;

            if (selectedObjectInArray > selectableObjects.Length - 1)
            {
                selectedObjectInArray = 0;
            }

            Destroy(currentlySelectedObject);
            currentlySelectedObject = (GameObject)Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && isAnObjectSelected == true)
        {
            selectedObjectInArray--;

            if (selectedObjectInArray < 0)
            {
                selectedObjectInArray = selectableObjects.Length - 1;
            }

            Destroy(currentlySelectedObject);
            currentlySelectedObject = (GameObject)Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
        }
    }
}