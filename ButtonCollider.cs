



using UnityEngine;

public class ButtonCollider : MonoBehaviour
{
   
   public AudioClip audioClip;
   
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("indexCollider"))
      {
         Color color =new  Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));
         
               MeshRenderer meshRend = GetComponent<MeshRenderer>();
               AudioSource src = GetComponent<AudioSource>();
               meshRend.material.color = color;
               src.PlayOneShot(audioClip);
      }
      

   }
}
