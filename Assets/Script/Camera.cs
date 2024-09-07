using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 참조
    public float smoothSpeed = 0.125f; // 카메라 이동의 부드러움 정도
    public Vector2 offset; // 플레이어와 카메라 사이의 오프셋

    void LateUpdate()
    {
        // 카메라의 목표 위치를 계산
        Vector2 desiredPosition = (Vector2)player.position + offset;
        // 카메라의 현재 위치에서 목표 위치까지의 부드러운 이동
        Vector2 smoothedPosition = Vector2.Lerp((Vector2)transform.position, desiredPosition, smoothSpeed);
        // 카메라의 위치 업데이트
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}