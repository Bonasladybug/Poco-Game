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

    public GameObject winScreen;
    int winCounter;
    
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Mud " + Mudarea.gameObject.name + "MudPos" + Mudarea.gameObject.transform.position);
        }
        if (winCounter == 3)
        {
            winScreen.SetActive(true);
        }
    }
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
        if (Mudarea != null && Mudarea.GetComponent<mudPositionComponent>().isPlanted == false)
        {
            Mudarea.GetComponent<mudPositionComponent>().isPlanted = true;
            winCounter += 1;
            //Vector3 position = new Vector3(Random.Range(Mudarea.transform.localPosition.x - .975f,  Mudarea.transform.localPosition.x + 0.975f) ,Mudarea.transform.localPosition.y, Random.Range(Mudarea.transform.localPosition.z - 0.325f, Mudarea.transform.localPosition.z + 0.325f));
            GameObject plant = Instantiate(seed, Mudarea.transform.position, Mudarea.transform.rotation);

            //plant.transform.position.x += 300;

            items.Remove(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }            
        }
        else
        {
            Debug.Log("please go to mud area");
        }        
    }
}
