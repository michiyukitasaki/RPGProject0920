using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int number;
    public bool redMushroom = false;
    public bool purpleMushroom = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(redMushroom)
            {
                if(InventoryItems.redMushrooms == 0)
                {
                    DisplayIcons();
                }

                InventoryItems.redMushrooms++;
                Destroy(gameObject);
            }

            else if (purpleMushroom)
            {
                if (InventoryItems.purpleMushrooms == 0)
                {
                    DisplayIcons();
                }

                InventoryItems.purpleMushrooms++;
                Destroy(gameObject);
            }
            else
            {
                DisplayIcons();
                Destroy(gameObject);
            }          

        }
    }

    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
