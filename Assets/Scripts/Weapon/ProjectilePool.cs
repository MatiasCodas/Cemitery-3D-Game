using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public List<GameObject> objPool;

    public void ReturnToPool(GameObject _obj)
    {
		objPool.Add(_obj);
		_obj.SetActive(false);
    }
}
