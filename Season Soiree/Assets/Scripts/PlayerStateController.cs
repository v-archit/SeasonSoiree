using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField] private Sprite waterSprite;
    [SerializeField] private Sprite iceSprite;
    [SerializeField] private GameObject UI;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

    private float health;
    private double scale;
    private float defaultHealth;
    private double defaultScale;
    private Vector3 defaultActualScale;

    public Slider healthBar;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();

        health = 100;
        //scale = 0.15;
        scale = 100;

        defaultHealth = health;
        defaultScale = scale;
        defaultActualScale = transform.localScale;
    }

    public void ChangeState(int Season)
    {
        if ((SeasonType)Season == SeasonType.Summer)
        {
            spriteRenderer.sprite = waterSprite;

            // Adjust circle collider to fit shape of water
            circleCollider.offset = new Vector2(0.71f, -2.43f);
            circleCollider.radius = 4.54f;
        }
        else if ((SeasonType)Season == SeasonType.Winter)
        {
            spriteRenderer.sprite = iceSprite;

            // Adjust circle collider to fit shape of ice
            circleCollider.offset = new Vector2(0.55f, -1.58f);
            circleCollider.radius = 5.64f;
        }
    }

    public double getScale()
    {
        return scale;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collide with Obstacle");
            ChangeHealth(-5, -4);
        }

        // If player collides with enemy level restarts
        else if (collision.gameObject.CompareTag("Enemy")) 
        {
            //SceneManager.LoadScene("HouseArea"); 
            UI.GetComponent<UIManager>().ShowDeathMenu();
        }
    }

    public void ChangeHealth(float healthDiff, float scaleDiff)
    {
        //Apply the supplied differences, then ensure they don't exceed the default (max)
        health = Mathf.Clamp(health + healthDiff, 0, defaultHealth);
        scale = System.Math.Min(scale + scaleDiff, defaultScale);

        healthBar.value = health;
        if (health <= 0 || scale <= 0)
        {
            health = 0;
            scale = 0;
            //end state
            //SceneManager.LoadScene("MainMenu");
            // Open the death menu when health reaches 0
            UI.GetComponent<UIManager>().ShowDeathMenu();
        }
        transform.localScale += new Vector3(0.0015f * scaleDiff, 0.0015f * scaleDiff, 0);
        transform.localScale = Vector3.Min(transform.localScale, defaultActualScale);
    }
}
