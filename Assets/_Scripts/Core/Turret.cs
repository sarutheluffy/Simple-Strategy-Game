using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
   [Range(10, 100)] [SerializeField] private float detectionRadius;
   [SerializeField] private LayerMask layerMask;
   [SerializeField] private Transform transformBulletPoint;

   public LayerMask GetLayerMask
   {
      get { return layerMask; }
   }

   public float DetectionRadius
   {
      get { return detectionRadius; }
   }

   [SerializeField] private float fireInterval;
   [SerializeField] private GameObject objBulletPrefab;

   private Transform _thisTransform;

   private float _time;
   private float _nearEnemyDistance;
   private Vector3 _enemyPosition;
   private float _distance;
   private Vector3 _targetPosition;

   private void Start() => _thisTransform = transform;

   private void Update()
   {
      if (GameManager.Instance.currentState == GameState.Ready)
      {
         _time += Time.deltaTime;
         if(_time < fireInterval)
            return;
         Collider[] colliders = Physics.OverlapSphere(_thisTransform.position, detectionRadius, layerMask);
         if (colliders.Length == 0)
            return;
         _nearEnemyDistance = int.MaxValue;
         foreach (var collider in colliders)
         {
            _enemyPosition = collider.transform.position;
            _distance = Vector3.Distance(_thisTransform.position, _enemyPosition);
            if (_distance < _nearEnemyDistance)
            {
               _nearEnemyDistance = _distance;
               _targetPosition = _enemyPosition;
            }
         }

         LookAtTarget(_targetPosition);
      }
   }

   public bool IsTurretReady() => _time > fireInterval;


   private void LookAtTarget(Vector3 target)
   {
      _thisTransform.LookAt(target);
      Shoot();
      _time = 0;
   }

   public void Shoot() => SpawnBullet().Fire(transformBulletPoint.forward);

   private Bullet SpawnBullet()
   {
      GameObject obj =
         Instantiate(objBulletPrefab, transformBulletPoint.position, transformBulletPoint.rotation) as GameObject;
      Bullet bullet = obj.GetComponent<Bullet>();
      return bullet;
   }
}
