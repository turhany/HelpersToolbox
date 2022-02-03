![alt tag](/img/helperstoolbox.png)  

A set of C# extensions/helpers library

[![NuGet version](https://badge.fury.io/nu/HelpersToolbox.svg)](https://badge.fury.io/nu/HelpersToolbox)  ![Nuget](https://img.shields.io/nuget/dt/HelpersToolbox)

#### Extension Features:
* String Extensions
  * Truncate
  * EqualsWithIgnoreCase
  * ComputeHashSha  
  * IsValidJson
  * IsValidUrl
  * IsValidEmail
  * SanitizeHtml (feyzed on https://github.com/mganss/HtmlSanitizer)
  * Slugify (feyzed on https://github.com/ctolkien/Slugify)
  * FromJson
  * HashPassword (feyzed on https://github.com/BcryptNet/bcrypt.net)
  * VerifyPassword (feyzed on https://github.com/BcryptNet/bcrypt.net)
  * GetFileEncodingByFilePath 
* Enum Extensions
  * GetDescription
  * GetDisplayName
  * EnumToList 
* List Extensions
  * RemoveWhere
  * WhereIf
  * GetPage
  * SelectRandomFromList
* Queryable Extensions
  * WhereIf
  * AddPaging
* Enumerable Extensions
  * Chunk
* Object Extensions
  * GetPropertyValue
  * SetPropertyValue
  * GetPropertyInfo
  * HasProperty  
  * GetFieldValue   
  * GetFieldInfo  
  * HasField  
  * DeepClone
  * ToJson
* Reflection Extensions
  * HasAttribute
  * GetAttribute
* Dictionary Extensions
  * Merge
* Byte Extensions
  * ToEnum
  * IsEnumValueValid
* Int Extensions
  * ToEnum (Int32,Int64)
  * IsEnumValueValid (Int32,Int64)
* Bool Extensions
  * AsYesNo (bool, bool?)
* MessagePack Extensions (feyzed on https://github.com/neuecc/MessagePack-CSharp)
  * Serialize (static)
  * Deserialize (static)

### Release Notes

#### 1.1.9
* MessagePack library changed with https://github.com/neuecc/MessagePack-CSharp

#### 1.1.8
* MessagePack Extensions > Serialize method added 
* MessagePack Extensions > Deserialize method added
* MessagePack librar > https://github.com/msgpack/msgpack-cli
* SanitizeHtml version updated to 7.0.475

#### 1.1.7
* String Extensions > GetFileEncodingByFilePath method added
* Enum Extensions Extensions > EnumToList static method added (enum value,enum type - list)

#### 1.1.6
* Bool Extensions > AsYesNo method added
* SanitizeHtml version updated to 7.0.473

#### 1.1.5
* Byte Extensions > IsEnumValueValid method added
* Int Extensions > IsEnumValueValid method added

#### 1.1.4
* GetDisplayName method moved to Object Extensions

#### 1.1.3
* String Extensions > HashPassword method added
* String Extensions > VerifyPassword method added
* HtmlSanitizer version updated to 6.0.453

#### 1.1.2
* Enum Extensions > GetDisplayName method added
* List Extensions > SelectRandomFromList method added

#### 1.1.1
* List Extensions > GetPage method, 0 and below paging bug fix
* Queryable Extensions > AddPaging method, 0 and below paging bug fix

#### 1.1.0
* Object Extensions > GetFieldValue method added
* Object Extensions > GetFieldInfo method added
* Object Extensions > HasField method added

#### 1.0.9
* String Extensions > Slugify method turkish char support added

#### 1.0.8
* Byte Extensions > ToEnum method added
* Int Extensions > ToEnum method added
* String Extensions > FromJson method JsonSerializerSettings updated
  * ReferenceLoopHandling = ReferenceLoopHandling.Ignore
  * TypeNameHandling = TypeNameHandling.All
  * ObjectCreationHandling = ObjectCreationHandling.Replace
* Object Extensions > ToJson method  JsonSerializerSettings updated
  * ReferenceLoopHandling = ReferenceLoopHandling.Ignore
  * TypeNameHandling = TypeNameHandling.All
  * ObjectCreationHandling = ObjectCreationHandling.Replace

#### 1.0.7
* String Extensions > FromJson method added
* Object Extensions > ToJson method added

#### 1.0.6
* String Extensions > Slugify method added
* Object Extensions > DeepClone method usage changed as extension
* Newtonsoft.Json version updated to 13.0.1

#### 1.0.5
* String Extensions > SanitizeHtml method added

#### 1.0.4
* String Extensions > ComputeHashSha method added
* Dictionary Extensions > Merge method added

#### 1.0.3
* Enumerable Extensions > Chunk method added

#### 1.0.2
* List Extensions > GetPage method added
* Queryable Extensions > AddPaging method added

#### 1.0.1
* GetAttribute method moved under the ReflectionExtensions

#### 1.0.0
* Base Release
