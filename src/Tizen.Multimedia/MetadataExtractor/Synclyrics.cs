/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents synchronized lyrics information of media.
    /// </summary>
    public class SyncLyrics
    {
        /// <summary>
        /// Initialize a new instance of the MetadataExtractor class with the specified lyrics and timestamp.
        /// </summary>
        public SyncLyrics(string lyrics, uint timestamp)
        {
            Lyrics = lyrics;
            Timestamp = timestamp;
        }

        /// <summary>
        /// The lyrics of the index
        /// </summary>
        public string Lyrics { get; }

        /// <summary>
        /// The time information of the index
        /// </summary>
        public uint Timestamp { get; }
    }
}
