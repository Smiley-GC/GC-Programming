using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle
{
    public Vector2 pos;
    public Vector2 vel;
    public Vector2 acc;
}

public class PhysicsSystem : MonoBehaviour
{
    public GameObject prefab;
    GameObject particleGO;
    Particle particle = new Particle();

    void Start()
    {
        particleGO = Instantiate(prefab);
        particle.vel = new Vector2(0.0f, 10.0f);
        particle.acc = Physics.gravity;
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

        // 1. Add acceleration * time to velocity
        particle.vel = Integrate(particle.vel, particle.acc, dt);

        // 2. Add velocity * time to position
        particle.pos = Integrate(particle.pos, particle.vel, dt);

        // 3. Write position from particle to game object
        particleGO.transform.position = particle.pos;
    }
}
