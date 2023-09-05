using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryViewController : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryViewObject;
    [SerializeField] private GameObject _contextMenuObject;
    [SerializeField] private GameObject _firstContextMenuOption;

    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemDescriptionText;

    [SerializeField] private List<ItemSlot> _slots;

    [SerializeField] private ItemSlot _currentSlot;

    [SerializeField] private ScreenFader _fader;

    [SerializeField] private List<Button> _contextMenuIgnore;

    

    private enum State
    {
        menuClosed,
        menuOpen,
        contextMenu,
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
        _currentSlot = selectedSlot;
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
                _state = State.menuOpen;
           }
           else if (_state == State.menuOpen)
           {
                Time.timeScale = 1;
                _fader.FadeFromBlack(2, FadeFromMenuCallback);
                _state = State.menuClosed;
            }
           else if(_state == State.contextMenu && Input.GetKeyDown(KeyCode.Escape))
            {
                _contextMenuObject.SetActive(false);
                foreach (var button in _contextMenuIgnore)
                {
                    button.interactable = true;
                }
            }
        }

        // opens context menu
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(_state == State.menuOpen)
            {
                if (EventSystem.current.currentSelectedGameObject.TryGetComponent<ItemSlot>(out var slot))
                {
                    _state = State.contextMenu;
                    _contextMenuObject.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(_firstContextMenuOption);
                    foreach (var button in _contextMenuIgnore)
                    {
                        button.interactable = false;
                    }
                }
            }
        }
    }

    private void FadeToMenuCallback()
    {
        _inventoryViewObject.SetActive(true);
        _fader.FadeFromBlack(2, null);
        
    }

    private void FadeFromMenuCallback()
    {
        _inventoryViewObject.SetActive(false);
        _fader.FadeFromBlack(2, null);
    }
}
