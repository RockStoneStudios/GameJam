using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    GameObject finish;
    private PoolEnemy poolEnemy;
    Rigidbody rb;
    private ParticleSystem walkParticles;
    private ParticleSystem deadParticles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        poolEnemy = FindAnyObjectByType<PoolEnemy>();
        finish = GameObject.FindWithTag("Finish");
        walkParticles = ParticlesManager.Instance.PlayWalkParticles(transform);
        deadParticles = ParticlesManager.Instance.PlayDestroyParticles(transform);
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
         if(!walkParticles.isPlaying){
            walkParticles.Play();
         }
         rb.MovePosition(rb.position + Vector3.left*speed*Time.fixedDeltaTime);
    }

    void OnMouseDown()
    {
         Debug.Log("Muerto . . .. . ");
        if(!deadParticles.isPlaying){
            Debug.Log("Muerto");
            deadParticles.Play();
        }
        Destroy(gameObject);
    }
}
