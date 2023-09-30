using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Inventory : MonoBehaviour
{
    public Item testItem;
    [SerializeField]
    private Item[] inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool AddItem(Item item)
    {
        // TODO: Stack item if applicaple
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                Debug.LogFormat("Adding item {0} to inventory at slot {1}", item.name, i);
                return true;
            }
        }

        Debug.Log("Inventory is full");

        return false;
    }

    bool RemoveItem(int pos)
    {
        if (pos >= inventory.Length || pos < 0)
            return false;


        if (inventory[pos] == null)
        {
            Debug.Log("Nothing to remove");
            return false;
        }

        Item item = inventory[pos];
        inventory[pos] = null;
        Debug.LogFormat("Removing item {0} from inventory at slot {1}", item.name, pos);
        // TODO: Spawn item on ground
        return true;

    }

    bool UseItem(int pos)
    {
        if (pos >= inventory.Length || pos < 0)
            return false;


        if (inventory[pos] == null)
        {
            Debug.Log("Nothing to use");
            return false;

        }
        Item item = inventory[pos];
        inventory[pos] = null;
        item.Use();
        return true;
    }

    bool ReplaceItem(int a, int b)
    {
        if (a >= inventory.Length || a < 0 ||
            b >= inventory.Length || b < 0)
            return false;

        Item itemA = inventory[a];
        inventory[a] = inventory[b];
        inventory[b] = itemA;
        Debug.LogFormat("Swapped items at position {0} and {1}", a, b);
        return true;
    }
}
