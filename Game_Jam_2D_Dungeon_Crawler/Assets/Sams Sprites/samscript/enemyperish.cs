using UnityEngine;

public class enemyperish : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("beam"))
        {
            animator.SetTrigger("perish");

            Destroy(gameObject, 1);
        }
    }
}
