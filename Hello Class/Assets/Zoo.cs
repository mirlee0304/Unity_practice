using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal Tom = new Animal();
        Tom.name = "tom";
        Tom.sound = "meow";

        Animal Jerry = new Animal();
        Jerry.name = "jerry";
        Jerry.sound = "skrr";

        Jerry = Tom;
        Jerry.name = "mickie";

        Tom.PlaySound();
        Jerry.PlaySound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
