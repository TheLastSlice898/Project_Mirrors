using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{


    public bool IsSelected;

    public bool timer;
    public float Timerlength = 0.1f;
    public MeshRenderer Mesh;
    public List<Material> ObjMaterials;
    public List<Material> OrigianlMats;

    public Material OrigianlMat;
    // Start is called before the first frame update
    void Start()
    {
        Mesh = gameObject.GetComponent<MeshRenderer>();
        OrigianlMats.Add(OrigianlMat);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer)
        {
            Timerlength -= Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                GameManager.GayManager.SetOverStim();
            }
        }


        if (Timerlength <= 0f)
        {
            timer = false;
            IsSelected = false;
        }
        else
        {
            IsSelected = true;
        }


        if (IsSelected)
        {
            Mesh.SetMaterials(ObjMaterials);
        }
        else
        {
            Mesh.SetMaterials(OrigianlMats);
        }
    }

    public void SetTimer()
    {
        timer = true;
        Timerlength = 0.1f;
    }

}
