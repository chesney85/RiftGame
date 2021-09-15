using System.Collections;
using UnityEngine;


public class HandSetup : MonoBehaviour
{

    #region Class Variables

    [Header("Colliders For The Hands")] 
    public GameObject indexFingerPrefab;
        public GameObject knucklesPrefab;
    
        public Camera camera;
    
        //These represent the collider on each hand
        private GameObject indexLeft;
        private GameObject indexRight;
        private GameObject knucklesLeft;
        private GameObject knucklesRight;
    

        [Header("Holsters For Guns")] 
        public GameObject leftHols;
        public GameObject leftShoulHols;
        public GameObject rightHols;
        public GameObject rightShoulHols;
    
        
        [Header("Materials For Hands")] 
        public Material leftHand;
        public Material rightHand;

        public GameObject PlayerCashPrefab;
    
        private bool allsetUp;

    #endregion
    

    void OnEnable()
    {
        allsetUp = false;
        StartCoroutine(HandsSetup());
//        StartCoroutine(SetUpLoadThings());
    }

   

    #region Update and Input
 void Update()
    {
        if (allsetUp)
        {
            //This input determines if the index fingers are touching the trigger
            //if the fingers are touching it then the index collider are de-activated
            GetInput();
        }

        //This keeps the holsters inline with the player position
        UpdateHolsterPositions();


        if (Input.GetButtonDown("BreakPedal"))
        {
            Save();
        }

        if (Input.GetButtonDown("GasPedal"))
        {
            Load();
        }


        //This Input determines if the knuckle colliders are active
        //if gripping and trigger then active
//        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.2f &&
//            OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0.2f)
//            knucklesLeft.SetActive(true);
//        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.2f ||
//            OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) < 0.2f)
//            knucklesLeft.SetActive(false);
//        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.2f &&
//            OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.2f)
//            knucklesRight.SetActive(true);
//        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) < 0.2f ||
//            OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) < 0.2f)
//            knucklesRight.SetActive(false);
    }
     void GetInput()
        {
            if (!Input.GetButton("rIndexTouch"))
                indexRight.SetActive(true);
            if (Input.GetButton("rIndexTouch"))
                indexRight.SetActive(false);
            if (!Input.GetButton("lIndexTouch"))
                indexLeft.SetActive(true);
            if (Input.GetButton("lIndexTouch"))
                indexLeft.SetActive(false);
        }

        #endregion

    #region Hands Stuff

    //I chose to wait 4 seconds before setting hands up as the local avatar takes a random number of seconds
    //to add all child elements needed for the headset and hands to work.
    //this allows me to add my own game objects and scripts to dynamically generated hands.
    IEnumerator HandsSetup()
    {
        //---------------Give four second delay to ensure Oculus has setup hands for player------------//
        yield return new WaitForSeconds(4f);

        //---------------Create colliders at tips of index fingers------------//
        CreateIndexFingers();

        //---------------Create colliders where knuckles are------------//
        //      CreateKnuckles();

        //        //---------------Ensure hands are initilaized------------//
        SetColliders(indexLeft, indexRight);

        //-------------Set up Holsters----------------//
        SetUpHolsters();

        //---------------Set up hands-----------------//
        SetUpHands();

        yield return new WaitForSeconds(1f);
        //Do some loading stuff here
        //        LoadPlayer();
        allsetUp = true;
        if (allsetUp)
        {
            transform.GetChild(6).GetComponent<OvrAvatarComponent>().SetCustomTrue();
            transform.GetChild(5).GetComponent<OvrAvatarComponent>().SetCustomTrue();
        }
    }


    //This method is used to ensure class variables for hands match those created in the co-routine HandsSetup()
    void SetColliders(GameObject _leftHand, GameObject _rightHand)
    {
        indexLeft = _leftHand;
        indexRight = _rightHand;
        //        knucklesLeft = _knucklesLeft;
        //        knucklesRight = _knucklesRight;
    }

    public void CreateIndexFingers()
    {
        //-----------Set Scale of index colliders-----------//
        indexLeft = Instantiate(indexFingerPrefab, transform.GetChild(5).position, transform.rotation);
        indexRight = Instantiate(indexFingerPrefab, transform.GetChild(6).position, transform.rotation);
        //-----------Set Scale of index colliders-----------//
        indexLeft.transform.SetParent(transform.GetChild(5));
        indexRight.transform.SetParent(transform.GetChild(6));
        //-----------Set Scale of index colliders-----------//
        indexLeft.transform.localScale = new Vector3(1, 1, 1);
        indexRight.transform.localScale = new Vector3(1, 1, 1);
        //-----------Set the position of the index colliders-------------//
        indexLeft.transform.localPosition = new Vector3(-0.037f, -0.0035f, 0.07f);
        indexRight.transform.localPosition = new Vector3(0.037f, -0.0035f, 0.07f);
    }

