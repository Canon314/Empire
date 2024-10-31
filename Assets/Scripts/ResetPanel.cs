using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPanel : MonoBehaviour
{
    public GameObject resetPanel;

    // Start is called before the first frame update
    void Start()
    {
        resetPanel.SetActive(false);
    }

    public void OpenResetPanel()
    {
        resetPanel.SetActive(true);
    }

    public void CloseResetPanel()
    {
        resetPanel.SetActive(false);
    }
}
