using UnityEngine;

public class HeroMovementController : MonoBehaviour
{

    [SerializeField] private HeroInputController heroInputController;    

    [SerializeField] private float forwardmovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalMovementLimit;
    

    private float newPositionX;
    void FixedUpdate()
    {
        SetForwardMovementSpeed();
        SetHorizontalMovement();    
    }

    private void SetForwardMovementSpeed()
    {
        transform.Translate(Vector3.down * forwardmovementSpeed * Time.fixedDeltaTime);
    }

    private void SetHorizontalMovement()
    {
        newPositionX= transform.position.x + heroInputController.HorizontalValue() * horizontalMovementSpeed * Time.fixedDeltaTime;
       // newPositionX = Mathf.Clamp(newPositionX, horizontalMovementLimit, horizontalMovementLimit);

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

}