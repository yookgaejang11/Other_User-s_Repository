using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public float groundDistance;
    public LayerMask groundMask;
    public bool isGround
    {
        get
        {
            RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundMask.value); //Raycast

            return Hit.transform != null;//유니티에서 값 탐지하는게 있는데 걍 보기편하게 처리한거
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Vector3.down * groundDistance + transform.position);
    }
}