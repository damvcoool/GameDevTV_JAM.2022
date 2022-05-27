using UnityEngine;

public class Died : MonoBehaviour
{
    [SerializeField] GameObject BlankScreen;
    private Rigidbody rb;
    private bool Out = false;
    private void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        Out = true;
    }
    private void Update()
    {
        if (Out)
        {
            Out = false;
         BlankScreen.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
