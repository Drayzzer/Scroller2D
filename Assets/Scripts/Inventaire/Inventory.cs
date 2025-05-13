using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //permet de lister les item de mon inventaire
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(ItemData itemData, int quantity)
    {
        foreach (InventoryItem item in items)
        {
            if (item.data.itemName == itemData.itemName)
            {
                item.data.quantity += quantity;
                return;
            }
        }
        
        items.Add(new InventoryItem { data = itemData });
    }

    public void UseItem(string itemName)
    {
        foreach (InventoryItem item in items)
        {
            if (item.data.itemName == itemName && item.data.quantity > 0)
            {
                item.data.quantity--;
                Debug.Log(itemName + " used");
                return;
            }
        }
        
        Debug.Log("No item found");
    }

    public void DisplayInventory()
    {
        Debug.Log("Inventory displayed");
        foreach (InventoryItem item in items)
        {
            Debug.Log("Item name: " + item.data.itemName + " quantity: " + item.data.quantity);
        }
    }
}
