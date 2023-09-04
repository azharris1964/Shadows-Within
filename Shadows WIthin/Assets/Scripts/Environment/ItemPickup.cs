using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;

    [SerializeField] private KeyCode pickupKey = KeyCode.E;

    public void OnTriggerStay(Collider other)
    {

        if (!other.CompareTag("Player")) return;

        if(Input.GetKey(pickupKey))
        {
            EventBus.Instance.PickUpItem(_itemData);
            Destroy(gameObject);
        }

        
    }

}
