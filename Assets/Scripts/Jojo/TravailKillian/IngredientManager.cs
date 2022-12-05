using System;
using UnityEngine;

public class IngredientManager : Drag
{
    [SerializeField] private Item item;
    [SerializeField] GameObject vfx;
    [SerializeField] GameObject vfx2;

    private bool hasBeenDragged = false;
    private bool inCauldron = false;


    private void Update()
    {
        if (!hasBeenDragged && isDragged)
        {
            hasBeenDragged = true;
        }
        
        if (hasBeenDragged && !isDragged && !inCauldron)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        inCauldron = true;

        if (!other.CompareTag("Cauldron") || isDragged) return;

        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory.isBrewing) return;
         
        inventory.ingredients.Add(item);

        GameObject go = Instantiate(vfx, new Vector3(0, -2.4f, 0), Quaternion.identity);
        go.transform.Rotate(new Vector3(-90, 0, 0));
        ParticleSystem.MainModule settings = go.GetComponent<ParticleSystem>().main;

        GameObject go2 = Instantiate(vfx2, new Vector3(0, -2.4f, 0), Quaternion.identity);
        go2.transform.Rotate(new Vector3(-90, 0, 0));
        ParticleSystem.MainModule settingsChild = go2.GetComponentInChildren<ParticleSystem>().main;
  

        if (item.name.Contains("NymphTear"))
        {
            settings.startColor = new ParticleSystem.MinMaxGradient(Color.blue);
            settingsChild.startColor = new ParticleSystem.MinMaxGradient(Color.blue);
        }           
        if (item.name.Contains("DragonScale"))
        {
            settings.startColor = new ParticleSystem.MinMaxGradient(Color.red);
            settingsChild.startColor = new ParticleSystem.MinMaxGradient(Color.red);
        } 
        if (item.name.Contains("DeathShadow"))
        {
            settings.startColor = new ParticleSystem.MinMaxGradient(Color.black);
            settingsChild.startColor = new ParticleSystem.MinMaxGradient(Color.black);
        }
        if (item.name.Contains("LuckyLeaf"))
        {
            settings.startColor = new ParticleSystem.MinMaxGradient(Color.green);
            settingsChild.startColor = new ParticleSystem.MinMaxGradient(Color.green);
        }
        if (item.name.Contains("MoonFlower"))
        {
            settings.startColor = new ParticleSystem.MinMaxGradient(Color.white);
            settingsChild.startColor = new ParticleSystem.MinMaxGradient(Color.white);
        }
 


        go.GetComponent<ParticleSystem>().Play();
        go2.GetComponent<ParticleSystem>().Play();
        Destroy(go, 1.0f);
        Destroy(go2, 1.0f);

        Animator anim = gameObject.GetComponent<Animator>();

        anim.SetBool("IsDropped", true);

        if (inventory.ingredients.Count == inventory.maxIngredients) inventory.CheckPotionExist();

        Destroy(gameObject,1f);
        Destroy(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cauldron"))
        {
            inCauldron = false;
        }
    }
}