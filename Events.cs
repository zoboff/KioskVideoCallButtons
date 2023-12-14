using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VideoSDK.VideoSDKEvents_V1;

namespace VideoSDK
{
    class Events : VideoSDKEvents_V1
    {
        private VideoSDK m_Wrapper;

        public Events(VideoSDK wrapper)
        {
            m_Wrapper = wrapper;
        }

        public event EventHandler<string> On_abReceivedAfterLogin;
        public event EventHandler<string> On_allSlidesCachingStopped;
        public event EventHandler<string> On_allSlidesRemoved;
        public event EventHandler<string> On_appSndDevChanged;
        public event EventHandler<string> On_appStateChanged;
        public event EventHandler<string> On_appUpdateAvailable;
        public event EventHandler<string> On_audioCapturerMute;
        public event EventHandler<string> On_audioDelayDetectorTestStateChanged;
        public event EventHandler<string> On_audioRendererMute;
        public event EventHandler<string> On_authorizationNeeded;
        public event EventHandler<string> On_availableServersListLoaded;
        public event EventHandler<string> On_backgroundImageChanged;
        public event EventHandler<string> On_broadcastPictureStateChanged;
        public event EventHandler<string> On_broadcastSelfieChanged;
        public event EventHandler<string> On_callHistoryCleared;
        public event EventHandler<string> On_cameraStateChangedByConferenceOwner;
        public event EventHandler<string> On_chatMessageSent;
        public event EventHandler<string> On_cmdChatClear;
        public event EventHandler<string> On_commandReceived;
        public event EventHandler<string> On_commandSent;
        public event EventHandler<string> On_conferenceCreated;
        public event EventHandler<string> On_conferenceDeleted;
        public event EventHandler<string> On_conferenceList;
        public event EventHandler<string> On_contactBlocked;
        public event EventHandler<string> On_contactsAdded;
        public event EventHandler<string> On_contactsDeleted;
        public event EventHandler<string> On_contactsRenamed;
        public event EventHandler<string> On_contactUnblocked;
        public event EventHandler<string> On_cropChanged;
        public event EventHandler<string> On_currentSlideIndexChanged;
        public event EventHandler<string> On_currentUserDisplayNameChanged;
        public event EventHandler<string> On_currentUserProfileUrlChanged;
        public event EventHandler<string> On_customLogoUsageChanged;
        public event EventHandler<string> On_dataDeleted;
        public event EventHandler<string> On_dataSaved;
        public event EventHandler<string> On_detailsInfo;
        public event EventHandler<string> On_deviceModesDone;
        public event EventHandler<string> On_deviceStatusReceived;
        public event EventHandler<string> On_downloadProgress;
        public event EventHandler<string> On_dsStarted;
        public event EventHandler<string> On_dsStopped;
        public event EventHandler<string> On_enableAudioReceivingChanged;
        public event EventHandler<string> On_enableVideoReceivingChanged;
        public event EventHandler<string> On_extraVideoFlowNotify;
        public event EventHandler<string> On_fileAccepted;
        public event EventHandler<string> On_fileConferenceSent;
        public event EventHandler<string> On_fileDownloadingProgress;
        public event EventHandler<string> On_fileRejected;
        public event EventHandler<string> On_fileSent;
        public event EventHandler<string> On_fileStatus;
        public event EventHandler<string> On_fileTransferAvailable;
        public event EventHandler<string> On_fileTransferCleared;
        public event EventHandler<string> On_fileTransferFileDeleted;
        public event EventHandler<string> On_fileTransferPinChanged;
        public event EventHandler<string> On_fileUploadingProgress;
        public event EventHandler<string> On_groupChatMessageSent;
        public event EventHandler<string> On_groupsAdded;
        public event EventHandler<string> On_groupsRemoved;
        public event EventHandler<string> On_groupsRenamed;
        public event EventHandler<string> On_hangUpPressed;
        public event EventHandler<string> On_hardwareChanged;
        public event EventHandler<string> On_hookOffPressed;
        public event EventHandler<string> On_httpServerSettingChanged;
        public event EventHandler<string> On_httpServerStateChanged;
        public event EventHandler<string> On_imageAddedToCachingQueue;
        public event EventHandler<string> On_imageRemovedFromCachingQueue;
        public event EventHandler<string> On_incomingChatMessage;
        public event EventHandler<string> On_incomingGroupChatMessage;
        public event EventHandler<string> On_incomingPodiumInvitationRemoved;
        public event EventHandler<string> On_incomingRequestCameraControlAccepted;
        public event EventHandler<string> On_incomingRequestCameraControlRejected;
        public event EventHandler<string> On_incomingRequestToPodiumAnswered;
        public event EventHandler<string> On_inviteReceived;
        public event EventHandler<string> On_inviteRequestSent;
        public event EventHandler<string> On_inviteSent;
        public event EventHandler<string> On_joinToConferenceLinkReceived;
        public event EventHandler<string> On_lastCallsViewed;
        public event EventHandler<string> On_licenseActivation;
        public event EventHandler<string> On_licenseStatusChanged;
        public event EventHandler<string> On_login;
        public event EventHandler<string> On_logoImageChanged;
        public event EventHandler<string> On_logout;
        public event EventHandler<string> On_micStateChangedByConferenceOwner;
        public event EventHandler<string> On_monitorsInfoUpdated;
        public event EventHandler<string> On_myEvent;
        public event EventHandler<string> On_mySlideShowStarted;
        public event EventHandler<string> On_mySlideShowStopped;
        public event EventHandler<string> On_mySlideShowTitleChanged;
        public event EventHandler<string> On_NDIDeviceCreated;
        public event EventHandler<string> On_NDIDeviceDeleted;
        public event EventHandler<string> On_NDIStateChanged;
        public event EventHandler<string> On_newParticipantInConference;
        public event EventHandler<string> On_outgoingBitrateChanged;
        public event EventHandler<string> On_outgoingRequestCameraControlAccepted;
        public event EventHandler<string> On_outgoingRequestCameraControlRejected;
        public event EventHandler<string> On_outputSelfVideoRotateAngleChanged;
        public event EventHandler<string> On_participantLeftConference;
        public event EventHandler<string> On_peerAccepted;
        public event EventHandler<string> On_propertiesUpdated;
        public event EventHandler<string> On_ptzControlsChanged;
        public event EventHandler<string> On_realtimeManagmentUrlAvailabilityChanged;
        public event EventHandler<string> On_receivedFileRequest;
        public event EventHandler<string> On_receiversInfoUpdated;
        public event EventHandler<string> On_recordRequest;
        public event EventHandler<string> On_recordRequestReply;
        public event EventHandler<string> On_rejectReceived;
        public event EventHandler<string> On_rejectSent;
        public event EventHandler<string> On_remarkCountDown;
        public event EventHandler<string> On_remotelyControlledCameraNotAvailableAnymore;
        public event EventHandler<string> On_requestCameraControlReceived;
        public event EventHandler<string> On_requestCameraControlSent;
        public event EventHandler<string> On_requestInviteReceived;
        public event EventHandler<string> On_roleEventOccured;
        public event EventHandler<string> On_serverConnected;
        public event EventHandler<string> On_serverDisconnected;
        public event EventHandler<string> On_settingsChanged;
        public event EventHandler<string> On_showCurrentUserWidget;
        public event EventHandler<string> On_showIncomingRequestWidget;
        public event EventHandler<string> On_showInfoConnect;
        public event EventHandler<string> On_showLogo;
        public event EventHandler<string> On_showTime;
        public event EventHandler<string> On_showUpcomingMeetings;
        public event EventHandler<string> On_slideAdded;
        public event EventHandler<string> On_slideCached;
        public event EventHandler<string> On_slideCachingStarted;
        public event EventHandler<string> On_slidePositionChanged;
        public event EventHandler<string> On_slideRemoved;
        public event EventHandler<string> On_slideShowAvailabilityChanged;
        public event EventHandler<string> On_slideShowCleared;
        public event EventHandler<string> On_slidesSorted;
        public event EventHandler<string> On_slideUploaded;
        public event EventHandler<string> On_stopCalling;
        public event EventHandler<string> On_systemRatingUpdated;
        public event EventHandler<string> On_tariffRestrictionsChanged;
        public event EventHandler<string> On_testAudioCapturerLevel;
        public event EventHandler<string> On_testAudioCapturerStateChanged;
        public event EventHandler<string> On_toneDial;
        public event EventHandler<string> On_updateAvatar;
        public event EventHandler<string> On_updateCameraInfo;
        public event EventHandler<string> On_updateFailed;
        public event EventHandler<string> On_userRecordingMeStatusChanged;
        public event EventHandler<string> On_usersAddedToGroups;
        public event EventHandler<string> On_usersRemovedFromGroups;
        public event EventHandler<string> On_usersStatusesChanged;
        public event EventHandler<string> On_videoCapturerMute;
        public event EventHandler<string> On_videoMatrixChanged;
        public event EventHandler<string> On_videoSlotMovedToMonitor;
        public event EventHandler<string> On_videoSlotRemovedFromMonitor;
        public event EventHandler<string> On_windowStateChanged;

