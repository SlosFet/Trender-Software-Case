using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CurrentOS currentOS;
    private void Awake()
    {
        Instance = this;
    }



}
