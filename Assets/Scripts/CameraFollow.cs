using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform target; // Об'єкт, за яким слідує камера (наш персонаж)
    public float smoothSpeed = 0.125f; // Швидкість згладження
    public Vector3 offset; // Відступ камери від персонажа
    public float followLimit = 55f; // Межа слідування камери

    public void FollowPlayer()
    {
        // Умова для перевірки, чи камера має слідувати
        if (target.position.x <= followLimit)

        {
            Vector3 desiredPosition = target.position + offset; // Позиція, до якої повинна переміститися камера
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // Згладжена позиція камери
            transform.position = smoothedPosition; // Встановлюємо нову позицію камери
        }

    }
}