using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UtilityMethods;
using RuntimeSets;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public UnityEvent onDestroy;
    [SerializeField] private RuntimeSetCharacterController availableCharacters;
    [SerializeField] private bool isStarter = false;
    public PortraitGameController portraitController;
    [SerializeField] private float maxLifeLeft = 10f;
    public float lifeLeft;
    public float[] bloodPercentages = new float[4];
    public float maxSpeed;
    public PortraitData portraitData;
    [SerializeField] private float speed;
    private Vector2 latestMovementVector;
    private Rigidbody2D rb;
    private List<CharacterController> bredCharacterControllers;
    public Renderer rendererComponent;

    public float lifePercentage
    {
        get
        {
            return lifeLeft / maxLifeLeft;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rendererComponent = GetComponent<Renderer>();
    }
    private void Start()
    {
        CalculateSpeed();
        lifeLeft = maxLifeLeft;
        portraitData = new PortraitData(GameManager.Instance.portraitCreator);
        portraitController.currentPortrait = portraitData;
    }
    public void Setup(float[] newBloodPercentages)
    {
        onDestroy = new UnityEvent();
        bloodPercentages = newBloodPercentages;
        isStarter = false;
        availableCharacters.Add(this);
    }

    private void FixedUpdate()
    {
        rb.velocity = latestMovementVector * maxSpeed;
    }
    private void Update()
    {
        SubstractLife();
    }

    public void SetMoveVector(Vector2 v)
    {
        latestMovementVector = Vector2.ClampMagnitude(v.WithY(Mathf.Clamp(v.y, -1, 0)), 1);
    }

    public void SubstractLife()
    {
        lifeLeft -= Time.deltaTime;
        if (lifeLeft <= 0)
        {
            maxSpeed = 0;
            Destroy(rb);
            Destroy(this);
            //TODO: Poner el marco en sepia.
        }
    }

    public void CalculateSpeed(float newSpeed = -1)
    {
        if (isStarter)
        {
            speed = maxSpeed;
            return;
        }
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        CharacterController otherCharacter = other.gameObject.GetComponent<CharacterController>();
        if (bredCharacterControllers == null) bredCharacterControllers = new List<CharacterController>();
        if (bredCharacterControllers.Contains(otherCharacter))
        {
            return;
        }
        if (otherCharacter == null)
        {
            return;
        }
        if (GetHashCode() > otherCharacter.GetHashCode())
        {
            bredCharacterControllers.Add(otherCharacter);
            Breed(otherCharacter);
        }

    }

    public void Breed(CharacterController other)
    {
        Debug.Log("Breeding", gameObject);
        CharacterController newChild = Instantiate(gameObject,
                transform.position + (Vector3)Vector2.down * transform.lossyScale.y * 2.5f,
                Quaternion.identity).GetComponent<CharacterController>();
        newChild.Setup(GetChildBloodPercentages(other.bloodPercentages));
    }

    private float[] GetChildBloodPercentages(float[] otherBloodPercentages)
    {
        float[] childBloodPercentages = { 0, 0, 0, 0 };
        for (int i = 0; i < childBloodPercentages.Length; i++)
        {
            childBloodPercentages[i] = (bloodPercentages[i] + otherBloodPercentages[i]) / 2f;
        }
        return childBloodPercentages;
    }

    private void OnDestroy()
    {
        onDestroy.Invoke();
        availableCharacters.Remove(this);
    }
}
