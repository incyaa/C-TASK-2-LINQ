using System.Linq;

namespace C__TASK__2_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> corpus = new List<string>
            {
                "Котенок играет с мячиком в комнате.",
                "Собака бежит по зеленому полю.",
                "Птицы щебечут на ветках деревьев.",
                "Рыбы плывут в пруду под лучами солнца.",
                "Цветы расцветают весной в саду."
            };

            var values = corpus.Select(cs => cs.Split(' '))
                                .SelectMany(sa => sa.Select(s => s))
                                .GroupBy(s => s)
                                .Select(gp => new
                                {
                                    Name = gp.Key,
                                    Count = gp.Where(s => s == gp.Key).Count()
                                });
            var CountInCorpus = corpus.Select(s => s.Count()).ToList();
            var BestWord = values.OrderByDescending(nc => nc.Count).Take(3);
            foreach (var item in BestWord)
            {
                Console.WriteLine(item.Name + " " + item.Count);
            }
            var UniqWord = values.Where(nc => nc.Count == 1).OrderBy(s => s.Name);

            foreach (var item in UniqWord)
            {
                Console.WriteLine(item.Name);
            }
            List<string> strings = new List<string> { "Котенок", "мячик" };
            var Search = strings.SelectMany(ss => corpus.Select(cs => cs), (ss, cs) => new
            {
                str = cs.Contains(ss) == true ? cs : string.Empty
            }).Where(s => s.str.Length > 0).Distinct();
            foreach (var item in Search)
            {
                Console.WriteLine(item.str);
            }
        }
    }
}