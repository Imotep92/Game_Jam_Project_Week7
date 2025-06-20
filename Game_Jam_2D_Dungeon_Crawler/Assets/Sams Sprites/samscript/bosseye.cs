using UnityEngine;

public class bosseye : MonoBehaviour
{
   public GameObject injuredeye;
   public int eyehealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eyehealth = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (eyehealth == 0)
        {
            injuredeye.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("beam"))
        {
            eyehealth--;
        }
    }
}
