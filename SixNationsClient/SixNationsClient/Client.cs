using SixNations2017.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SixNationsClient
{
    class Client
    {
        static async Task GetsAsync()                        
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9167/api/sixnations/"); //base address

                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml

                    HttpResponseMessage response = await client.GetAsync("players/all");              // returns all players            
                    if (response.IsSuccessStatusCode)                                                   
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



                    response = await client.GetAsync("players/tries"); //gets a list of tries scored by all players
                    if (response.IsSuccessStatusCode)
                    {
                        var tries = await response.Content.ReadAsAsync<IEnumerable<Player>>();
                        foreach (var Try in tries)
                        {
                            Console.WriteLine(Try.Name + " " + Try.TriesScored);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    response = await client.GetAsync("players/scoredtries/Ireland");  //gets players who have scored more than one try in a specific team
                    if (response.IsSuccessStatusCode)
                    {
                        var team = await response.Content.ReadAsAsync<IEnumerable<Player>>();
                        foreach (var t in team)
                        {
                            Console.WriteLine("Team:" + t.InternationalTeam + ", Name: " + t.Name + ", Tries Scored: " + t.TriesScored);
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
        
            static void Main()
            {
                GetsAsync().Wait();
                Console.ReadLine();
            }
        }
    }
