/*
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
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using RedmineApi.Core.Extensions;
using RedmineApi.Core.Internals;
using Newtonsoft.Json;

namespace RedmineApi.Core.Types
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(RedmineKeys.CUSTOM_FIELD)]
    public class CustomField : IdentifiableName, IEquatable<CustomField>
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.CUSTOMIZED_TYPE)]
        public string CustomizedType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.FIELD_FORMAT)]
        public string FieldFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.REGEXP)]
        public string Regexp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.MIN_LENGTH)]
        public int? MinLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.MAX_LENGTH)]
        public int? MaxLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.IS_REQUIRED)]
        public bool IsRequired { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.IS_FILTER)]
        public bool IsFilter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.SEARCHABLE)]
        public bool Searchable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.MULTIPLE)]
        public bool Multiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.DEFAULT_VALUE)]
        public string DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(RedmineKeys.VISIBLE)]
        public bool Visible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlArray(RedmineKeys.POSSIBLE_VALUES)]
        [XmlArrayItem(RedmineKeys.POSSIBLE_VALUE)]
        public IList<CustomFieldPossibleValue> PossibleValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlArray(RedmineKeys.TRACKERS)]
        [XmlArrayItem(RedmineKeys.TRACKER)]
        public IList<TrackerCustomField> Trackers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlArray(RedmineKeys.ROLES)]
        [XmlArrayItem(RedmineKeys.ROLE)]
        public IList<CustomFieldRole> Roles { get; set; }

        #region Implementation of IXmlSerializable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public override void ReadXml(XmlReader reader)
        {
            reader.Read();
            while (!reader.EOF)
            {
                if (reader.IsEmptyElement && !reader.HasAttributes)
                {
                    reader.Read();
                    continue;
                }

                switch (reader.Name)
                {
                    case RedmineKeys.ID: Id = reader.ReadElementContentAsInt(); break;

                    case RedmineKeys.NAME: Name = reader.ReadElementContentAsString(); break;

                    case RedmineKeys.CUSTOMIZED_TYPE: CustomizedType = reader.ReadElementContentAsString(); break;

                    case RedmineKeys.FIELD_FORMAT: FieldFormat = reader.ReadElementContentAsString(); break;

                    case RedmineKeys.REGEXP: Regexp = reader.ReadElementContentAsString(); break;

                    case RedmineKeys.MIN_LENGTH: MinLength = reader.ReadElementContentAsNullableInt(); break;

                    case RedmineKeys.MAX_LENGTH: MaxLength = reader.ReadElementContentAsNullableInt(); break;

                    case RedmineKeys.IS_REQUIRED: IsRequired = reader.ReadElementContentAsBoolean(); break;

                    case RedmineKeys.IS_FILTER: IsFilter = reader.ReadElementContentAsBoolean(); break;

                    case RedmineKeys.SEARCHABLE: Searchable = reader.ReadElementContentAsBoolean(); break;

                    case RedmineKeys.VISIBLE: Visible = reader.ReadElementContentAsBoolean(); break;

                    case RedmineKeys.DEFAULT_VALUE: DefaultValue = reader.ReadElementContentAsString(); break;

                    case RedmineKeys.MULTIPLE: Multiple = reader.ReadElementContentAsBoolean(); break;

                    case RedmineKeys.TRACKERS: Trackers = reader.ReadElementContentAsCollection<TrackerCustomField>(); break;

                    case RedmineKeys.ROLES: Roles = reader.ReadElementContentAsCollection<CustomFieldRole>(); break;

                    case RedmineKeys.POSSIBLE_VALUES: PossibleValues = reader.ReadElementContentAsCollection<CustomFieldPossibleValue>(); break;

                    default: reader.Read(); break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public override void WriteXml(XmlWriter writer) { }
        #endregion

        #region Implementation of IJsonSerialization
        public override void WriteJson(JsonReader reader)
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
                    case RedmineKeys.ID: Id = reader.ReadAsInt(); break;

                    case RedmineKeys.NAME: Name = reader.ReadAsString(); break;

                    case RedmineKeys.CUSTOMIZED_TYPE: CustomizedType = reader.ReadAsString(); break;

                    case RedmineKeys.FIELD_FORMAT: FieldFormat = reader.ReadAsString(); break;

                    case RedmineKeys.REGEXP: Regexp = reader.ReadAsString(); break;

                    case RedmineKeys.MIN_LENGTH: MinLength = reader.ReadAsInt32(); break;

                    case RedmineKeys.MAX_LENGTH: MaxLength = reader.ReadAsInt32(); break;

                    case RedmineKeys.IS_REQUIRED: IsRequired = reader.ReadAsBool(); break;

                    case RedmineKeys.IS_FILTER: IsFilter = reader.ReadAsBool(); break;

                    case RedmineKeys.SEARCHABLE: Searchable = reader.ReadAsBool(); break;

                    case RedmineKeys.VISIBLE: Visible = reader.ReadAsBool(); break;

                    case RedmineKeys.DEFAULT_VALUE: DefaultValue = reader.ReadAsString(); break;

                    case RedmineKeys.MULTIPLE: Multiple = reader.ReadAsBool(); break;

                    case RedmineKeys.TRACKERS: Trackers = reader.ReadAsCollection<TrackerCustomField>(); break;

                    case RedmineKeys.ROLES: Roles = reader.ReadAsCollection<CustomFieldRole>(); break;

                    case RedmineKeys.POSSIBLE_VALUES: PossibleValues = reader.ReadAsCollection<CustomFieldPossibleValue>(); break;

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
        public bool Equals(CustomField other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id
                && IsFilter == other.IsFilter
                && IsRequired == other.IsRequired
                && Multiple == other.Multiple
                && Searchable == other.Searchable
                && Visible == other.Visible
                && CustomizedType.Equals(other.CustomizedType)
                && DefaultValue.Equals(other.DefaultValue)
                && FieldFormat.Equals(other.FieldFormat)
                && MaxLength == other.MaxLength
                && MinLength == other.MinLength
                && Name.Equals(other.Name)
                && Regexp.Equals(other.Regexp)
                && PossibleValues.Equals(other.PossibleValues)
                && Roles.Equals(other.Roles)
                && Trackers.Equals(other.Trackers);
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

            return Equals(obj as CustomField);
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
                hashCode = HashCodeHelper.GetHashCode(Id, hashCode);
                hashCode = HashCodeHelper.GetHashCode(IsFilter, hashCode);
                hashCode = HashCodeHelper.GetHashCode(IsRequired, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Multiple, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Searchable, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Visible, hashCode);
                hashCode = HashCodeHelper.GetHashCode(CustomizedType, hashCode);
                hashCode = HashCodeHelper.GetHashCode(DefaultValue, hashCode);
                hashCode = HashCodeHelper.GetHashCode(FieldFormat, hashCode);
                hashCode = HashCodeHelper.GetHashCode(MaxLength, hashCode);
                hashCode = HashCodeHelper.GetHashCode(MinLength, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Name, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Regexp, hashCode);
                hashCode = HashCodeHelper.GetHashCode(PossibleValues, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Roles, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Trackers, hashCode);
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
            return $"[CustomField: Id={Id}, Name={Name}, CustomizedType={CustomizedType}, FieldFormat={FieldFormat}, Regexp={Regexp}, MinLength={MinLength}, MaxLength={MaxLength}, IsRequired={IsRequired}, IsFilter={IsFilter}, Searchable={Searchable}, Multiple={Multiple}, DefaultValue={DefaultValue}, Visible={Visible}, PossibleValues={PossibleValues}, Trackers={Trackers}, Roles={Roles}]";
        }
    }
}