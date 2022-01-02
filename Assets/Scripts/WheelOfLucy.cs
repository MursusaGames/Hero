using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WheelOfLucy : MonoBehaviour
{
    public event Action<string> winField;
    [SerializeField] private GameObject pic;
    [SerializeField] private List<GameObject> fields = new List<GameObject>(8);    

    private GameObject currentField;
    private float dystance;
    private float force;
    private Rigidbody rg;
    private bool isRotate;
    private float rgPosZ;
    private float rgPosZDelta;

    private void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
    }
    public void RotateWheel()
    {
        force = UnityEngine.Random.Range(4f, 12f);
        rg.AddTorque(Vector3.forward * force, ForceMode.Impulse);
        Invoke(nameof(RotateOn), 2f);
    }

    private void RotateOn()
    {
        isRotate = true;
    }

    private void WinField()
    {
        winField?.Invoke(currentField.transform.GetChild(0).name);
        Debug.Log(currentField.transform.GetChild(0).name);
    }

    
    private void FixedUpdate()
    {
        if (isRotate)
        {
            rgPosZDelta = rgPosZ - rg.rotation.z;
            if (rgPosZDelta == 0)
            {
                isRotate = false;
                dystance = 100;
                for (int i = 0; i < fields.Count; i++)
                {
                    var currentDystance = Vector3.Distance(pic.transform.position, fields[i].transform.position);
                    if (currentDystance < dystance)
                    {
                        dystance = currentDystance;
                        currentField = fields[i];
                    }
                }
                WinField();

            }
            rgPosZ = rg.rotation.z;
        }
        
    }
}
