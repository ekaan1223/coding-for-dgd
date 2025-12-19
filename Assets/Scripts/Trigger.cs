using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject triggeredObject;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                triggeredObject.SetActive(true);
            }

        }

       

    }
}
