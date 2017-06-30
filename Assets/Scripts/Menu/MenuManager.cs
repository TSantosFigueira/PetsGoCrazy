using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    public EventSystem eventSystem;
    private GameObject selectedObject;

	void OnEnable ()
    {
        selectedObject = eventSystem.firstSelectedGameObject;
	}
	
	void Update ()
    {
		if(eventSystem.currentSelectedGameObject != selectedObject)
        {
            if (eventSystem.currentSelectedGameObject == null)
                eventSystem.SetSelectedGameObject(selectedObject);
            else
                selectedObject = eventSystem.currentSelectedGameObject;
        }
	}

    public void Sair()
    {
        Application.Quit();
    }
}
