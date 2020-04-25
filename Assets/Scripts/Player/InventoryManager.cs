using UnityEngine;
using UnityEngine.UI;

using model;
public class InventoryManager : MonoBehaviour
{
    GameObject[] uiButtons;
    Inventory inventory;
    public GameObject inventoryObject;
    public GameObject genericItemGameObject;

    void Awake()
    {
        inventory = Inventory.GetInstance();
    }

    public void addObject(GameObject obj)
    {
        inventory.add(obj);
    }


    public void showInventory()
    {
        uiButtons = GameObject.FindGameObjectsWithTag("UIButtons");
        foreach(GameObject button in uiButtons)
        {
            button.SetActive(false);
        }

        var objectMap = inventory.getObjectMap();
        foreach(var keyValue in objectMap)
        {
            addItemToInventoryView(keyValue.Value);
        }

        inventoryObject.SetActive(true);
    }




    public void add(GameObject obj)
    {
        inventory.add(obj);
    }

    public void hideInventory()
    {
        foreach (GameObject button in uiButtons)
        {
            button.SetActive(true);
        }
        inventoryObject.SetActive(false);
    }

    public void selectLantern()
    {
        GameObject.Find(Dictionary.GameObjects.PLAYER).transform.GetChild(2).GetComponent<Light>().enabled = true;
        hideInventory();
    }



    public void addItemToInventoryView(Item item)
    {
        GameObject obj = Instantiate(genericItemGameObject);
        obj.transform.SetParent(inventoryObject.transform);
        obj.SetActive(true);
        obj.GetComponent<Image>().sprite = item.getSprite();
        obj.name = item.name;
        obj.transform.position = new Vector2(76, 363);
        obj.GetComponent<Button>().onClick.AddListener(delegate { selectLantern(); });
    }    

}
