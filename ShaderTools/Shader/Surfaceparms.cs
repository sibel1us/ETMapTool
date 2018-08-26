using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader
{
    public enum Surfaceparms
    {
        [Surfaceparm(Name = "Missile Clip", Volume = true)]
        clipmissile,

        [Surfaceparm(Name = "Water", Volume = true)]
        water,

        [Surfaceparm(Name = "Slag", Volume = true)]
        slag,

        [Surfaceparm(Name = "Lava", Volume = true)]
        lava,

        [Surfaceparm(Name = "Clip", Volume = true)]
        playerclip,

        [Surfaceparm(Name = "Monster Clip", Volume = true)]
        monsterclip,

        [Surfaceparm(Name = "No Drop", Volume = true)]
        nodrop,

        [Surfaceparm(Name = "Non-solid")]
        nonsolid,

        [Surfaceparm(Name = "Origin", Volume = true)]
        origin,

        [Surfaceparm(Name = "Trans", Notes = "")]
        trans,

        [Surfaceparm(Name = "Detail", Volume = true)]
        detail,

        [Surfaceparm(Name = "Structural", Volume = true)]
        structural,

        [Surfaceparm(Name = "Area Portal", Volume = true)]
        areaportal,

        [Surfaceparm(Name = "No Save", Volume = true, ETJump = true)]
        clusterportal,

        [Surfaceparm(Name = "No Prone", Volume = true, ETJump = true)]
        donotenter,

        [Surfaceparm(Name = "Do Not Enter (Large)", Volume = true, ETJump = true)]
        donotenterlarge,

        [Surfaceparm(Name = "Fog", Volume = true)]
        fog,

        [Surfaceparm(Name = "Sky")]
        sky,

        [Surfaceparm(Name = "Light Filter")]
        lightfilter,

        [Surfaceparm(Name = "Alpha-shadow")]
        alphashadow,

        [Surfaceparm(Name = "Hint")]
        hint,

        [Surfaceparm(Name = "Skip")]
        skip,

        [Surfaceparm(Name = "Slick")]
        slick,

        [Surfaceparm(Name = "No Impact")]
        noimpact,

        [Surfaceparm(Name = "No Marks")]
        nomarks,

        [Surfaceparm(Name = "Ladder")]
        ladder,

        [Surfaceparm(Name = "Cushion")]
        nodamage,

        [Surfaceparm(Name = "Monster Slick", Unused = true)]
        monsterslick,

        [Surfaceparm(Name = "Glass", Footsteps = true)]
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

        [Surfaceparm(Name = "No Draw")]
        nodraw,

        [Surfaceparm(Name = "No Pointlight")]
        pointlight,

        [Surfaceparm(Name = "No Lightmap")]
        nolightmap,

        [Surfaceparm(Name = "No Dynamic Light")]
        nodlight,

        [Surfaceparm(Name = "No Jump Delay", ETJump = true)]
        monsterslicknorth,

        [Surfaceparm(Name = "Portal Surface", ETJump = true)]
        monsterslickeast,

        [Surfaceparm(Name = "No Overbounce", ETJump = true)]
        monsterslicksouth,

        [Surfaceparm(Name = "Monsterslick West", Unused = true)]
        monsterslickwest,

        //TODO: check
        [Surfaceparm(Name = "Landmine")]
        landmine = monsterslickwest
    }
}
