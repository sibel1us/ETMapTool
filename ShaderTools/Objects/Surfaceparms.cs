using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects
{
    /// <summary>
    /// Definitions for surfaceparm-values.
    /// </summary>
    public enum Surfaceparms
    {
        [Display(Name = "Missile Clip", Description = "Clip that blocks missile weapons (grenades, panzer, etc.).")]
        [Surfaceparm()]
        clipmissile,

        [Display(Name = "Water", Description = "Liquid.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Liquid)]
        water,

        [Display(Name = "Slag", Description = "Liquid with lower acceleration than 'water'.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Liquid)]
        slag,

        [Display(Name = "Lava", Description = "TODO")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Liquid)]
        lava,

        [Display(Name = "Clip", Description = "Basic clip, blocks player movement but not projectiles.")]
        [Surfaceparm(SurfparmFlags.Volume)]
        playerclip,

        [Display(Name = "Monster Clip", Description = "Clip that blocks BOT/AI movement.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Unused)]
        monsterclip,

        [Display(Name = "No Drop", Description = "Spawning entities (weapons, gibs, medpacks) disappear/don't spawn inside this volume.")]
        [Surfaceparm(SurfparmFlags.Volume)]
        nodrop,

        [Display(Name = "Non-solid", Description = "There is no collision with this brush.")]
        [Surfaceparm(SurfparmFlags.Volume)]
        nonsolid,

        [Display(Name = "Origin", Description = "Used with brush based entities.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.DoNotUse)]
        origin,

        [Display(Name = "Trans", Description = "Compiler ignores these surfaces when compiling vis, also doesn't eat up contained brushes.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.AffectsVis)]
        trans,

        [Display(Name = "Detail", Description = "Compiler ignores brushes that have this surfaceparm when compiling vis.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Avoid | SurfparmFlags.AffectsVis)]
        detail,

        [Display(Name = "Structural", Description = "Compiler takes into account brushes that have this surfaceparm when compiling vis.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Avoid | SurfparmFlags.AffectsVis)]
        structural,

        [Display(Name = "Area Portal", Description = "Use to split vis portals in the map (inside doors for example).")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Avoid | SurfparmFlags.AffectsVis)]
        areaportal,

        [Display(Name = "No Save", Description = "Allows/Disallows save inside this volume depending on 'nosave'-worldspawn key.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.ETJump)]
        clusterportal,

        [Display(Name = "No Prone", Description = "Allows/Disallows proning inside this volume depending on 'noprone'-worldspawn key.")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.ETJump)]
        donotenter,

        [Display(Name = "Do Not Enter (Large)", Description = "?")]
        [Surfaceparm(SurfparmFlags.Volume | SurfparmFlags.Avoid | SurfparmFlags.Unused)]
        donotenterlarge,

        [Display(Name = "Fog", Description = "Use for fog with 'fogparms'.")]
        [Surfaceparm(SurfparmFlags.Volume, UseWith = new Surfaceparms[] { nodraw, nonsolid, trans })]
        fog,

        [Display(Name = "Sky", Description = "Use for skyboxes with 'skyparms'.")]
        [Surfaceparm(SurfparmFlags.None, UseWith = new Surfaceparms[] { nodlight, noimpact, nolightmap })]
        sky,

        [Display(Name = "Light Filter", Description = "Light is filtered using this surface's color and alpha channels. Slows down light compile a lot.")]
        [Surfaceparm(SurfparmFlags.AffectsLight)]
        lightfilter,

        [Display(Name = "Alpha-shadow", Description = "Light is filtered using this surface's alpha channel. Slows down light compile.")]
        [Surfaceparm(SurfparmFlags.AffectsLight)]
        alphashadow,

        [Display(Name = "Hint", Description = "Compiler splits all vis portals across this surface's global plane.")]
        [Surfaceparm(SurfparmFlags.AffectsVis | SurfparmFlags.Avoid)]
        hint,

        [Display(Name = "Skip", Description = "Compiler skips these surfaces completely.")]
        [Surfaceparm(SurfparmFlags.Avoid)]
        skip,

        [Display(Name = "Slick", Description = "Use on slick surfaces like ice.")]
        slick,

        [Display(Name = "No Impact", Description = "Explosives disappear without exploding when hitting this surface.")]
        noimpact,

        [Display(Name = "No Marks", Description = "Decals (bullet holes, explosion marks) don't appear on this surface.")]
        nomarks,

        [Display(Name = "Ladder", Description = "")]
        ladder,

        [Display(Name = "Cushion", Description = "Enables/Disables fall damage on this surface depending on 'nofalldamage'-worldspawn key.")]
        nodamage,

        [Display(Name = "Monster Slick")]
        [Surfaceparm(SurfparmFlags.Avoid)]
        monsterslick,

        [Display(Name = "Glass", Description = "Changes bullet sounds when hitting this surface.")]
        glass,

        [Display(Name = "No Footsteps", Description = "No footsteps play on this surface.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        nosteps,

        [Display(Name = "Splash Steps", Description = "Treated as splashy water for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        splash,

        [Display(Name = "Metal steps", Description = "Treated as a metal material for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        metalsteps,

        [Display(Name = "Wood Steps", Description = "Treated as a wooden material for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        woodsteps,

        [Display(Name = "Grass Steps", Description = "Treated as a grassy ground for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        grasssteps,

        [Display(Name = "Gravel Steps", Description = "Treated as gravel for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        gravelsteps,

        [Display(Name = "Carpet Steps", Description = "Treated as soft carpet for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        carpetsteps,

        [Display(Name = "Snow Steps", Description = "Treated as snow for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        snowsteps,

        [Display(Name = "Roof Steps", Description = "Treated as a tin metal roof for footsteps and bullet impacts.")]
        [Surfaceparm(SurfparmFlags.Footsteps)]
        roofsteps,

        [Display(Name = "Rubble")]
        [Surfaceparm(SurfparmFlags.Unused)]
        rubble,

        [Display(Name = "No Draw", Description = "This surface isn't drawn in-game at all.")]
        nodraw,

        [Display(Name = "No Pointlight")]
        [Surfaceparm(SurfparmFlags.AffectsLight)]
        pointlight,

        [Display(Name = "No Lightmap", Description = "Compiler ignores these surfaces when compiling lightmaps.")]
        [Surfaceparm(SurfparmFlags.AffectsLight)]
        nolightmap,

        [Display(Name = "No Dynamic Light")]
        [Surfaceparm(SurfparmFlags.AffectsLight)]
        nodlight,

        [Display(Name = "No Jump Delay", Description = "Enables/Disables jump delay on this surface depending on 'nojumpdelay'-worldspawn key.")]
        [Surfaceparm(SurfparmFlags.ETJump)]
        monsterslicknorth,

        [Display(Name = "Portal Surface", Description = "Enables/Disables portalgun portals on this surface depending on 'portalsurfaces'-worldspawn key.")]
        [Surfaceparm(SurfparmFlags.ETJump)]
        monsterslickeast,

        [Display(Name = "No Overbounce", Description = "Enables/Disables overbounce on this surface depending on 'nooverbounce'-worldspawn key.")]
        [Surfaceparm(SurfparmFlags.ETJump)]
        monsterslicksouth,

        [Display(Name = "Landmine")]
        landmine,
    }
}
