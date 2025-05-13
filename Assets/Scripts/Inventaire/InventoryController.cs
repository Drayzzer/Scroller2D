using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;

    private bool isOpen = false;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);
        }
    }
}
 //a réécrire