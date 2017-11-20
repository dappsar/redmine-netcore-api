﻿/*
   Copyright 2011 - 2017 Adrian Popescu.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using RedmineApi.Core.Extensions;
using RedmineApi.Core.Internals;
using Newtonsoft.Json;
using RedmineApi.Core.Serializers;

namespace RedmineApi.Core.Types
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(RedmineKeys.CHANGESET)]
    public class ChangeSet : IXmlSerializable, IEquatable<ChangeSet>, IJsonSerializable
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(RedmineKeys.REVISION)]
        public int Revision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.USER)]
        public IdentifiableName User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.COMMENTS)]
        public string Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.COMMITTED_ON, IsNullable = true)]
        public DateTime? CommittedOn { get; set; }

        #region Implementation of IXmlSerializable
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema() { return null; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            while (!reader.EOF)
            {
                if (reader.IsEmptyElement && !reader.HasAttributes)
                {
                    reader.Read();
                    continue;
                }

                Revision = reader.ReadAttributeAsInt(RedmineKeys.REVISION);

                switch (reader.Name)
                {
                    case RedmineKeys.USER: User = new IdentifiableName(reader); break;

                    case RedmineKeys.COMMENTS: Comments = reader.ReadElementContentAsString(); break;

                    case RedmineKeys.COMMITTED_ON: CommittedOn = reader.ReadElementContentAsNullableDateTime(); break;

                    default: reader.Read(); break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer) { }
        #endregion

        #region Implementation of IJsonSerialization
        public void WriteJson(JsonWriter writer) { }

        public void ReadJson(JsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return;
                }

                if (reader.TokenType != JsonToken.PropertyName)
                {
                    continue;
                }

                switch (reader.Value)
                {
                    case RedmineKeys.USER: User = new IdentifiableName(reader); break;

                    case RedmineKeys.COMMENTS: Comments = reader.ReadAsString(); break;

                    case RedmineKeys.COMMITTED_ON: CommittedOn = reader.ReadAsDateTime(); break;

                    case RedmineKeys.REVISION: Revision = reader.ReadAsInt(); break;

                    default: reader.Read(); break;
                }
            }
        }
        #endregion

        #region Implementation of IEquatable<>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ChangeSet other)
        {
            if (other == null)
            {
                return false;
            }

            return Revision == other.Revision
                && User == other.User
                && Comments == other.Comments
                && CommittedOn == other.CommittedOn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals(obj as ChangeSet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                hashCode = HashCodeHelper.GetHashCode(Revision, hashCode);
                hashCode = HashCodeHelper.GetHashCode(User, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Comments, hashCode);
                hashCode = HashCodeHelper.GetHashCode(CommittedOn, hashCode);
                return hashCode;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Revision: {Revision}, User: '{User}', CommitedOn: {CommittedOn}, Comments: '{Comments}'";
        }
    }
}