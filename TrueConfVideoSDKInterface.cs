using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSDK
{
    class AppStates
    {
        public static (int State, string Hint) Unknown =    (-1, "Unknown application state");
        public static (int State, string Hint) None =       (0, "No connection to the server and VideoSDK does nothing");
        public static (int State, string Hint) Connect =    (1, "TrueConf VideoSDK tries to connect to the server");
        public static (int State, string Hint) Login =      (2, "TrueConf VideoSDK need to login");
        public static (int State, string Hint) Normal =     (3, "TrueConf VideoSDK is connected to the server and logged in");
        public static (int State, string Hint) Wait =       (4, "TrueConf VideoSDK is pending: either it calls somebody or somebody calls it");
        public static (int State, string Hint) Conference = (5, "TrueConf VideoSDK is in the conference");
        public static (int State, string Hint) Close =      (6, "TrueConf VideoSDK is finishing the conference");

        public static string GetHint(int State)
        {
            if(None.State == State)
                return None.Hint;
            else if (Connect.State == State)
                return Connect.Hint;
            else if (Login.State == State)
                return Login.Hint;
            else if (Normal.State == State)
                return Normal.Hint;
            else if (Wait.State == State)
                return Wait.Hint;
            else if (Conference.State == State)
                return Conference.Hint;
            else if (Close.State == State)
                return Close.Hint;

            return Unknown.Hint;
        }
    }

    interface VideoSDKMethods_V1
    {
        event EventHandler<string> OnMethodResponse;

        //void ProcessResponse(string response);

        /// <summary>
        /// Make a video call
        /// (<paramref name="trueconf_id"/>).
        /// </summary>
        /// <param name="trueconf_id">A unique ID (TrueConfID or conference ID).</param>
        void call(string trueconf_id);

        /// <summary>
        /// Accept the call. The command is run immediately and the result of execution is received at once.
        /// </summary>
        /// <example> Response example
        /// <code>
        /// {"method" : "accept", "result" : true}
        /// </code>
        /// </example>
        void accept();

        void hangUp(bool forAll = false);
        void login(string callId, string password);
        void logout();
        void connectToServer(string server, int port = 4307);
    }

    class EventNames
    {
        public const string EV_abReceivedAfterLogin = "abReceivedAfterLogin";
        public const string EV_allSlidesCachingStopped = "allSlidesCachingStopped";
        public const string EV_allSlidesRemoved = "allSlidesRemoved";
        public const string EV_appSndDevChanged = "appSndDevChanged";
        public const string EV_appStateChanged = "appStateChanged";
        public const string EV_appUpdateAvailable = "appUpdateAvailable";
        public const string EV_audioCapturerMute = "audioCapturerMute";
        public const string EV_audioDelayDetectorTestStateChanged = "audioDelayDetectorTestStateChanged";
        public const string EV_audioRendererMute = "audioRendererMute";
        public const string EV_authorizationNeeded = "authorizationNeeded";
        public const string EV_availableServersListLoaded = "availableServersListLoaded";
        public const string EV_backgroundImageChanged = "backgroundImageChanged";
        public const string EV_broadcastPictureStateChanged = "broadcastPictureStateChanged";
        public const string EV_broadcastSelfieChanged = "broadcastSelfieChanged";
        public const string EV_callHistoryCleared = "callHistoryCleared";
        public const string EV_cameraStateChangedByConferenceOwner = "cameraStateChangedByConferenceOwner";
        public const string EV_chatMessageSent = "chatMessageSent";
        public const string EV_cmdChatClear = "cmdChatClear";
        public const string EV_commandReceived = "commandReceived";
        public const string EV_commandSent = "commandSent";
        public const string EV_conferenceCreated = "conferenceCreated";
        public const string EV_conferenceDeleted = "conferenceDeleted";
        public const string EV_conferenceList = "conferenceList";
        public const string EV_contactBlocked = "contactBlocked";
        public const string EV_contactsAdded = "contactsAdded";
        public const string EV_contactsDeleted = "contactsDeleted";
        public const string EV_contactsRenamed = "contactsRenamed";
        public const string EV_contactUnblocked = "contactUnblocked";
        public const string EV_cropChanged = "cropChanged";
        public const string EV_currentSlideIndexChanged = "currentSlideIndexChanged";
        public const string EV_currentUserDisplayNameChanged = "currentUserDisplayNameChanged";
        public const string EV_currentUserProfileUrlChanged = "currentUserProfileUrlChanged";
        public const string EV_customLogoUsageChanged = "customLogoUsageChanged";
        public const string EV_dataDeleted = "dataDeleted";
        public const string EV_dataSaved = "dataSaved";
        public const string EV_detailsInfo = "detailsInfo";
        public const string EV_deviceModesDone = "deviceModesDone";
        public const string EV_deviceStatusReceived = "deviceStatusReceived";
        public const string EV_downloadProgress = "downloadProgress";
        public const string EV_dsStarted = "dsStarted";
        public const string EV_dsStopped = "dsStopped";
        public const string EV_enableAudioReceivingChanged = "enableAudioReceivingChanged";
        public const string EV_enableVideoReceivingChanged = "enableVideoReceivingChanged";
        public const string EV_extraVideoFlowNotify = "extraVideoFlowNotify";
        public const string EV_fileAccepted = "fileAccepted";
        public const string EV_fileConferenceSent = "fileConferenceSent";
        public const string EV_fileDownloadingProgress = "fileDownloadingProgress";
        public const string EV_fileRejected = "fileRejected";
        public const string EV_fileSent = "fileSent";
        public const string EV_fileStatus = "fileStatus";
        public const string EV_fileTransferAvailable = "fileTransferAvailable";
        public const string EV_fileTransferCleared = "fileTransferCleared";
        public const string EV_fileTransferFileDeleted = "fileTransferFileDeleted";
        public const string EV_fileTransferPinChanged = "fileTransferPinChanged";
        public const string EV_fileUploadingProgress = "fileUploadingProgress";
        public const string EV_groupChatMessageSent = "groupChatMessageSent";
        public const string EV_groupsAdded = "groupsAdded";
        public const string EV_groupsRemoved = "groupsRemoved";
        public const string EV_groupsRenamed = "groupsRenamed";
        public const string EV_hangUpPressed = "hangUpPressed";
        public const string EV_hardwareChanged = "hardwareChanged";
        public const string EV_hookOffPressed = "hookOffPressed";
        public const string EV_httpServerSettingChanged = "httpServerSettingChanged";
        public const string EV_httpServerStateChanged = "httpServerStateChanged";
        public const string EV_imageAddedToCachingQueue = "imageAddedToCachingQueue";
        public const string EV_imageRemovedFromCachingQueue = "imageRemovedFromCachingQueue";
        public const string EV_incomingChatMessage = "incomingChatMessage";
        public const string EV_incomingGroupChatMessage = "incomingGroupChatMessage";
        public const string EV_incomingPodiumInvitationRemoved = "incomingPodiumInvitationRemoved";
        public const string EV_incomingRequestCameraControlAccepted = "incomingRequestCameraControlAccepted";
        public const string EV_incomingRequestCameraControlRejected = "incomingRequestCameraControlRejected";
        public const string EV_incomingRequestToPodiumAnswered = "incomingRequestToPodiumAnswered";
        public const string EV_inviteReceived = "inviteReceived";
        public const string EV_inviteRequestSent = "inviteRequestSent";
        public const string EV_inviteSent = "inviteSent";
        public const string EV_joinToConferenceLinkReceived = "joinToConferenceLinkReceived";
        public const string EV_lastCallsViewed = "lastCallsViewed";
        public const string EV_licenseActivation = "licenseActivation";
        public const string EV_licenseStatusChanged = "licenseStatusChanged";
        public const string EV_login = "login";
        public const string EV_logoImageChanged = "logoImageChanged";
        public const string EV_logout = "logout";
        public const string EV_micStateChangedByConferenceOwner = "micStateChangedByConferenceOwner";
        public const string EV_monitorsInfoUpdated = "monitorsInfoUpdated";
        public const string EV_myEvent = "myEvent";
        public const string EV_mySlideShowStarted = "mySlideShowStarted";
        public const string EV_mySlideShowStopped = "mySlideShowStopped";
        public const string EV_mySlideShowTitleChanged = "mySlideShowTitleChanged";
        public const string EV_NDIDeviceCreated = "NDIDeviceCreated";
        public const string EV_NDIDeviceDeleted = "NDIDeviceDeleted";
        public const string EV_NDIStateChanged = "NDIStateChanged";
        public const string EV_newParticipantInConference = "newParticipantInConference";
        public const string EV_outgoingBitrateChanged = "outgoingBitrateChanged";
        public const string EV_outgoingRequestCameraControlAccepted = "outgoingRequestCameraControlAccepted";
        public const string EV_outgoingRequestCameraControlRejected = "outgoingRequestCameraControlRejected";
        public const string EV_outputSelfVideoRotateAngleChanged = "outputSelfVideoRotateAngleChanged";
        public const string EV_participantLeftConference = "participantLeftConference";
        public const string EV_peerAccepted = "peerAccepted";
        public const string EV_propertiesUpdated = "propertiesUpdated";
        public const string EV_ptzControlsChanged = "ptzControlsChanged";
        public const string EV_realtimeManagmentUrlAvailabilityChanged = "realtimeManagmentUrlAvailabilityChanged";
        public const string EV_receivedFileRequest = "receivedFileRequest";
        public const string EV_receiversInfoUpdated = "receiversInfoUpdated";
        public const string EV_recordRequest = "recordRequest";
        public const string EV_recordRequestReply = "recordRequestReply";
        public const string EV_rejectReceived = "rejectReceived";
        public const string EV_rejectSent = "rejectSent";
        public const string EV_remarkCountDown = "remarkCountDown";
        public const string EV_remotelyControlledCameraNotAvailableAnymore = "remotelyControlledCameraNotAvailableAnymore";
        public const string EV_requestCameraControlReceived = "requestCameraControlReceived";
        public const string EV_requestCameraControlSent = "requestCameraControlSent";
        public const string EV_requestInviteReceived = "requestInviteReceived";
        public const string EV_roleEventOccured = "roleEventOccured";
        public const string EV_serverConnected = "serverConnected";
        public const string EV_serverDisconnected = "serverDisconnected";
        public const string EV_settingsChanged = "settingsChanged";
        public const string EV_showCurrentUserWidget = "showCurrentUserWidget";
        public const string EV_showIncomingRequestWidget = "showIncomingRequestWidget";
        public const string EV_showInfoConnect = "showInfoConnect";
        public const string EV_showLogo = "showLogo";
        public const string EV_showTime = "showTime";
        public const string EV_showUpcomingMeetings = "showUpcomingMeetings";
        public const string EV_slideAdded = "slideAdded";
        public const string EV_slideCached = "slideCached";
        public const string EV_slideCachingStarted = "slideCachingStarted";
        public const string EV_slidePositionChanged = "slidePositionChanged";
        public const string EV_slideRemoved = "slideRemoved";
        public const string EV_slideShowAvailabilityChanged = "slideShowAvailabilityChanged";
        public const string EV_slideShowCleared = "slideShowCleared";
        public const string EV_slidesSorted = "slidesSorted";
        public const string EV_slideUploaded = "slideUploaded";
        public const string EV_stopCalling = "stopCalling";
        public const string EV_systemRatingUpdated = "systemRatingUpdated";
        public const string EV_tariffRestrictionsChanged = "tariffRestrictionsChanged";
        public const string EV_testAudioCapturerLevel = "testAudioCapturerLevel";
        public const string EV_testAudioCapturerStateChanged = "testAudioCapturerStateChanged";
        public const string EV_toneDial = "toneDial";
        public const string EV_updateAvatar = "updateAvatar";
        public const string EV_updateCameraInfo = "updateCameraInfo";
        public const string EV_updateFailed = "updateFailed";
        public const string EV_userRecordingMeStatusChanged = "userRecordingMeStatusChanged";
        public const string EV_usersAddedToGroups = "usersAddedToGroups";
        public const string EV_usersRemovedFromGroups = "usersRemovedFromGroups";
        public const string EV_usersStatusesChanged = "usersStatusesChanged";
        public const string EV_videoCapturerMute = "videoCapturerMute";
        public const string EV_videoMatrixChanged = "videoMatrixChanged";
        public const string EV_videoSlotMovedToMonitor = "videoSlotMovedToMonitor";
        public const string EV_videoSlotRemovedFromMonitor = "videoSlotRemovedFromMonitor";
        public const string EV_windowStateChanged = "windowStateChanged";
    }

    interface VideoSDKEvents_V1
    {
        //void ProcessResponse(string response);

        event EventHandler<string> On_abReceivedAfterLogin;
        event EventHandler<string> On_allSlidesCachingStopped;
        event EventHandler<string> On_allSlidesRemoved;
        event EventHandler<string> On_appSndDevChanged;
        event EventHandler<string> On_appStateChanged;
        event EventHandler<string> On_appUpdateAvailable;
        event EventHandler<string> On_audioCapturerMute;
        event EventHandler<string> On_audioDelayDetectorTestStateChanged;
        event EventHandler<string> On_audioRendererMute;
        event EventHandler<string> On_authorizationNeeded;
        event EventHandler<string> On_availableServersListLoaded;
        event EventHandler<string> On_backgroundImageChanged;
        event EventHandler<string> On_broadcastPictureStateChanged;
        event EventHandler<string> On_broadcastSelfieChanged;
        event EventHandler<string> On_callHistoryCleared;
        event EventHandler<string> On_cameraStateChangedByConferenceOwner;
        event EventHandler<string> On_chatMessageSent;
        event EventHandler<string> On_cmdChatClear;
        event EventHandler<string> On_commandReceived;
        event EventHandler<string> On_commandSent;
        event EventHandler<string> On_conferenceCreated;
        event EventHandler<string> On_conferenceDeleted;
        event EventHandler<string> On_conferenceList;
        event EventHandler<string> On_contactBlocked;
        event EventHandler<string> On_contactsAdded;
        event EventHandler<string> On_contactsDeleted;
        event EventHandler<string> On_contactsRenamed;
        event EventHandler<string> On_contactUnblocked;
        event EventHandler<string> On_cropChanged;
        event EventHandler<string> On_currentSlideIndexChanged;
        event EventHandler<string> On_currentUserDisplayNameChanged;
        event EventHandler<string> On_currentUserProfileUrlChanged;
        event EventHandler<string> On_customLogoUsageChanged;
        event EventHandler<string> On_dataDeleted;
        event EventHandler<string> On_dataSaved;
        event EventHandler<string> On_detailsInfo;
        event EventHandler<string> On_deviceModesDone;
        event EventHandler<string> On_deviceStatusReceived;
        event EventHandler<string> On_downloadProgress;
        event EventHandler<string> On_dsStarted;
        event EventHandler<string> On_dsStopped;
        event EventHandler<string> On_enableAudioReceivingChanged;
        event EventHandler<string> On_enableVideoReceivingChanged;
        event EventHandler<string> On_extraVideoFlowNotify;
        event EventHandler<string> On_fileAccepted;
        event EventHandler<string> On_fileConferenceSent;
        event EventHandler<string> On_fileDownloadingProgress;
        event EventHandler<string> On_fileRejected;
        event EventHandler<string> On_fileSent;
        event EventHandler<string> On_fileStatus;
        event EventHandler<string> On_fileTransferAvailable;
        event EventHandler<string> On_fileTransferCleared;
        event EventHandler<string> On_fileTransferFileDeleted;
        event EventHandler<string> On_fileTransferPinChanged;
        event EventHandler<string> On_fileUploadingProgress;
        event EventHandler<string> On_groupChatMessageSent;
        event EventHandler<string> On_groupsAdded;
        event EventHandler<string> On_groupsRemoved;
        event EventHandler<string> On_groupsRenamed;
        event EventHandler<string> On_hangUpPressed;
        event EventHandler<string> On_hardwareChanged;
        event EventHandler<string> On_hookOffPressed;
        event EventHandler<string> On_httpServerSettingChanged;
        event EventHandler<string> On_httpServerStateChanged;
        event EventHandler<string> On_imageAddedToCachingQueue;
        event EventHandler<string> On_imageRemovedFromCachingQueue;
        event EventHandler<string> On_incomingChatMessage;
        event EventHandler<string> On_incomingGroupChatMessage;
        event EventHandler<string> On_incomingPodiumInvitationRemoved;
        event EventHandler<string> On_incomingRequestCameraControlAccepted;
        event EventHandler<string> On_incomingRequestCameraControlRejected;
        event EventHandler<string> On_incomingRequestToPodiumAnswered;
        event EventHandler<string> On_inviteReceived;
        event EventHandler<string> On_inviteRequestSent;
        event EventHandler<string> On_inviteSent;
        event EventHandler<string> On_joinToConferenceLinkReceived;
        event EventHandler<string> On_lastCallsViewed;
        event EventHandler<string> On_licenseActivation;
        event EventHandler<string> On_licenseStatusChanged;
        event EventHandler<string> On_login;
        event EventHandler<string> On_logoImageChanged;
        event EventHandler<string> On_logout;
        event EventHandler<string> On_micStateChangedByConferenceOwner;
        event EventHandler<string> On_monitorsInfoUpdated;
        event EventHandler<string> On_myEvent;
        event EventHandler<string> On_mySlideShowStarted;
        event EventHandler<string> On_mySlideShowStopped;
        event EventHandler<string> On_mySlideShowTitleChanged;
        event EventHandler<string> On_NDIDeviceCreated;
        event EventHandler<string> On_NDIDeviceDeleted;
        event EventHandler<string> On_NDIStateChanged;
        event EventHandler<string> On_newParticipantInConference;
        event EventHandler<string> On_outgoingBitrateChanged;
        event EventHandler<string> On_outgoingRequestCameraControlAccepted;
        event EventHandler<string> On_outgoingRequestCameraControlRejected;
        event EventHandler<string> On_outputSelfVideoRotateAngleChanged;
        event EventHandler<string> On_participantLeftConference;
        event EventHandler<string> On_peerAccepted;
        event EventHandler<string> On_propertiesUpdated;
        event EventHandler<string> On_ptzControlsChanged;
        event EventHandler<string> On_realtimeManagmentUrlAvailabilityChanged;
        event EventHandler<string> On_receivedFileRequest;
        event EventHandler<string> On_receiversInfoUpdated;
        event EventHandler<string> On_recordRequest;
        event EventHandler<string> On_recordRequestReply;
        event EventHandler<string> On_rejectReceived;
        event EventHandler<string> On_rejectSent;
        event EventHandler<string> On_remarkCountDown;
        event EventHandler<string> On_remotelyControlledCameraNotAvailableAnymore;
        event EventHandler<string> On_requestCameraControlReceived;
        event EventHandler<string> On_requestCameraControlSent;
        event EventHandler<string> On_requestInviteReceived;
        event EventHandler<string> On_roleEventOccured;
        event EventHandler<string> On_serverConnected;
        event EventHandler<string> On_serverDisconnected;
        event EventHandler<string> On_settingsChanged;
        event EventHandler<string> On_showCurrentUserWidget;
        event EventHandler<string> On_showIncomingRequestWidget;
        event EventHandler<string> On_showInfoConnect;
        event EventHandler<string> On_showLogo;
        event EventHandler<string> On_showTime;
        event EventHandler<string> On_showUpcomingMeetings;
        event EventHandler<string> On_slideAdded;
        event EventHandler<string> On_slideCached;
        event EventHandler<string> On_slideCachingStarted;
        event EventHandler<string> On_slidePositionChanged;
        event EventHandler<string> On_slideRemoved;
        event EventHandler<string> On_slideShowAvailabilityChanged;
        event EventHandler<string> On_slideShowCleared;
        event EventHandler<string> On_slidesSorted;
        event EventHandler<string> On_slideUploaded;
        event EventHandler<string> On_stopCalling;
        event EventHandler<string> On_systemRatingUpdated;
        event EventHandler<string> On_tariffRestrictionsChanged;
        event EventHandler<string> On_testAudioCapturerLevel;
        event EventHandler<string> On_testAudioCapturerStateChanged;
        event EventHandler<string> On_toneDial;
        event EventHandler<string> On_updateAvatar;
        event EventHandler<string> On_updateCameraInfo;
        event EventHandler<string> On_updateFailed;
        event EventHandler<string> On_userRecordingMeStatusChanged;
        event EventHandler<string> On_usersAddedToGroups;
        event EventHandler<string> On_usersRemovedFromGroups;
        event EventHandler<string> On_usersStatusesChanged;
        event EventHandler<string> On_videoCapturerMute;
        event EventHandler<string> On_videoMatrixChanged;
        event EventHandler<string> On_videoSlotMovedToMonitor;
        event EventHandler<string> On_videoSlotRemovedFromMonitor;
        event EventHandler<string> On_windowStateChanged;
    }

}