        public void ProcessResponse(string response)
        {
            var json = JObject.Parse(response);

            string name = (string)json["event"];

            switch (name)
            {
                case EventNames.EV_abReceivedAfterLogin:
                    On_abReceivedAfterLogin?.Invoke(this, response);
                    break;
                case EventNames.EV_allSlidesCachingStopped:
                    On_allSlidesCachingStopped?.Invoke(this, response);
                    break;
                case EventNames.EV_allSlidesRemoved:
                    On_allSlidesRemoved?.Invoke(this, response);
                    break;
                case EventNames.EV_appSndDevChanged:
                    On_appSndDevChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_appStateChanged:
                    On_appStateChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_appUpdateAvailable:
                    On_appUpdateAvailable?.Invoke(this, response);
                    break;
                case EventNames.EV_audioCapturerMute:
                    On_audioCapturerMute?.Invoke(this, response);
                    break;
                case EventNames.EV_audioDelayDetectorTestStateChanged:
                    On_audioDelayDetectorTestStateChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_audioRendererMute:
                    On_audioRendererMute?.Invoke(this, response);
                    break;
                case EventNames.EV_authorizationNeeded:
                    On_authorizationNeeded?.Invoke(this, response);
                    break;
                case EventNames.EV_availableServersListLoaded:
                    On_availableServersListLoaded?.Invoke(this, response);
                    break;
                case EventNames.EV_backgroundImageChanged:
                    On_backgroundImageChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_broadcastPictureStateChanged:
                    On_broadcastPictureStateChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_broadcastSelfieChanged:
                    On_broadcastSelfieChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_callHistoryCleared:
                    On_callHistoryCleared?.Invoke(this, response);
                    break;
                case EventNames.EV_cameraStateChangedByConferenceOwner:
                    On_cameraStateChangedByConferenceOwner?.Invoke(this, response);
                    break;
                case EventNames.EV_chatMessageSent:
                    On_chatMessageSent?.Invoke(this, response);
                    break;
                case EventNames.EV_cmdChatClear:
                    On_cmdChatClear?.Invoke(this, response);
                    break;
                case EventNames.EV_commandReceived:
                    On_commandReceived?.Invoke(this, response);
                    break;
                case EventNames.EV_commandSent:
                    On_commandSent?.Invoke(this, response);
                    break;
                case EventNames.EV_conferenceCreated:
                    On_conferenceCreated?.Invoke(this, response);
                    break;
                case EventNames.EV_conferenceDeleted:
                    On_conferenceDeleted?.Invoke(this, response);
                    break;
                case EventNames.EV_conferenceList:
                    On_conferenceList?.Invoke(this, response);
                    break;
                case EventNames.EV_contactBlocked:
                    On_contactBlocked?.Invoke(this, response);
                    break;
                case EventNames.EV_contactsAdded:
                    On_contactsAdded?.Invoke(this, response);
                    break;
                case EventNames.EV_contactsDeleted:
                    On_contactsDeleted?.Invoke(this, response);
                    break;
                case EventNames.EV_contactsRenamed:
                    On_contactsRenamed?.Invoke(this, response);
                    break;
                case EventNames.EV_contactUnblocked:
                    On_contactUnblocked?.Invoke(this, response);
                    break;
                case EventNames.EV_cropChanged:
                    On_cropChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_currentSlideIndexChanged:
                    On_currentSlideIndexChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_currentUserDisplayNameChanged:
                    On_currentUserDisplayNameChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_currentUserProfileUrlChanged:
                    On_currentUserProfileUrlChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_customLogoUsageChanged:
                    On_customLogoUsageChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_dataDeleted:
                    On_dataDeleted?.Invoke(this, response);
                    break;
                case EventNames.EV_dataSaved:
                    On_dataSaved?.Invoke(this, response);
                    break;
                case EventNames.EV_detailsInfo:
                    On_detailsInfo?.Invoke(this, response);
                    break;
                case EventNames.EV_deviceModesDone:
                    On_deviceModesDone?.Invoke(this, response);
                    break;
                case EventNames.EV_deviceStatusReceived:
                    On_deviceStatusReceived?.Invoke(this, response);
                    break;
                case EventNames.EV_downloadProgress:
                    On_downloadProgress?.Invoke(this, response);
                    break;
                case EventNames.EV_dsStarted:
                    On_dsStarted?.Invoke(this, response);
                    break;
                case EventNames.EV_dsStopped:
                    On_dsStopped?.Invoke(this, response);
                    break;
                case EventNames.EV_enableAudioReceivingChanged:
                    On_enableAudioReceivingChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_enableVideoReceivingChanged:
                    On_enableVideoReceivingChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_extraVideoFlowNotify:
                    On_extraVideoFlowNotify?.Invoke(this, response);
                    break;
                case EventNames.EV_fileAccepted:
                    On_fileAccepted?.Invoke(this, response);
                    break;
                case EventNames.EV_fileConferenceSent:
                    On_fileConferenceSent?.Invoke(this, response);
                    break;
                case EventNames.EV_fileDownloadingProgress:
                    On_fileDownloadingProgress?.Invoke(this, response);
                    break;
                case EventNames.EV_fileRejected:
                    On_fileRejected?.Invoke(this, response);
                    break;
                case EventNames.EV_fileSent:
                    On_fileSent?.Invoke(this, response);
                    break;
                case EventNames.EV_fileStatus:
                    On_fileStatus?.Invoke(this, response);
                    break;
                case EventNames.EV_fileTransferAvailable:
                    On_fileTransferAvailable?.Invoke(this, response);
                    break;
                case EventNames.EV_fileTransferCleared:
                    On_fileTransferCleared?.Invoke(this, response);
                    break;
                case EventNames.EV_fileTransferFileDeleted:
                    On_fileTransferFileDeleted?.Invoke(this, response);
                    break;
                case EventNames.EV_fileTransferPinChanged:
                    On_fileTransferPinChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_fileUploadingProgress:
                    On_fileUploadingProgress?.Invoke(this, response);
                    break;
                case EventNames.EV_groupChatMessageSent:
                    On_groupChatMessageSent?.Invoke(this, response);
                    break;
                case EventNames.EV_groupsAdded:
                    On_groupsAdded?.Invoke(this, response);
                    break;
                case EventNames.EV_groupsRemoved:
                    On_groupsRemoved?.Invoke(this, response);
                    break;
                case EventNames.EV_groupsRenamed:
                    On_groupsRenamed?.Invoke(this, response);
                    break;
                case EventNames.EV_hangUpPressed:
                    On_hangUpPressed?.Invoke(this, response);
                    break;
                case EventNames.EV_hardwareChanged:
                    On_hardwareChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_hookOffPressed:
                    On_hookOffPressed?.Invoke(this, response);
                    break;
                case EventNames.EV_httpServerSettingChanged:
                    On_httpServerSettingChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_httpServerStateChanged:
                    On_httpServerStateChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_imageAddedToCachingQueue:
                    On_imageAddedToCachingQueue?.Invoke(this, response);
                    break;
                case EventNames.EV_imageRemovedFromCachingQueue:
                    On_imageRemovedFromCachingQueue?.Invoke(this, response);
                    break;
                case EventNames.EV_incomingChatMessage:
                    On_incomingChatMessage?.Invoke(this, response);
                    break;
                case EventNames.EV_incomingGroupChatMessage:
                    On_incomingGroupChatMessage?.Invoke(this, response);
                    break;
                case EventNames.EV_incomingPodiumInvitationRemoved:
                    On_incomingPodiumInvitationRemoved?.Invoke(this, response);
                    break;
                case EventNames.EV_incomingRequestCameraControlAccepted:
                    On_incomingRequestCameraControlAccepted?.Invoke(this, response);
                    break;
                case EventNames.EV_incomingRequestCameraControlRejected:
                    On_incomingRequestCameraControlRejected?.Invoke(this, response);
                    break;
                case EventNames.EV_incomingRequestToPodiumAnswered:
                    On_incomingRequestToPodiumAnswered?.Invoke(this, response);
                    break;
                case EventNames.EV_inviteReceived:
                    On_inviteReceived?.Invoke(this, response);
                    break;
                case EventNames.EV_inviteRequestSent:
                    On_inviteRequestSent?.Invoke(this, response);
                    break;
                case EventNames.EV_inviteSent:
                    On_inviteSent?.Invoke(this, response);
                    break;
                case EventNames.EV_joinToConferenceLinkReceived:
                    On_joinToConferenceLinkReceived?.Invoke(this, response);
                    break;
                case EventNames.EV_lastCallsViewed:
                    On_lastCallsViewed?.Invoke(this, response);
                    break;
                case EventNames.EV_licenseActivation:
                    On_licenseActivation?.Invoke(this, response);
                    break;
                case EventNames.EV_licenseStatusChanged:
                    On_licenseStatusChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_login:
                    On_login?.Invoke(this, response);
                    break;
                case EventNames.EV_logoImageChanged:
                    On_logoImageChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_logout:
                    On_logout?.Invoke(this, response);
                    break;
                case EventNames.EV_micStateChangedByConferenceOwner:
                    On_micStateChangedByConferenceOwner?.Invoke(this, response);
                    break;
                case EventNames.EV_monitorsInfoUpdated:
                    On_monitorsInfoUpdated?.Invoke(this, response);
                    break;
                case EventNames.EV_myEvent:
                    On_myEvent?.Invoke(this, response);
                    break;
                case EventNames.EV_mySlideShowStarted:
                    On_mySlideShowStarted?.Invoke(this, response);
                    break;
                case EventNames.EV_mySlideShowStopped:
                    On_mySlideShowStopped?.Invoke(this, response);
                    break;
                case EventNames.EV_mySlideShowTitleChanged:
                    On_mySlideShowTitleChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_NDIDeviceCreated:
                    On_NDIDeviceCreated?.Invoke(this, response);
                    break;
                case EventNames.EV_NDIDeviceDeleted:
                    On_NDIDeviceDeleted?.Invoke(this, response);
                    break;
                case EventNames.EV_NDIStateChanged:
                    On_NDIStateChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_newParticipantInConference:
                    On_newParticipantInConference?.Invoke(this, response);
                    break;
                case EventNames.EV_outgoingBitrateChanged:
                    On_outgoingBitrateChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_outgoingRequestCameraControlAccepted:
                    On_outgoingRequestCameraControlAccepted?.Invoke(this, response);
                    break;
                case EventNames.EV_outgoingRequestCameraControlRejected:
                    On_outgoingRequestCameraControlRejected?.Invoke(this, response);
                    break;
                case EventNames.EV_outputSelfVideoRotateAngleChanged:
                    On_outputSelfVideoRotateAngleChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_participantLeftConference:
                    On_participantLeftConference?.Invoke(this, response);
                    break;
                case EventNames.EV_peerAccepted:
                    On_peerAccepted?.Invoke(this, response);
                    break;
                case EventNames.EV_propertiesUpdated:
                    On_propertiesUpdated?.Invoke(this, response);
                    break;
                case EventNames.EV_ptzControlsChanged:
                    On_ptzControlsChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_realtimeManagmentUrlAvailabilityChanged:
                    On_realtimeManagmentUrlAvailabilityChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_receivedFileRequest:
                    On_receivedFileRequest?.Invoke(this, response);
                    break;
                case EventNames.EV_receiversInfoUpdated:
                    On_receiversInfoUpdated?.Invoke(this, response);
                    break;
                case EventNames.EV_recordRequest:
                    On_recordRequest?.Invoke(this, response);
                    break;
                case EventNames.EV_recordRequestReply:
                    On_recordRequestReply?.Invoke(this, response);
                    break;
                case EventNames.EV_rejectReceived:
                    On_rejectReceived?.Invoke(this, response);
                    break;
                case EventNames.EV_rejectSent:
                    On_rejectSent?.Invoke(this, response);
                    break;
                case EventNames.EV_remarkCountDown:
                    On_remarkCountDown?.Invoke(this, response);
                    break;
                case EventNames.EV_remotelyControlledCameraNotAvailableAnymore:
                    On_remotelyControlledCameraNotAvailableAnymore?.Invoke(this, response);
                    break;
                case EventNames.EV_requestCameraControlReceived:
                    On_requestCameraControlReceived?.Invoke(this, response);
                    break;
                case EventNames.EV_requestCameraControlSent:
                    On_requestCameraControlSent?.Invoke(this, response);
                    break;
                case EventNames.EV_requestInviteReceived:
                    On_requestInviteReceived?.Invoke(this, response);
                    break;
                case EventNames.EV_roleEventOccured:
                    On_roleEventOccured?.Invoke(this, response);
                    break;
                case EventNames.EV_serverConnected:
                    On_serverConnected?.Invoke(this, response);
                    break;
                case EventNames.EV_serverDisconnected:
                    On_serverDisconnected?.Invoke(this, response);
                    break;
                case EventNames.EV_settingsChanged:
                    On_settingsChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_showCurrentUserWidget:
                    On_showCurrentUserWidget?.Invoke(this, response);
                    break;
                case EventNames.EV_showIncomingRequestWidget:
                    On_showIncomingRequestWidget?.Invoke(this, response);
                    break;
                case EventNames.EV_showInfoConnect:
                    On_showInfoConnect?.Invoke(this, response);
                    break;
                case EventNames.EV_showLogo:
                    On_showLogo?.Invoke(this, response);
                    break;
                case EventNames.EV_showTime:
                    On_showTime?.Invoke(this, response);
                    break;
                case EventNames.EV_showUpcomingMeetings:
                    On_showUpcomingMeetings?.Invoke(this, response);
                    break;
                case EventNames.EV_slideAdded:
                    On_slideAdded?.Invoke(this, response);
                    break;
                case EventNames.EV_slideCached:
                    On_slideCached?.Invoke(this, response);
                    break;
                case EventNames.EV_slideCachingStarted:
                    On_slideCachingStarted?.Invoke(this, response);
                    break;
                case EventNames.EV_slidePositionChanged:
                    On_slidePositionChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_slideRemoved:
                    On_slideRemoved?.Invoke(this, response);
                    break;
                case EventNames.EV_slideShowAvailabilityChanged:
                    On_slideShowAvailabilityChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_slideShowCleared:
                    On_slideShowCleared?.Invoke(this, response);
                    break;
                case EventNames.EV_slidesSorted:
                    On_slidesSorted?.Invoke(this, response);
                    break;
                case EventNames.EV_slideUploaded:
                    On_slideUploaded?.Invoke(this, response);
                    break;
                case EventNames.EV_stopCalling:
                    On_stopCalling?.Invoke(this, response);
                    break;
                case EventNames.EV_systemRatingUpdated:
                    On_systemRatingUpdated?.Invoke(this, response);
                    break;
                case EventNames.EV_tariffRestrictionsChanged:
                    On_tariffRestrictionsChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_testAudioCapturerLevel:
                    On_testAudioCapturerLevel?.Invoke(this, response);
                    break;
                case EventNames.EV_testAudioCapturerStateChanged:
                    On_testAudioCapturerStateChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_toneDial:
                    On_toneDial?.Invoke(this, response);
                    break;
                case EventNames.EV_updateAvatar:
                    On_updateAvatar?.Invoke(this, response);
                    break;
                case EventNames.EV_updateCameraInfo:
                    On_updateCameraInfo?.Invoke(this, response);
                    break;
                case EventNames.EV_updateFailed:
                    On_updateFailed?.Invoke(this, response);
                    break;
                case EventNames.EV_userRecordingMeStatusChanged:
                    On_userRecordingMeStatusChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_usersAddedToGroups:
                    On_usersAddedToGroups?.Invoke(this, response);
                    break;
                case EventNames.EV_usersRemovedFromGroups:
                    On_usersRemovedFromGroups?.Invoke(this, response);
                    break;
                case EventNames.EV_usersStatusesChanged:
                    On_usersStatusesChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_videoCapturerMute:
                    On_videoCapturerMute?.Invoke(this, response);
                    break;
                case EventNames.EV_videoMatrixChanged:
                    On_videoMatrixChanged?.Invoke(this, response);
                    break;
                case EventNames.EV_videoSlotMovedToMonitor:
                    On_videoSlotMovedToMonitor?.Invoke(this, response);
                    break;
                case EventNames.EV_videoSlotRemovedFromMonitor:
                    On_videoSlotRemovedFromMonitor?.Invoke(this, response);
                    break;
                case EventNames.EV_windowStateChanged:
                    On_windowStateChanged?.Invoke(this, response);
                    break;
            }
        }
    }
}
