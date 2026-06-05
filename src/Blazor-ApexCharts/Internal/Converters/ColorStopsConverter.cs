using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApexCharts.Internal
{
    /// <summary>
    /// Serializes <see cref="ColorStopsCollection"/> as either a flat array (shared)
    /// or a nested array (per-series) depending on how it was constructed.
    /// </summary>
    internal class ColorStopsConverter : JsonConverter<ColorStopsCollection>
    {
        /// <inheritdoc/>
        /// <exception cref="NotImplementedException"/>
        public override ColorStopsCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, ColorStopsCollection value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            if (value.IsPerSeries)
            {
                // Nested array: [[{offset, color, opacity}, ...], [...]]
                JsonSerializer.Serialize(writer, value.PerSeriesStops, options);
            }
            else
            {
                // Flat array: [{offset, color, opacity}, ...]
                JsonSerializer.Serialize(writer, value.PerSeriesStops[0], options);
            }
        }
    }
}
