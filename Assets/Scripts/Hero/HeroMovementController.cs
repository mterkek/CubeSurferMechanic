using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private HeroInputController heroInputController;

    [Header("Speeds")]
    [SerializeField] private float forwardMovementSpeed = 5f;
    [SerializeField] private float horizontalMovementSpeed = 5f;

    [Header("Horizontal")]
    [SerializeField] private float horizontalMovementLimit = 2f;
    [SerializeField] private float horizontalSmooth = 12f; // büyüdükçe daha hızlı yakalar (daha az gecikme)

    private float targetX;

    private void Start()
    {
        targetX = transform.position.x;
    }

    private void Update()
    {
        SetForwardMovement();
        SetHorizontalMovementSmooth();
    }

    private void SetForwardMovement()
    {
        // Mavi ok (world forward) her zaman ileri
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.deltaTime, Space.World);
    }

    private void SetHorizontalMovementSmooth()
    {
        // 1) hedef X’i input ile güncelle
        targetX += heroInputController.HorizontalValue() * horizontalMovementSpeed * Time.deltaTime;

        // 2) limit uygula
        targetX = Mathf.Clamp(targetX, -horizontalMovementLimit, horizontalMovementLimit);

        // 3) anlık setlemek yerine hedefe Lerp ile yaklaş
        float newX = Mathf.Lerp(transform.position.x, targetX, horizontalSmooth * Time.deltaTime);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}