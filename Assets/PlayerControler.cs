using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody PlayerRB;
    public float PlayerSensitivity = 5;
    public Transform MainCam;
    // Start is called before the first frame update
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
            //transform.rotation = Quaternion.Euler(0f, Targetangle, 0f);


            Vector3 MoveDir = Quaternion.Euler(0f, Targetangle, 0f) * Vector3.forward;
            PlayerRB.velocity = new Vector3(MoveDir.x, PlayerRB.velocity.y, MoveDir.z);
        }



    }
}
