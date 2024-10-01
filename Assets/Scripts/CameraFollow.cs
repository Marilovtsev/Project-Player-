using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform target; // ��'���, �� ���� ���� ������ (��� ��������)
    public float smoothSpeed = 0.125f; // �������� ����������
    public Vector3 offset; // ³����� ������ �� ���������

    void LateUpdate()
    {
        // ����� ��� ��������, �� ������ �� ��������
        if (target.position.x <= 5) ;

        {
            Vector3 desiredPosition = target.position + offset; // �������, �� ��� ������� ������������ ������
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // ��������� ������� ������
            transform.position = smoothedPosition; // ������������ ���� ������� ������
        }

    }
}