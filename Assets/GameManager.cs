using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    public bool Parent;
    public bool OverStim;
    public bool Social;
    public bool MindFog;
    public bool Iso;
    public bool Loss;
    public bool Breaking;
    public bool Accept;

    private static GameManager _GayManager;
    public static GameManager GayManager { get { return _GayManager; } }

    // looks to see if theres not already a event bus if there is it Destroy itself
    private void Awake()
    {
        if (_GayManager != null && _GayManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _GayManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetOverStim()
    {
        OverStim = true;
    }



}
