using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;
    bool isInvincible = false;
    float invincibilityDuration = 10f;
    public GameObject Coin;

    [SerializeField]

    Rigidbody2D RB;
    public Text ScoreTxt;
    public AudioSource audioSource;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 2;
            ScoreTxt.text = "SCORE : " + score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            isInvincible = true;
            StartCoroutine(EndInvincibility());
            Destroy(collision.gameObject);

        }

        if (isInvincible && collision.gameObject.CompareTag("Virus"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Virus") && !isInvincible)
        {
            audioSource.Play();
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator EndInvincibility()
    {
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene("MainMenu");
    }
}