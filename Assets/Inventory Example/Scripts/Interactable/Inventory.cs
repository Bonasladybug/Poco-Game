using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    //Simple Singleton Pattern
    public static Inventory instance;
    public GameObject Mudarea;

    public GameObject seed;


    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of Inventory");
        }
        instance = this;       
    }
    #endregion

    public List<Item> items = new List<Item>();
    public int inventorySpace;

    //delegate other methods can subscribe to
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Full");
                return false; //return bool false if item was not picked up
                
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke(); 
            }
            
        }
        return true;
    }
    public void remove(Item item)
    {
        Vector3 position = new Vector3(Mudarea.transform.position.x+195,Mudarea.transform.position.y + 1 ,Mudarea.transform.position.z-155);
        GameObject plant = Instantiate(seed, position, Mudarea.transform.rotation);
        
        //plant.transform.position.x += 300;

        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
