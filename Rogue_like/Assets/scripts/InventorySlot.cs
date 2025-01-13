using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InventorySlot
{
    public ItemData item; // Referencia al ScriptableObject del item
    public int quantity;  // Cantidad del item en este slot

    // Constructor para inicializar el slot
    public InventorySlot(ItemData newItem, int newQuantity)
    {
        item = newItem;
        quantity = newQuantity;
    }

    // M�todo para a�adir cantidad al slot
    public void AddQuantity(int amount)
    {
        quantity += amount;
    }

    // M�todo para restar cantidad del slot
    public void RemoveQuantity(int amount)
    {
        quantity -= amount;
        if (quantity < 0) quantity = 0;
    }
}
