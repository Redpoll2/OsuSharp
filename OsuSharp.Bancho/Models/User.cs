using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OsuSharp.Bancho
{
    public class User
    {
        public class Event
        {
            /// <summary>Html code</summary>
            [JsonProperty("display_html")]
            public string DisplayHtml { get; set; }

            /// <summary>Difficulty identifier</summary>
            [JsonProperty("beatmap_id")]
            public uint BeatmapId { get; set; }

            /// <summary>Beatmap identifier</summary>
            [JsonProperty("beatmapset_id")]
            public uint BeatmapsetId { get; set; }

            /// <summary>Date when score was submitted</summary>
            [JsonProperty("date")]
            public DateTime Date { get; set; }

            /// <summary>How "epic" this event is</summary>
            [JsonProperty("epicfactor")]
            public byte Epicfactor { get; set; }
        }

        /// <summary>User identifier</summary>
        [JsonProperty("user_id")]
        public uint UserId { get; set; }

        /// <summary>Name of user</summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>Date when user joined</summary>
        [JsonProperty("join_date")]
        public DateTime JoinDate { get; set; }

        /// <summary>Number of 300s</summary>
        [JsonProperty("count300")]
        public uint Count300 { get; set; }

        /// <summary>Number of 100s in Standart, 150s in Taiko, 100s in CatchTheBeat, 100s in Mania</summary>
        [JsonProperty("count100")]
        public uint Count100 { get; set; }

        /// <summary>Number of 50s in Standart, small fruit in CatchTheBeat, 50s in Mania</summary>
        [JsonProperty("count50")]
        public uint Count50 { get; set; }

        /// <summary>Number of plays on ranked, approved, and loved beatmaps</summary>
        [JsonProperty("playcount")]
        public uint Playcount { get; set; }

        /// <summary>Number of all best scores on each ranked, approved, and loved beatmaps</summary>
        [JsonProperty("ranked_score")]
        public ulong RankedScore { get; set; }

        /// <summary>Number of all scores on ranked, approved, and loved beatmaps</summary>
        [JsonProperty("total_score")]
        public ulong TotalScore { get; set; }

        /// <summary>Leaderboard position</summary>
        [JsonProperty("pp_rank")]
        public uint Rank { get; set; }

        /// <summary>User level</summary>
        [JsonProperty("level")]
        public float Level { get; set; }

        /// <summary>Performance points</summary>
        [JsonProperty("pp_raw")]
        public float Performance { get; set; }

        /// <summary>Hit accuracy</summary>
        [JsonProperty("accuracy")]
        public double Accuracy { get; set; }

        /// <summary>Number of SS ranks</summary>
        [JsonProperty("count_rank_ss")]
        public ushort CountSS { get; set; }

        /// <summary>Number of SS ranks with Hidden</summary>
        [JsonProperty("count_rank_ssh")]
        public ushort CountSSH { get; set; }

        /// <summary>Number of S ranks</summary>
        [JsonProperty("count_rank_s")]
        public ushort CountS { get; set; }

        /// <summary>Number of S ranks with Hidden</summary>
        [JsonProperty("count_rank_sh")]
        public ushort CountSH { get; set; }

        /// <summary>Number of A ranks</summary>
        [JsonProperty("count_rank_a")]
        public ushort CountA { get; set; }

        /// <summary>ISO3166-1 alpha-2 country code</summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>Number of seconds that spent in osu!</summary>
        [JsonProperty("total_seconds_played")]
        public uint TotalSecondsPlayed { get; set; }

        /// <summary>Country leaderboard position</summary>
        [JsonProperty("pp_country_rank")]
        public uint CountryRank { get; set; }

        /// <summary>Collection of user activity</summary>
        [JsonProperty("events")]
        public IEnumerable<Event> Events { get; set; }
    }
}
