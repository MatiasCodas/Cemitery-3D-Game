using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> objPool;

    public void ReturnToPool(GameObject _obj)
    {
        objPool.Add(_obj);
    }
}
