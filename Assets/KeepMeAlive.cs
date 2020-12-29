using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMeAlive : MonoBehaviour
{
    // Start is called before the first frame update
    public static KeepMeAlive instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
