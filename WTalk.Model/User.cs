﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wtalk.MvvM;
using WTalk.ProtoJson;

namespace WTalk.Model
{
    public class User : ObservableObject
    {
        Entity _entity;
        public User(Entity entity)
        {
            _entity = entity;
        }

        public User() { }

        public string Id { get { return _entity.id.chat_id; } }
        public string DisplayName { get { return _entity.properties.display_name; } }
        public string FirstName { get { return _entity.properties.first_name; } }
        public string PhotoUrl { get { return string.Format("https:{0}",_entity.properties.photo_url); } }
        public List<string> Emails { get { return _entity.properties.email; } }
        public bool Online { get { return _entity.presence != null ? _entity.presence.available : false; } }
        public string Email { get { return _entity.properties.canonical_email; } }

        public void SetPresence(Presence presence)
        {
            _entity.presence = presence;
            OnPropertyChanged("Online");
        }
    }
}