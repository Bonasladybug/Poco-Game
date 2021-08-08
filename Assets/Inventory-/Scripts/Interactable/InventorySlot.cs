using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;

    //public Button removeButton;

    // Start is called before the first frame update
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void clearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //when item is destroyed
        //removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.remove(item);
    }

    public void useItem()
    {
        if(item != null)
        {
            //CharacterStats.instance.addEnergy(item.energy);
            item.Use();
            
        }        
    }
}
