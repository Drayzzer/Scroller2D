using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        ItemData potion = new ItemData
        {
            itemName = "Healing Potion",
            ItemType = ItemType.potion,
            quantity = 3,
            effectAmount = 3
        };
        
        inventory.AddItem(potion, 2);
        
        inventory.DisplayInventory();
        inventory.UseItem("Healing Potion");
        // me permet de regarder l'affichage apres utilisation
        inventory.DisplayInventory();
    }
}