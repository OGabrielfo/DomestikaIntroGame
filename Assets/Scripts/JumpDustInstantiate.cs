using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDustInstantiate : MonoBehaviour
{

    public GameObject prefab;
    public Transform point;
    public float livingTime;

    public void JumpInstantiate()
    {
        GameObject instantiatedJumpObject = Instantiate(prefab, point.position, Quaternion.identity) as GameObject;
        instantiatedJumpObject.transform.localScale = gameObject.transform.localScale;

        if (livingTime > 0f)
        {
            Destroy(instantiatedJumpObject, livingTime);
        }
    }
}
