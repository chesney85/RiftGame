using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using UnityEngine.UI;

public class ShootInteract : Interact
{
    [Header("Weapon Info")] public Transform barrelExit;
    public int clipSize;
    public int fullClip;
    public float cooldown;
    public GameObject barrelParticle;

    [Header("Bullet Info")] public GameObject pellet;
    public Text bulletsLeft;
    public int pelletCount;
    public float spreadAngle;
    

    [Header("Gun Sounds")] public AudioClip[] shootSounds;
    public AudioClip gunEmpty;

    private bool shooting;
    private List<Quaternion> pellets;
    private Rigidbody rigid;

    void OnEnable()
    {
        shooting = false;
        rigid = GetComponent<Rigidbody>();
        clipSize = fullClip;
        bulletsLeft.text = fullClip.ToString();
    }
    

    // Update is called once per frame
    public override void TriggerAction()
    {
        if (shooting)
            return;

        if (clipSize > 0)
        {
            StartCoroutine(Shoot());
        }

        else
        {
            StartCoroutine(Empty());
        }
    }

    IEnumerator Shoot()
    {
        shooting = true;
        LeanPool.Spawn(barrelParticle, barrelExit.transform.position, barrelExit.transform.rotation);
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }

        for (int i = 0; i < pellets.Count; i++)
        {
            pellets[i] = Random.rotation;
            GameObject p = LeanPool.Spawn(pellet, barrelExit.position, barrelExit.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
        }

        GetComponent<AudioSource>().PlayOneShot(shootSounds[Random.Range(0, shootSounds.Length - 1)]);
        yield return new WaitForSeconds(cooldown);
        
        clipSize--;
        shooting = false;
        bulletsLeft.text = clipSize.ToString();
    }


    IEnumerator Empty()
    {
        shooting = true;
        GetComponent<AudioSource>().PlayOneShot(gunEmpty);
        yield return new WaitForSeconds(cooldown);
        shooting = false;
    }

    public override void DropAction(OVRInput.Controller _controller,Vector3 _velocity, Vector3 _angularVelocity)
    {
        rigid.isKinematic = false;
        transform.SetParent(null);
        rigid.velocity = _velocity;
        rigid.angularVelocity = _angularVelocity;
        LeanPool.Despawn(gameObject,3f);
    }
}