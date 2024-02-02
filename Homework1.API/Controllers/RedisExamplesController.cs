using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Homework1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisExamplesController : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisExamplesController(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = _redis.GetDatabase();
        }

        // String veri tipi örneği
        [HttpGet("StringExample")]
        public IActionResult StringExample()
        {
            string value = "JohnDoe";
            _db.StringSet("stringExampleKey", value);
            return Ok(value);
        }

        // Hash veri tipi örneği
        [HttpGet("HashExample")]
        public IActionResult HashExample()
        {
            HashEntry[] hashEntries = new HashEntry[]
            {
                new HashEntry("name", "John"),
                new HashEntry("age", 30),
                new HashEntry("city", "New York")
            };

            _db.HashSet("hashExampleKey", hashEntries);

            return Ok(hashEntries.Select(entry => new
            {
                Name = entry.Name.ToString(),
                Value = entry.Value.ToString(),
                Key = "hashExampleKey"
            }));
        }

        // List veri tipi örneği
        [HttpGet("ListExample")]
        public IActionResult ListExample()
        {
            string[] values = new string[] { "Item1", "Item2", "Item3" };
            _db.ListLeftPush("listExampleKey", values.Select(value => (RedisValue)value).ToArray());
            return Ok(values);
        }

        // Set veri tipi örneği
        [HttpGet("SetExample")]
        public IActionResult SetExample()
        {
            string[] values = new string[] { "Member1", "Member2", "Member3" };
            _db.SetAdd("setExampleKey", values.Select(value => (RedisValue)value).ToArray());
            return Ok(values);
        }

        // Sorted Set veri tipi örneği
        [HttpGet("SortedSetExample")]
        public IActionResult SortedSetExample()
        {
            SortedSetEntry[] sortedSetEntries = new SortedSetEntry[]
            {
                new SortedSetEntry("Member1", 1),
                new SortedSetEntry("Member2", 2),
                new SortedSetEntry("Member3", 3)
            };

            _db.SortedSetAdd("sortedSetExampleKey", sortedSetEntries);
            return Ok(sortedSetEntries);
        }
    }
}


