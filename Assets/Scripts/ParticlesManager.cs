using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ParticlesManager : MonoBehaviour
{
   
    public static ParticlesManager Instance {get; private set;}
    [SerializeField] private List<ParticleSystem> list_particles = new List<ParticleSystem>();
    // [SerializeField] private ParticleSystem walkParticles;
    [SerializeField] private ParticleSystem destroyParticles;


    private void Awake()
    {
        if(Instance != null  && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public ParticleSystem PlayWalkParticles(Transform parent){
        var particles = Instantiate(list_particles[Random.Range(0,list_particles.Count)], parent.position, Quaternion.identity, parent);
        return particles;
    }

    public ParticleSystem PlayDestroyParticles(Transform parent) {
        var particles = Instantiate(destroyParticles,parent.position,Quaternion.identity,parent);
        return particles;
    }

}
