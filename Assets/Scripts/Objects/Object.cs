using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    Student connor = new Student();

    // Classes are passed "by-reference" so modifications will work as intended
    void ChangeNumber(Phone phone)
    {
        phone.number = 69;
    }

    // Structures are passed "by-value" by default, so this WON'T change the number
    void ChangeNumber(Phone2 phone)
    {
        phone.number = 69;
    }

    // We can add the "ref" keyword to pass structures "by-reference" to make them like classes
    void ChangeNumber(ref Phone2 phone)
    {
        phone.number = 69;
    }

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

        Phone phone1 = new Phone();
        Phone2 phone2 = new Phone2();
        Phone2 phone3 = new Phone2();
        ChangeNumber(phone1);
        ChangeNumber(phone2);
        ChangeNumber(ref phone3);

        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
