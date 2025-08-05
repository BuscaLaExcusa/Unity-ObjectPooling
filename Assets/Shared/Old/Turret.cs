using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuscaLaExcusa {
    public class Turret : MonoBehaviour {
        /*
        [Header("Behaviour")]
        public float _startCooldown = 3f;
        public float _endCooldown = 0.5f;
        public float _cooldownStep = 0.25f;
        public float _stepTime = 1f;


        [Header("Settings")]
        [SerializeField] GameObject _bulletPrefab;
        [SerializeField] Transform _bulletsParent;
        [SerializeField] Transform _spawnPoint;

        private bool _firstTime;
        private float _cooldown;
        private float _timer;
        private float _downtime;

        void Awake() {
            _cooldown = _startCooldown;
            _downtime = _cooldown;
            _timer = _cooldown + _stepTime;
        }

        void Update() {
            UpdateStep();
            Cooldown();
        }

        private void UpdateStep() {
            if (_cooldown <= _endCooldown) {
                return;
            }

            _timer -= Time.deltaTime;
            if (_timer > 0) {
                return;
            }

            _cooldown -= _cooldownStep;
            _timer = _stepTime;
        }

        private void Cooldown() {
            _downtime -= Time.deltaTime;
            if (_downtime > 0) {
                return;
            }

            Shoot();
            _downtime = _cooldown;
        }

        private void Shoot() {
            GameObject bulletGO = Instantiate(_bulletPrefab, _bulletsParent);
            bulletGO.name = this.name + "_Bullet";

            Transform bulletTrm = bulletGO.transform;
            bulletTrm.position = _spawnPoint.position;
            bulletTrm.rotation = _spawnPoint.rotation;
        }*/
    }
}