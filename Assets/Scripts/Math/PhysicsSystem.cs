using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Particle
{
    public Vector2 pos;
    public Vector2 vel;
    public Vector2 acc;
}

public class PhysicsSystem : MonoBehaviour
{
    public GameObject prefab;

    // Single object
    //Particle particle = new Particle();
    //GameObject particleGO;
    
    // Multiple objects
    List<Particle> particles = new List<Particle>();    // Physics
    List<GameObject> objects = new List<GameObject>();  // Rendering

    void Add(Particle particle)
    {
        particles.Add(particle);
        objects.Add(Instantiate(prefab));
    }

    private void ResetParticles()
    {
        for (int i = 0; i < 10; i++)
        {
            Particle particle = particles[i];
            particle.pos = Vector2.zero;
            particle.vel = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            particle.acc = Physics.gravity;
        }
    }

    void Start()
    {
        // Single object
        //particleGO = Instantiate(prefab);
        //particle.vel = new Vector2(0.0f, 10.0f);
        //particle.acc = Physics.gravity;

        // Multiple objects
        for (int i = 0; i < 10; i++)
            Add(new Particle());
        ResetParticles();
    }

    // pi = 5m, v = 2.5ms, t = 2s
    // pf = pi + v * t
    // pf = 5 + 2.5 * 2 = 10m
    Vector2 Integrate(Vector2 initial, Vector2 change, float t)
    {
        return initial + change * t;
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        for (int i = 0; i < particles.Count; i++)
        {
            Particle particle = particles[i];

            // 1. Add acceleration * time to velocity
            particle.vel = Integrate(particle.vel, particle.acc, dt);

            // 2. Add velocity * time to position
            particle.pos = Integrate(particle.pos, particle.vel, dt);

            // 3. Write position from particle to game object
            objects[i].transform.position = particle.pos;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ResetParticles();
        }
    }
}
