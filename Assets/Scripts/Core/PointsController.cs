using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public static PointsController Instance;
	public static int points;
	public static int kills;
    private void Awake()
    {
        Instance = this;
    }
}
