using BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace DataAccessLayer
{
    public class TwitterApiService
    {
        private readonly TwitsDataContext _twitsContext;

        public TwitterApiService(TwitsDataContext twitsContext)
        {
            _twitsContext = twitsContext;
        }


        private string accessToken = null;
        public async Task checkForPhotosInTwitsByText(string textToSearchFor)
        {
            try
            {

             

                var stream = Tweetinvi.Stream.CreateFilteredStream(
                    new TwitterCredentials("CY238Vi51lLvDLw8xbhzh2JCu",
                        "B5Pik3mQ6GebCc214MwXOUmfYQxGUB2rCW7JBV1V7k4jtSx1ht",
                        "935800346601033729-Dv0QUWtYx73R341AC5jSvqnLFXWI8p3",
                        "GcsQzEvCuE4ytHp3dx1lfru5L0eEwwdI0HoVOfenhO2Gw"));

                stream.AddTrack(textToSearchFor);

                stream.MatchingTweetReceived +=  (sender, args) =>
              {
                  var newTwit = new Twitt()
                  {
                      Text = args.Tweet.FullText,
                      AddingDate = args.Tweet.CreatedAt,
                      Track = textToSearchFor
                  };

                  var entities = args.Tweet.Entities;
                  if (entities != null && entities.Medias != null && entities.Medias.Any(e => e.MediaType == "photo"))
                  {
                      newTwit.HasImage = true;

                      foreach (var item in entities.Medias.Where(e => e.MediaType == "photo").Select(a => a.MediaURL).ToList())
                      {
                          newTwit.Images.Add(new TwitImage() { Url = item, TwittId = newTwit.Id , Track= newTwit.Track, AddingDate=newTwit.AddingDate});
                      }
                  }

                   _twitsContext.Add(newTwit);
                   _twitsContext.SaveChanges();

              };

                await stream.StartStreamMatchingAnyConditionAsync();

                #region old

                //var client = new HttpClient();

                ////HttpRequestMessage objRequest = new HttpRequestMessage(HttpMethod.Get,
                ////  "https://api.twitter.com/1.1/search/tweets.json?q=%" + textToSearchFor + "&count=" + twittsCount);
                //HttpRequestMessage objRequest = new HttpRequestMessage(System.Net.Http.HttpMethod.Post,
                //    "https://stream.twitter.com/1.1/statuses/filter.json?track=twitter");

                //objRequest.Headers.Add("track", "twitter");
                //objRequest.Headers.Add(HttpRequestHeader.Authorization.ToString(), "Bearer " + accessToken);
                //HttpResponseMessage response = await client.SendAsync(objRequest);

                //if (!response.IsSuccessStatusCode)
                //{ }

                //HttpContent responseContent = response.Content;

                //List<string> photos = new List<string>();
                //using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                //{

                //    string result = await reader.ReadToEndAsync();
                //    var stuffasds = JsonConvert.DeserializeObject<TwitterApiResponse>(result);


                //    photos = stuffasds.statuses.Where(x => x.entities.media != null)
                //       .SelectMany(x => x.entities.media.Where(a => a.type == "photo")).Select(w => w.media_url).ToList();

                //}
                //return photos; 
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void getAccessToken()
        {
            var post = WebRequest.Create("https://api.twitter.com/oauth2/token") as HttpWebRequest;
            post.Method = "POST";
            post.ContentType = "application/x-www-form-urlencoded";
            post.Headers[HttpRequestHeader.Authorization] = "Basic " + "Q1kyMzhWaTUxbEx2REx3OHhiaHpoMkpDdTpCNVBpazNtUTZHZWJDYzIxNE13WE9VbWZZUXhHVUIyckNXN0pCVjFWN2s0anRTeDFodA==";
            var reqbody = Encoding.UTF8.GetBytes("grant_type=client_credentials");
            post.ContentLength = reqbody.Length;
            using (var req = post.GetRequestStream())
            {
                req.Write(reqbody, 0, reqbody.Length);
            }
            try
            {
                string respbody = null;
                using (var resp = post.GetResponse().GetResponseStream())//there request sends
                {
                    var respR = new StreamReader(resp);
                    respbody = respR.ReadToEnd();
                }
                //TODO use a library to parse json
                accessToken = respbody.Substring(respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length, respbody.IndexOf("\"}") - (respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length));
            }
            catch (Exception ex)//if credentials are not valid (403 error)
            {
                //TODO
            }
        }
    }
}
