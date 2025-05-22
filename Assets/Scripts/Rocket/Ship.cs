using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class Ship : MonoBehaviour
{
    public onInteract JoniniumScript;
    public GameObject Player;
    public Camera camera;
    public GameObject RocketWHOLE;
    public GameObject Rocket;
    public GameObject JoniniumOutline;
    public GameObject InteractText;
    public AudioSource AudioSource;
    public AudioClip Takeoff;
    public AudioClip JOE;

    private bool isLaunching = false;
    private float launchTimer = 0f;
    public float shakeMagnitude = 0.2f;
    public float shakeTime = 5f;
    private Vector3 originalCameraPos;

    public float acceleration = 2f; 
    public float maxSpeed = 20f;    
    private float currentSpeed = 0f;

    void Start()
    {
        originalCameraPos = camera.transform.localPosition;
    }

    void Update()
    {
        if (isLaunching)
        {
            if (currentSpeed < maxSpeed)
                currentSpeed += acceleration * Time.deltaTime;

            RocketWHOLE.transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);

            if (launchTimer < shakeTime)
            {
                camera.transform.localPosition = originalCameraPos + Random.insideUnitSphere * shakeMagnitude;
            }
            else
            {
                camera.transform.localPosition = originalCameraPos;
            }

            launchTimer += Time.deltaTime;
        }
        else
        {
            camera.transform.localPosition = originalCameraPos;
        }
    }

    public void onInteract()
    {
        if (JoniniumScript.joeLevel == 3)
        {
            Player.gameObject.SetActive(false);
            camera.gameObject.SetActive(true);
            JoniniumOutline.gameObject.SetActive(false);
            InteractText.gameObject.SetActive(false);
            isLaunching = true;
            launchTimer = 0f;
            currentSpeed = 0f;

            var interactable = Rocket.GetComponent<Interactable>();
            
            interactable.enabled = false;

            originalCameraPos = camera.transform.localPosition;

            StartCoroutine(PlayTakeoffThenJoe());
            StartCoroutine(SwitchToEndSceneAfterDelay(15f));
        }
    }

    private IEnumerator PlayTakeoffThenJoe()
    {
        
            AudioSource.PlayOneShot(Takeoff);
            yield return new WaitForSeconds(Takeoff.length);
       
            AudioSource.PlayOneShot(JOE);
        
    }

    private IEnumerator SwitchToEndSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("End");
    }
}