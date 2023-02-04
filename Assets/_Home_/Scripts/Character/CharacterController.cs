using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UtilityMethods;

public class CharacterController : MonoBehaviour
{
    public PortraitGameController portraitController;
    [SerializeField] private float maxLifeLeft = 10f;
    public float lifeLeft;
    public float[] bloodPercentages = new float[4];
    public float maxSpeed;
    [SerializeField] private float speed;
    private Vector2 latestMovementVector;
    private Rigidbody2D characterRigyBody;

    private void FixedUpdate()
    {
        characterRigyBody.velocity = latestMovementVector * maxSpeed;
    }
    private void Update()
    {
        SubstractLife();
    }
    private void Awake()
    {
        characterRigyBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CalculateSpeed();
        lifeLeft = maxLifeLeft;
    }



    public void move(Vector2 v)
    {
        latestMovementVector = Vector2.ClampMagnitude(v.WithY(Mathf.Clamp(v.y, -1, 0)), 1);
    }

    public void SubstractLife()
    {
        lifeLeft -= Time.deltaTime;
        if (lifeLeft <= 0)
        {
            maxSpeed = 0;
            Destroy(this);
            //TODO: Poner el marco en sepia.
        }
    }

    public void CalculateSpeed(float newSpeed = -1)
    {
        if (newSpeed < 0)
        {
            float highestBloodPercentage = GetHighestBloodPercentage();
            if (highestBloodPercentage > 0.5f)
            {
                speed = maxSpeed * Math.Remap(highestBloodPercentage, 0.5f, 1f, 1f, 0f);
            }
            else speed = maxSpeed;
        }
        else
        {
            speed = newSpeed;
        }
    }

    private float GetHighestBloodPercentage()
    {
        float max = -1;
        foreach (var percentage in bloodPercentages)
        {
            if (percentage > max) max = percentage;
        }
        return max;
    }

    public void breed()
    {

    }
}
