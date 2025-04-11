//CPSC 386 Eric May
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UXMLDoc_Script : MonoBehaviour
{
    UIDocument doc;
    // Start is called before the first frame update
    void Start()
    {
        doc = GetComponent<UIDocument>();

        doc.rootVisualElement.Q<Button>("RBtn1").clickable.clicked += () =>
        {
            Debug.Log("Red Button 1 clicked");
        };        
        doc.rootVisualElement.Q<Button>("RBtn2").clickable.clicked += spawnObject;
        doc.rootVisualElement.Q<Toggle>("RedToggle").RegisterValueChangedCallback(ToggleToggled);
    }
    void spawnObject()
    {
        Debug.Log("Red Button 2 clicked");
    }

    //https://docs.unity3d.com/Manual/UIE-Change-Events.html

    void ToggleToggled(ChangeEvent<bool> evt)
    {
        Debug.Log("Toggle Toggled: " + evt.newValue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
