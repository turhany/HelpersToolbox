#   **HelpersToolbox**

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
* Enum Extensions
  * GetDescription
  * GetDisplayName
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
* Int Extensions
  * ToEnum (Int32,Int64)

### Release Notes

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
