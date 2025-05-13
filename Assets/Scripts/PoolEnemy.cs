using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] Queue<GameObject> pool = new Queue<GameObject>();
    [SerializeField] List<GameObject> enemys = new List<GameObject>();
    [SerializeField] List<Transform> origins;
    
    private Coroutine changeOfRound;
    private Coroutine createEnemys;
    [SerializeField] int numberOfRounds=1;
    private int poolSize = 7;
    [SerializeField] int numEnemys = 0;
    [SerializeField] float timeOfRound = 50f;
    [SerializeField] int numLimitOfEnemyForRound = 25;
    private UIGame uIGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddToPool(poolSize);
        changeOfRound = StartCoroutine(ChangeOfRounds());
    }

    void AddToPool(int size){
        for(int i = 0; i< size; i++){
            GameObject prefab = enemys[Random.Range(0, enemys.Count)];
            Vector3 currentRotation = prefab.transform.rotation.eulerAngles;
            
            Transform spawnPoint = origins[Random.Range(0, origins.Count)];
            GameObject enemy = Instantiate(
                prefab,
                Vector3.zero,
                prefab.transform.rotation = Quaternion.Euler(currentRotation)
            );
            enemy.SetActive(true);
            pool.Enqueue(enemy);
        }
    }

    void RespawnEnemy(){
        numEnemys++;
        if(pool.Count>0){
         
            GameObject enemy = pool.Dequeue();
            enemy.transform.position = origins[Random.Range(0,origins.Count)].transform.position;
            enemy.SetActive(true);
        }
        else {
            AddToPool(1);
            RespawnEnemy();
        }
        
    }

    public void EnqueEnemy(GameObject enemy){
        enemy.SetActive(false);
        pool.Enqueue(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator CreateEnemys(){
       while(true){
         switch (numberOfRounds){
            case 1 :
                yield return new WaitForSeconds(Random.Range(1.3f,4.2f));
                RespawnEnemy();
                break;
            case 2 :
              yield return new WaitForSeconds(Random.Range(0.8f,3.5f));
              RespawnEnemy();
              break;
            case 3 : 
              yield return new WaitForSeconds(Random.Range(0.8f,2.8f));
              RespawnEnemy();
              break;
            default : 
              yield return new WaitForSeconds(Random.Range(0.6f,1.8f));
              RespawnEnemy();
              break;
            
         }
       }
    }

    private IEnumerator ChangeOfRounds(){
        while (true){
        numEnemys = 0; 
        float startTime = Time.time;

        createEnemys = StartCoroutine(CreateEnemys());
        UIGame.Instance.SetMessageForSeconds($"Ronda {numberOfRounds}",4);
       
        while ((Time.time - startTime) < timeOfRound && numEnemys < numLimitOfEnemyForRound)
        {
            yield return null;
        }

        
        StopCoroutine(createEnemys);
        numberOfRounds++;
        Debug.Log("Pasando a la ronda: " + numberOfRounds);
       
        timeOfRound += 10f; 
        numLimitOfEnemyForRound += 5; 

        yield return new WaitForSeconds(8f);
    }
  }
}
