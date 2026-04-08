using System.Collections.Generic;

namespace ApexCharts
{
    /// <summary>
    /// Represents gradient color stops that can be shared across all series or specified per-series.
    /// <br /><br />
    /// The ApexCharts JS API accepts <c>colorStops</c> as either a flat array (shared by all series)
    /// or a nested array where each inner array corresponds to a series index.
    /// <br /><br />
    /// <code>
    /// // Shared stops (all series use the same gradient)
    /// ColorStops = new List&lt;FillGradientStops&gt;
    /// {
    ///     new() { Offset = 0, Color = "#FF0000", Opacity = 1 },
    ///     new() { Offset = 100, Color = "#00FF00", Opacity = 1 }
    /// };
    ///
    /// // Per-series stops (each series gets its own gradient)
    /// ColorStops = new List&lt;List&lt;FillGradientStops&gt;&gt;
    /// {
    ///     new() { new() { Offset = 0, Color = "#FF0000", Opacity = 1 } }, // series 0
    ///     new() { new() { Offset = 0, Color = "#0000FF", Opacity = 1 } }  // series 1
    /// };
    /// </code>
    /// </summary>
    public class ColorStopsCollection
    {
        internal List<List<FillGradientStops>> PerSeriesStops { get; }
        internal bool IsPerSeries { get; }

        /// <summary>
        /// Creates a shared color stops collection (all series use the same stops).
        /// </summary>
        public ColorStopsCollection(List<FillGradientStops> stops)
        {
            PerSeriesStops = new List<List<FillGradientStops>> { stops };
            IsPerSeries = false;
        }

        /// <summary>
        /// Creates a per-series color stops collection (each inner list corresponds to a series index).
        /// </summary>
        public ColorStopsCollection(List<List<FillGradientStops>> perSeriesStops)
        {
            PerSeriesStops = perSeriesStops;
            IsPerSeries = true;
        }

        /// <summary>
        /// Implicitly converts a flat list of stops into a shared color stops collection.
        /// </summary>
        public static implicit operator ColorStopsCollection(List<FillGradientStops> stops) => new(stops);

        /// <summary>
        /// Implicitly converts a nested list of stops into a per-series color stops collection.
        /// </summary>
        public static implicit operator ColorStopsCollection(List<List<FillGradientStops>> perSeriesStops) => new(perSeriesStops);
    }
}
