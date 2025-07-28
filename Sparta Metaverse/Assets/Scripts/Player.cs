using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;
    public float surviveTime = 7f; // ���� ���� �ð�
    private float elapsedTime = 0f; // ���� ���� �ð�
    private bool miniGameEnded = false; // EndMiniGame �ߺ� ȣ�� ����

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager = null;

    void Start()
    {
        gameManager = GameManager.Instance;

        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // ���� �����
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;

            if (!miniGameEnded && elapsedTime >= surviveTime)
            {
                miniGameEnded = true;
                gameManager.EndMiniGame(true, gameManager.GetHighScore()); 
                // ���� ó��
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode || isDead)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;

        if (!miniGameEnded)
        {
            miniGameEnded = true;
            gameManager.EndMiniGame(true, gameManager.GetCurrentScore());
            gameManager.EndMiniGame(false, gameManager.GetCurrentScore()); // ���� ó��
        }
    }
}