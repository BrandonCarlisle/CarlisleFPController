using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class FPSPlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Text countText;
    public Text winText;
    public Text timerText;
    public Button restartGame;
    private float timer;
    private bool timerActive;
    private int count;
    private bool won;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    
    public GunController gun;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        timerActive = true;
        won = false;
        count = 0;
        SetCountText();
        winText.text = "";
        timerText.text = "";
        restartGame.gameObject.SetActive(false);

        controller = GetComponent<CharacterController>();
        gun.GunOwner = this;
        //init Object State
        gameObject.transform.position = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
            timer += Time.deltaTime;
        
        int seconds = Mathf.RoundToInt(timer % 60f);
        timerText.text = seconds.ToString();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        // move
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) {
            gun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            gun.isFiring = false;
        }

        if (won) {
            //restart
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(1);
            }
            //menu
            if (Input.GetKeyDown(KeyCode.Q)) {
                SceneManager.LoadScene(0);
                
            }
        }
    }


    public void addScore(int amt) {
        count++;
        SetCountText();
        CheckWinCondition();       
    }

    void CheckWinCondition()
    {
        if (count > 14)
        {
            winText.text = "You Win Score: " + timerText.text + " Press R to Restart or Q for main menu.";
            timerActive = false;
            won = true;
        }        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
