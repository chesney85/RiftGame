using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InventoryActions : MonoBehaviour
    {

        [Header("weapon/glove Shop and Player Inventory")]
        public List<GameObject> playerGlovesList;
        public List<GameObject> playerGunsList;
        
        [Header("Random Audio Clips")]
        public List<AudioClip> exclamations;
        public List<AudioClip> rejection;
        
        [Header("Player and Hands")]
        public GameObject Player;
        public SkinnedMeshRenderer leftHand;
        public SkinnedMeshRenderer rightHand;
        public AudioSource playerAudio;
        public int playerTokens;
        public TextMeshProUGUI tokensLeft;
        public GameObject tokenCanvasPrefab;
        
        [Header("Player Holsters")]
        public HolsterInteract leftHip;
        public HolsterInteract rightHip;
        public HolsterInteract leftShoulder;
        public HolsterInteract rightShoulder;
        


        private void Start()
        {
            StartCoroutine(findPlayer());
        }

        private void Update()
        {
            if (Input.GetButton("Oculus_CrossPlatform_Button4"))
            {
                SavePlayer();
            }
            if (Input.GetButton("Load"))
            {
             LoadPlayer();
            }
        }


        public void buyGun(GameObject _gun)
        {
            playerGunsList.Add(_gun);
            tokensLeft.text = playerTokens.ToString();
        }

        public void EquipGun(HolsterInteract _holster,GameObject _gun)
        {
            _holster.itemToSpawn = _gun;
            
        }

        public void BuyGlove(GameObject _glove)
        {
            playerGlovesList.Add(_glove);
            tokensLeft.text = playerTokens.ToString();
        }

        public void EquipGlove(SkinnedMeshRenderer _renderer, GameObject _glove)
        {
            _renderer.material = _glove.GetComponent<MenuItems>().gloveTexture;
        }

        IEnumerator findPlayer()
        {
            //wait for player to set up
            yield return new WaitForSeconds(5f);
            //find player
//           Player = GameObject.Find("OculusPlayer(Clone)");
           //find audio source
//           playerAudio = Player.GetComponent<AudioSource>();
           //find Hands
           leftHand = Player.transform.GetChild(0).GetChild(10).GetChild(5).GetChild(0).GetComponent<SkinnedMeshRenderer>();
           rightHand = Player.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(0).GetComponent<SkinnedMeshRenderer>();
           //find holsters
//           leftHip = Player.transform.GetChild(0).GetChild(8).GetComponent<HolsterInteract>();
//           rightHip = Player.transform.GetChild(0).GetChild(7).GetComponent<HolsterInteract>();
//           leftShoulder = Player.transform.GetChild(0).GetChild(6).GetComponent<HolsterInteract>();
//           rightShoulder = Player.transform.GetChild(0).GetChild(9).GetComponent<HolsterInteract>();
           //Add Canvas to Left Hand
           GameObject tokenCanvas = Instantiate(tokenCanvasPrefab, Player.transform.GetChild(0).GetChild(10).GetChild(5).GetChild(0).transform.position, Player.transform.GetChild(0).GetChild(10).GetChild(5).GetChild(0).transform.rotation);
           tokenCanvas.transform.SetParent(Player.transform.GetChild(0).GetChild(10).GetChild(5).GetChild(0).transform);
           tokenCanvas.transform.localPosition = new Vector3(-0.043f,-0.025f,-0.12f);
           tokenCanvas.transform.localRotation = Quaternion.Euler(8f,13.2f,0.5f);
           tokensLeft = tokenCanvas.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
           tokensLeft.text = playerTokens.ToString();
           yield return new WaitForSeconds(1f);
           LoadPlayer();
        }

        public void SavePlayer()
        {
            ES3.Save<GameObject>("hip", leftHip.itemToSpawn);
            ES3.Save<GameObject>("shoulder", leftShoulder.itemToSpawn);
            ES3.Save<Material>("hand", leftHand.material);
            ES3.Save<int>("playerTokens", playerTokens);
        }

        public void LoadPlayer()
        {
            GameObject left = ES3.Load<GameObject>("hip");
            rightHip.itemToSpawn = left;
            leftHip.itemToSpawn = left;
            GameObject shoulder = ES3.Load<GameObject>("shoulder");
            rightShoulder.itemToSpawn = shoulder;
            leftShoulder.itemToSpawn = shoulder;
            Material mat = ES3.Load<Material>("hand");
            leftHand.material = mat;
            rightHand.material = mat;
            int tokens = ES3.Load<int>("playerTokens");
            playerTokens = tokens;
        }

        public void PlayRandomExclamation()
        {
            playerAudio.PlayOneShot(exclamations[Random.Range(0, exclamations.Count -1)]);
        }
        

        public void NotEnoughTokens()
        {
            playerAudio.PlayOneShot(rejection[Random.Range(0, rejection.Count -1)]);
        }
    }
