using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Particle
{
    public Vector2 pos;
    public Vector2 vel;
    public Vector2 acc;
    public float age;
}

public class PhysicsSystem : MonoBehaviour
{
    public GameObject prefab;
    List<Particle> particles = new List<Particle>();    // Physics
    List<GameObject> objects = new List<GameObject>();  // Rendering

    float currentTime = 0.0f;
    float totalTime = 1.0f;

    void Add(Particle particle)
    {
        particles.Add(particle);

        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        GameObject obj = Instantiate(prefab);
        obj.GetComponent<SpriteRenderer>().color = new Color(r, g, b);
        objects.Add(obj);
    }

    void Remove(Particle particle)
    {
        int index = particles.IndexOf(particle);
        particles.RemoveAt(index);
        Destroy(objects[index]);
        objects.RemoveAt(index);
    }

    void CreateBatch(Vector2 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Particle particle = new Particle();
            particle.pos = position;
            particle.vel = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            particle.acc = Physics.gravity;
            Add(particle);
        }
    }

    void Start()
    {
        CreateBatch(Vector2.zero, 16);
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
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;
        for (int i = 0; i < particles.Count; i++)
        {
            Particle particle = particles[i];
            objects[i].transform.position = particle.pos;

            particle.age += dt;
            if (particle.age > 2.5f)
                Remove(particle);
        }

        currentTime += dt;
        if (currentTime > totalTime)
        {
            currentTime = 0.0f;
            CreateBatch(new Vector2(Random.Range(-20.0f, 20.0f), Random.Range(-10.0f, 10.0f)), 16);
            totalTime += Random.Range(-0.5f, 0.5f);
            totalTime = Mathf.Max(0.25f, totalTime);
        }
    }
}
