//Importing Unity Extensions
using System;
using UnityEngine;
using UnityEngine.UI;


//Class
public class Terminal : MonoBehaviour
{
    //UI info
    public GameObject WholeUI;
    public GameObject ResourceUI;
    public GameObject HomeStoreUI;
    public GameObject StoreUI;
    public GameObject infoUI;

   //Close Button
    public Button btnStore;
    public Button close;

    //Player info
    public GameObject playerCamera;
    public GameObject playerMovement;

    //audio 
    public AudioSource audioSource;

    public AudioClip OpenSound;
    public AudioClip CloseSound;



    //Runs when script is turned on
    void OnEnable()
    {

        audioSource.PlayOneShot(OpenSound);

        //Checking if canvas is enabled
        if (WholeUI != null && WholeUI.activeSelf)
        {
            if (playerCamera != null)
            {
                //If the player and the canvas are active locking the mouse
                FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();
                if (Look != null)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Look.sensitivity = 0;
                }
            }

            //Locking player movement
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


    //When disabled
    void OnDisable()
    {

        //Setting the senstivity back to normal
        if (playerCamera != null)
        {
            FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();
            if (Look != null)
            {
                Look.sensitivity = 2;

            }
        }

        //Updating player movement to normal
        if (playerMovement != null)
        {
            FirstPersonMovement Move = playerMovement.GetComponent<FirstPersonMovement>();
            if (Move != null)
            {
                Move.enabled = true;
            }
        }

        //Setting the mouse to correct size
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Closes menu when run
    public void closeMenu()
    {

        WholeUI.gameObject.SetActive(false);

    }

    //Opens store menu
    public void openStore ()
    {
        StoreUI.gameObject.SetActive(true);
    }

    //Closes store menu
    public void closeStore()
    {
        StoreUI.gameObject.SetActive(false);
    }

    //Opens info tab
    public void openInfo()
    {
        infoUI.gameObject.SetActive(true);
    }

    //Closes info tab
    public void closeInfo()
    {
        infoUI.gameObject.SetActive(false);
    }

    //Closes resource window and re-enables Joemazon
    public void closeResources()
    {
        ResourceUI.gameObject.SetActive(false);
        HomeStoreUI.gameObject.SetActive(true);
    }

    //Opens resource menu and disables Joemazon
    public void openResources()
    {
        ResourceUI.gameObject.SetActive(true);
        HomeStoreUI.gameObject.SetActive(false);
    }

    public void Update()
    {
        audioSource.PlayOneShot(OpenSound);

    }

}