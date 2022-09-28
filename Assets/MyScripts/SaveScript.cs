using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int pchar = 0;
    public static string pname = "player";


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Debug.Log("Name" + pname);
    }
}
