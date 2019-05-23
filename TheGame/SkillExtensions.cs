using Newtonsoft.Json;

namespace TheGame
{
    public static class SkillExtensions
    {
        public static ISkill FromString(this string s)
        {
            if (s == null) return null;
            var skill = JsonConvert.DeserializeObject(s);
            switch (skill)
            {
                case ThunderSkill fromString:
                    return fromString;
                case SpeedSkill speedSkill:
                    return speedSkill;
                default:
                    return null;
            }
        }
    }
}