    public void CreateKnuckles()
    {
        //-----------Create the knuckles--------------------//
        knucklesLeft = Instantiate(knucklesPrefab, transform.GetChild(5).position, transform.rotation);
        knucklesRight = Instantiate(knucklesPrefab, transform.GetChild(6).position, transform.rotation);
        //-----------Set the parent game object of knuckles-----------//
        knucklesRight.transform.SetParent(transform.GetChild(6));
        knucklesLeft.transform.SetParent(transform.GetChild(5));
        //-----------Set Scale of knuckles-----------//
        knucklesRight.transform.localScale = new Vector3(1, 1, 1);
        knucklesLeft.transform.localScale = new Vector3(1, 1, 1);
        //-----------Set the position of the knuckles-------------//
        knucklesRight.transform.localPosition = new Vector3(0.02f, -0.05f, 0f);
        knucklesLeft.transform.localPosition = new Vector3(-0.02f, -0.05f, 0f);
    }

    public void SetUpHands()
    {
        ////===========================LEFT HAND==========================================

        //-------------Add Scripts to Left Hand-------------------//
        transform.GetChild(5).gameObject.AddComponent<Hand>();
        transform.GetChild(5).gameObject.GetComponent<Hand>().gripTrigger = OVRInput.Axis1D.PrimaryHandTrigger;
        transform.GetChild(5).gameObject.GetComponent<Hand>().indexTrigger = OVRInput.Axis1D.PrimaryIndexTrigger;
        //-------------Change Tag on left hand-------------------//
        transform.GetChild(5).gameObject.tag = "Player";
        //-------------Change glove material on left hand-------------------//
        transform.GetChild(5).GetChild(0).gameObject.GetComponent<Renderer>().material = leftHand;
        //----------------Change tag for every child object the left hand has-----------------//
        foreach (Transform t in transform.GetChild(5))
        {
            t.gameObject.tag = "Player";
        }

        //---------------Set which controller the LeftHand script should use--------------------//
        transform.GetChild(5).GetComponent<Hand>().controller = OVRInput.Controller.LTouch;


        ////==========================RIGHT HAND==============================================

        //-------------Add Scripts to Right Hand-------------------//
        transform.GetChild(6).gameObject.AddComponent<Hand>();
        transform.GetChild(6).gameObject.GetComponent<Hand>().gripTrigger = OVRInput.Axis1D.SecondaryHandTrigger;
        transform.GetChild(6).gameObject.GetComponent<Hand>().indexTrigger = OVRInput.Axis1D.SecondaryIndexTrigger;
        //-------------Change Tag on Right hand-------------------//
        transform.GetChild(6).gameObject.tag = "Player";
        //-------------Change glove material on Right hand-------------------//
        transform.GetChild(6).GetChild(0).gameObject.GetComponent<Renderer>().material = rightHand;
        //----------------Change tag for every child object the Right hand has-----------------//
        foreach (Transform t in transform.GetChild(6))
        {
            t.gameObject.tag = "Player";
        }

        //---------------Set which controller the RightHand script should use--------------------//
        transform.GetChild(6).GetComponent<Hand>().controller = OVRInput.Controller.RTouch;
    }

    #endregion

    #region Holster Stuff

    public void SetUpHolsters()
    {
        //--------------------Set the hand the Left Hip holster should parent guns to---------------//
        leftHols.GetComponent<HolsterInteract>().hand = transform.GetChild(5).gameObject;
        //--------------------Set the hand the Left Shoulder holster should parent guns to---------------//
        leftShoulHols.GetComponent<HolsterInteract>().hand = transform.GetChild(5).gameObject;
        //--------------------Set the hand the Right Hip holster should parent guns to---------------//
        rightHols.GetComponent<HolsterInteract>().hand = transform.GetChild(6).gameObject;
        //--------------------Set the hand the Right Shoulder holster should parent guns to---------------//
        rightShoulHols.GetComponent<HolsterInteract>().hand = transform.GetChild(6).gameObject;
    }

    void UpdateHolsterPositions()
    {
        leftHols.transform.localPosition = new Vector3(camera.transform.localPosition.x - 0.3f,
            camera.transform.localPosition.y - 0.6f, camera.transform.localPosition.z - 0.1f);
        leftShoulHols.transform.localPosition = new Vector3(camera.transform.localPosition.x - 0.2f,
            camera.transform.localPosition.y, camera.transform.localPosition.z - 0.1f);
        rightShoulHols.transform.localPosition = new Vector3(camera.transform.localPosition.x + 0.2f,
            camera.transform.localPosition.y, camera.transform.localPosition.z - 0.1f);
        rightHols.transform.localPosition = new Vector3(camera.transform.localPosition.x + 0.3f,
            camera.transform.localPosition.y - 0.6f, camera.transform.localPosition.z - 0.1f);
    }

    #endregion

    #region Save and Load

      public void Save()
        {
        }
    
        public void Load()
        {
        }

    #endregion


   


  
}