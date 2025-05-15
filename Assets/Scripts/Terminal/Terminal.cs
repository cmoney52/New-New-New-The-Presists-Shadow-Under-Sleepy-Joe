using System;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    public GameObject WholeUI;
    public Button btnStore;
    public GameObject StoreUI;
    public Button close;
    public GameObject playerCamera;
    public GameObject playerMovement;

    void OnEnable()
    {
        if (WholeUI != null && WholeUI.activeSelf)
        {
            if (playerCamera != null)
            {
                FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();
                if (Look != null)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Look.sensitivity = 0;
                }
            }

            if (playerMovement != null)
            {
                FirstPersonMovement Move = playerMovement.GetComponent<FirstPersonMovement>();
                if (Move != null)
                {
                    Move.enabled = false;
                }
            }
        }
    }

    void OnDisable()
    {
        if (playerCamera != null)
        {
            FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();
            if (Look != null)
            {
                Look.sensitivity = 2;
            }
        }

        if (playerMovement != null)
        {
            FirstPersonMovement Move = playerMovement.GetComponent<FirstPersonMovement>();
            if (Move != null)
            {
                Move.enabled = true;
            }
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (playerMovement != null)
        {
            FirstPersonMovement Move = playerMovement.GetComponent<FirstPersonMovement>();
            Move.enabled = true;
        }
            Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Start()
    {
        if (close != null)
        {
            close.onClick.AddListener(closeMenu);
        }

            btnStore.onClick.AddListener(openStore);

    }

    public void closeMenu()
    {
        Debug.Log("Close Menu");
            WholeUI.gameObject.SetActive(false);
        
    }

    public void openStore ()
    {
        Debug.Log("OPENSTORE");
        StoreUI.gameObject.SetActive(true);
    }
    public void closeStore()
    {
        StoreUI.gameObject.SetActive(false);
    }
    
}