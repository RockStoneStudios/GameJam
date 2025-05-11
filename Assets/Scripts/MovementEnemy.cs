using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    GameObject finish;
    private PoolEnemy poolEnemy;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        poolEnemy = FindAnyObjectByType<PoolEnemy>();
        finish = GameObject.FindWithTag("Finish");

    }

    private void FixedUpdate() {
       Movement();
    }

    void Update()
    {
        if(transform.position.x < finish.transform.position.x){
             poolEnemy.EnqueEnemy(gameObject);
        }
    }

    void Movement() {
         rb.MovePosition(rb.position + Vector3.left*speed*Time.fixedDeltaTime);
    }
}
