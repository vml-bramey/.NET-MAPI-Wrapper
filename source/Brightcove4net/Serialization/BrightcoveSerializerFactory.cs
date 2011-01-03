﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Brightcove4net.Model;
using Brightcove4net.Model.Containers;
using Brightcove4net.Model.Items;

namespace Brightcove4net.Serialization
{
	public class BrightcoveSerializerFactory
	{
		private static JavaScriptSerializer _serializer;

		static BrightcoveSerializerFactory()
		{
			_serializer = new JavaScriptSerializer();

			// Although we only need a single generic converter, BrightcoveItemConverter<T>, we must
			// register all possible types for T or the JavaScriptSerializer will not be able to find 
			// the appropriate converter for those types.
			// TODO: This seems overly verbose... Is there a better way?
			_serializer.RegisterConverters(new JavaScriptConverter[]
						                              	{
															// individual items
						                              		new BrightcoveItemConverter<BrightcoveVideo>(),
						                              		new BrightcoveItemConverter<BrightcoveAudioTrack>(),
						                              		new BrightcoveItemConverter<BrightcoveRendition>(),
						                              		new BrightcoveItemConverter<BrightcovePlaylist>(),
						                              		new BrightcoveItemConverter<BrightcoveError>(),
						                              		new BrightcoveItemConverter<BrightcoveCuePoint>(),
						                              		new BrightcoveItemConverter<BrightcoveNestedError>(),
						                              		new BrightcoveItemConverter<BrightcoveImage>(),
						                              		new BrightcoveItemConverter<BrightcoveLogoOverlay>(),
						                              		new BrightcoveItemConverter<BrightcoveAudioTrackPlaylist>(),

															// collections of items
						                              		new BrightcoveItemConverter<BrightcoveItemCollection<BrightcoveVideo>>(),
						                              		new BrightcoveItemConverter<BrightcoveItemCollection<BrightcoveAudioTrack>>(),
						                              		new BrightcoveItemConverter<BrightcoveItemCollection<BrightcovePlaylist>>(),
						                              		new BrightcoveItemConverter<BrightcoveItemCollection<BrightcoveAudioTrackPlaylist>>(),

															// items contained within the POST response container
						                              		new BrightcoveItemConverter<BrightcoveResultContainer<long>>(),
						                              		new BrightcoveItemConverter<BrightcoveResultContainer<long[]>>(),
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveUploadStatus>>(),
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveAudioTrack>>(),
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveVideo>>(),
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcovePlaylist>>(),
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveImage>>(),
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveLogoOverlay>>(),
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveAudioTrackPlaylist>>(),

															// collections of items contained within the POST response container
															new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveItemCollection<BrightcoveVideo>>>(),
						                              		new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveItemCollection<BrightcoveAudioTrack>>>(),
						                              		new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveItemCollection<BrightcovePlaylist>>>(),
						                              		new BrightcoveItemConverter<BrightcoveResultContainer<BrightcoveItemCollection<BrightcoveAudioTrackPlaylist>>>()
						                              	});
		}

		public static JavaScriptSerializer GetSerializer()
		{
			return _serializer;
		}
	}
}
