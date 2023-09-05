using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    private FirstPersonController firstPersonController;
    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public bool isInventory = false;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private KeyCode inventoryKey = KeyCode.Tab;
    [SerializeField] private GameObject par_Scene;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject InventoryUI;

    private void Start()
    {
        UnpauseGame();
    }

    void Awake()
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }

    public void UnpauseGame()
    {
        isPaused = false;
       // isInventory = false;

        par_Scene.transform.GetChild(0).gameObject.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstPersonController.CanMove = true; 

    }

    public void PauseWithoutUI()
    {
        firstPersonController.CanMove = false; // Stop movement

        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PauseWithUI()
    {
        PauseWithoutUI();
        par_Scene.transform.GetChild(0).gameObject.SetActive(true);

    }

    public void OpenInventory()
    {
        firstPersonController.CanMove = false;
        isInventory = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        par_Scene.transform.GetChild(2).gameObject.SetActive(true);

    }

    public void CloseInventory()
    {
        isInventory = false;

        par_Scene.transform.GetChild(2).gameObject.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstPersonController.CanMove = true;
    }

    private void Update()
    {
        if (!isInventory && Input.GetKeyDown(pauseKey))
        {
           isPaused = !isPaused;
            Debug.Log("The game is paused");
        }

        if (!isPaused && Input.GetKeyDown(inventoryKey))
        {
            isInventory = !isInventory;
            Debug.Log("The inventory is open");
        }



        if (isPaused
            && !PauseUI.activeInHierarchy
            && !InventoryUI.activeInHierarchy)
        {
            PauseWithUI();
        }

        if (isInventory
            && !InventoryUI.activeInHierarchy
            && !PauseUI.activeInHierarchy)
        {
            OpenInventory();
        }

        else if (!isPaused
             && PauseUI.activeInHierarchy)
        {
            Debug.Log("The game is unpaused");
            UnpauseGame();
        }

      else if (!isInventory
             && InventoryUI.activeInHierarchy)
        {
            Debug.Log("The inventory is closed");
            CloseInventory();
        }
    }

    // ... Other pause-related code ...
}
