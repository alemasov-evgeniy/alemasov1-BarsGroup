using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Коллекции
{
    class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }


        public void OrderByEx1()
        {
            List<Entity> entities = new List<Entity>
                {new Entity {Id=1, ParentId=0, Name = "Root entity"},
                 new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity" },
                 new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity" },
                 new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity" },
                 new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity" }};

            Dictionary<int, List<Entity>> dic = new Dictionary<int, List<Entity>>();
            //Dictionary<string, string> dic = new Dictionary<string, string>();

            IEnumerable<Entity> query = entities.OrderBy(x => x.Id).ToList();
            foreach (Entity entity in query)
            {
                
                if (!dic.ContainsKey(entity.ParentId))
                {
                    dic.Add(entity.ParentId, new List<Entity> { });
                    Console.WriteLine(entity.ParentId.ToString());
                    //Console.WriteLine(dic.Count);
                }

                //else
                //{
                //    //dic.Add(ParentId.ToString(), Id.ToString());
                    //Console.WriteLine("false");
                    dic[entity.ParentId].Add(new Entity());

                //}

                //add
                //dic.Add($"Key = {entity.ParentId}", new List<string>());

                //dic[entity.ParentId.ToString()].Add($"Value = { entity.Id}");

                //dic.Add($"Key = {entity.ParentId}", $"Value = {entity.Id}");
                //Console.WriteLine($"Key = {entity.ParentId}, Value = { entity.Id}");
            }

            foreach (var value in dic)
            {
                //Console.WriteLine("key"+value.Key);
                foreach (var item in value.Value)
                    
                    //Console.WriteLine($"Key = {value.Key} Value = {item}");
                    Console.Write("value "+item);
            }

            //foreach (var k1 in dic)
            //{
            //    foreach (var k2 in k1.Value)
            //    {
            //        Console.WriteLine($"Key = {k1.Key}  value: {k2}");
            //    }    

            //}
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Entity entity = new Entity();
            entity.OrderByEx1();
            Console.ReadKey();
        }
    }
}
