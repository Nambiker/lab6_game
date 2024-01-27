using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public GameObject panelEndGame, PanelWinGame;
    public GameObject effectPartical;
    public float moveSpeed = 5f;
    int coinInLevel = 5;
    int coin = 0;
    public Text txtCoin, poin;


    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Instantiate(effectPartical, gameObject.transform);
       
    }
 

    public void Jump()
    {
        Debug.Log("Vao ham Jump");
        rigidbody2D.AddForce(Vector2.up * 6, ForceMode2D.Impulse);


    }
    void MoveCharacter(float direction)
    {
        Vector2 movement = new Vector2(direction, 0f);
        rigidbody2D.velocity = new Vector2(movement.x * moveSpeed, rigidbody2D.velocity.y);
    }
    // Gọi từ nút button bên trái
    public void MoveLeft()
    {
        MoveCharacter(-1f);
    }

    // Gọi từ nút button bên phải
    public void MoveRight()
    {
        MoveCharacter(1f);
    }
    public void RestartGame()
    {
        panelEndGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "obstacles")
        {
            panelEndGame.SetActive(true);
            Time.timeScale = 0;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coin++;
            Destroy(collision.gameObject);
            txtCoin.text ="Coin " +coin.ToString();
            poin.text ="Score " +coin.ToString();
            // Kiểm tra nếu đã ăn hết vàng
            if (coin >= coinInLevel)
            {
                WinGame();
            }
        }
    }
    void WinGame()
    {
        PanelWinGame.SetActive(true);
        Time.timeScale = 0;
        txtCoin.enabled = false;
       
    }
    public void LoadNextLevel()
    {
        // Lấy index của màn chơi hiện tại
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Chuyển đến màn chơi tiếp theo (cộng thêm 1 vào index)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {

    }

}
