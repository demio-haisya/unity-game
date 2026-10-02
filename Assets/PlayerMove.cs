using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Car Settings")]
    public float speed = 0f;              // 現在の速度
    public float maxSpeed = 30f;          // 最高速度
    public float minSpeed = 8.33f;        //最低速度
    public float acceleration = 15f;      // 加速度
    public float brakePower = 20f;        // ブレーキ
    public float naturalDeceleration = 5f;// アクセルを離した時の減速

    [Header("Steering")]
    public float maxSteerSpeed = 60f;    // 低速時のハンドル
    public float minSteerSpeed = 10f;     // 高速時のハンドル

    [Header("Jump")]
    public float jumpForce = 5f;

    [Header("Camera")]
    public Transform cameraPivot;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (cameraPivot != null)
            cameraPivot.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            // ========= アクセル =========
            if (Keyboard.current.wKey.isPressed)
            {
                speed += acceleration * Time.deltaTime;
            }

            // ========= ブレーキ =========
            if (Keyboard.current.sKey.isPressed)
            {
                speed -= brakePower * Time.deltaTime;
            }

            // ========= 自然減速 =========
            if (!Keyboard.current.wKey.isPressed &&
                !Keyboard.current.sKey.isPressed)
            {
                speed -= naturalDeceleration * Time.deltaTime;
            }

            // 速度制限
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);

            // ========= ハンドル =========
            float steer = 0;

            if (Keyboard.current.aKey.isPressed)
                steer = -1;

            if (Keyboard.current.dKey.isPressed)
                steer = 1;

            // 速度に応じてハンドルを重くする
            float t = speed / maxSpeed;
            float currentSteer =
                Mathf.Lerp(maxSteerSpeed, minSteerSpeed, t);

            transform.Rotate(
                0,
                steer * currentSteer * Time.deltaTime,
                0);

            // ========= カメラ =========
            if (cameraPivot != null)
            {
                if (Keyboard.current.upArrowKey.wasPressedThisFrame)
                    cameraPivot.localRotation = Quaternion.Euler(0, 0, 0);

                if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
                    cameraPivot.localRotation = Quaternion.Euler(0, 90, 0);

                if (Keyboard.current.downArrowKey.wasPressedThisFrame)
                    cameraPivot.localRotation = Quaternion.Euler(0, 180, 0);

                if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
                    cameraPivot.localRotation = Quaternion.Euler(0, 270, 0);
            }

            // ========= ジャンプ =========
            if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        // 常に前進
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}