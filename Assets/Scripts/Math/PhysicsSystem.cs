using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle
{
    public Vector3 pos;
    public Vector3 vel;
    public Vector3 acc;
}

public class PhysicsSystem : MonoBehaviour
{
    public GameObject particlePrefab;
    List<Particle> particles = new List<Particle>();
    List<GameObject> objects = new List<GameObject>();

    // final = initial + change * time
    Vector3 Integrate(Vector3 initial, Vector3 change, float time)
    {
        // pi = 5m, vi = 2.5m/s, t = 2s
        // pf = 5 + 2.5 * 2 = 10m
        return initial + change * time;
    }

    void Simulate(Particle particle, float dt)
    {
        // 1. Update velocity based on acceleration (vf = vi + a * t)
        particle.vel = Integrate(particle.vel, particle.acc, dt);

        // 2. Update position based on velocity (pf = pi + v * t)
        particle.pos = Integrate(particle.pos, particle.vel, dt);
    }

    // Start is called before the first frame update
    void Start()
    {
        Particle particle = new Particle();
        particle.pos = new Vector3(0.0f, 0.0f, 0.0f);
        particle.vel = new Vector3(0.0f, 10.0f, 0.0f);
        particle.acc = Physics.gravity;

        Add(particle);
    }

    void Add(Particle particle)
    {
        objects.Add(Instantiate(particlePrefab, particle.pos, Quaternion.identity));
        particles.Add(particle);
    }

    //void Remove(Particle particle)
    //{
    //
    //}

    // Runs at the same frequency (50fps by default) regardless of the fps of your game!
    void FixedUpdate()
    {
        for (int i = 0; i < particles.Count; i++)
        {
            Simulate(particles[i], Time.fixedDeltaTime);
        }

        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.position = particles[i].pos;
        }
    }
}
