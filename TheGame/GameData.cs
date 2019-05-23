using System.Collections.Generic;
using System.Linq;

namespace TheGame
{
    public class GameData
    {
        public List<string> Map;
        public int Score;
        public int Lvl;
        public string Skill;
        public Player Player;

        public GameData()
        {
            Map = new List<string>();
            Score = 0;
            Lvl = 1;
            Skill = null;
            Player = null;
        }
            
        public void SetGameData(List<IGameObject> map, int score, int lvl, ISkill skill, Player player)
        {
            Map = map.Where(e => !(e is Spawner)).Select(e => e.ToString()).ToList();
            Score = score;
            Lvl = lvl;
            Skill = skill?.ToString();
            Player = player;
        }
 
        public Game GetGameFromData()
        {
            var map = new List<IGameObject>();
            foreach (var e in Map)
            {
                map.Add(e.FromString(true));
            }
            return new Game(map)
            {
                Score = Score,
                Lvl = Lvl,
               // Skill = Skill.FromString(),
                Player = Player
            };
        }
    }
}