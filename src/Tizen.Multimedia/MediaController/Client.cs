/// MediaControllerClient
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Multimedia.MediaController
{

	/// <summary>
	/// The MediaControllerClient class provides APIs required for media-controller-client.
	/// </summary>
	/// <remarks>
	/// The MediaControllerClient APIs provides functions to 
	/// </remarks>
	public class MediaControllerClient : IDisposable
	{
		internal IntPtr _handle = IntPtr.Zero;

		private bool _disposed = false;
		private EventHandler<ServerUpdatedEventArgs> _serverUpdated;
		private Interop.MediaControllerClient.ServerUpdatedCallback _serverUpdatedCallback;
		private EventHandler<PlaybackUpdatedEventArgs> _playbackUpdated;
		private Interop.MediaControllerClient.PlaybackUpdatedCallback _playbackUpdatedCallback;
		private EventHandler<MetadataUpdatedEventArgs> _metadataUpdated;
		private Interop.MediaControllerClient.MetadataUpdatedCallback _metadataUpdatedCallback;
		private EventHandler<ShuffleModeUpdatedEventArgs> _shufflemodeUpdated;
		private Interop.MediaControllerClient.ShuffleModeUpdatedCallback _shufflemodeUpdatedCallback;
		private EventHandler<RepeatModeUpdatedEventArgs> _repeatmodeUpdated;
		private Interop.MediaControllerClient.RepeatModeUpdatedCallback _repeatmodeUpdatedCallback;
		private EventHandler<CommandReplyEventArgs> _commandReply;
		private Interop.MediaControllerClient.CommandReplyRecievedCallback _commandReplyCallback;

		public MediaControllerClient ()
		{
			Interop.MediaControllerClient.Create (out _handle);
		}

		~MediaControllerClient ()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(!_disposed)
			{
				if(disposing)
				{
					// To be used if there are any other disposable objects
				}
				if(_handle != IntPtr.Zero)
				{
					Interop.MediaControllerClient.Destroy(_handle);
					_handle = IntPtr.Zero;
				}
				_disposed = true;
			}
		}

		/// <summary>
		/// ServerUpdated event is raised when server is changed
		/// </summary>
		public event EventHandler<ServerUpdatedEventArgs> ServerUpdated
		{
			add
			{
				if(_serverUpdated == null)
				{
					RegisterServerUpdatedEvent();
				}
				_serverUpdated += value;

			}
			remove
			{
				_serverUpdated -= value;
				if(_serverUpdated == null)
				{
					UnregisterServerUpdatedEvent();
				}
			}
		}

		/// <summary>
		/// PlaybackUpdated event is raised when playback is changed
		/// </summary>
		public event EventHandler<PlaybackUpdatedEventArgs> PlaybackUpdated
		{
			add
			{
				if(_playbackUpdated == null)
				{
					RegisterPlaybackUpdatedEvent();
				}
				_playbackUpdated += value;

			}
			remove
			{
				_playbackUpdated -= value;
				if(_playbackUpdated == null)
				{
					UnregisterPlaybackUpdatedEvent();
				}
			}
		}

		/// <summary>
		/// MetadataUpdated event is raised when metadata is changed
		/// </summary>
		public event EventHandler<MetadataUpdatedEventArgs> MetadataUpdated
		{
			add
			{
				if(_metadataUpdated == null)
				{
					RegisterMetadataUpdatedEvent();
				}
				_metadataUpdated += value;

			}
			remove
			{
				_metadataUpdated -= value;
				if(_metadataUpdated == null)
				{
					UnregisterMetadataUpdatedEvent();
				}
			}
		}

		/// <summary>
		/// ShuffleModeUpdated event is raised when shuffle mode is changed
		/// </summary>
		public event EventHandler<ShuffleModeUpdatedEventArgs> ShuffleModeUpdated
		{
			add
			{
				if(_shufflemodeUpdated == null)
				{
					RegisterShuffleModeUpdatedEvent();
				}
				_shufflemodeUpdated += value;

			}
			remove
			{
				_shufflemodeUpdated -= value;
				if(_shufflemodeUpdated == null)
				{
					UnregisterShuffleModeUpdatedEvent();
				}
			}
		}

		/// <summary>
		/// RepeatModeUpdated event is raised when server is changed
		/// </summary>
		public event EventHandler<RepeatModeUpdatedEventArgs> RepeatModeUpdated
		{
			add
			{
				if(_repeatmodeUpdated == null)
				{
					RegisterRepeatModeUpdatedEvent();
				}
				_repeatmodeUpdated += value;

			}
			remove
			{
				_repeatmodeUpdated -= value;
				if(_repeatmodeUpdated == null)
				{
					UnregisterRepeatModeUpdatedEvent();
				}
			}
		}

		/// <summary>
		/// CommandReply event is raised when reply for command is recieved
		/// </summary>
		public event EventHandler<CommandReplyEventArgs> CommandReply
		{
			add
			{
				if(_commandReply == null)
				{
					_commandReplyCallback = (string serverName, int result, IntPtr bundle, IntPtr userData) =>
					{
						CommandReplyEventArgs eventArgs = new CommandReplyEventArgs(serverName, result, bundle, userData);
						_commandReply?.Invoke(this, eventArgs);
					};
				}
				_commandReply += value;

			}
			remove
			{
				_commandReply -= value;
				if(_commandReply == null)
				{
					_commandReplyCallback = null;
				}
			}
		}

		/// <summary>
		/// gets latest server information </summary>
		public ServerInformation GetLatestServer()
		{
			MediaControllerError res = MediaControllerError.None;
			string _name;
			int _state;

			res = (MediaControllerError)Interop.MediaControllerClient.GetLatestServer(_handle, out _name, out _state);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Latest server failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Latest server failed");
			}

			ServerInformation _serverInfo = new ServerInformation (_name, (ServerState)_state);
			return _serverInfo;
		}

		/// <summary>
		/// gets playback information for specific server </summary>
		/// <param name="serverName"> Server Name  </param>
		public Playback GetPlayback(String serverName)
		{
			MediaControllerError res = MediaControllerError.None;
			IntPtr _playbackHandle = IntPtr.Zero;

			res = (MediaControllerError)Interop.MediaControllerClient.GetServerPlayback(_handle, serverName, out _playbackHandle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Playback handle failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Playback handle failed");
			}

			Playback _playback = new Playback (_playbackHandle);
			return _playback;
		}

		/// <summary>
		/// gets metadata information for specific server </summary>
		/// <param name="serverName"> Server Name  </param>
		public Metadata GetMetadata(String serverName)
		{
			MediaControllerError res = MediaControllerError.None;
			IntPtr _metadataHandle = IntPtr.Zero;

			res = (MediaControllerError)Interop.MediaControllerClient.GetServerMetadata(_handle, serverName, out _metadataHandle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Playback handle failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Playback handle failed");
			}

			Metadata _metadata = new Metadata (_metadataHandle);
			return _metadata;
		}

		/// <summary>
		/// gets shuffle mode for specific server </summary>
		/// <param name="serverName"> Server Name  </param>
		public ShuffleMode GetShuffleMode(String serverName)
		{
			MediaControllerError res = MediaControllerError.None;
			int _shuffleMode;
			res = (MediaControllerError)Interop.MediaControllerClient.GetServerShuffleMode(_handle, serverName, out _shuffleMode);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Playback handle failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Playback handle failed");
			}

			return (ShuffleMode)_shuffleMode;
		}

		/// <summary>
		/// gets repeat mode for specific server </summary>
		/// <param name="serverName"> Server Name  </param>
		public RepeatMode GetRepeatMode(String serverName)
		{
			MediaControllerError res = MediaControllerError.None;
			int _repeatMode;
			res = (MediaControllerError)Interop.MediaControllerClient.GetServerRepeatMode(_handle, serverName, out _repeatMode);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Playback handle failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Playback handle failed");
			}

			return (RepeatMode)_repeatMode;
		}

		/// <summary>
		/// Send command of playback state to server application </summary>
		/// <param name="serverName"> Server Name  </param>
		/// <param name="state"> Playback State  </param>
		public void SendPlaybackStateCommand(string serverName, PlaybackState state)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerClient.SendPlaybackStateCommand(_handle, serverName, (int)state);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Send playback state command failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Send playback state command failed");
			}
		}

		/// <summary>
		/// Send customized command to server application </summary>
		/// <param name="serverName"> Server Name  </param>
		/// <param name="command"> Command  </param>
		/// <param name="bundle"> Bundle data  </param>
		/// <param name="userData"> User Data  </param>
		public void SendCustomCommand(string serverName, string command, IntPtr bundle, IntPtr userData)
		{
			MediaControllerError res = MediaControllerError.None;
			if (_commandReply == null) {
				res = (MediaControllerError)Interop.MediaControllerClient.SendCustomCommand(_handle, serverName, command, bundle, _commandReplyCallback, IntPtr.Zero);
			} else {
				res = (MediaControllerError)Interop.MediaControllerClient.SendCustomCommand(_handle, serverName, command, bundle, _commandReplyCallback, userData);
			}
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Send custom command failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Send custom command failed");
			}
		}

		/// <summary>
		/// Subscribe subscription type from specific server application </summary>
		/// <param name="type"> Subscription Type  </param>
		/// <param name="serverName"> Server Name  </param>
		public void Subscribe(SubscriptionType type, string serverName)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerClient.Subscribe(_handle, (int)type, serverName);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Subscribe failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Subscribe failed");
			}
		}

		/// <summary>
		/// Subscribe subscription type from specific server application </summary>
		/// <param name="type"> Subscription Type  </param>
		/// <param name="serverName"> Server Name  </param>
		public void Unsubscribe(SubscriptionType type, string serverName)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerClient.Unsubscribe(_handle, (int)type, serverName);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Unsubscribe failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Unsubscribe failed");
			}
		}

		/// <summary>
		/// gets activated server list </summary>
		public Task<IEnumerable<string>> GetActivatedServerList()
		{
			var task = new TaskCompletionSource<IEnumerable<string>>();

			List<string> collectionList = ForEachActivatedServer(_handle);
			task.TrySetResult((IEnumerable<string>)collectionList);

			return task.Task;
		}

		/// <summary>
		/// gets subscribed server list </summary>
		/// <param name="subscriptionType"> Subscription Type  </param>
		public Task<IEnumerable<string>> GetSubscribedServerList(SubscriptionType subscriptionType)
		{
			var task = new TaskCompletionSource<IEnumerable<string>>();

			List<string> collectionList = ForEachSubscribedServer(_handle, (int)subscriptionType);
			task.TrySetResult((IEnumerable<string>)collectionList);

			return task.Task;
		}

		private void RegisterServerUpdatedEvent()
		{
			_serverUpdatedCallback = (string serverName, int serverState, IntPtr userData) =>
			{
				ServerUpdatedEventArgs eventArgs = new ServerUpdatedEventArgs(serverName, (ServerState)serverState, userData);
				_serverUpdated?.Invoke(this, eventArgs);
			};
			Interop.MediaControllerClient.SetServerUpdatedCb(_handle, _serverUpdatedCallback, IntPtr.Zero);
		}

		private void UnregisterServerUpdatedEvent()
		{
			Interop.MediaControllerClient.UnsetServerUpdatedCb(_handle);
		}

		private void RegisterPlaybackUpdatedEvent()
		{
			_playbackUpdatedCallback = (string serverName, IntPtr playback, IntPtr userData) =>
			{
				PlaybackUpdatedEventArgs eventArgs = new PlaybackUpdatedEventArgs(serverName, playback, userData);
				_playbackUpdated?.Invoke(this, eventArgs);
			};
			Interop.MediaControllerClient.SetPlaybackUpdatedCb(_handle, _playbackUpdatedCallback, IntPtr.Zero);
		}

		private void UnregisterPlaybackUpdatedEvent()
		{
			Interop.MediaControllerClient.UnsetPlaybackUpdatedCb(_handle);
		}

		private void RegisterMetadataUpdatedEvent()
		{
			_metadataUpdatedCallback = (string serverName, IntPtr metadata, IntPtr userData) =>
			{
				MetadataUpdatedEventArgs eventArgs = new MetadataUpdatedEventArgs(serverName, metadata, userData);
				_metadataUpdated?.Invoke(this, eventArgs);
			};
			Interop.MediaControllerClient.SetMetadataUpdatedCb(_handle, _metadataUpdatedCallback, IntPtr.Zero);
		}

		private void UnregisterMetadataUpdatedEvent()
		{
			Interop.MediaControllerClient.UnsetMetadataUpdatedCb(_handle);
		}

		private void RegisterShuffleModeUpdatedEvent()
		{
			MediaControllerError res = MediaControllerError.None;
			_shufflemodeUpdatedCallback = (string serverName, int shuffleMode, IntPtr userData) =>
			{
				ShuffleModeUpdatedEventArgs eventArgs = new ShuffleModeUpdatedEventArgs(serverName, (ShuffleMode)shuffleMode, userData);
				_shufflemodeUpdated?.Invoke(this, eventArgs);
			};
			res = (MediaControllerError)Interop.MediaControllerClient.SetShuffleModeUpdatedCb(_handle, _shufflemodeUpdatedCallback, IntPtr.Zero);
			if (res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set ShuffleModeUpdated callback failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set ShuffleModeUpdated callback failed");
			}
		}

		private void UnregisterShuffleModeUpdatedEvent()
		{
			Interop.MediaControllerClient.UnsetShuffleModeUpdatedCb(_handle);
		}

		private void RegisterRepeatModeUpdatedEvent()
		{
			MediaControllerError res = MediaControllerError.None;
			_repeatmodeUpdatedCallback = (string serverName, int repeatMode, IntPtr userData) =>
			{
				RepeatModeUpdatedEventArgs eventArgs = new RepeatModeUpdatedEventArgs(serverName, (RepeatMode)repeatMode, userData);
				_repeatmodeUpdated?.Invoke(this, eventArgs);
			};
			res = (MediaControllerError)Interop.MediaControllerClient.SetRepeatModeUpdatedCb(_handle, _repeatmodeUpdatedCallback, IntPtr.Zero);
			if (res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set RepeatModeUpdated callback failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set RepeatModeUpdated callback failed");
			}
		}

		private void UnregisterRepeatModeUpdatedEvent()
		{
			Interop.MediaControllerClient.UnsetRepeatModeUpdatedCb(_handle);
		}

		private static List<string> ForEachSubscribedServer(IntPtr handle, int subscriptionType)
		{
			MediaControllerError res = MediaControllerError.None;
			List<string> subscribedServerCollections = new List<string>();

			Interop.MediaControllerClient.SubscribedServerCallback serverCallback = (string serverName, IntPtr userData) =>
			{
				subscribedServerCollections.Add (serverName);
				return true;
			};
			res = (MediaControllerError)Interop.MediaControllerClient.ForeachSubscribedServer (handle, subscriptionType, serverCallback, IntPtr.Zero);
			if (res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Foreach Subscribed server failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Foreach Subscribed server failed");
			}
			return subscribedServerCollections;
		}

		private static List<string> ForEachActivatedServer(IntPtr handle)
		{
			MediaControllerError res = MediaControllerError.None;
			List<string> activatedServerCollections = new List<string>();

			Interop.MediaControllerClient.ActivatedServerCallback serverCallback = (string serverName, IntPtr userData) =>
			{
				activatedServerCollections.Add (serverName);
				return true;
			};
			res = (MediaControllerError)Interop.MediaControllerClient.ForeachActivatedServer (handle, serverCallback, IntPtr.Zero);
			if (res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Foreach Activated server failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Foreach Activated server failed");
			}
			return activatedServerCollections;
		}


	}
}

