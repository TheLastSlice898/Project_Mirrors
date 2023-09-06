using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody PlayerRB;
    public float PlayerSensitivity = 5;
    public Transform MainCam;

    public GameObject PlayerOBJ;
    public LayerMask layerMask;



    public float JumpHeight;
    // owo
    // owo
    void Start()
    {
        PlayerRB = gameObject.GetComponent<Rigidbody>();
        MainCam = Camera.main.gameObject.transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        Vector3 PlayerInput = new Vector3(MoveX, 0f, MoveZ);

        Vector3 PlayerForce = PlayerInput * PlayerSensitivity;


        if (PlayerInput.magnitude >= 0.1f)
        {
            float Targetangle = Mathf.Atan2(PlayerInput.x, PlayerInput.z) * Mathf.Rad2Deg + MainCam.eulerAngles.y;
            PlayerOBJ.gameObject.transform.rotation = Quaternion.Euler(0f, Targetangle, 0f);


            Vector3 MoveDir = Quaternion.Euler(0f, Targetangle, 0f) * Vector3.forward;
            PlayerRB.velocity = new Vector3((MoveDir.x * PlayerSensitivity), PlayerRB.velocity.y, (MoveDir.z * PlayerSensitivity));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRB.velocity = new Vector3(PlayerRB.velocity.x, JumpHeight, PlayerRB.velocity.z);
        }




        Debug.DrawRay(MainCam.transform.position, MainCam.forward);

        
        
        RaycastHit HitData;

        if (Physics.Raycast(MainCam.transform.position, MainCam.forward, out HitData, 10f, layerMask))
        {
            GameObject @object = HitData.collider.gameObject;

            if (@object.GetComponent<ItemSelect>() == true)
            {
                @object.GetComponent<ItemSelect>().IsSelected = true;
                @object.GetComponent<ItemSelect>().SetTimer();

                
            }

        }
        else
        {
            Debug.Log("Not Interactable");
        }
        
        

        
        

        
    }
}
