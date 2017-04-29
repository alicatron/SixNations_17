using SixNations2017.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SixNationsClient
{
    class Client
    {
        static async Task GetsAsync()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9167/api/sixnations/");

                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml

                    HttpResponseMessage response = await client.GetAsync("all");              // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        var players = await response.Content.ReadAsAsync<IEnumerable<Player>>();
                        foreach (var player in players)
                        {
                            Console.WriteLine(player.Name);
                        }

                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }



                    response = await client.GetAsync("tries");
                    if(response.IsSuccessStatusCode)
                    {
                        var tries = await response.Content.ReadAsAsync<IEnumerable<Player>>();
                        foreach (var Try in tries)
                        {
                            Console.WriteLine(Try.TriesScored + " " + Try.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            // kick off
            static void Main()
            {
                //PatchAsync().Wait();
                GetsAsync().Wait();
                Console.ReadLine();
            }
        }
    }
