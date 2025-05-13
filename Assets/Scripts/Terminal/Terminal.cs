using System;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    public GameObject WholeUI;
    public Button close;
    public GameObject playerCamera;
    public GameObject playerMovement;
    

    void OnEnable()
    {
        if (WholeUI.activeSelf)
        {
            FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();
            FirstPersonMovement Move = playerMovement.GetComponent<FirstPersonMovement>();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Look.enabled = false;
            Move.enabled = false;

        }
    }

    void OnDisable()
    {
        if(playerCamera != null)
        {
            FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();
            Look.enabled = true;
        }
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
        close.onClick.AddListener(closeMenu);
    }

    public void closeMenu()
    {
        Debug.Log(" ukjhberjsdmsfudilkjhgb,mx nzcrdwethmf rmbseghrnm ,klcjkhscfgvn hrcm,ebukeryjhdngm,f.)");
        WholeUI.gameObject.SetActive(false);
    }
}