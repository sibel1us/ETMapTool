using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Rect = System.Tuple<double, double, double, double>;

namespace ETMapHelper.Maps
{
    public static class MapExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="texture"></param>
        /// <param name="keepStructural"></param>
        /// <param name="deletePatches"></param>
        /// <returns></returns>
        public static int DeleteSingleTextured(this Map map, string texture, bool keepStructural, bool deletePatches)
        {
            // TODO: replace this whole thing with linq in the UI
            int deletedCount = 0;

            foreach (Entity entity in map.Entities)
            {
                deletedCount += entity.Brushes.RemoveAll
                (
                    brush => keepStructural ? brush.Detail : true
                          && brush.Faces.All(f => f.Texture == texture)
                );

                if (deletePatches)
                {
                    deletedCount += entity.Patches.RemoveAll(patch => patch.Texture == texture);
                }
            }

            return 0;
        }

        /// <summary>
        /// Deletes brush based entities with zero brushes.
        /// </summary>
        /// <returns>List of deleted entities</returns>
        public static List<Entity> DeleteEmptyBrushBasedEntities(this Map map)
        {
            List<Entity> deleted = new List<Entity>();

            /*
            var toBeDeleted = from entity in map.Entities
                              where entity.Classname().StartsWith("trigger_") || entity.Classname().StartsWith("trigger_")
                              where !entity.Brushes.Any()
                              select entity;
            */

            for (int i = map.Entities.Count - 1; i >= 0; --i)
            {
                var ent = map.Entities[i];
                if (ent.Classname.StartsWith("trigger_") || ent.Classname.StartsWith("func_"))
                {
                    if (ent.Brushes.Count == 0)
                    {
                        deleted.Add(ent);
                        map.Entities.RemoveAt(i);
                    }
                }
            }

            return deleted;
        }

        public static List<Entity> ReplaceValue(this Map map, string key, string oldValue, string newValue, IEnumerable<string> targets = null)
        {
            if (key == Tokens.classname)
                throw new ArgumentException("", nameof(key));

            if (!targets.Any()) targets = null;

            foreach (var entity in map.Entities.Where(ent => targets?.Contains(ent.Classname) ?? true))
            {
                if (entity.Props.ContainsKey(key))
                {
                    // TODO
                }
            }

            return null;
        }

        /// <summary>
        /// Calculates the bounds of map's brushes for use in command map. Format: [minX,minY,maxX,maxY]
        /// </summary>
        /// <param name="structuralOnly"></param>
        /// <param name="margin"></param>
        /// <returns>Coordinates in format [minX,minY,maxX,maxY]</returns>
        public static Rect CalculateMapCoords(this Map map, bool structuralOnly, double margin)
        {
            return map.CalculateMapCoords(structuralOnly, margin, margin, margin, margin);
        }

        /// <summary>
        /// Calculates the bounds of map's brushes for use in command map. Format: [minX,minY,maxX,maxY]
        /// </summary>
        /// <param name="marginMinX">Margin for lower X limit.</param>
        /// <param name="marginMinY">Margin for lower Y limit.</param>
        /// <param name="marginMaxX">Margin for upper X limit.</param>
        /// <param name="marginMaxY">Margin for upper Y limit.</param>
        /// <returns>Coordinates in format [minX,minY,maxX,maxY]</returns>
        public static Rect CalculateMapCoords(this Map map, bool structuralOnly, double marginMinX, double marginMinY, double marginMaxX, double marginMaxY)
        {
            // Min/MaxValue ensures the first brush will assign always (in theory!)
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = double.MinValue;
            double maxY = double.MinValue;

            foreach (var ent in map.Entities)
            {
                var brushes = ent.Brushes.Where(b => structuralOnly ? !b.Detail : true);

                foreach (var brush in brushes)
                {
                    foreach (var face in brush.Faces)
                    {
                        foreach (var vertex in face.Vertex)
                        {
                            if (vertex.X > maxX) maxX = vertex.X;
                            if (vertex.X < minX) minX = vertex.X;
                            if (vertex.Y > maxY) maxY = vertex.Y;
                            if (vertex.Y < minY) minY = vertex.Y;
                        }
                    }
                }
            }

            return Tuple.Create
            (
                minX - marginMinX,
                minY - marginMinY,
                maxX + marginMaxX,
                maxY + marginMaxY
            );
        }
    }
}
