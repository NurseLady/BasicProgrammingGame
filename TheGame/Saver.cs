using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheGame
{
    public class Saver
    {
        public static void SaveTheGame(Game game)
        {
            var temp = new GameData();
            temp.SetGameData(game.GameObjects, game.Score, game.Lvl, game.Skill, game.Player);
            
            var serialized = JsonConvert.SerializeObject(temp);

            using (FileStream fstream = new FileStream(@".\save.json", FileMode.Truncate))
            {
                var array = System.Text.Encoding.Default.GetBytes(serialized);
                fstream.Write(array, 0, array.Length);
            }
        }

        public static Game LoadTheGame()
        {
            using (FileStream fstream = File.OpenRead(@".\save.json"))
            {
                var array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                var json = System.Text.Encoding.Default.GetString(array);
                var gameData = JsonConvert.DeserializeObject<GameData>(json);
                return gameData.GetGameFromData();
            }
        }
    }
}