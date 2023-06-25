using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character2
    {
        /* Character Properties */
        private Transform _transform;
        private Renderer _renderer;
        private Animation idleAnimation;
        private Animation walkAnimation;
        private Animation currentAnimation;




        public Transform Transform => _transform;
        public Renderer Renderer => _renderer;

        /* Speed Values */
        private float _movementSpeed;


        #region PUBLIC_METODS

        public Character2(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed)
        {

            _transform = new Transform(position, scale, angle);


            CreateAnimations();
            currentAnimation = idleAnimation;
            _movementSpeed = movementSpeed;

            _renderer = new Renderer(idleAnimation, scale);

        }

        private void OnGetDamageHandler()
        {
            Engine.Debug("aca puedo hacer una animacion de que el personaje recibe daño");
        }

        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 1; i < 10; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Soldierder/Idles/Idle{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idles", idleTextures, 0.1f, true);



            List<Texture> walkTextures = new List<Texture>();
            for (int i = 1; i < 9; i++)
            {

                Texture frame = Engine.GetTexture($"Textures/Soldierder/Walks/Walk{i}.png");
                walkTextures.Add(frame);
            }
            walkAnimation = new Animation("Walk", walkTextures, 0.1f, true);

        }



        public void Update()
        {
            InputReading();

            if (_transform.Position.X >= 1280 + _renderer.Texture.Width)
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));
            currentAnimation.Update();
        }
        public void Render()
        {


            _renderer.Render(_transform);
        }

        #endregion

        #region PRIVATE_METHODS


        private void InputReading()
        {
            if (Engine.GetKey(Keys.I)) MoveUp();
            if (Engine.GetKey(Keys.K)) MoveDown();
            if (Engine.GetKey(Keys.J)) MoveLeft();
            if (Engine.GetKey(Keys.L)) MoveRight();
            if (Engine.GetKey(Keys.O)) Shoot();
        }

        private void MoveUp() => _transform.Translate(new Vector2(0, -1), _movementSpeed);
        private void MoveDown() => _transform.Translate(new Vector2(0, 1), _movementSpeed);
        private void MoveLeft() => _transform.Translate(new Vector2(-1, 0), _movementSpeed);
        private void MoveRight() => _transform.Translate(new Vector2(1, 0), _movementSpeed);

        private void Shoot() => LevelController.CreateBullet2(_transform.Position);

        #endregion
    }
}

