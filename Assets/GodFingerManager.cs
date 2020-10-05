using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodFingerManager : MonoBehaviour
{
    [SerializeField] float _pokeImpulseForceMagnitude = 10;
    [SerializeField]float _pokeNormalForceMagnitude = 5;
    [SerializeField]float _ballImpulseForce = 5;
    private bool _bLeftAlt, _bLeftCtrl;
    //Usethisforinitialization
    void Start () {
    }
    //Updateiscalledonceperframe
    protected virtual void Update () {
        _bLeftAlt = Input.GetKey (KeyCode.LeftAlt);
        _bLeftCtrl = Input.GetKey(KeyCode.LeftControl);
        if(Input.GetMouseButtonDown(0)){
            ProcessLeftMouseClick();}
            else if(Input.GetMouseButtonDown(1)){
                ProcessRightMouseClick();
                }else if(Input.GetMouseButtonDown(2)){
                    ProcessMiddleMouseClick();
                    }
                    }
                    private void ProcessLeftMouseClick(){
                        //ARaycastHitinformationobject
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if(Physics.Raycast(ray,out hit))
                        {
                            if(hit.rigidbody !=null)
                        {
                            Vector3 rayDir = ray.direction;
                            rayDir = rayDir.normalized;
                            if(!_bLeftCtrl)
                            {
                                hit.rigidbody.AddForceAtPosition(rayDir * _pokeImpulseForceMagnitude, hit.point, ForceMode.Impulse);
                                Utilities.CreateVectorGameObjectAt(hit.point, rayDir,_pokeImpulseForceMagnitude,3);
                                } 
                                else
                                {
                                    hit.rigidbody.AddForceAtPosition(-rayDir * _pokeImpulseForceMagnitude, hit.point, ForceMode.Impulse);
                                    Utilities.CreateVectorGameObjectAt(hit.point, -rayDir,_pokeImpulseForceMagnitude,3);
                                    }
                                }
                            }
                         }
                                    private void ProcessRightMouseClick() {
                                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                        //Shootabulletifleftaltisbeingheld
                                        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                                        go.transform.position = ray.origin;
                                        go.transform.rotation = Quaternion.identity;
                                        Rigidbody rb = go.AddComponent<Rigidbody>();
                                        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                                        go.GetComponent<Rigidbody>().AddForce(ray.direction.normalized *_ballImpulseForce, ForceMode.Impulse);
                                        Destroy(go, 3);
                                        }
                                        private void ProcessMiddleMouseClick() {
                                            RaycastHit hit;
                                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                            if(Physics.Raycast(ray,out hit))
                                            {
                                                if(hit.rigidbody !=null)
                                                {
                                                    Vector3 hitNormal = hit.normal;
                                                    hitNormal.Normalize();
                                                    if(!_bLeftCtrl)
                                                    {
                                                        hit.rigidbody.AddForceAtPosition(hitNormal *_pokeImpulseForceMagnitude, hit.point, ForceMode.Impulse);
                Utilities.CreateVectorGameObjectAt(hit.point, hitNormal,_pokeImpulseForceMagnitude,3);
                }
                else{
                    hit.rigidbody.AddForceAtPosition(-hitNormal *_pokeImpulseForceMagnitude, hit.point, ForceMode.Impulse);
                    Utilities.CreateVectorGameObjectAt(hit.point, -hitNormal,_pokeImpulseForceMagnitude,3);
                    }
            }
         }
     }

}
