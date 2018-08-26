using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader
{
    public static class Surfaceparm
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<Surfaceparms, string> Strings { get; set; }

        /// <summary>
        /// Initialize string reference dictionary.
        /// </summary>
        static Surfaceparm()
        {
            Strings = new Dictionary<Surfaceparms, string>();

            foreach (var surfaceparm in (Surfaceparms[])Enum.GetValues(typeof(Surfaceparms)))
            {
                Strings.Add(surfaceparm, surfaceparm.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static string ToString(Surfaceparms surfaceparm)
        {
            return Surfaceparm.Strings[surfaceparm];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Surfaceparms FromString(string input)
        {
            foreach (var kvp in Surfaceparm.Strings)
            {
                if (kvp.Value == input)
                {
                    return kvp.Key;
                }
            }

            return Surfaceparms.NULL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static SurfaceparmAttribute GetAttributes(Surfaceparms surfaceparm)
        {
            var memInfo = typeof(Surfaceparms).GetMember(surfaceparm.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(SurfaceparmAttribute), false);
            return (SurfaceparmAttribute)attributes[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static string GetName(Surfaceparms surfaceparm)
        {
            return Surfaceparm.GetAttributes(surfaceparm).Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static string GetDescription(Surfaceparms surfaceparm)
        {
            return Surfaceparm.GetAttributes(surfaceparm).Description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static bool IsVolume(Surfaceparms surfaceparm)
        {
            return Surfaceparm.GetAttributes(surfaceparm).Volume;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static bool IsFootstep(Surfaceparms surfaceparm)
        {
            return Surfaceparm.GetAttributes(surfaceparm).Footsteps;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static bool IsETJump(Surfaceparms surfaceparm)
        {
            return Surfaceparm.GetAttributes(surfaceparm).ETJump;
        }
    }

    public enum Surfaceparms
    {
        [Surfaceparm(Name = "NULL")]
        NULL = 0,

        [Surfaceparm(Name = "Missile Clip", Description = "Clip that blocks missile weapons (grenades, panzer, etc.).", Volume = true)]
        clipmissile,

        [Surfaceparm(Name = "Water", Description = "Liquid.", Volume = true)]
        water,

        [Surfaceparm(Name = "Slag", Description = "Liquid with lower acceleration than 'water'.", Volume = true)]
        slag,

        [Surfaceparm(Name = "Lava", Description = "TODO", Volume = true)]
        lava,

        [Surfaceparm(Name = "Clip", Description = "Basic clip, blocks player movement but not projectiles.", Volume = true)]
        playerclip,

        [Surfaceparm(Name = "Monster Clip", Description = "TODO", Volume = true)]
        monsterclip,

        [Surfaceparm(Name = "No Drop", Description = "Spawning entities (weapons, gibs, medpacks) disappear/don't spawn inside this volume.", Volume = true)]
        nodrop,

        // TODO: volume
        [Surfaceparm(Name = "Non-solid", Description = "There is no collision with this brush.", Volume = true)]
        nonsolid,

        [Surfaceparm(Name = "Origin",
            Description = "Used with brush based entities. There should never be a reason to use this aside from common/origin.",
            Volume = true)]
        origin,

        [Surfaceparm(Name = "Trans", Description = "Compiler ignores these surfaces when compiling vis.")]
        trans,

        [Surfaceparm(Name = "Detail",
            Description = "Compiler ignores brushes that have this surfaceparm when compiling vis. " +
            "Mark brushes as detail in Radiant instead unless you know what you are doing.")]
        detail,

        [Surfaceparm(Name = "Structural",
            Description = "Compiler takes into account brushes that have this surfaceparm when compiling vis. " +
            "Mark brushes as structural in Radiant instead unless you know what you are doing.",
            Volume = true)]
        structural,

        [Surfaceparm(Name = "Area Portal", Volume = true)]
        areaportal,

        [Surfaceparm(Name = "No Save", Description = "Allows/Disallows save inside this volume depending on 'nosave'-worldspawn key.", Volume = true, ETJump = true)]
        clusterportal,

        [Surfaceparm(Name = "No Prone", Description = "Allows/Disallows proning inside this volume depending on 'noprone'-worldspawn key.", Volume = true, ETJump = true)]
        donotenter,

        [Surfaceparm(Name = "Do Not Enter (Large)", Volume = true, ETJump = true)]
        donotenterlarge,

        [Surfaceparm(Name = "Fog", Description = "Use for fog with 'fogparms'. Surfaceparms 'nodraw', 'nonsolid' and 'trans' recommended.", Volume = true)]
        fog,

        [Surfaceparm(Name = "Sky", Description = "Use for skyboxes with 'skyparms'. Surfaceparms 'nodlight', 'noimpact' and 'nolightmap' recommended.")]
        sky,

        [Surfaceparm(Name = "Light Filter", Description = "Light is filtered using this surface's color and alpha channels. Slows down light compile a lot.")]
        lightfilter,

        [Surfaceparm(Name = "Alpha-shadow", Description = "Light is filtered using this surface's alpha channel. Slows down light compile.")]
        alphashadow,

        [Surfaceparm(Name = "Hint", Description = "Compiler splits all vis portals across this surface's global plane.")]
        hint,

        [Surfaceparm(Name = "Skip", Description = "Compiler skips these surfaces completely.")]
        skip,

        [Surfaceparm(Name = "Slick", Description = "Use on slick surfaces like ice.")]
        slick,

        [Surfaceparm(Name = "No Impact", Description = "Explosives disappear without exploding when hitting this surface.")]
        noimpact,

        [Surfaceparm(Name = "No Marks", Description = "Decals (bullet holes, explosion marks) don't appear on this surface.")]
        nomarks,

        [Surfaceparm(Name = "Ladder", Description = "")]
        ladder,

        [Surfaceparm(Name = "Cushion", Description = "")]
        nodamage,

        [Surfaceparm(Name = "Monster Slick", Unused = true)]
        monsterslick,

        [Surfaceparm(Name = "Glass")]
        glass,

        [Surfaceparm(Name = "Splash Steps", Footsteps = true)]
        splash,

        /*
        [Surfaceparm(Name = "", Footsteps = true)]
        metal = metalsteps,
        */

        [Surfaceparm(Name = "Metal steps", Footsteps = true)]
        metalsteps,

        [Surfaceparm(Name = "No Footsteps", Footsteps = true)]
        nosteps,

        [Surfaceparm(Name = "Wood Steps", Footsteps = true)]
        woodsteps,

        [Surfaceparm(Name = "Grass Steps", Footsteps = true)]
        grasssteps,

        [Surfaceparm(Name = "Gravel Steps", Footsteps = true)]
        gravelsteps,

        [Surfaceparm(Name = "Carpet Steps", Footsteps = true)]
        carpetsteps,

        [Surfaceparm(Name = "Snow Steps", Footsteps = true)]
        snowsteps,

        [Surfaceparm(Name = "Roof Steps", Footsteps = true)]
        roofsteps,

        [Surfaceparm(Name = "Rubble", Unused = true)]
        rubble,

        [Surfaceparm(Name = "No Draw", Description = "This surface isn't drawn in-game at all.")]
        nodraw,

        [Surfaceparm(Name = "No Pointlight")]
        pointlight,

        [Surfaceparm(Name = "No Lightmap", Description = "Compiler ignores these surfaces when compiling lightmaps.")]
        nolightmap,

        [Surfaceparm(Name = "No Dynamic Light")]
        nodlight,

        [Surfaceparm(Name = "No Jump Delay", Description = "Enables/Disables jump delay on this surface depending on 'nojumpdelay'-worldspawn key.", ETJump = true)]
        monsterslicknorth,

        [Surfaceparm(Name = "Portal Surface", Description = "Enables/Disables portalgun portals on this surface depending on '???'-worldspawn key.", ETJump = true)]
        monsterslickeast,

        [Surfaceparm(Name = "No Overbounce", Description = "Enables/Disables overbounce on this surface depending on 'nooverbounce'-worldspawn key.", ETJump = true)]
        monsterslicksouth,

        [Surfaceparm(Name = "Monsterslick West", Unused = true)]
        monsterslickwest,

        //TODO: check
        [Surfaceparm(Name = "Landmine")]
        landmine = monsterslickwest
    }
}
