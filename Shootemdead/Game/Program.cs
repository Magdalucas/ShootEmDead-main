using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
     
        static void Main(string[] args)
        {
            Engine.Initialize("Game", 1280, 720);
            Initialization();

            while (true)
            {
                Update();
                Render();
            }
        }

        private static void Initialization()
        {
            GameManager.Instance.Initilization();
         }

        private static void Update()
        {
            GameManager.Instance.Update();
        }

        public static void Render()
        {
            GameManager.Instance.Render();
        }
    }
}