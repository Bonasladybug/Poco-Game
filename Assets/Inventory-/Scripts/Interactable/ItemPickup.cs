using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUP();
    }

    void PickUP()
    {        
        Debug.Log("Picking Up " + item.name);
        bool wasPickedUp = Inventory.instance.add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }

    //activate/deactivate selection icon on mouse over
    private void OnMouseOver()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
