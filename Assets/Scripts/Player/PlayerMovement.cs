using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public float forwardSpeed = 5f;
    public float laneSpeed = 5f;
    public float laneDistance = 1f;
    public int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    public float targetX;
    public Rigidbody rb;
    private float newX;

    public Vector2 startTouchPosition;
    public Vector2 endTouchPosition;
    public float swipeThreshold = 50f;

    public Animator characterAnim;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentLane = Mathf.Clamp(currentLane, 0, 2);
        targetX=(currentLane - 1) * laneDistance;
    }

    void Update()
    {
        if (GameManager.instance.currentState != GameManager.GameState.Playing)
        {
            return;
        }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            {
                currentLane--;
                targetX = (currentLane - 1) * laneDistance;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
            {
                currentLane++;
                targetX = (currentLane - 1) * laneDistance;
            }

            if (Input.GetMouseButtonDown(0))
            {
                startTouchPosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                endTouchPosition = Input.mousePosition;
                float deltaX = Mathf.Abs(endTouchPosition.x - startTouchPosition.x);
                float deltaY = Mathf.Abs(endTouchPosition.y - startTouchPosition.y);

                if (deltaX > swipeThreshold && deltaX > deltaY)
                {
                    if (endTouchPosition.x < startTouchPosition.x)
                    {
                        if (currentLane > 0)
                        {
                            currentLane--;
                            targetX = (currentLane - 1) * laneDistance;
                            Debug.Log("Sağa kaydırıldı" + currentLane);
                        }
                        else
                        {
                            Debug.Log("Sağa kaydırılamaz");
                        }
                    }
                    else if (endTouchPosition.x > startTouchPosition.x)
                    {
                        if (currentLane < 2)
                        {
                            currentLane++;
                            targetX = (currentLane - 1) * laneDistance;
                            Debug.Log("Sola kaydırıldı" + currentLane);
                        }
                        else
                        {
                            Debug.Log("Sola kaydırılamaz");
                        }
                    }
                }
                else
                {
                    Debug.Log("Geçersiz kaydırma");
                }
            }
        if (GameManager.instance.currentState == GameManager.GameState.Playing && forwardSpeed > 0)
        {
            characterAnim.SetFloat("Speed", 1.0f);
        }
        else
        {
            characterAnim.SetFloat("Speed", 0.0f);
        }
    }

    void FixedUpdate()
    {
        newX = Mathf.Lerp(rb.position.x, targetX, laneSpeed * Time.fixedDeltaTime);
        Vector3 currentPosition = new Vector3(newX, rb.position.y, rb.position.z + forwardSpeed * Time.fixedDeltaTime);

        rb.MovePosition(currentPosition); 
    }

    
}