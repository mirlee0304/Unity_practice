using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Start is called before the first frame update


    //동물 변수
    public string name;
    public string sound;

    public void PlaySound()
    {
        Debug.Log(name + " : " + sound);
    }
}
