
using UnityEngine;


public class Key : MonoBehaviour
{
    // index of key
    public int keyIndex;






    // 2D trigger callback. For 3D, rename this to OnTriggerEnter(Collider other)
    /*private void OnTriggerEnter2D(Collider2D collidingObject)
    {

        if (col)
        {

        }










        /*if (!other.CompareTag("Player"))
            return;

        // e.g. "Key2" → "Door2"
        string doorName = gameObject.name.Replace("Key", "Door");
        GameObject door = GameObject.Find(doorName);

        if (door != null)
        {
            // Try opening via Animator
            Animator anim = door.GetComponent<Animator>();
            if (anim != null)
                anim.SetTrigger("Open");
            else
                door.SetActive(false);  // fallback
        }

        Destroy(gameObject);  // remove the key
    }*/


} // end of class
