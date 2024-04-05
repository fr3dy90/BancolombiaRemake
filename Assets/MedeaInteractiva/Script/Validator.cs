using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour
{
    [SerializeField] private Transform anchore;

    public Transform GetAnchore()
    {
        return anchore;
    }
}
