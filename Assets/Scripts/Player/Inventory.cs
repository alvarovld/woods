using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using model;
public class Inventory
{
    Dictionary<string, Item> objectMap;

    private static Inventory instance = null;

    private Inventory()
    {
        objectMap = new Dictionary<string, Item>();
    }

    public static Inventory GetInstance()
    {
        if (instance == null)
        {
            instance = new Inventory();
        }
        return instance;
    }

    public void add(GameObject obj)
    {
        Item item = new Item(obj);
        objectMap.Add(obj.name, item);
    }

    public Item get(string name)
    {
        return objectMap[name];
    }

    public Dictionary<string, Item>  getObjectMap()
    {
        return objectMap;
    }

}
