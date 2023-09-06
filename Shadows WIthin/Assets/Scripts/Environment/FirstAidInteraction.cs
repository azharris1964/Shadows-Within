using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidInteraction : MonoBehaviour
{

    [SerializeField] private ItemData _requiredItem;
    //private Renderer _renderer;

    private void Awake()
    {
        //_renderer.GetComponent<Renderer>();
    }

    private void Start()
    {
        EventBus.Instance.onItemUsed += OnItemUsed;

    }

    private void OnDestroy()
    {
        EventBus.Instance.onItemUsed -= OnItemUsed;

    }

    private void OnItemUsed(ItemData item)
    {
        if (item == _requiredItem)
        {
            //_renderer.material.color = new Color(0, 0, 0, 1);
        }
    }
}
