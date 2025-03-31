using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Базова швидкість руху вперед
    public float sideSpeed = 5f; // Швидкість руху в сторони
    public float jumpForce = 7f; // Сила стрибка
    public float boostMultiplier = 2f; // Множник прискорення
    public float boostDuration = 3f; // Час прискорення в секундах

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isBoosting = false;
    private float boostTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material.color = Color.white;
    }

    void Update()
    {
        MoveForward();
        MoveSideways();
        Jump();
        HandleBoost();
    }

    void MoveForward()
    {
        float currentSpeed = isBoosting ? speed * boostMultiplier : speed;

        // Рух вперед і назад
        if (Input.GetKey(KeyCode.UpArrow)) // Вперед
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // Назад
        {
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
        }
    }

    void MoveSideways()
    {
        float move = 0f;
        float currentSideSpeed = isBoosting ? sideSpeed * boostMultiplier : sideSpeed;

        if (Input.GetKey(KeyCode.LeftArrow))  // Рух вліво
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))  // Рух вправо
        {
            move = 1f;
        }

        rb.linearVelocity = new Vector3(move * currentSideSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Гравець у повітрі
        }
    }

    void HandleBoost()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            isBoosting = true;
            boostTime = boostDuration; // Встановлюємо таймер
        }

        if (isBoosting)
        {
            boostTime -= Time.deltaTime; // Зменшуємо час прискорення

            if (boostTime <= 0)
            {
                isBoosting = false; // Вимикаємо прискорення, коли таймер сплив
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Повертаємо можливість стрибати при торканні землі
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Фініш досягнуто!");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Забороняємо стрибати, коли в повітрі
        }
    }
}
