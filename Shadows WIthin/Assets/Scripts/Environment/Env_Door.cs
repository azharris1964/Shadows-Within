using UnityEngine;

public class Env_Door : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private string doorOpenAnimName, doorCloseAnimName;
    [SerializeField] private GameObject intText;
    [SerializeField] private AudioClip doorOpen, doorClose;

    private void Update()
    {
        Ray ray = new(transform.position, transform.forward);

        if (!Physics.Raycast(ray, 
                             out RaycastHit hit,
                             interactionDistance))
        {
            intText.SetActive(false);
        }
        else
        {
            if (!hit.collider.gameObject.CompareTag("Door")) intText.SetActive(false);
            else
            {
                GameObject doorParent = hit.collider.transform.root.gameObject;
                Animator doorAnim = doorParent.GetComponent<Animator>();
                AudioSource doorSound = hit.collider.gameObject.GetComponent<AudioSource>();
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        doorAnim.ResetTrigger("Open");
                        doorAnim.SetTrigger("Close");
                        doorSound.clip = doorOpen;
                        doorSound.Play();
                    }
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        doorAnim.ResetTrigger("Close");
                        doorAnim.SetTrigger("Open");
                        doorSound.clip = doorClose;
                        doorSound.Play();
                    }
                }
            }
        }
    }
}