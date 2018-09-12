using ShaderTools.Shaders.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Helpers
{
    public static class SurfaceparmHelper
    {
        /// <summary>
        /// Returns all <see cref="Surfaceparms"/>.
        /// </summary>
        public static List<Surfaceparms> Members => ((Surfaceparms[])Enum.GetValues(typeof(Surfaceparms))).ToList();

        /// <summary>
        /// Returns a list of surfaceparms that are useless when used on volume shaders.
        /// </summary>
        /// <returns></returns>
        public static List<Surfaceparms> UselessWithVolume()
        {
            var list = new List<Surfaceparms>
            {
                Surfaceparms.slick,
                Surfaceparms.nodamage,
            };

            list.AddRange(Members.Where(sp => GetFlags(sp).HasFlag(SurfparmFlags.Footsteps)));
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static DisplayAttribute GetDisplayAttributes(Surfaceparms surfaceparm)
        {
            var memInfo = typeof(Surfaceparms).GetMember(surfaceparm.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return (DisplayAttribute)attributes[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static SurfaceparmAttribute GetSurfaceparmAttributes(Surfaceparms surfaceparm)
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
        public static SurfparmFlags GetFlags(Surfaceparms surfaceparm)
        {
            return SurfaceparmHelper.GetSurfaceparmAttributes(surfaceparm).Flags;
        }
    }
}
