using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    Student connor = new Student();

    // Start is called before the first frame update
    void Start()
    {
        connor.id = 69420;
        connor.name = "Connor John David Smiley";
        connor.grade = 42.0f;
        connor.age = 25;
        connor.debt = 99999999999999.0f;
        connor.hasJob = true;

        connor.phone = new Phone();
        connor.phone.number = int.MaxValue;
        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
