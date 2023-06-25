using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelController
    {
        private static List<Character> player = new List<Character>();
        private static List<Character2> player2 = new List<Character2>();
        private static List<Bullet> bullets = new List<Bullet>();
        
      

        private static Character _player;
        private static Character2 _player2;
        public static Character Player => _player;
        public static Character2 Player2 => _player2;

        /// Timeframe Calculation Properties
        private  Time _time;


        public void Initialization()
        {
             _time.Initialize();
            _player = new Character("Textures/Soldierizq/Idle1.png", new Vector2(100, 200), new Vector2(1.50f, 1.50f), 0, 150);
            _player2 = new Character2("Textures/Soldierder/Idle1.png", new Vector2(1200, 200), new Vector2(1.50f, 1.50f), 0, 175);

          
        }

    public void Update()
    {
        _time.Update();
        _player.Update();
        _player2.Update();
        foreach (Bullet bullet in bullets) bullet.Update();
        
        }

        public static void CreateBullet(Vector2 position)
        {
            bullets.Add(new Bullet(new Vector2(Player.Transform.Position.X + 50, Player.Transform.Position.Y), new Vector2(1f, 1f), 0, 300));
        }

        public static void CreateBullet2(Vector2 position)
        {
            bullets.Add (new Bullet(new Vector2(Player2.Transform.Position.X - 50, Player2.Transform.Position.Y), new Vector2(-1f, -1f), 0, -300));
        }


        public void Render()
    {
        Engine.Clear();

        _player.Render();
        _player2.Render();
        foreach (Bullet bullet in bullets) bullet.Render();

        Engine.Show();
        }
    }
}