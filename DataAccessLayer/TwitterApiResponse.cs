using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class TwitterApiResponse
    {
        public Status[] statuses { get; set; }
    }

    public class Status
    {
        public string created_at { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public Entities entities { get; set; }
        public Metadata metadata { get; set; }
        public string source { get; set; }
        public object in_reply_to_status_id { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public object in_reply_to_user_id { get; set; }
        public object in_reply_to_user_id_str { get; set; }
        public object in_reply_to_screen_name { get; set; }
        public User user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public Retweeted_Status retweeted_status { get; set; }
        public bool is_quote_status { get; set; }
        public string retweet_count { get; set; }
        public string favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public string lang { get; set; }
        public Extended_Entities1 extended_entities { get; set; }
        public bool possibly_sensitive { get; set; }
        public long quoted_status_id { get; set; }
        public string quoted_status_id_str { get; set; }
        public Quoted_Status1 quoted_status { get; set; }
    }

    public class Entities
    {
        public Hashtag[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public User_Mentions[] user_mentions { get; set; }
        public Url[] urls { get; set; }
        public List<Media> media { get; set; }
    }

    public class Hashtag
    {
        public string text { get; set; }
        public string[] indices { get; set; }
    }

    public class User_Mentions
    {
        public string screen_name { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string[] indices { get; set; }
    }

    public class Url
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Media
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string[] indices { get; set; }
        public string media_url { get; set; }
        public string media_url_https { get; set; }
        public string url { get; set; }
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string type { get; set; }
        public Sizes sizes { get; set; }
        public long source_status_id { get; set; }
        public string source_status_id_str { get; set; }
        public string source_user_id { get; set; }
        public string source_user_id_str { get; set; }
    }

    public class Sizes
    {
        public Large large { get; set; }
        public Medium medium { get; set; }
        public Thumb thumb { get; set; }
        public Small small { get; set; }
    }

    public class Large
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Medium
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Thumb
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Small
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Metadata
    {
        public string iso_language_code { get; set; }
        public string result_type { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public Entities1 entities { get; set; }
        public bool _protected { get; set; }
        public string followers_count { get; set; }
        public string friends_count { get; set; }
        public string listed_count { get; set; }
        public string created_at { get; set; }
        public string favourites_count { get; set; }
        public long? utc_offset { get; set; }
        public string time_zone { get; set; }
        public bool geo_enabled { get; set; }
        public bool verified { get; set; }
        public string statuses_count { get; set; }
        public string lang { get; set; }
        public bool contributors_enabled { get; set; }
        public bool is_translator { get; set; }
        public bool is_translation_enabled { get; set; }
        public string profile_background_color { get; set; }
        public string profile_background_image_url { get; set; }
        public string profile_background_image_url_https { get; set; }
        public bool profile_background_tile { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_banner_url { get; set; }
        public string profile_link_color { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string profile_text_color { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool has_extended_profile { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public object following { get; set; }
        public object follow_request_sent { get; set; }
        public object notifications { get; set; }
        public string translator_type { get; set; }

        internal static object GetAuthenticatatedUser()
        {
            throw new NotImplementedException();
        }
    }

    public class Entities1
    {
        public Description description { get; set; }
        public Url1 url { get; set; }
    }

    public class Description
    {
        public object[] urls { get; set; }
    }

    public class Url1
    {
        public Url2[] urls { get; set; }
    }

    public class Url2
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Retweeted_Status
    {
        public string created_at { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public Entities2 entities { get; set; }
        public Metadata1 metadata { get; set; }
        public string source { get; set; }
        public long? in_reply_to_status_id { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public long? in_reply_to_user_id { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public User1 user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public bool is_quote_status { get; set; }
        public string retweet_count { get; set; }
        public string favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public bool possibly_sensitive { get; set; }
        public string lang { get; set; }
        public Extended_Entities extended_entities { get; set; }
        public long quoted_status_id { get; set; }
        public string quoted_status_id_str { get; set; }
        public Quoted_Status quoted_status { get; set; }
    }

    public class Entities2
    {
        public Hashtag1[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public object[] user_mentions { get; set; }
        public Url3[] urls { get; set; }
        public Medium2[] media { get; set; }
    }

    public class Hashtag1
    {
        public string text { get; set; }
        public string[] indices { get; set; }
    }

    public class Url3
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Medium2
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string[] indices { get; set; }
        public string media_url { get; set; }
        public string media_url_https { get; set; }
        public string url { get; set; }
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string type { get; set; }
        public Sizes1 sizes { get; set; }
    }

    public class Sizes1
    {
        public Large1 large { get; set; }
        public Medium3 medium { get; set; }
        public Thumb1 thumb { get; set; }
        public Small1 small { get; set; }
    }

    public class Large1
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Medium3
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Thumb1
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Small1
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Metadata1
    {
        public string iso_language_code { get; set; }
        public string result_type { get; set; }
    }

    public class User1
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public Entities3 entities { get; set; }
        public bool _protected { get; set; }
        public string followers_count { get; set; }
        public string friends_count { get; set; }
        public string listed_count { get; set; }
        public string created_at { get; set; }
        public string favourites_count { get; set; }
        public string utc_offset { get; set; }
        public string time_zone { get; set; }
        public bool geo_enabled { get; set; }
        public bool verified { get; set; }
        public string statuses_count { get; set; }
        public string lang { get; set; }
        public bool contributors_enabled { get; set; }
        public bool is_translator { get; set; }
        public bool is_translation_enabled { get; set; }
        public string profile_background_color { get; set; }
        public string profile_background_image_url { get; set; }
        public string profile_background_image_url_https { get; set; }
        public bool profile_background_tile { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_banner_url { get; set; }
        public string profile_link_color { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string profile_text_color { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool has_extended_profile { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public object following { get; set; }
        public object follow_request_sent { get; set; }
        public object notifications { get; set; }
        public string translator_type { get; set; }
    }

    public class Entities3
    {
        public Url4 url { get; set; }
        public Description1 description { get; set; }
    }

    public class Url4
    {
        public Url5[] urls { get; set; }
    }

    public class Url5
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Description1
    {
        public Url6[] urls { get; set; }
    }

    public class Url6
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Extended_Entities
    {
        public Medium4[] media { get; set; }
    }

    public class Medium4
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string[] indices { get; set; }
        public string media_url { get; set; }
        public string media_url_https { get; set; }
        public string url { get; set; }
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string type { get; set; }
        public Sizes2 sizes { get; set; }
        public Additional_Media_Info additional_media_info { get; set; }
    }

    public class Sizes2
    {
        public Large2 large { get; set; }
        public Medium5 medium { get; set; }
        public Thumb2 thumb { get; set; }
        public Small2 small { get; set; }
    }

    public class Large2
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Medium5
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Thumb2
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Small2
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Additional_Media_Info
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool embeddable { get; set; }
        public bool monetizable { get; set; }
    }

    public class Quoted_Status
    {
        public string created_at { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public Entities4 entities { get; set; }
        public Metadata2 metadata { get; set; }
        public string source { get; set; }
        public object in_reply_to_status_id { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public object in_reply_to_user_id { get; set; }
        public object in_reply_to_user_id_str { get; set; }
        public object in_reply_to_screen_name { get; set; }
        public User2 user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public bool is_quote_status { get; set; }
        public string retweet_count { get; set; }
        public string favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public string lang { get; set; }
    }

    public class Entities4
    {
        public object[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public object[] user_mentions { get; set; }
        public object[] urls { get; set; }
    }

    public class Metadata2
    {
        public string iso_language_code { get; set; }
        public string result_type { get; set; }
    }

    public class User2
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public Entities5 entities { get; set; }
        public bool _protected { get; set; }
        public string followers_count { get; set; }
        public string friends_count { get; set; }
        public string listed_count { get; set; }
        public string created_at { get; set; }
        public string favourites_count { get; set; }
        public string utc_offset { get; set; }
        public string time_zone { get; set; }
        public bool geo_enabled { get; set; }
        public bool verified { get; set; }
        public string statuses_count { get; set; }
        public string lang { get; set; }
        public bool contributors_enabled { get; set; }
        public bool is_translator { get; set; }
        public bool is_translation_enabled { get; set; }
        public string profile_background_color { get; set; }
        public string profile_background_image_url { get; set; }
        public string profile_background_image_url_https { get; set; }
        public bool profile_background_tile { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_banner_url { get; set; }
        public string profile_link_color { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string profile_text_color { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool has_extended_profile { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public object following { get; set; }
        public object follow_request_sent { get; set; }
        public object notifications { get; set; }
        public string translator_type { get; set; }
    }

    public class Entities5
    {
        public Url7 url { get; set; }
        public Description2 description { get; set; }
    }

    public class Url7
    {
        public Url8[] urls { get; set; }
    }

    public class Url8
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Description2
    {
        public object[] urls { get; set; }
    }

    public class Extended_Entities1
    {
        public Medium6[] media { get; set; }
    }

    public class Medium6
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string[] indices { get; set; }
        public string media_url { get; set; }
        public string media_url_https { get; set; }
        public string url { get; set; }
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string type { get; set; }
        public Sizes3 sizes { get; set; }
        public long source_status_id { get; set; }
        public string source_status_id_str { get; set; }
        public string source_user_id { get; set; }
        public string source_user_id_str { get; set; }
    }

    public class Sizes3
    {
        public Large3 large { get; set; }
        public Medium7 medium { get; set; }
        public Thumb3 thumb { get; set; }
        public Small3 small { get; set; }
    }

    public class Large3
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Medium7
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Thumb3
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Small3
    {
        public string w { get; set; }
        public string h { get; set; }
        public string resize { get; set; }
    }

    public class Quoted_Status1
    {
        public string created_at { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public Entities6 entities { get; set; }
        public Metadata3 metadata { get; set; }
        public string source { get; set; }
        public object in_reply_to_status_id { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public object in_reply_to_user_id { get; set; }
        public object in_reply_to_user_id_str { get; set; }
        public object in_reply_to_screen_name { get; set; }
        public User3 user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public bool is_quote_status { get; set; }
        public string retweet_count { get; set; }
        public string favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public bool possibly_sensitive { get; set; }
        public string lang { get; set; }
    }

    public class Entities6
    {
        public object[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public object[] user_mentions { get; set; }
        public Url9[] urls { get; set; }
    }

    public class Url9
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Metadata3
    {
        public string iso_language_code { get; set; }
        public string result_type { get; set; }
    }

    public class User3
    {
        public string id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public Entities7 entities { get; set; }
        public bool _protected { get; set; }
        public string followers_count { get; set; }
        public string friends_count { get; set; }
        public string listed_count { get; set; }
        public string created_at { get; set; }
        public string favourites_count { get; set; }
        public string utc_offset { get; set; }
        public string time_zone { get; set; }
        public bool geo_enabled { get; set; }
        public bool verified { get; set; }
        public string statuses_count { get; set; }
        public string lang { get; set; }
        public bool contributors_enabled { get; set; }
        public bool is_translator { get; set; }
        public bool is_translation_enabled { get; set; }
        public string profile_background_color { get; set; }
        public string profile_background_image_url { get; set; }
        public string profile_background_image_url_https { get; set; }
        public bool profile_background_tile { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_banner_url { get; set; }
        public string profile_link_color { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string profile_text_color { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool has_extended_profile { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public object following { get; set; }
        public object follow_request_sent { get; set; }
        public object notifications { get; set; }
        public string translator_type { get; set; }
    }

    public class Entities7
    {
        public Url10 url { get; set; }
        public Description3 description { get; set; }
    }

    public class Url10
    {
        public Url11[] urls { get; set; }
    }

    public class Url11
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string[] indices { get; set; }
    }

    public class Description3
    {
        public object[] urls { get; set; }
    }
}
