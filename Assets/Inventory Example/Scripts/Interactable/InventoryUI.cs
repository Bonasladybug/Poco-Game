using UnityEngine;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{
    #region Singleton
    //Simple Singleton Pattern
    public static InventoryUI instance;   

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of Inventory");
        }
        instance = this;        
    }
    #endregion

    Inventory inventory;
    public Transform itemsParent;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += updateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
              slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}
