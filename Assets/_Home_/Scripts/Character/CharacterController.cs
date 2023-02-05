using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UtilityMethods;
using RuntimeSets;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public bool isControlled = false;
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
    [HideInInspector] public Rigidbody2D rb;
    private List<CharacterController> bredCharacterControllers;
    private int unseenFrames = 0;
    public Renderer rendererComponent;
    private IEnumerator notBreedTimeout;
    [SerializeField] private bool breedable;
    public int timesBred = 0;

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
    }
    private void Start()
    {
        CalculateSpeed();
        lifeLeft = maxLifeLeft;
        portraitData = new PortraitData(GameManager.Instance.portraitCreator);
        portraitController.currentPortrait = portraitData;
        NotBreedFor(1f);
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
        DeleteIfUnseen();
    }

    public void NotBreedFor(float seconds)
    {
        if (notBreedTimeout != null)
        {
            StopCoroutine(notBreedTimeout);
        }
        notBreedTimeout = NotBreedTimeout(seconds);
        StartCoroutine(notBreedTimeout);
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

    public float GetHighestBloodPercentage()
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
            if (Breed(otherCharacter))
            {
                otherCharacter.timesBred++;
            }
        }
    }

    public bool Breed(CharacterController other)
    {
        //if (other.timesBred + timesBred > 2) return false;
        if (!breedable) return false;
        if (!other.isControlled && !isControlled) return false;
        Vector2 newChildPosition = transform.position + (Vector3)Vector2.down * transform.lossyScale.y * 2.5f;
        Vector2 screenCoords = Camera.main.WorldToScreenPoint(newChildPosition);
        if (screenCoords.y < 0) return false;
        Collider2D[] hits = Physics2D.OverlapCircleAll(newChildPosition, .3f);
        if (hits.Length > 0) return false;

        AudioController audio = GameObject.FindObjectOfType<AudioController>();
        audio.PlaySFX(audio.SoundsSFX[5]);
        bredCharacterControllers.Add(other);
        CharacterController newChild = Instantiate(gameObject,
                newChildPosition,
                Quaternion.identity).GetComponent<CharacterController>();
        newChild.isControlled = false;
        newChild.Setup(GetChildBloodPercentages(other.bloodPercentages));
        newChild.portraitController.SetColor(Color.white);
        return true;
    }

    private IEnumerator NotBreedTimeout(float seconds)
    {
        Debug.Log("Timeout");
        breedable = false;
        yield return new WaitForSeconds(seconds);
        breedable = true;
        notBreedTimeout = null;
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

    private void DeleteIfUnseen()
    {
        if (!rendererComponent.isVisible)
        {
            unseenFrames++;
            if (unseenFrames > 5)
            {
                Debug.Log("Destroying");
                Destroy(this);
            }
        }
        else unseenFrames = 0;
    }

    private void OnDestroy()
    {
        onDestroy.Invoke();
        AudioController audio = GameObject.FindObjectOfType<AudioController>();
        portraitController.SetToSepia();
        availableCharacters.Remove(this);
        audio.PlaySFX(audio.SoundsSFX[0]);
    }
}
