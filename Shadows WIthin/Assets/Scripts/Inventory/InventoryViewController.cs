using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InventoryViewController : MonoBehaviour
{
    [SerializeField] private GameObject _invetoryViewObject;

    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemDescriptionText;

    [SerializeField] private List<ItemSlot> _slots;

    [SerializeField] private ScreenFader _fader;

    private enum State
    {
        menuClosed,
        menuOpen,
    };

    private State _state;

    private void Start()
    {
        Debug.Log(1);
        EventBus.Instance.onPickupItem += OnItemPickedUp;
    }

    private void OnDestroy()
    {
        EventBus.Instance.onPickupItem -= OnItemPickedUp;
    }

    private void OnItemPickedUp(ItemData itemData)
    {
        foreach(var slot in _slots)
        {
           
            Debug.Log("here");
            if (slot.IsEmpty())
            {
                slot._itemData = itemData;
                break;
            }
        }
    }

    public void OnSlotSelected(ItemSlot selectedSlot)
    {
        if(selectedSlot._itemData == null)
        {
            _itemNameText.ClearMesh();
            _itemDescriptionText.ClearMesh();
            return;
        }

        _itemNameText.SetText(selectedSlot._itemData.Name);
        _itemDescriptionText.SetText(selectedSlot._itemData.Description[0]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           if (_state == State.menuClosed)
           {
                Time.timeScale = 0;
                _fader.FadeFromBlack(2, FadeToMenuCallback);
           }
           else if (_state == State.menuOpen)
           {
                Time.timeScale = 1;
                _fader.FadeFromBlack(2, FadeFromMenuCallback);
           }
        }
    }

    private void FadeToMenuCallback()
    {
        _invetoryViewObject.SetActive(true);
        _fader.FadeFromBlack(2, null);
    }

    private void FadeFromMenuCallback()
    {
        _invetoryViewObject.SetActive(false);
        _fader.FadeFromBlack(2, null);
    }
}
