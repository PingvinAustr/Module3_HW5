using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_HW5
{
    public class AsyncHandler
    {
        public async ValueTask<string> ReadHello()
        {
            string path = "../../../TextFiles/HelloFile.txt";
            string text = string.Empty;

            using (StreamReader reader = new StreamReader(path))
            {
                text = await reader.ReadToEndAsync();
            }

            return text;
        }

        public async ValueTask<string> ReadWorld()
        {
            string path = "../../../TextFiles/WorldFile.txt";
            string text = string.Empty;

            using (StreamReader reader = new StreamReader(path))
            {
                text = await reader.ReadToEndAsync();
            }

            return text;
        }

        public async ValueTask<string> Concat()
        {
            string helloString = string.Empty, worldString = string.Empty;

            var taskList = new List<Task>();
            taskList.Add(Task.Run(async () =>
            {
                helloString = await ReadHello();
            }));

            taskList.Add(Task.Run(async () =>
            {
                worldString = await ReadWorld();
            }));

            Task.WhenAll(taskList).Wait();
            return helloString + worldString;
        }
    }
}
