using UnityEngine;

// je pourrais faire sans la fonction enum mais jai préféré le faire pour apprendre et savoir l'utiliser
public enum ItemType
{
    potion,
    
}
[System.Serializable]
public class ItemData
{
    public string itemName;
    public ItemType ItemType;
    public int quantity;
    public int effectAmount;
}

[System.Serializable]
public class InventoryItem
{
    public ItemData data;
}
