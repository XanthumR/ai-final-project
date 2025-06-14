
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Birb : MonoBehaviour
{

    InputAction birbHoop;
    private int score = 0;

    [SerializeField] Rigidbody2D rg;
    public GameOverScreen gameOverScreen;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birbHoop = InputSystem.actions.FindAction("Attack");
        rg = GetComponent<Rigidbody2D>();
        birbHoop.performed += BirbHoop_performed;
    }

    private void OnDestroy()
    {
        birbHoop.performed -= BirbHoop_performed;
    }


    private void BirbHoop_performed(InputAction.CallbackContext obj)
    {
        rg.linearVelocity = new Vector2(0f,8f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      GameOver();
    }

    public void GameOver()
    {
        gameOverScreen.Setup(score);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D pipe = Physics2D.Raycast(new Vector2(-5.8f, -3.42f), Vector2.right);


        if (pipe.transform.name == "pipeBody")
        {
            Debug.Log(pipe.transform.parent.parent.position);
        }
    }





    public void UpdateScore() 
    {
        score++;

        scoreText.text = score + " Points";
        Debug.Log(score);
    }
}
