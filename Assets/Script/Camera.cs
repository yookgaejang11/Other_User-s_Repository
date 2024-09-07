using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� ����
    public float smoothSpeed = 0.125f; // ī�޶� �̵��� �ε巯�� ����
    public Vector2 offset; // �÷��̾�� ī�޶� ������ ������

    void LateUpdate()
    {
        // ī�޶��� ��ǥ ��ġ�� ���
        Vector2 desiredPosition = (Vector2)player.position + offset;
        // ī�޶��� ���� ��ġ���� ��ǥ ��ġ������ �ε巯�� �̵�
        Vector2 smoothedPosition = Vector2.Lerp((Vector2)transform.position, desiredPosition, smoothSpeed);
        // ī�޶��� ��ġ ������Ʈ
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}