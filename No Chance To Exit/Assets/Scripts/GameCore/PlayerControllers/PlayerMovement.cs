using UnityEngine;


namespace GameCore
{

    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private float speed = 1f;
        [SerializeField] private Animator playerAnimator;


        public void UpdateMovement(InputSystem inputSystem)
        {
            // Move

            float xAxisValue = inputSystem.GetHorizontalInput();
            float yAxisValue = inputSystem.GetVerticalInput();

            transform.position += Vector3.right * xAxisValue * Time.deltaTime * speed;
            transform.position += Vector3.up * yAxisValue * Time.deltaTime * speed;

            if (Mathf.Abs(xAxisValue) > Mathf.Epsilon || Mathf.Abs(yAxisValue) > Mathf.Epsilon)
                playerAnimator.SetInteger("ChangeAnimState", 1);

            // Idle

            else
                playerAnimator.SetInteger("ChangeAnimState", 0);


            // FlipSprite

            if (xAxisValue > 0)
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else if (xAxisValue < 0)
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }
}
