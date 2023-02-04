using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

public class CharacterController : MonoBehaviour
{
    public PortraitGameController portraitController;
    public int vida;
    public float[] sangre = new float[4];
    public float velocity;
    private Rigidbody2D characterRigyBody;

    private void Awake() {
        characterRigyBody  = GetComponent<Rigidbody2D>();
    }

   public void move(Vector2 v){
        v = v.WithY(Mathf.Clamp(v.y,-1,0));
        characterRigyBody.velocity = v * velocity;
   }

   public void lifeCalculator(){
    if(vida <= 0){
        velocity = 0;
        //TO DO: Poner el marco en sepia.
    }
   }

   public void breed(){

   }
}
