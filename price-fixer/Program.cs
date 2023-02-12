// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;

//internal class Program
//{
//    private async static void Main(string[] args)
//    {
//var client = new HttpClient();

//// Create the HttpContent for the form to be posted.
//var requestContent = new FormUrlEncodedContent(new[] {
//    new KeyValuePair<string, string>("text", "This is a block of text"),
//});



//List<Item> items = new();
////Object lockMe = new Object();


////Parallel.For(6874621-10, 6874621+10, async (i) =>
////Parallel.For((uint)0, uint.MaxValue, async (i) =>
////for (; i++)
//var t = Stopwatch.StartNew();
//var tt = Stopwatch.GetTimestamp();





//for (uint i = 0; i< uint.MaxValue; i++)
//{

//    if (i % 1000 == 0)
//        Console.WriteLine(i);

//    try
//    {
//        HttpResponseMessage response = await client.PostAsync($"https://www.continente.pt/produto/{i}.html", requestContent);
//        HttpContent responseContent = response.Content;
//        string str;
//        using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
//        {
//            str = await reader.ReadToEndAsync();
//        }



//        var productDetailsIdx = str.IndexOf("product-name-details--wrapper");
//        if (productDetailsIdx != -1)
//        {
//            var details = str.Substring(productDetailsIdx, 2000);

//            var name = str.Substring(str.IndexOf("product-name "), 100).Split("\n")[1];
//            name = System.Net.WebUtility.HtmlDecode(name);

//            var brandToken = "ct-pdp--brand";
//            var brand = details.Substring(details.IndexOf(brandToken), 250).Split("\n")[1];


//            var qtdToken = "ct-pdp--unit";
//            var qtd = details.Substring(details.IndexOf(qtdToken), 250).Split("\n")[1];

//            if (qtd.Contains("</span>"))
//                qtd = "";

//            var p = str.Substring(str.IndexOf("ct-price-formatted"), 50).Split("\n")[1].Split(';')[1];
//            var price = float.Parse(p, new CultureInfo("de-DE"));

//            items.Add(
//                new Item()
//                {
//                    ID = (uint)i,
//                    Name = name,
//                    Brand = brand,
//                    Description = qtd,
//                    Price = price,
//                });
//        }

//    }
//    catch (Exception e)
//    {
//        Console.WriteLine($"prod {i} failed");
//    }
//    //});
//}

///////////////////////


//0   357913941
//357913941   715827882
//715827882   1073741823
//1073741823  1431655764
//1431655764  1789569705
//1789569705  2147483646
//2147483646  2505397587
//2505397587  2863311528
//2863311528  3221225469
//3221225469  3579139410
//3579139410  3937053351
//3937053351  4294967292





//6874611
//6874631





//var t2 = new Task(() => ProcessBacthAsync(6874621-10, 6874621+10));


//var t1 = ProcessBacthAsync(0, 357913941);
//var t2 = ProcessBacthAsync(357913941, 715827882);
//var t3 = ProcessBacthAsync(715827882, 1073741823);
//var t4 = ProcessBacthAsync(1073741823, 1431655764);
//var t5 = ProcessBacthAsync(1431655764, 1789569705);
//var t6 = ProcessBacthAsync(1789569705, 2147483646);

//var t21 = ProcessBacthAsync(2147483646, 2505397587);
//var t22 = ProcessBacthAsync(2505397587, 2863311528);
//var t23 = ProcessBacthAsync(2863311528, 3221225469);
//var t24 = ProcessBacthAsync(3221225469, 3579139410);
//var t25 = ProcessBacthAsync(3579139410, 3937053351);
//var t26 = ProcessBacthAsync(3937053351, 4294967295);


var taskArray = CreateTasks(000_177_031, 357_913_941, 12);

//var taskArray = new Task[] { t1, t2};



//foreach (var task in taskArray)
//{
//    task.Start();
//}

Task.WaitAll(taskArray);



/////////////////////////////









//Console.WriteLine(Stopwatch.GetElapsedTime(tt));


Console.WriteLine("END");

//using (StreamWriter sw = new StreamWriter("dump.txt"))
//{
//    foreach (var item in items)
//    {
//        var it = item.ToString();
//        Console.WriteLine(it);
//        sw.WriteLine(it);
//    }
//}


Console.ReadLine();



Task[] CreateTasks(uint start, uint stop, byte nTasks)
{
    var tasks = new Task[nTasks];
    uint n = (stop - start) / nTasks;

    for (uint i = 0; i < nTasks; i++)
    {
        uint s = start + i * n;
        Console.WriteLine($"{s} {s+n}");
        tasks[i] = ProcessBacthAsync(s, s + n);
    }
    return tasks;
}


static async void P1(uint start, uint stop)
{
    using (StreamWriter sw = new StreamWriter($"D{start}_{stop}.txt"))
    {
        for (uint i = start; i< stop; i++)
        {
            await sw.WriteLineAsync((char)i);
        }
    }
}




static async Task ProcessBacthAsync(uint start, uint stop)
{
    var client = new HttpClient();
    var requestContent = new FormUrlEncodedContent(new[] {
    new KeyValuePair<string, string>("text", "This is a block of text"),
    });

    using (StreamWriter sw = new StreamWriter($"dump{start}_{stop}.txt"))
    {

        for (uint i = start; i< stop; i++)
        {
            sw.WriteLine(i);
            sw.Flush();

            //if (i % 1000 == 0)
            //    Console.WriteLine(i);

            try
            {
                HttpResponseMessage response = await client.PostAsync($"https://www.continente.pt/produto/{i}.html", requestContent);
                HttpContent responseContent = response.Content;
                string str;
                using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                {
                    str = await reader.ReadToEndAsync();
                }

                var productDetailsIdx = str.IndexOf("product-name-details--wrapper");
                if (productDetailsIdx != -1)
                {
                    var details = str.Substring(productDetailsIdx, 2000);

                    var name = str.Substring(str.IndexOf("product-name "), 100).Split("\n")[1];
                    name = System.Net.WebUtility.HtmlDecode(name);

                    var brandToken = "ct-pdp--brand";
                    var brand = details.Substring(details.IndexOf(brandToken), 250).Split("\n")[1];


                    var qtdToken = "ct-pdp--unit";
                    var qtd = details.Substring(details.IndexOf(qtdToken), 250).Split("\n")[1];

                    if (qtd.Contains("</span>"))
                        qtd = "";

                    var p = str.Substring(str.IndexOf("ct-price-formatted"), 50).Split("\n")[1].Split(';')[1];
                    var price = float.Parse(p, new CultureInfo("de-DE"));

                    var it =
                        new Item()
                        {
                            ID = (uint)i,
                            Name = name,
                            Brand = brand,
                            Description = qtd,
                            Price = price,
                        };


                    sw.WriteLine(it.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"prod {i} failed");
                sw.WriteLine($"prod {i} failed");
            }
        }
    }
}