using UnityEngine;

public class playeranimation : MonoBehaviour
{
    public bool hasremote;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("up");
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("down");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("right");
        }


    }
            private void OnTriggerEnter2D(Collider2D other)
         {
        if (other.CompareTag("remote"))
        {
            animator.SetBool("hasremote", true);

            hasremote = true;

            Destroy(other.gameObject);
        }
    }
}
