using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Ball : MonoBehaviour, IInputClickHandler, IHoldHandler, IManipulationHandler {
    private float HoldStartTime;
    private float HoldFinishTime;
    private float force;
    private bool isClicked;
    private Vector3 manipulationPreviousPosition;
    private Vector3 moveVector;

    private Vector3 UpHandPosition;
    private Vector3 DownHandPosition;


    public void OnHoldCanceled(HoldEventData eventData)
    {
        HoldFinishTime = Time.time;
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
       
    }
    public void OnHoldStarted(HoldEventData eventData)
    {

        HoldStartTime = Time.time;

    }

    public void OnInputUp(InputClickedEventData eventData)
    {
        uint SourceID = eventData.SourceId;
        eventData.InputSource.TryGetPosition(SourceID,out UpHandPosition);

        Debug.Log("Czas ktory uplynal od tapniecia: " + (Time.time - HoldStartTime));
        HoldFinishTime = Time.time - HoldStartTime;
        if (!gameObject.GetComponent<Rigidbody>())
        {
            gameObject.AddComponent<Rigidbody>();
        }

        var BallRigidbody = GetComponent<Rigidbody>();

        BallRigidbody.mass = 1;
        BallRigidbody.drag = 1;
        BallRigidbody.angularDrag = 0.05f;
        BallRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        BallRigidbody.interpolation = RigidbodyInterpolation.None;
        BallRigidbody.isKinematic = false;
        BallRigidbody.useGravity = true;
        force = 300f;
        float DistanceDifference = UpHandPosition.y - DownHandPosition.y;
        BallRigidbody.AddForce(new Vector3(0, 1, 1) * DistanceDifference * force);
        Debug.Log(DistanceDifference);
    }
    public void OnInputDown(InputClickedEventData eventData)
    {    
        uint SourceID = eventData.SourceId;
        eventData.InputSource.TryGetPosition(SourceID, out DownHandPosition);
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //TODO
        // isClicked = true;
        // InputManager.Instance.AddGlobalListener(gameObject);
        // isClicked = false;
        // InputManager.Instance.RemoveGlobalListener(gameObject);
    }

    // Use this for initialization
    void Start () {
        InputManager.Instance.AddGlobalListener(gameObject);
        moveVector = Vector3.zero;
        Physics.gravity = new Vector3(0, -20, 0);
    }
	
    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        manipulationPreviousPosition = eventData.CumulativeDelta;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        moveVector = Vector3.zero;

        // 4.a: Calculate the moveVector as position - manipulationPreviousPosition.
        moveVector = eventData.CumulativeDelta - manipulationPreviousPosition;

        // 4.a: Update the manipulationPreviousPosition with the current position.
        manipulationPreviousPosition = eventData.CumulativeDelta;

        // 4.a: Increment this transform's position by the moveVector.
        transform.position += moveVector * 2.5f;
    }
    
    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
     
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
     
    }
}
