﻿using Conference.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Conference.Frontend
{
    public class ConferenceService
    {
        private IHttpService httpService;

        public ConferenceService(IHttpService httpServiceImpl)
        {
            httpService = httpServiceImpl;
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            var json = await httpService.GetStringAsync("https://raw.githubusercontent.com/robinmanuelthiel/xamarinworkshop/master/06%20Speaker%20App%20with%20Xamarin.Forms/Mock/mocksessions.json");
            var sessions = JsonConvert.DeserializeObject<List<Session>>(json);
            return sessions;
        }

        public async Task<List<Speaker>> GetSpeakersAsync()
        {
            var json = await httpService.GetStringAsync("https://raw.githubusercontent.com/robinmanuelthiel/xamarinworkshop/master/06%20Speaker%20App%20with%20Xamarin.Forms/Mock/mockspeakers.json");
            var speakers = JsonConvert.DeserializeObject<List<Speaker>>(json);
            return speakers;
        }
    }
}