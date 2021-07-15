using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config paramaters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int maxHit;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //To do only serialized for debug purposes
    private void Start()
    {

        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            //her block başlangıçta bununla başlayacağından bu void start blog sayısı kadar çalışacak
            level.countBreakableBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (tag == "Breakable")
        {
            
            int maxHit=hitSprites.Length+1; //+1 dizilerde index 0 dan başladığı için geliyor 
            timesHit++;
            if (timesHit >= maxHit)
            {
                destroyBlock();
            }
            else
            {
                showNextSprites();
            }
        }

    }

    private void showNextSprites()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    private void destroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        FindObjectOfType<GameStatus>().AddPointToScore();
        level.blockDestroyed();
        TriggerSparklesVFX();

    }
    private void TriggerSparklesVFX()
    {
        //instantiate belirlediğimiz pozisyonlardan bir obje çıkmasını sağlar
        //bunu çekerken sürekli nesne üreticektir
        //bunu çekerken sürekli nesne üreticektir
        //bunu belirli bir zaman aralığına çekmek istiyorsak invoke fonksiyonunu kullan

        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);


    }
}
