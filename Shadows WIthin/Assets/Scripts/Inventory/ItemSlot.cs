using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, ISelectHandler
{
    public ItemData _itemData;

    private InventoryViewController _viewController;

    private Image spawnedItemSprite;

    public void OnSelect(BaseEventData eventData)
    {
        _viewController.OnSlotSelected(this);
    }

    private void OnEnable()
    {
        _viewController = FindObjectOfType<InventoryViewController>();
        if (_itemData == null) return;
        spawnedItemSprite = Instantiate<Image>(_itemData.Sprite, transform.position, Quaternion.identity, transform);
    }

    private void OnDisable()
    {
        if (spawnedItemSprite != null)
        {
            Destroy(spawnedItemSprite);
        }
    }

    public bool IsEmpty()
    {
        return _itemData == null;
    }
}
