using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro; // Assuming you're using TextMeshPro
using System.Collections.Generic;

public class ButtonRenameManager : MonoBehaviour
{
    public GameObject inputFieldPrefab;
    public List<Button> buttons;

    private void Start()
    {
        // Add EventTriggers to all buttons in the list
        foreach (Button button in buttons)
        {
            AddEventTriggerToButton(button);
        }
    }

    private void AddEventTriggerToButton(Button button)
    {
        EventTrigger eventTrigger = button.gameObject.AddComponent<EventTrigger>();

        // Create an entry for the right-click event
        EventTrigger.Entry rightClickEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        rightClickEntry.callback.AddListener((data) => OnRightClick((PointerEventData)data, button));

        eventTrigger.triggers.Add(rightClickEntry);
    }

    private void OnRightClick(PointerEventData eventData, Button button)
    {
        // Check if the right mouse button was clicked
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Instantiate the input field at the button's position
            GameObject inputFieldObject = Instantiate(inputFieldPrefab, button.transform.position, Quaternion.identity, button.transform.parent);
            TMP_InputField inputField = inputFieldObject.GetComponent<TMP_InputField>();

            // Set the input field's text to the current button's text
            inputField.text = button.GetComponentInChildren<Text>().text;

            // Add a listener to handle when the input field ends editing
            inputField.onEndEdit.AddListener(delegate { OnEndEdit(inputField, button); });

            inputField.ActivateInputField();
        }
    }

    private void OnEndEdit(TMP_InputField inputField, Button button)
    {
        // Update the button's text with the input field's text
        button.GetComponentInChildren<Text>().text = inputField.text;

        // Destroy the input field after editing is done
        Destroy(inputField.gameObject);
    }
}
