using System;
using System.Collections.Generic;

namespace Коллекции
{
    public class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

        public Entity(int Id, int ParentId, string Name)
        {
            this.Id = Id;
            this.ParentId = ParentId;
            this.Name = Name;
        }
    }
    static class Program
    {
        private static void Main()
        {

            Entity Entity1 = new Entity(1, 0, "Root entity");
            Entity Entity2 = new Entity(2, 1, "Child of 1 entity");
            Entity Entity3 = new Entity(3, 1, "Child of 1 entity");
            Entity Entity4 = new Entity(4, 2, "Child of 2 entity");
            Entity Entity5 = new Entity(5, 4, "Child of 4 entity");

            List<Entity> entitiesList = new List<Entity>() { Entity1, Entity1, Entity3, Entity4, Entity5 };

            Dictionary<int, List<Entity>> entitiesDict = Dic(entitiesList);

            foreach (var keys in entitiesDict)
            {
                Console.Write($"Key : {keys.Key}, Value: List{{");
                foreach (var values in keys.Value)
                {
                    Console.Write($"Entity{{Id = {values.Id}}}");
                }
                Console.WriteLine("}");
            }
            Console.ReadKey();
        }

        public static Dictionary<int, List<Entity>> Dic(List<Entity> list)
        {
            Dictionary<int, List<Entity>> dic = new Dictionary<int, List<Entity>>();

            List<Entity> entities = new List<Entity>();

            foreach (Entity en in list)
            {
                if (dic.TryGetValue(en.ParentId, out List<Entity> newList))
                {
                    if (!newList.Contains(en))
                    {
                        newList.Add(en);
                    }
                }
                else
                {
                    dic.Add(en.ParentId, new List<Entity>() { en });
                }
            }
            return dic;
        }
    }

    
}
