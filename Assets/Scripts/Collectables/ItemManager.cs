using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public int fruit;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        fruit = 0;
    }

    public void AddFuits(int amount = 1)
    {
        fruit += amount;
    }
}
