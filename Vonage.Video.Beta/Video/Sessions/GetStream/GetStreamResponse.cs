﻿using Newtonsoft.Json;

namespace Vonage.Video.Beta.Video.Sessions.GetStream;

/// <summary>
///     Represents the response of a GetStreamRequest.
/// </summary>
public struct GetStreamResponse
{
    /// <summary>
    ///     Creates a response.
    /// </summary>
    /// <param name="id">The stream ID.</param>
    /// <param name="videoType">The video type.</param>
    /// <param name="name"></param>
    /// <param name="layoutClassList"></param>
    public GetStreamResponse(string id, string videoType, string name, string[] layoutClassList)
    {
        this.Id = id;
        this.VideoType = videoType;
        this.Name = name;
        this.LayoutClassList = layoutClassList;
    }

    /// <summary>
    ///     The stream Id.
    /// </summary>
    /// <remarks>
    ///     This struct should be read-only. The setter is mandatory for deserialization.
    /// </remarks>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    ///     Set to "camera", "screen", or "custom". A "screen" video uses screen sharing on the publisher as the video source;
    ///     a "custom" video is published by a web client using an HTML VideoTrack element as the video source.
    /// </summary>
    /// <remarks>
    ///     This struct should be read-only. The setter is mandatory for deserialization.
    /// </remarks>
    [JsonProperty("videoType")]
    public string VideoType { get; set; }

    /// <summary>
    ///     The stream name (if one was set when the client published the stream).
    /// </summary>
    /// <remarks>
    ///     This struct should be read-only. The setter is mandatory for deserialization.
    /// </remarks>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///     An array of the layout classes for the stream.
    /// </summary>
    /// <remarks>
    ///     This struct should be read-only. The setter is mandatory for deserialization.
    /// </remarks>
    [JsonProperty("layoutClassList")]
    public string[] LayoutClassList { get; set; }
}