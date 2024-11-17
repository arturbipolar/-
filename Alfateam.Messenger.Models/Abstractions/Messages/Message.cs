﻿using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.Abstractions.Messages.External;
using Alfateam.Messenger.Models.General;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Messenger.Models.Messages.Alfateam.SystemMessages;
using Alfateam.Messenger.Models.Messages.Alfateam.UserMessages;
using Alfateam.Messenger.Models.Messages.External.SystemMessages;
using Alfateam.Messenger.Models.Messages.External.UserMessages;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages
{

    [JsonConverter(typeof(JsonKnownTypesConverter<Message>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamMessengerMessage), "AlfateamMessengerMessage")]
    [JsonKnownType(typeof(AlfateamMessengerSystemMessage), "AlfateamMessengerSystemMessage")]
    [JsonKnownType(typeof(AlfateamMessengerUserMessage), "AlfateamMessengerUserMessage")]
    [JsonKnownType(typeof(ExternalMessengerMessage), "ExternalMessengerMessage")]
    [JsonKnownType(typeof(ExternalMessengerSystemMessage), "ExternalMessengerSystemMessage")]
    [JsonKnownType(typeof(ExternalMessengerUserMessage), "ExternalMessengerUserMessage")]


    [JsonKnownType(typeof(ChatPhotoChangedMessage), "ChatPhotoChangedMessage")]
    [JsonKnownType(typeof(ChatTitleChangedMessage), "ChatTitleChangedMessage")]
    [JsonKnownType(typeof(GroupChatCreatedMessage), "GroupChatCreatedMessage")]
    [JsonKnownType(typeof(JoinedUserMessage), "JoinedUserMessage")]
    [JsonKnownType(typeof(KickedUserMessage), "KickedUserMessage")]
    [JsonKnownType(typeof(PinnedSystemMessage), "PinnedSystemMessage")]

    [JsonKnownType(typeof(ContactMessage), "ContactMessage")]
    [JsonKnownType(typeof(LocationMessage), "LocationMessage")]
    [JsonKnownType(typeof(StickerMessage), "StickerMessage")]
    [JsonKnownType(typeof(TextMessage), "TextMessage")]
    [JsonKnownType(typeof(VoiceMessage), "VoiceMessage")]




    [JsonKnownType(typeof(ExtChatPhotoChangedMessage), "ExtChatPhotoChangedMessage")]
    [JsonKnownType(typeof(ExtChatTitleChangedMessage), "ExtChatTitleChangedMessage")]
    [JsonKnownType(typeof(ExtGroupChatCreatedMessage), "ExtGroupChatCreatedMessage")]
    [JsonKnownType(typeof(ExtJoinedUserMessage), "ExtJoinedUserMessage")]
    [JsonKnownType(typeof(ExtKickedUserMessage), "ExtKickedUserMessage")]
    [JsonKnownType(typeof(ExtPinnedSystemMessage), "ExtPinnedSystemMessage")]

    [JsonKnownType(typeof(ExtContactMessage), "ExtContactMessage")]
    [JsonKnownType(typeof(ExtLocationMessage), "ExtLocationMessage")]
    [JsonKnownType(typeof(ExtStickerMessage), "ExtStickerMessage")]
    [JsonKnownType(typeof(ExtTextMessage), "ExtTextMessage")]
    [JsonKnownType(typeof(ExtVoiceMessage), "ExtVoiceMessage")]
    public class Message : AbsModel
    {

    }
}