using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SingleScreen
    {
        private string _image;

        public SingleScreen(string image)
        {
            _image = image;
        }

        public void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.ChangeGameState(GameState.MainMenu);
            }
            if (Engine.GetKey(Keys.SPACE))
            {
                if (GameManager.Instance.CurrentState == GameState.MainMenu)
                {
                    GameManager.Instance.ChangeGameState(GameState.Level);
                }
            }
            if (Engine.GetKey(Keys.C))
            {
                GameManager.Instance.ChangeGameState(GameState.Credits);
            }
        }

        public void Render()
        {
            Engine.Draw(_image, 0, 0);
        }
    }
}
