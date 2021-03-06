﻿// Copyright 2017 Dirk Lemstra (https://github.com/dlemstra/line-bot-sdk-dotnet)
//
// Dirk Lemstra licenses this file to you under the Apache License,
// version 2.0 (the "License"); you may not use this file except in compliance
// with the License. You may obtain a copy of the License at:
//
//   https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Line
{
    /// <summary>
    /// Encapsulates a carousel template.
    /// </summary>
    public sealed class CarouselTemplate : ICarouselTemplate
    {
        private IEnumerable<ICarouselColumn> _columns;

#pragma warning disable 0414 // Suppress value is never used.

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<TemplateType>))]
        private TemplateType _type = TemplateType.Carousel;

#pragma warning restore 0414

        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <remarks>
        /// Max: 5
        /// </remarks>
        [JsonProperty("columns")]
        public IEnumerable<ICarouselColumn> Columns
        {
            get
            {
                return _columns;
            }

            set
            {
                if (value == null)
                    throw new InvalidOperationException("The columns cannot be null.");

                int count = value.Count();

                if (count < 1)
                    throw new InvalidOperationException("The minimum number of columns is 1.");

                if (count > 5)
                    throw new InvalidOperationException("The maximum number of columns is 5.");

                _columns = value;
            }
        }
    }
}
