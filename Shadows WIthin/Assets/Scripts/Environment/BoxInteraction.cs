using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoxInteraction : MonoBehaviour
{
    [SerializeField] private ItemData _requiredItem;
    private Renderer boxRenderer;

    private void Awake()
    {
        boxRenderer = GetComponent<Renderer>();
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
        if (Vector3.Distance(FirstPersonController.instance.transform.position, transform.position) < 3)
        {
            if (item == _requiredItem)
            {
                Debug.Log("Item Used");
                boxRenderer.material.color = new Color(1, 0, 0, 0);
            }

        }
        
    }
}
