using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    { 
    /* Character Properties */
    private Transform _transform;
    private Renderer _renderer;
    private Animation idleAnimation;
    private Animation currentAnimation;
    private Character _player;
    private Character _player2;


        /* Speed Values */
    private float _movementSpeed;
    private float _rotationSpeed;

        #region PUBLIC_METODS

        public Bullet(Vector2 position, Vector2 scale, float angle, float movementSpeed)
        {
            _player = LevelController.Player;
            _player.LifeController.onGetDamage += OnGetDamageHandler;

            _transform = new Transform(position, scale, angle);


            _player2 = LevelController.Player;
            _player2.LifeController.onGetDamage += OnGetDamageHandler;

            _transform = new Transform(position, scale, angle);

   



            CreateAnimations();
            currentAnimation = idleAnimation;
            _movementSpeed = movementSpeed;
            _rotationSpeed = 100f;

            _renderer = new Renderer(idleAnimation, scale);

        }

        
        
          

            
        private void OnGetDamageHandler()
        {
            Engine.Debug("acá podría hacer desaparecer la bala");
        }

        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Bullet/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);


            //for (int i = 0; i < 4; i++)
            //{
            //    Texture frame = Engine.GetTexture($"Textures/Bullet2/Idle/{i}.png");
            //    idleTextures.Add(frame);
            //}
            //idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
        }




        public void Update()
        {

            _transform.Translate(new Vector2(1, 0), _movementSpeed);

            currentAnimation.Update();
            CheckCollision();

        }

        public void CheckCollision()
        {
            float distanceX = Math.Abs(_player.Transform.Position.X - _transform.Position.X);
            float distanceY = Math.Abs(_player.Transform.Position.Y - _transform.Position.Y);

            float sumHalfWidths = _player.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
            float sumHalfHeights = _player.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {

               
                GameManager.Instance.ChangeGameState(GameState.GameOverScreen);
            }

        }



        public void CheckCollision2()
        {
            float distanceX = Math.Abs(_player2.Transform.Position.X - _transform.Position.X);
            float distanceY = Math.Abs(_player2.Transform.Position.Y - _transform.Position.Y);

            float sumHalfWidths = _player2.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
            float sumHalfHeights = _player2.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

            if (distanceX >= sumHalfWidths && distanceY >= sumHalfHeights)
            {

                GameManager.Instance.ChangeGameState(GameState.WinScreen);
            }

        }



        public void Render()
    {
        _renderer.Render(_transform);
    }

    #endregion
}
}